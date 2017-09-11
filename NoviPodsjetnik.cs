using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HotelBob
{
    public partial class NoviPodsjetnik : Form
    {
        System.Data.SqlServerCe.SqlCeCommand command = new System.Data.SqlServerCe.SqlCeCommand("", DatabaseClass.getConnection());
        System.Data.SqlServerCe.SqlCeDataReader reader;

        List<string> JMBG = new List<string>();

        public NoviPodsjetnik()
        {
            InitializeComponent();
        }

        private void NoviPodsjetnik_Load(object sender, EventArgs e)
        {
            sat.SelectedIndex = DateTime.Now.Hour;
            minut.SelectedIndex = DateTime.Now.Minute;
            dateTimePicker1.MinDate = DateTime.Now;

            osobaComboBox.Items.Clear();
            sobaComboBox.Items.Clear();

            command.CommandText = "SELECT * FROM Sobe_Gost;";
            
            DatabaseClass.getConnection().Close();
            DatabaseClass.getConnection().Open();
            

            reader = command.ExecuteReader();
            while (reader.Read())
            {
                JMBG.Add(reader.GetString(1));
            }
            for (int i = 0; i < JMBG.Count; i++)
            {
                command.CommandText = "SELECT * FROM Gost WHERE JMBG = '" + JMBG[i] + "';";
                reader = command.ExecuteReader();
                while(reader.Read())
                    osobaComboBox.Items.Add(reader.GetString(2) + " " + reader.GetString(3));
            }

            command.CommandText = "SELECT * FROM Sobe;";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                sobaComboBox.Items.Add(reader.GetString(0));
            }
            DatabaseClass.getConnection().Close();
        }

        private void osobaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseClass.getConnection().Close();
            DatabaseClass.getConnection().Open();
            command.CommandText = "SELECT SobeSifra FROM Sobe_gost WHERE GostJMBG = '"
            + JMBG[osobaComboBox.SelectedIndex] + "';";
            reader = command.ExecuteReader();
            if(reader.Read())
                sobaComboBox.SelectedItem = reader.GetString(0);
            DatabaseClass.getConnection().Close();

        }

        private void sobaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            DatabaseClass.getConnection().Close();
            DatabaseClass.getConnection().Open();
            command.CommandText = "SELECT GostJMBG FROM Sobe_gost WHERE SobeSifra = '"
            + sobaComboBox.SelectedItem + "';";
            reader = command.ExecuteReader();
            if (reader.Read())
                osobaComboBox.SelectedIndex = JMBG.IndexOf(reader.GetString(0));
            DatabaseClass.getConnection().Close();


        }

        private void Potvrdi_Click(object sender, EventArgs e)
        {
            if (osobaComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Molim Vas unesite osobu za koju je potreban podsjetnik");
                osobaComboBox.Focus();
            }
            else
            {
                DateTime tempTime = dateTimePicker1.Value;
                DateTime time = new DateTime(tempTime.Year, tempTime.Month, tempTime.Day, sat.SelectedIndex, minut.SelectedIndex, 0);
                DatabaseClass.getConnection().Close();
                DatabaseClass.getConnection().Open();
                command.CommandText = "INSERT INTO Reminders(JMBG, SOBA, Vrijeme, Tekst) VALUES"
                    + "('" + JMBG[osobaComboBox.SelectedIndex] + "', '" 
                    + sobaComboBox.SelectedItem + "', '" +  PrijavaGosta.datumVrijeme(time) + "', '" + tekstPodsjetnika.Text + "');";
                command.ExecuteNonQuery();
                DatabaseClass.getConnection().Close();
                MessageBox.Show("Podsjetnik unesen u bazu");
                Dispose();
            }
        }
    }
}
