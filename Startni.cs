using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace HotelBob
{
    public partial class Startni : Form
    {
        public enum stanjeSobe : int { Slobodna = 0, Zauzeta = 1, PotrebnoCisenje = 2,  Puna = 3};
        private SqlCeCommand command = new SqlCeCommand("", DatabaseClass.getConnection());
        private SqlCeDataReader reader;

        public static string password = "066466065";

        List<int> reminderNumber = new List<int>();
        List<DateTime> reminders = new List<DateTime>();
        Podsjetnici reminderForm = new Podsjetnici();
        DateTime dateTime = DateTime.Now;
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer secondTimer = new Timer();
        DateTime lastUpload;
        DateTime postrone;

        public Startni()
        {
            InitializeComponent();
            DatabaseClass.setHandler(this);
            DatabaseClass.CheckDatabase();
            DatabaseClass.GrantAccess();
            UploadPeriod();
            sat.Text = dateTime.ToLongTimeString();
            implementTimer();
        }

        private void implementTimer()
        {
            t.Interval = 250; // specify interval time as you want
            t.Tick += new EventHandler(timer_Tick);
            t.Start();
            secondTimer.Interval = 1000 * 5;
            secondTimer.Tick += new EventHandler(SecondTimer_Tick);
            secondTimer.Start();
        }

        void SecondTimer_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("Aktivira se u: " + postrone);
            if (DateTime.Now > postrone)
            {
                secondTimer.Enabled = false;
                UploadToUpstream.RunWorkerAsync();
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            dateTime = DateTime.Now;
            sat.Text = dateTime.ToLongTimeString();
            for (int i = 0; i < reminders.Count; i++)
            {
                if (dateTime.Subtract(reminders[i]).TotalSeconds < 1
                    && dateTime.Subtract(reminders[i]).TotalSeconds > -1)
                    {
                        t.Stop();
                        if (reminderForm.IsDisposed)
                        {
                            reminderForm = new Podsjetnici();
                            reminderForm.Show();
                            Form form = new Form();
                            form.Location = new Point(this.Location.X + this.Size.Width + 100, this.Location.Y + 40);
                            Program.Locate(reminderForm, form);

                            reminderForm.addElement(reminderNumber[i]);
                            reminders.RemoveAt(i);
                            reminderNumber.RemoveAt(i);
                        }
                        else
                        {
                            reminderForm.Show();
                            reminderForm.addElement(reminderNumber[i]);
                            reminders.RemoveAt(i);
                            reminderNumber.RemoveAt(i);
                        }
                    }
            }
            t.Start();
            //Call method
        }
        private void button_Click(object sender, EventArgs e)
        {
            string nazivSobe = ((Button)sender).Text;
            DatabaseClass.getConnection().Close();
            DatabaseClass.getConnection().Open();
            command.CommandText = "Select * FROM Sobe WHERE sifra = '" + ((Button)sender).Name.Substring(0, ((Button)sender).Name.IndexOf('_')) + "';";
            SqlCeDataReader read = command.ExecuteReader();
            
            read.Read();

            string brojSobe = read.GetString(0);
            Console.WriteLine(brojSobe);
            if (read.GetInt32(2) == (int)stanjeSobe.Zauzeta)
            {
                SqlCeDataReader subReader = new SqlCeCommand(
                    "SELECT broj_kreveta FROM vrsta WHERE id = " + read.GetInt32(1) + ";", DatabaseClass.getConnection()).ExecuteReader();
                if (subReader.Read())
                {
                    DialogBox kutija = new DialogBox("U ovoj sobi ima " + (subReader.GetInt32(0) - read.GetInt32(3)) + " kreveta.", "Poruka");
                    Program.Locate(kutija, this);
                    DialogResult result = kutija.ShowDialog();
                   if (result == System.Windows.Forms.DialogResult.Yes)
                   {
                       PrijavaGosta soba = new PrijavaGosta(nazivSobe, ((Button)sender).Name);
                       Program.Locate(soba, this);
                       soba.Show();   
                   }
                   else if (result == System.Windows.Forms.DialogResult.No)
                       {
                           listaGostiju lista = new listaGostiju(brojSobe);
                           Program.Locate(lista, this);
                           lista.Show();
                       }
                       else if (result == System.Windows.Forms.DialogResult.Cancel)
                       {

                       }
                       else
                            MessageBox.Show("DRUGO " + result.ToString());
                }
                else
                    MessageBox.Show("ERROR");
            }
            else if (read.GetSqlInt32(2) == (int)stanjeSobe.Puna)
            {
                listaGostiju lista = new listaGostiju(brojSobe);
                Program.Locate(lista, this);
                lista.Show();
            }
            else if(read.GetInt32(2) == (int) stanjeSobe.Slobodna)
            {
                PrijavaGosta soba = new PrijavaGosta(nazivSobe, ((Button)sender).Name);
                Program.Locate(soba, this);
                soba.Show();
            }
            else if (read.GetInt32(2) == (int)stanjeSobe.PotrebnoCisenje)
            {
                DialogResult result = MessageBox.Show("Potrebno je čišćenje. Da li nastaviti?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    PrijavaGosta soba = new PrijavaGosta(nazivSobe, ((Button)sender).Name.Substring(0, ((Button)sender).Name.IndexOf('_')));
                    Program.Locate(soba, this);
                    soba.Show();
                }
            }
            DatabaseClass.getConnection().Close();
            
        }
       
        private void lista_Click(object sender, EventArgs e)
        {
            listaGostiju lista = new listaGostiju();
            Program.Locate(lista, this);
            lista.Show();
        }
        private void ciscenje_Click(object sender, EventArgs e)
        {
            SobeZaCiscenje lista = new SobeZaCiscenje();
            Program.Locate(lista, this);
            lista.Show();
        }
        private void UpdateSobaCount()
        {
            DatabaseClass.getConnection().Close();
            DatabaseClass.getConnection().Open();
            command.CommandText = "SELECT COUNT(*) FROM Sobe WHERE stanje = " + (int)stanjeSobe.Slobodna + ";";
            SqlCeDataReader reader = command.ExecuteReader();
            reader.Read();
            slobodnih.Text = "" + reader.GetSqlInt32(0);
            
            command.CommandText = "SELECT COUNT(*) FROM Sobe WHERE stanje = " + (int)stanjeSobe.Zauzeta + ";";
            reader = command.ExecuteReader();
            reader.Read();
            zauzetihButton.Text = "" + reader.GetSqlInt32(0);
            
            command.CommandText = "SELECT COUNT(*) FROM Sobe WHERE stanje = " + (int)stanjeSobe.Puna + ";";
            reader = command.ExecuteReader();
            reader.Read();
            zauzetihButton.Text = "" + (int.Parse(zauzetihButton.Text) + reader.GetSqlInt32(0));
            
            command.CommandText = "SELECT COUNT(*) FROM Sobe WHERE stanje = " + (int)stanjeSobe.PotrebnoCisenje + ";";
            reader = command.ExecuteReader();
            reader.Read();
            ciscenje.Text = "" + reader.GetSqlInt32(0);
            
            DatabaseClass.getConnection().Close();
        }
        public void Startni_Activated(object sender, EventArgs e)
        {
            lista_soba.Visible = false;
            this.Opacity = 1;
            UpdateSobaCount();
            UpdateButtons();
            UpdateReminders();
        }

        public void UpdateReminders()
        {
            DatabaseClass.getConnection().Close();
            DatabaseClass.getConnection().Open();
            command.CommandText = "SELECT * FROM Reminders;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                reminderNumber.Add(reader.GetInt32(0));
                reminders.Add(reader.GetDateTime(3));
            }

            DatabaseClass.getConnection().Close();
        }

        private void Startni_Deactivate(object sender, EventArgs e)
        {
            if (!reminderForm.Visible)
                this.Opacity = 0;
            else
                this.Opacity = 1;
        }

        private void slobodnih_Click(object sender, EventArgs e)
        {
            lista_soba.Clear();
            lista_soba.Visible = !lista_soba.Visible;
            DatabaseClass.getConnection().Open();
            command.CommandText = "SELECT sifra FROM Sobe WHERE stanje = " + (int)stanjeSobe.Slobodna + " ORDER BY sifra;";
            SqlCeDataReader reader = command.ExecuteReader();
            int countSprat = -1;
            if (reader.Read())
            {
                countSprat = Int32.Parse("" + reader.GetString(0)[1]);
                lista_soba.Text += "Sprat " + (countSprat++) + ":\n";

                lista_soba.Text += "\tSoba " + reader.GetString(0).Substring(1) + "\n";
                
            }
            while (reader.Read())
            {
                if (Int32.Parse("" + reader.GetString(0)[1]) == countSprat)
                    lista_soba.Text += "Sprat " + (countSprat++) + ":\n";

                lista_soba.Text += "\tSoba " + reader.GetString(0).Substring(1) + "\n";
            }
            DatabaseClass.getConnection().Close();
        }
        
        private void UpdateButtons()
        {
            foreach (var tc in this.Controls)
            {
                if (tc is TabControl)
                {
                    foreach (TabPage tp in ((TabControl)tc).Controls)
                        foreach (Button b in ((TabPage)tp).Controls)
                            b.BackColor = setColor(b.Name.Substring(0, b.Name.IndexOf('_')));
                }
            }
        }
        
        private string Broj(int i)
        {
            if (i < 10)
                return "0" + i;
            else
                return "" + i;
        }
        private Color setColor(string name)
        {
            DatabaseClass.getConnection().Open();
            command.CommandText = "SELECT stanje FROM Sobe WHERE sifra = '"
                + name + "';";
            SqlCeDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.GetSqlInt32(0) == (int)stanjeSobe.Zauzeta)
            {
                DatabaseClass.getConnection().Close();
                return Color.Red;
            }
            else if (reader.GetSqlInt32(0) == (int)stanjeSobe.Slobodna)
            {
                DatabaseClass.getConnection().Close();
                return Color.ForestGreen;
            }
            else if (reader.GetSqlInt32(0) == (int)stanjeSobe.PotrebnoCisenje)
            {
                DatabaseClass.getConnection().Close();
                return Color.Yellow;
            }
            else if (reader.GetSqlInt32(0) == (int)stanjeSobe.Puna)
            {
                DatabaseClass.getConnection().Close();
                return Color.DarkRed;
            }
            else
            {
                DatabaseClass.getConnection().Close();
                return (Button.DefaultBackColor);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void izvjestaji_Click(object sender, EventArgs e)
        {
            new Izvjestaji().Show();
        }

        private void rezervacije_Click(object sender, EventArgs e)
        {
            new Rezervacije().Show();
        }

        private void SendMail_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!Program.Upload())
            {
                postrone = postrone.AddMinutes(30);
            }
            else
            {
                Console.WriteLine("UPLOADED");
                UploadPeriod();
            }
         }

        private void UploadPeriod()
        {
            lastUpload = DatabaseClass.LastUpload();
            postrone = lastUpload.AddDays(4);
        }

        private void Startni_Load(object sender, EventArgs e)
        {

        }

        private void podsjetnici_Click(object sender, EventArgs e)
        {
            new NoviPodsjetnik().Show();
        }

        private void aboutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DialogResult result = new EnterPass().ShowDialog();
            //if (result == System.Windows.Forms.DialogResult.Yes)
                new Opcije(0).Show();
            //else if (result == System.Windows.Forms.DialogResult.No)
              //  new Opcije(1).Show();
            
        }

        private void UploadToUpstream_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            secondTimer.Enabled = true;
        }
    }
}
