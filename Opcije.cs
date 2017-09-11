using System;
using System.Windows.Forms;

namespace HotelBob
{
    public partial class Opcije : Form
    {
        System.Data.SqlServerCe.SqlCeCommand command = new System.Data.SqlServerCe.SqlCeCommand("", DatabaseClass.getConnection());
        System.Data.SqlServerCe.SqlCeDataReader reader;
        int enter;
        public Opcije(int opcija)
        {
            InitializeComponent();
            enter = opcija;
        }

        private void Opcije_Load(object sender, EventArgs e)
        {
            JMBG2.Items.Clear();
            JMBG1.Items.Clear();
            ime2.Items.Clear();
            ime1.Items.Clear();
            trenutno.Clear();
            kolicina.Clear();

            command.CommandText = "SELECT JMBG, ime,  prezime FROM gost "
                + "WHERE JMBG IN ((SELECT GostJMBG FROM sobe_gost));";
            DatabaseClass.getConnection().Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                JMBG1.Items.Add(reader.GetString(0));
                JMBG2.Items.Add(reader.GetString(0));

                ime1.Items.Add(reader.GetString(1) + " " + reader.GetString(2));
                ime2.Items.Add(reader.GetString(1) + " "  +reader.GetString(2));
            }


            DatabaseClass.getConnection().Close();
        }

        private void PrintIt()
        {
            command.CommandText = "SELECT dodatniCeh FROM sobe_gost WHERE GostJMBG = '" + JMBG1.SelectedItem.ToString() + "';";
            DatabaseClass.getConnection().Open();
            reader = command.ExecuteReader();
            if (reader.Read())
                trenutno.Text = reader.GetString(0);
            DatabaseClass.getConnection().Close();
        }

        private void JMBG1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ime1.SelectedIndex = JMBG1.SelectedIndex;
            PrintIt();
        }

        private void JMBG2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ime2.SelectedIndex = JMBG2.SelectedIndex;
        }

        private void ime1_SelectedIndexChanged(object sender, EventArgs e)
        {
            JMBG1.SelectedIndex = ime1.SelectedIndex;
            PrintIt();
        }

        private void ime2_SelectedIndexChanged(object sender, EventArgs e)
        {
            JMBG2.SelectedIndex = ime2.SelectedIndex;
        }

        private void potvrdi_Click(object sender, EventArgs e)
        {
            if (JMBG1.SelectedIndex < 0 || ime1.SelectedIndex < 0)
            {
                MessageBox.Show("Odaberite od koga želite da prebacite");
                ime1.Focus();
            }
            else if (JMBG2.SelectedIndex < 0 || ime2.SelectedIndex < 0)
            {
                MessageBox.Show("Odaberite kome želite da prebacite");
                ime2.Focus();
            }
            else if (string.IsNullOrEmpty(kolicina.Text))
            {
                MessageBox.Show("Odaberite koliko želite da prebacite");
                kolicina.Focus();
            }
            else if(Double.Parse(trenutno.Text) < Double.Parse(kolicina.Text))
            {
                MessageBox.Show("Pokušavate da prebacite više nego što ima");
                kolicina.Clear();
                kolicina.Focus();
            }
            else
            {
                double t = double.Parse(trenutno.Text) - double.Parse(kolicina.Text); 

                DatabaseClass.getConnection().Open();
                command.CommandText = "UPDATE Sobe_gost SET dodatniCeh = '" + t
                    + "' WHERE GostJMBG = '" + JMBG1.SelectedItem.ToString() + "';";
                command.ExecuteNonQuery();

                command.CommandText = "SELECT dodatniCeh FROM Sobe_gost "
                    + " WHERE GostJMBG = '" + JMBG2.SelectedItem.ToString() + "';";
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    t = double.Parse(reader.GetString(0)) + double.Parse(kolicina.Text);
                    command.CommandText = "UPDATE Sobe_gost SET dodatniCeh = '" + t
                                        + "' WHERE GostJMBG = '" + JMBG2.SelectedItem.ToString() + "';";
                    command.ExecuteNonQuery();
                }
                DatabaseClass.getConnection().Close();
                Opcije_Load(sender, e);
            }        
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            PrijavaGosta.popust_KeyDown(sender, e);
        }
    }
}
