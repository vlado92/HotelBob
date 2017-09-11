using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HotelBob
{
    public partial class Rezervacije : Form
    {
        System.Data.SqlServerCe.SqlCeCommand command = new System.Data.SqlServerCe.SqlCeCommand("", DatabaseClass.getConnection());
        System.Data.SqlServerCe.SqlCeDataReader reader;

        DataGridViewRow row;
        List<string> lista = new List<string>();

        List<string> rezervacijaID = new List<string>();
        
        int index = -1;
                
        public Rezervacije()
        {
            InitializeComponent();
            prijavaDatum.MinDate = odjavaDatum.MinDate = DateTime.Now;
        }

        private void Rezervacije_Load(object sender, EventArgs e)
        {
            soba.Items.Clear();
            placeno.SelectedIndex = status.SelectedIndex = 0;

            mjeseci.SelectedIndex = DateTime.Now.Month - 1;

            godina.Value = DateTime.Now.Year;
            godina.Minimum = 2000;
            godina.Maximum = 2400;
             
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].HeaderText = "" + (i);
                dataGridView1.Columns[i].Width = 30;
            }
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.Rows[0].Height = 30;

            DatabaseClass.getConnection().Close();
            
            DatabaseClass.getConnection().Open();
            command.CommandText = "SELECT sifra FROM Sobe ORDER BY sifra;";
            reader = command.ExecuteReader();
             dataGridView1.AllowUserToAddRows = true;
            while(reader.Read())
            {
                lista.Add(reader.GetString(0));
                row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = reader.GetString(0);
                dataGridView1.Rows.Add(row);
                soba.Items.Add(reader.GetString(0));
            }
            
            dataGridView1.AllowUserToAddRows = false;
            DatabaseClass.getConnection().Close();
            
            
            RefreshCalendar();
        }

        void RefreshCalendar()
        {
            rezervacijaID.Clear();
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                for(int j = 0; j < dataGridView1.Rows.Count; j++)
                dataGridView1[i, j].Style.BackColor = Color.Empty;

            int danaUMjesecu = DateTime.DaysInMonth((int) godina.Value, mjeseci.SelectedIndex+1);
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Visible = false;
            }
            for (int i = 1; i <= danaUMjesecu; i++)
                dataGridView1.Columns[i].Visible = true;
            
            DatabaseClass.getConnection().Open();
            command.CommandText = "SELECT prijava, odjava, soba_id, status, id FROM Rezervacija WHERE "
                + " DatePart(mm, prijava) = " + (mjeseci.SelectedIndex + 1)
                + " AND DatePart(year, prijava) = " + ((int)godina.Value) + ";";
            reader = command.ExecuteReader();
            int boundry;

            while (reader.Read())
            {
                if (reader.GetDateTime(1).Month == mjeseci.SelectedIndex + 1)
                    boundry = reader.GetDateTime(1).Day;
                else
                    boundry = danaUMjesecu;
                for (int i = reader.GetDateTime(0).Day; i <= danaUMjesecu; i++)
                {
                    rezervacijaID.Add(i + "-" + lista.IndexOf(reader.GetString(2))
                    + ":" + reader.GetInt32(4));

                    dataGridView1[i, lista.IndexOf(reader.GetString(2))].Style.BackColor = setColor(reader.GetInt32(3));
                }
            }

            command.CommandText = "SELECT prijava, odjava, soba_id, status, id FROM Rezervacija WHERE "
               + " DatePart(mm, odjava) = " + (mjeseci.SelectedIndex + 1)
               + " AND DatePart(year, odjava) = " + ((int)godina.Value) + ";";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetDateTime(0).Month == mjeseci.SelectedIndex + 1)
                    boundry = reader.GetDateTime(0).Day;
                else
                    boundry = 1;
                for (int i = boundry; i <= reader.GetDateTime(1).Day; i++)
                {
                    rezervacijaID.Add(i + "-" + lista.IndexOf(reader.GetString(2))
                    + ":" + reader.GetInt32(4));

                    dataGridView1[i, lista.IndexOf(reader.GetString(2))].Style.BackColor = setColor(reader.GetInt32(3));
                }
            }

            DatabaseClass.getConnection().Close();
        }

        private Color setColor(int status)
        {
            switch (status)
            {
                case 0:
                    return Color.Yellow;
                case 1:
                    return Color.Green;
                case 2:
                    return Color.Red; 
                case 3:
                    return Color.LightGray;
                default:
                    return Color.Black;
            }
        }

        private void mjeseci_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshCalendar();
        }

        private void godina_ValueChanged(object sender, EventArgs e)
        {
            RefreshCalendar();
        }

        private void Rezervacije_Resize(object sender, EventArgs e)
        {
            
        }

        private void mjeseci_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            RefreshCalendar();
        }

        private void Rezervacije_ResizeEnd(object sender, EventArgs e)
        {
            Console.WriteLine(this.Size.ToString());
            panel1.Size = new Size(this.Size.Width, this.Size.Height - 150); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (soba.SelectedIndex < 0)
            {
                MessageBox.Show("Izaberite sobu koja se rezervise");
                soba.Focus();
                soba.Text = "";
            }
            else if (string.IsNullOrEmpty(ime.Text))
            {
                MessageBox.Show("Napišite na koje se ime rezerviše");
                ime.Focus();
            }
            else
            {
                int index = lista.IndexOf(soba.SelectedItem.ToString());
                
                command.CommandText = "SELECT COUNT(*) FROM Rezervacija WHERE "
                    + " soba_id = '" + lista[index] + "' AND ((prijava <= '" + PrijavaGosta.ToSQLDateTime(prijavaDatum.Value)
                    + "' AND odjava >= '" + PrijavaGosta.ToSQLDateTime(prijavaDatum.Value)
                    + "' ) OR (prijava <= '" + PrijavaGosta.ToSQLDateTime(odjavaDatum.Value)
                    + "' AND odjava >= '" + PrijavaGosta.ToSQLDateTime(odjavaDatum.Value)
                    + "' ));";
                DatabaseClass.getConnection().Open();
                reader = command.ExecuteReader();
                reader.Read();
                if (reader.GetInt32(0) > 0)
                {
                    MessageBox.Show("Soba je vec rezervisana u tom periodu");
                    prijavaDatum.Focus();
                }
                else
                {
                    command.CommandText = "INSERT INTO Rezervacija (soba_id, prijava, odjava, ime, status, placeno) VALUES "
                        + " ('" + soba.SelectedItem + "', '" + PrijavaGosta.ToSQLDateTime(prijavaDatum.Value) 
                        +"', '" + PrijavaGosta.ToSQLDateTime(odjavaDatum.Value) + "', '" + ime.Text
                        + "', " + status.SelectedIndex + ", " + (placeno.SelectedIndex) + ");";
                    command.ExecuteNonQuery();
                    MessageBox.Show("Gosti prijavljeni u rezervacije");
                }

                DatabaseClass.getConnection().Close();
                
                RefreshCalendar();
            }

        }

        private void prijavaDatum_ValueChanged(object sender, EventArgs e)
        {
            odjavaDatum.MinDate = prijavaDatum.Value;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewSelectedCellCollection view = ((DataGridView)sender).SelectedCells;
            if (view[0].Style.BackColor != Color.Empty)
            {
                for (int i = 0; i < rezervacijaID.Count; i++)
                    if (rezervacijaID[i].Contains(view[0].ColumnIndex + "-" + view[0].RowIndex))
                    {
                        index = Int32.Parse(rezervacijaID[i].Substring(rezervacijaID[i].IndexOf(':') + 1));
                        break;
                    }
                DatabaseClass.getConnection().Open();
                command.CommandText = "SELECT ime, status, placeno FROM Rezervacija WHERE id = " + index + ";";
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    status1.SelectedIndex = reader.GetInt32(1);
                    imeTekst.Text = reader.GetString(0);
                    placen1.SelectedIndex = reader.GetInt32(2);
                    SetVisible(true);
                }

                DatabaseClass.getConnection().Close();
            }
            else
            {
                SetVisible(false);
            }
        }

        private void SetVisible(Boolean visible)
        {
            status1.Visible = placen1.Visible = c3.Visible = c4.Visible
                = ukloni.Visible = c5.Visible = imeTekst.Visible = promjena.Visible = visible;
        }

        private void promjena_Click(object sender, EventArgs e)
        {
            DatabaseClass.getConnection().Open();
            if (!ukloni.Checked)
            {
                command.CommandText = "UPDATE Rezervacija SET status = " + status1.SelectedIndex
                    + ", placeno = " + placen1.SelectedIndex + " WHERE id = "
                    + index + ";";
                command.ExecuteNonQuery();
            }
            else
            {
                DialogResult result = MessageBox.Show("Da li ste sigurni da zelite da uklonite rezervaciju?", "Upozorenje", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    command.CommandText = "DELETE FROM Rezervacija WHERE id = " + index + ";";
                    command.ExecuteNonQuery();
                }
            }

            DatabaseClass.getConnection().Close();
            RefreshCalendar();
            SetVisible(false);
        }

        private void ukloni_CheckedChanged(object sender, EventArgs e)
        {
            if (ukloni.Checked)
                promjena.Text = "Ukloni rezervaciju";
            else
                promjena.Text = "Prepravi rezervaciju";
        }
    }
}
