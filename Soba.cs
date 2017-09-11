using System;
using System.Data.SqlServerCe;
using System.Linq;
using System.Windows.Forms;

namespace HotelBob
{
    public partial class Soba : Form
    {
        string[] podaci;
        string sifraSobe;
        int sifraDrzave;
        string startPopust;
        int vrstaPansiona;
       
        public Soba(string naziv, SqlCeDataReader soba)
        {
            sifraSobe = soba.GetString(0);
            vrstaPansiona = soba.GetInt32(6);
            InitializeComponent();
            veserajText.Enabled = veserajCheckBox.Checked;
            SqlCeCommand command = new SqlCeCommand("SELECT * FROM Gost WHERE JMBG = '" + soba.GetString(1) + "';", DatabaseClass.getConnection());
            datumPrijave.Value = soba.GetDateTime(2);
            startPopust = popust.Text = soba.GetString(7);

            if (!soba.IsDBNull(3))
                datumOdjave.Value = (soba.GetDateTime(3));
            else
                datumOdjave.Value = DateTime.Now;
            soba = command.ExecuteReader();
            if (soba.Read())
            {
                sifraDrzave = soba.GetInt32(4);
                SqlCeDataReader reader = new SqlCeCommand("SELECT naziv FROM drzava WHERE id = " + sifraDrzave + ";", DatabaseClass.getConnection()).ExecuteReader();
                reader.Read();
                podaci = new string[5] { soba.GetString(0) /*JMBG*/, 
                    soba.GetString(2), soba.GetString(3),  /*Ime i prezime*/
                    soba.GetString(1), reader.GetString(0)};
                imeTextBox.Text = soba.GetString(2) + " " + soba.GetString(3);
                for (int i = 0; i < soba.FieldCount; i++)
                    Console.WriteLine(soba.GetName(i));
            }
            Text = naziv;

            datumOdjave.MinDate = datumPrijave.Value;
            kvarovi.Items.Clear();
            command.CommandText = "SELECT naziv, cijena FROM kvarovi;";
            soba = command.ExecuteReader();
            while (soba.Read())
            {
                kvarovi.Items.Add(soba.GetString(0) + "-" + soba.GetInt32(1));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Klijent klijent = new Klijent(podaci);
            Program.Locate(klijent, this);
            klijent.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Izmjena();
            Dispose();
        }

        string output = "";
        string centeredText = "";
        int numberOfRows = 4;
        int firstLine;
        int secondLine;
        private void odjava_Click(object sender, EventArgs e)
        {
            output += "\n\n\n\n\n\nHotel Bob, Trebević\t\t\tRAČUN/BILL\n\n";
            numberOfRows += 3;
            output += "USLUGA\t\t\tRazdoblje\t\tDana\tKoličina\tCijena\tIznos\n";
            numberOfRows += 2;
            firstLine = numberOfRows;
            output += "\n";

            int n;
            if (veserajCheckBox.Checked && !Int32.TryParse(veserajText.Text, out n))
            {
                MessageBox.Show("Molim Vas unesite kolicinu vesa");
            }
            else
            {
                Izmjena();
                if (popust.Text.Equals(startPopust))
                {
                    int dana = datumOdjave.Value.Subtract(datumPrijave.Value).Days;
                    SqlCeCommand command = new SqlCeCommand("", DatabaseClass.getConnection());
                    DatabaseClass.getConnection().Close();
                    DatabaseClass.getConnection().Open();
                    SqlCeDataReader sobaReader;

                    command.CommandText = "SELECT cijena, naziv FROM pansion "
                        + " WHERE id = " + vrstaPansiona + ";";
                    sobaReader = command.ExecuteReader();
                    sobaReader.Read();
                    int cijena = sobaReader.GetInt32(0);
                    string nazivPansiona = sobaReader.GetString(1);

                    command.CommandText = "SELECT paket FROM sobe_gost WHERE sobeSifra = '" + sifraSobe 
                        + "' AND GostJMBG = '" + podaci[0] + "';";

                    sobaReader = command.ExecuteReader();
                    sobaReader.Read();
                    Boolean specijalni = true;
                    if (sobaReader.GetInt32(0) == 0)
                    {
                        specijalni = false;
                        command.CommandText = "SELECT vrsta FROM sobe WHERE sifra = '" + sifraSobe + "';";
                        sobaReader = command.ExecuteReader();
                        sobaReader.Read();
                        command.CommandText = "SELECT cijena  FROM vrsta "
                            + " WHERE id = " + sobaReader.GetInt32(0) + ";";
                        sobaReader = command.ExecuteReader();

                        sobaReader.Read();
                    }
                    
                        command.CommandText = "SELECT popunjenost FROM sobe WHERE sifra = '" + sifraSobe + "';";
                        SqlCeDataReader read = command.ExecuteReader();
                        read.Read();
                        int popunjen = read.GetInt32(0) - 1;
                        output += "Hotelski smještaj\t\t\t" + datumPrijave.Value.ToShortDateString() + "-" + datumOdjave.Value.ToShortDateString() + "\t" + dana + "\t" + dana + "\t"
                            + ((!specijalni) ? (sobaReader.GetInt32(0) / (popunjen + 1)) : (sobaReader.GetInt32(0)))
                            + "\t" + (dana * ((!specijalni) ? (sobaReader.GetInt32(0) / (popunjen + 1)) : (sobaReader.GetInt32(0)))) + "\n";
                        numberOfRows++;
                        output += nazivPansiona + "\t\t\t" + datumPrijave.Value.ToShortDateString() + "-" + datumOdjave.Value.ToShortDateString() + "\t" + dana + "\t" + dana + "\t"
                            + cijena
                            + "\t" + (dana * cijena) + "\n";
                        numberOfRows++;
                        if (boravisna.Checked)
                        {
                            output += "Boravišna taksa i osiguranje\t\t" + datumPrijave.Value.ToShortDateString() + "-" + datumOdjave.Value.ToShortDateString() + "\t" + dana + "\t" + dana + "\t 2.5 \t" + (dana * 2.5) + "\n";
                            numberOfRows++;
                        }
                        double startBill = ((boravisna.Checked) ? (2.5) : (0)) + dana * cijena;
                        if (specijalni)
                            startBill += dana * ((sobaReader.GetInt32(0)));
                        else
                            startBill += dana * ((sobaReader.GetInt32(0))) / (read.GetInt32(0));
                        output += "UKUPNO\t\t\t\t\t\t\t\t\t" + startBill + "\n";
                        numberOfRows++;
                    startBill = (dana * (sobaReader.GetInt32(0) * (1 - double.Parse(startPopust) / 100) + cijena)) / ((!specijalni) ?(read.GetInt32(0)) : (1)) + ((boravisna.Checked) ? (2.5) : (0));
                        output += "Popust\t\t\t\t\t\t\t\t" + popust.Text + "%\t\t" + startBill + "\n\n\n";
                        numberOfRows += 3;

                        double bill = startBill + ((veserajCheckBox.Checked) ? (Int32.Parse(veserajText.Text) * 1.5) : (0));
                        output += "OSTALE USLUGE\n";
                        numberOfRows++;
                        secondLine = numberOfRows;

                        if (veserajCheckBox.Checked)
                        {
                            output += "Vešeraj\t\t\t\t\t1.5KM/kg\t\t" + veserajText.Text + "kg\t\t" + (Int32.Parse(veserajText.Text) * 1.5) + "\n";
                            numberOfRows++;
                        }
                        for (int i = 0; i < kvarovi.CheckedIndices.Count; i++)
                        {
                            bill += double.Parse(kvarovi.CheckedItems[i].ToString()
                                .Substring(kvarovi.CheckedItems[i].ToString().IndexOf('-') + 1));
                            output += "LOM: " + kvarovi.CheckedItems[i].ToString()
                                .Substring(0, kvarovi.CheckedItems[i].ToString().IndexOf('-')) + "\t\t\t\t\t\t\t"
                                + kvarovi.CheckedItems[i].ToString()
                                .Substring(kvarovi.CheckedItems[i].ToString().IndexOf('-') + 1) + "\t\t" + kvarovi.CheckedItems[i].ToString()
                                .Substring(kvarovi.CheckedItems[i].ToString().IndexOf('-') + 1) + "\n";
                            numberOfRows++;
                        }

                        command.CommandText = "SELECT dodatniCeh FROM sobe_gost WHERE Sobesifra = '" + sifraSobe
                            + "' AND GostJMBG = '" + podaci[0] + "';";
                        read = command.ExecuteReader();
                        read.Read();

                        output += "Ostali računi:\t\t\t\t\t\t\t\t\t" + read.GetString(0) + "\n";
                        bill += double.Parse(read.GetString(0));
                        numberOfRows++;
                        output += "UKUPNO\t\t\t\t\t\t\t\t\t" + (bill - startBill) + "\n\n\n";
                        numberOfRows += 3;
                        output += "Za uplatu:\t\t\t\t\t\t\t\t\t" + bill + "\n";
                        numberOfRows++;

                        DialogResult result = MessageBox.Show(this, "Bio je prijavljen " + dana + " dana."
                        + "Da li je uplatio " + (bill) + "KM?"
                            , "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            command.CommandText = "DELETE FROM Sobe_gost "
                                 + "WHERE sobeSifra = '" + sifraSobe + "' AND GostJMBG = '" + podaci[0] + "';";
                            command.ExecuteNonQuery();

                            command.CommandText = "UPDATE Sobe SET  popunjenost = "
                                + popunjen + " " + ((popunjen == 0) ? (", stanje = 2 ") : ("")) + " WHERE sifra = '" + sifraSobe + "';";
                            command.ExecuteNonQuery();

                            printBill();

                            DatabaseClass.getConnection().Close();
                            this.Dispose();
                        }
                        else
                            MessageBox.Show("Greske se desavaju! ;) ");

                    
                    DatabaseClass.getConnection().Close();
                }
            }
        }

        private void printBill()
        {
            System.Drawing.StringFormat format = new System.Drawing.StringFormat();
            format.LineAlignment = System.Drawing.StringAlignment.Center;
            format.Alignment = System.Drawing.StringAlignment.Center;

            System.Drawing.Printing.PrintDocument print = new System.Drawing.Printing.PrintDocument();
            System.Drawing.Graphics g = print.PrinterSettings.CreateMeasurementGraphics();
            System.Drawing.Font myFont = new System.Drawing.Font("Times New Roman", 12, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            print.PrintPage += delegate(object sender1, System.Drawing.Printing.PrintPageEventArgs e1)
            {
                e1.Graphics.DrawImage(Izvjestaji.image, 595 / 2 - Izvjestaji.image.Width / 2 + 70, 0, Izvjestaji.image.Width,
                      Izvjestaji.image.Height);

                e1.Graphics.DrawLine(new System.Drawing.Pen(System.Drawing.Color.Black), new System.Drawing.Point(0, firstLine * myFont.Height + 10), new System.Drawing.Point(800, myFont.Height * firstLine + 10));

                e1.Graphics.DrawString(output, myFont, new System.Drawing.SolidBrush(System.Drawing.Color.Black),
                    new System.Drawing.RectangleF(0, 0, print.DefaultPageSettings.PrintableArea.Width,
                    print.DefaultPageSettings.PrintableArea.Height));
                e1.Graphics.DrawString(centeredText, myFont, new System.Drawing.SolidBrush(System.Drawing.Color.Black),
                    new System.Drawing.RectangleF(0, 0, print.DefaultPageSettings.PrintableArea.Width,
                    print.DefaultPageSettings.PrintableArea.Height), format);
            };
            PrintPreviewDialog pdi = new PrintPreviewDialog();
            pdi.Document = print;
            pdi.ShowDialog();
            //print.Print();
        }

        bool clicked = false;
        private void izmjeni_Click(object sender, EventArgs e)
        {
            clicked = !clicked;
            if (clicked)
            {
                ((Button)sender).Text = "Potvrdi izmjenu";
            }
            else
            {
                Izmjena();
                ((Button)sender).Text = "Izmjeni";
            }
            popust.Enabled = datumOdjave.Enabled = dodatniCeh.Enabled = clicked;
        }

        private Boolean Izmjena()
        {
            if (string.IsNullOrEmpty(popust.Text))
                popust.Text = "0";
            DialogResult result;
            if (!popust.Text.Equals(startPopust))
                result = new EnterPass().ShowDialog();
            else
                result = System.Windows.Forms.DialogResult.Yes;
            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                Console.WriteLine(popust.Text + " 4");
                startPopust = popust.Text;
                SqlCeCommand command = new SqlCeCommand("SELECT odjava, dodatniCeh FROM Sobe_Gost WHERE sobeSifra = '" + sifraSobe + "';", DatabaseClass.getConnection());
                DatabaseClass.getConnection().Open();
                SqlCeDataReader reader = command.ExecuteReader();

                reader.Read();
                string databasePopust = reader.GetString(1);
                if (string.IsNullOrEmpty(dodatniCeh.Text))
                    dodatniCeh.Text = "0";
                if (veserajCheckBox.Checked || datumOdjave.Enabled)
                {
                    if (reader.IsDBNull(0))
                    {

                        Console.WriteLine(popust.Text + " 0 ");
                        command.CommandText = command.CommandText = "UPDATE Sobe_Gost SET " +
                            ((datumOdjave.Enabled) ? ("Odjava = '" + PrijavaGosta.ToSQLDateTime(datumOdjave.Value) + "', ") : (""))
                            + ((veserajCheckBox.Checked) ? (" veseraj = " + Int32.Parse(veserajText.Text) + ",") : (""))
                            + " Boravisna = " + ((boravisna.Checked) ? (1) : (0)) + " "
                            + ", dodatniCeh = '" + (double.Parse(databasePopust) + double.Parse(dodatniCeh.Text)) + "', popust = '"
                            + (popust.Text)
                            + "' WHERE sobeSifra = '" + sifraSobe + "' AND GostJMBG = '" + podaci[0] + "';";

                        command.ExecuteNonQuery();
                        DatabaseClass.getConnection().Close();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine(popust.Text + " 1 ");
                        command.CommandText = "UPDATE Sobe_Gost SET " +
                        ((datumOdjave.Enabled) ? ("Odjava = '" + PrijavaGosta.ToSQLDateTime(datumOdjave.Value) + "', ") : (""))
                        + ((veserajCheckBox.Checked) ? (" veseraj = " + Int32.Parse(veserajText.Text) + ",") : (""))
                        + " Boravisna = " + ((boravisna.Checked) ? (1) : (0)) + " "
                        + ", dodatniCeh = '" + (double.Parse(databasePopust) + double.Parse(dodatniCeh.Text))
                        + "', popust = '" + (popust.Text)
                        + "' WHERE sobeSifra = '" + sifraSobe + "' AND GostJMBG = '" + podaci[0] + "';";
                        command.ExecuteNonQuery();
                        DatabaseClass.getConnection().Close();
                        return true;
                    }

                }
                else
                    return false;
            }
            else
            {
                MessageBox.Show("Potrebno je unijeti ispravnu šifru za popust");
                return false;
            }
        }

        private void veserajCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            veserajText.Enabled = veserajCheckBox.Checked;
        }

        private void veserajText_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue >= '0' && e.KeyValue <= '9') || (e.KeyValue >= 96 && e.KeyValue <= 105) || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Back)
            { }
            else
                e.SuppressKeyPress = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
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

        private void Soba_Load(object sender, EventArgs e)
        {

        }
    }
}
