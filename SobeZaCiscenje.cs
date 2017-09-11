using System;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace HotelBob
{
    public partial class SobeZaCiscenje : Form
    {
        SqlCeCommand command = new SqlCeCommand("", DatabaseClass.getConnection());
        SqlCeDataReader read;

        public SobeZaCiscenje()
        {
            InitializeComponent();
        }

        private void SobeZaCiscenje_Load(object sender, EventArgs e)
        {
            lista.Items.Clear();
            command.CommandText = "SELECT sifra FROM Sobe WHERE stanje = " + (int)Startni.stanjeSobe.PotrebnoCisenje + ";";
            DatabaseClass.getConnection().Open();
            read = command.ExecuteReader();
            while (read.Read())
            {
                lista.Items.Add(read.GetString(0));
            }
            DatabaseClass.getConnection().Close();
        }

        private void button_Click(object sender, EventArgs e)
        {
            DatabaseClass.getConnection().Open();
            CheckedListBox.CheckedItemCollection list = lista.CheckedItems;
            for (int i = 0; i < list.Count; i++)
            {
                command.CommandText = "UPDATE Sobe "
                    + "SET stanje = " + (short)Startni.stanjeSobe.Slobodna
                    + " WHERE sifra = '" + list[i] + "';";
                command.ExecuteNonQuery();
            }
            DatabaseClass.getConnection().Close();

            SobeZaCiscenje_Load(sender, e);
        }
    }
}
