using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HotelBob
{
    public partial class PrijavaGosta : Form
    {
        private string brojSobe;
        System.Data.SqlServerCe.SqlCeDataReader read;
        System.Data.SqlServerCe.SqlCeCommand command = new System.Data.SqlServerCe.SqlCeCommand();
        List<int> idDrzave = new List<int>();

        Boolean povratnik = false;

        public PrijavaGosta(string soba, string brSobe)
        {
            InitializeComponent();
            command.Connection = DatabaseClass.getConnection();
            Correction(soba, brSobe);
            datumOdjave.MinDate = datumPrijave.MinDate = DateTime.Now;
            
        }

        private void Rezervacija_Load(object sender, EventArgs e)
        {
            bivsiComboBox.Visible = checkBox1.Checked;
            drzavaComboBox.Items.Clear();
            pansion.Items.Clear();
            command.CommandText = "SELECT naziv, id FROM Drzava;";
            DatabaseClass.getConnection().Close();
            DatabaseClass.getConnection().Open();
            read = command.ExecuteReader();
            while (read.Read())
            {
                drzavaComboBox.Items.Add(read.GetString(0));
                idDrzave.Add(read.GetInt32(1));
            }
            command.CommandText = "SELECT naziv, id FROM Pansion;";
            read = command.ExecuteReader();
            while (read.Read())
                pansion.Items.Add(read.GetString(0) + "-" + read.GetInt32(1));
            pansion.SelectedIndex = 0;

            command.CommandText = "SELECT * FROM Gost WHERE JMBG NOT IN"
                + " ((SELECT GostJMBG FROM sobe_gost));";
            read = command.ExecuteReader();
            while (read.Read())
                bivsiComboBox.Items.Add(read.GetString(0) + "-" + read.GetString(2) + " " + read.GetString(3));
            povratnik = false;

            DatabaseClass.getConnection().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result;
            if (double.Parse(popust.Text) != 0)
                result = new EnterPass().ShowDialog();
            else
                result = System.Windows.Forms.DialogResult.Yes;
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Boolean isJMBGNumber = true;
                for (int i = 0; i < JMBG.Text.Length; i++)
                {
                    if ((JMBG.Text[i] >= '0' && JMBG.Text[i] <= '9'))
                    {
                        isJMBGNumber = true;

                    }
                    else
                    {
                        isJMBGNumber = false;
                        break;
                    }
                }

                if (string.IsNullOrEmpty(imeText.Text))
                {
                    MessageBox.Show(this, "Molim vas unesite ime gosta!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    imeText.Focus();
                }
                else if (string.IsNullOrEmpty(prezimeText.Text))
                {
                    MessageBox.Show(this, "Molim vas unesite prezime gosta!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    prezimeText.Focus();
                }
                else if (string.IsNullOrEmpty(BLKTekst.Text))
                {
                    MessageBox.Show(this, "Molim vas unesite ispravno broj ličnog dokumenta!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    BLKTekst.Focus();
                    BLKTekst.Clear();
                }
                else if (!isJMBGNumber)
                {
                    MessageBox.Show(this, "Molim vas unesite ispravno cifre za JMBG!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    JMBG.Focus();
                    JMBG.Clear();
                }
                else if (string.IsNullOrEmpty(JMBG.Text) || JMBG.Text.Length != 13)
                {
                    MessageBox.Show(this, "Molim vas unesite ispravno JMBG!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    JMBG.Focus();
                    JMBG.Clear();
                }
                else if (drzavaComboBox.SelectedIndex < 0)
                {

                    MessageBox.Show(this, "Molim vas unesete državu!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    drzavaComboBox.Focus();
                }
                else if (datumOdjave.Enabled && (datumPrijave.Equals(datumOdjave)))
                {
                    MessageBox.Show(this, "Molim vas unesite ispravno datum prijave i odjave!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (string.IsNullOrEmpty(posebnaTekst.Text) && posebnaCijena.Checked)
                {
                    MessageBox.Show("Unesite cijenu posebne ponude!");
                    posebnaTekst.Focus();
                }
                else
                {
                    command.CommandText = "SELECT COUNT(*) FROM Gost WHERE JMBG = '" + JMBG.Text + "';";

                    DatabaseClass.getConnection().Open();

                    read = command.ExecuteReader();
                    read.Read();
                    if (read.GetSqlInt32(0) == 0 || povratnik)
                    {
                        if (povratnik)
                            command.CommandText = "UPDATE Gost "
                            + " SET BLK = '" + BLKTekst.Text + "',"
                            + "ime='" + imeText.Text
                            + "', prezime = '" + prezimeText.Text + "', "
                            + " drzavljanstvo = " + idDrzave[drzavaComboBox.SelectedIndex]
                            + " WHERE JMBG = '" + JMBG.Text + "';";
                        else
                            command.CommandText = "INSERT INTO Gost(JMBG, BLK, ime, prezime, drzavljanstvo) VALUES"
                            + "('" + JMBG.Text + "', '" + BLKTekst.Text + "', '" + imeText.Text + "','" + prezimeText.Text + "', "
                            + idDrzave[drzavaComboBox.SelectedIndex] + ");";
                        command.ExecuteNonQuery();
                        command.CommandText = "SELECT * FROM Sobe WHERE sifra = '" + brojSobe + "';";
                        read = command.ExecuteReader();
                        read.Read();
                        Console.WriteLine(brojSobe);
                        int vrsta = read.GetInt32(1);

                        System.Data.SqlServerCe.SqlCeDataReader subRead = new System.Data.SqlServerCe.SqlCeCommand("SELECT broj_kreveta FROM vrsta WHERE id = " + vrsta + ";", DatabaseClass.getConnection()).ExecuteReader();
                        subRead.Read();

                        command.CommandText = "UPDATE Sobe SET stanje = "
                            + ((subRead.GetInt32(0) == (read.GetInt32(3) + 1)) ? (3) : (1))
                            + ", " + "popunjenost = " + (read.GetInt32(3) + 1)
                            + "WHERE sifra = '" + brojSobe + "';";
                        command.ExecuteNonQuery();

                        command.CommandText = "INSERT INTO Sobe_Gost(SobeSifra, GostJMBG, Prijava, "
                            + ((!odjavaComboBox.Checked) ? ("odjava,") : ("")) + " veseraj, boravisna, popust, vrsta_pansiona, dodatniCeh , paket) VALUES"
                            + "('" + brojSobe + "', '" + JMBG.Text + "', '" + PrijavaGosta.ToSQLDateTime(datumPrijave.Value) + "', "
                            + ((!odjavaComboBox.Checked) ? ("'" + PrijavaGosta.ToSQLDateTime(datumOdjave.Value) + "',") : (""))
                            + " 0, " + ((taksa.Checked) ? (1) : (0)) + ", '" + popust.Text + "', "
                            + Int32.Parse(pansion.SelectedItem.ToString().Substring(pansion.SelectedItem.ToString().IndexOf('-') + 1)) + ", 0"
                            + ((posebnaCijena.Checked) ? (", " + int.Parse(posebnaTekst.Text)) : (", 0")) + ");";
                        command.ExecuteNonQuery();

                        command.CommandText = "INSERT INTO Izvjestaj(brojSobe, datumPrijave, "
                            + "datumOdjave, drzava, vrstaSobe, paket) VALUES"
                            + "('" + brojSobe + "', '" + PrijavaGosta.ToSQLDateTime(datumPrijave.Value) + "', "
                            + ((!odjavaComboBox.Checked) ? ("'" + PrijavaGosta.ToSQLDateTime(datumOdjave.Value) + "',") : ("'" + PrijavaGosta.ToSQLDateTime(datumPrijave.Value.AddDays(3))) + "',")
                            + idDrzave[drzavaComboBox.SelectedIndex] + ", " + vrsta
                            + ((posebnaCijena.Checked) ? (", " + int.Parse(posebnaTekst.Text)) : (", 0")) + ");";
                        command.ExecuteNonQuery();
                        MessageBox.Show("Uradjeno");


                    }
                    else
                    {
                        MessageBox.Show("Gost sa ovim maticnim brojem već je u hotelu!");
                        BLKTekst.Clear();
                        BLKTekst.Focus();
                    }
                    DatabaseClass.getConnection().Close();
                    Dispose();
  
                }
            }
            else
                MessageBox.Show("Potrebno je unijeti ispravnu šifru");
        }

        public static string ToSQLDateTime(DateTime time)
        {
            return time.Year + "-" + time.Month + "-" + time.Day;
        }

        public static string datumVrijeme(DateTime time)
        {
            return time.Year + "-" + time.Month + "-" + time.Day + " "
                + time.Hour + ":" + time.Minute + ":" + time.Second;
        }

        private void datumPrijave_ValueChanged(object sender, EventArgs e)
        {
            datumOdjave.MinDate = datumPrijave.Value;
        }

        private void Correction(string soba, string brSobe)
        {
            datumPrijave.MinDate = datumPrijave.Value = DateTime.Now;
            datumOdjave.MinDate = datumPrijave.Value;
            rezervisana_soba.Text = soba;
            brojSobe = brSobe.Substring(0, brSobe.IndexOf('_'));
        }

        private void odjavaComboBox_CheckedChanged(object sender, EventArgs e)
        {
            datumOdjave.Enabled = !odjavaComboBox.Checked;
        }

        public static void popust_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue >= '0' && e.KeyValue <= '9') || (e.KeyValue >= 96 && e.KeyValue <= 105) || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Back)
            { }
            else if ((e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Oemcomma || e.KeyCode == Keys.Decimal) && !((TextBox)sender).Text.Contains(','))
            {
                e.SuppressKeyPress = true;
                string text = ((TextBox)sender).Text;
                text += ',';
                ((TextBox)sender).Text = text;
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length; // add some logic if length is 0
                ((TextBox)sender).SelectionLength = 0;
            }
            else
                e.SuppressKeyPress = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bivsiComboBox.Visible = checkBox1.Checked;

        }

        private void bivsiComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            imeText.Clear();
            prezimeText.Clear();
            BLKTekst.Clear();
            JMBG.Clear();
            drzavaComboBox.SelectedIndex = -1;

            command.CommandText = "SELECT COUNT(*) FROM Sobe_Gost WHERE GostJMBG = '"
                + bivsiComboBox.SelectedItem.ToString().Substring(0, bivsiComboBox.SelectedItem.ToString().IndexOf('-'))
                + "';";

            DatabaseClass.getConnection().Close();
            DatabaseClass.getConnection().Open();
            read = command.ExecuteReader();
            read.Read();
            if (read.GetInt32(0) != 0)
            {
                povratnik = false;
            }
            else
            {
                command.CommandText = "SELECT * FROM Gost WHERE JMBG = '"
                   + bivsiComboBox.SelectedItem.ToString().Substring(0, bivsiComboBox.SelectedItem.ToString().IndexOf('-'))
                   + "';";
                read = command.ExecuteReader();
                read.Read();

                imeText.Text = read.GetString(2);
                prezimeText.Text = read.GetString(3);
                BLKTekst.Text = read.GetString(1);
                JMBG.Text = read.GetString(0);
                drzavaComboBox.SelectedIndex = read.GetInt32(4);
                povratnik = true;

            }
            DatabaseClass.getConnection().Close();
        }

        private void JMBG_TextChanged(object sender, EventArgs e)
        {
            povratnik = false;
        }

        private void posebnaTekst_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue >= '0' && e.KeyValue <= '9') || (e.KeyValue >= 96 && e.KeyValue <= 105) || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Back)
            { }
            else
                e.SuppressKeyPress = true;
        }
    }
}
