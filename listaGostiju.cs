using System;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace HotelBob
{
    public partial class listaGostiju : Form
    {
        string brSobe = "";
        public listaGostiju(string brojSobe = "")
        {
            InitializeComponent();
            brSobe = brojSobe;
        }

        private void listaGostiju_Load(object sender, EventArgs e)
        {
               DataGridViewRow row;
               SqlCeCommand command = new SqlCeCommand("SELECT * FROM Gost", DatabaseClass.getConnection());

               DatabaseClass.getConnection().Close();
               DatabaseClass.getConnection().Open();

            SqlCeDataReader gostReader = command.ExecuteReader();
            SqlCeDataReader medjuReader;
            
            
            while (gostReader.Read())
            {
                
                 command.CommandText = "SELECT * FROM Sobe_gost"
                    + " WHERE GostJMBG = '" + gostReader.GetString(0) + "' " + 
                    ((!string.IsNullOrEmpty(brSobe)) ? (" AND sobeSifra = '" + brSobe + "'"): ("")) + ";";
                medjuReader = command.ExecuteReader();
                if (medjuReader.Read())
                {
                    row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                    row.Cells[0].Value = gostReader.GetString(2) + " " + gostReader.GetString(3);
                    row.Cells[1].Value = medjuReader.GetString(0).Substring(1);
                    row.Cells[2].Value = medjuReader.GetDateTime(2).ToLongDateString();
                    
                    if(!medjuReader.IsDBNull(3))
                        row.Cells[3].Value = medjuReader.GetDateTime(3).ToLongDateString();
                    
                    row.Cells[4].Value = gostReader.GetString(0);
                    
                    dataGridView1.Rows.Add(row);
                }
            }
            DatabaseClass.getConnection().Close();
        }

        private void detalji_Click(object sender, EventArgs e)
        {
            string brojSobe = "" + dataGridView1.SelectedRows[0].Cells[1].Value;
        
            if (!string.IsNullOrEmpty(brojSobe))
            {
                SqlCeCommand command = new SqlCeCommand("Select * FROM Sobe_Gost WHERE SobeSifra = 's" + brojSobe + "' "
                    + "AND GostJMBG = '" + dataGridView1.SelectedRows[0].Cells[4].Value +"';", DatabaseClass.getConnection());
                DatabaseClass.getConnection().Open();
                SqlCeDataReader read = command.ExecuteReader();

                if (read.Read())
                {
                    Soba soba = new Soba("Soba " + brojSobe, read);
                    Program.Locate(soba, this);
                    soba.Show();
                    this.Dispose();
                }
                DatabaseClass.getConnection().Close();
            }
        }
    }
}
