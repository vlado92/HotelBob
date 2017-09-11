using System;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace HotelBob
{
    public partial class Podsjetnici : Form
    {
        SqlCeDataReader reader;
        SqlCeCommand command = new SqlCeCommand("", DatabaseClass.getConnection());

        public Podsjetnici()
        {
            InitializeComponent();
        }

        public void addElement(int index)
        {

            DatabaseClass.getConnection().Open();
            command.CommandText = "SELECT * FROM Reminders WHERE "
                + "ID = " + index;
            reader = command.ExecuteReader();
            SqlCeCommand subCommand = new SqlCeCommand("", DatabaseClass.getConnection());
            SqlCeDataReader subReader;

            while (reader.Read())
            {
                subCommand.CommandText = "SELECT ime, prezime FROM Gost WHERE JMBG = '" + reader.GetString(1) + "';";
                subReader = subCommand.ExecuteReader();
                if (subReader.Read())
                {
            checkedListBox1.Items.Add(reader.GetInt32(0) + "-Vrijeme: " 
                        + reader.GetDateTime(3).ToShortTimeString() + " Gost: "
                        + subReader.GetString(0) + " " 
                        + subReader.GetString(1) + " Soba: "
                        + reader.GetString(2)) ;
                }
            }

            DatabaseClass.getConnection().Close();
        }

        private void Podsjetnici_Load(object sender, EventArgs e)
        {
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            DatabaseClass.getConnection().Open();
            command.CommandText = "SELECT * FROM Reminders WHERE "
                + " Vrijeme < '" + PrijavaGosta.datumVrijeme(DateTime.Now) + "';";
            reader = command.ExecuteReader();
            SqlCeCommand subCommand = new SqlCeCommand("", DatabaseClass.getConnection());
            SqlCeDataReader subReader;

            while (reader.Read())
            {
                subCommand.CommandText = "SELECT ime, prezime FROM Gost WHERE JMBG = '" + reader.GetString(1) + "';";
                subReader = subCommand.ExecuteReader();
                if(subReader.Read())
                    checkedListBox1.Items.Add(reader.GetInt32(0) + "-Vrijeme: " + reader.GetDateTime(3).ToShortTimeString() + " Gost: " 
                        + subReader.GetString(0) + " " + subReader.GetString(1) + " Soba: " + reader.GetString(2));
            }
            DatabaseClass.getConnection().Close();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox.Clear();
            if (((CheckedListBox)sender).SelectedIndex > -1)
            {
                int index = Int32.Parse(((CheckedListBox)sender).SelectedItem.ToString().Substring(0, ((CheckedListBox)sender).SelectedItem.ToString().IndexOf('-')));

                DatabaseClass.getConnection().Close();
                DatabaseClass.getConnection().Open();
                command.CommandText = "SELECT Tekst FROM Reminders WHERE id = " + index + ";";
                reader = command.ExecuteReader();
                if (reader.Read())
                    textBox.Text = reader.GetString(0);
                DatabaseClass.getConnection().Close();
            }
        }

        private void potvrdi_Click(object sender, EventArgs e)
        {
            DatabaseClass.getConnection().Close();
            DatabaseClass.getConnection().Open();

            for (int i = 0; i < checkedListBox1.CheckedIndices.Count; i++)
            {
                command.CommandText = "DELETE FROM Reminders WHERE id = "
                    + (int.Parse(checkedListBox1.CheckedItems[i].ToString().Substring(0,
                    checkedListBox1.CheckedItems[i].ToString().IndexOf('-')))) + ";";
                command.ExecuteNonQuery();
                checkedListBox1.Items.RemoveAt(i);
                checkedListBox1.SelectedIndex = -1;
            }

            DatabaseClass.getConnection().Close();
        }
    }
}
