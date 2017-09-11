using System;
using System.Drawing;
using System.Windows.Forms;

namespace HotelBob
{
    public partial class Izvjestaji : Form
    {
        System.Data.SqlServerCe.SqlCeCommand command = new System.Data.SqlServerCe.SqlCeCommand("", DatabaseClass.getConnection());
        System.Data.SqlServerCe.SqlCeDataReader reader;
        int tip;
        string lijevo = "\n\n", desno = "\n\n\n";
        public static Image image = Image.FromFile(".\\Bob logo.png");
        int lines;

        public Izvjestaji()
        {
            InitializeComponent();
            SetMyCustomFormat(tip = 0);
            UpdateText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetMyCustomFormat(tip = 0);
            UpdateText();
        }

        public void UpdateText()
        {
            tekst.Clear();
            if(tip == 0)
                tekst.Text = "Na dan " + datum.Value.ToShortDateString() + " je bilo zauzeto:\n";
            else if(tip == 1)
                tekst.Text = "U mjesecu " + datum.Value.Month + ". " + datum.Value.Year + " je bilo zauzeto:\n";
            else if (tip == 2)
            {
                tekst.Text = "Za dan " + datum.Value.ToShortDateString() + " ima:\n";
            }
            lijevo = "\n\n\n\n" + tekst.Text + "\n";
            desno = "\n\n\n\n\n\n";
            lines = 6;
            if (tip == 2)
            {
                command.CommandText = "SELECT COUNT(*), vrsta_pansiona  FROM Sobe_GOST "
                              + (" WHERE Prijava <= '" + PrijavaGosta.ToSQLDateTime(datum.Value)
                              + "' AND Odjava >= '" + PrijavaGosta.ToSQLDateTime(datum.Value) + "'")
                              + " GROUP BY vrsta_pansiona;";
                DatabaseClass.getConnection().Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    System.Data.SqlServerCe.SqlCeDataReader subRead =
                        new System.Data.SqlServerCe.SqlCeCommand("SELECT naziv FROM pansion WHERE id = "
                            + reader.GetInt32(1) + ";", DatabaseClass.getConnection()).ExecuteReader();
                    if (subRead.Read())
                    {
                        tekst.Text += subRead.GetString(0) + ": " + reader.GetInt32(0) + "\n";
                        lijevo += subRead.GetString(0) + "\n";
                        desno += reader.GetInt32(0) + "\n";
                        lines++;
                    }
                }
                DatabaseClass.getConnection().Close();
            }
            else
            {
                DatabaseClass.getConnection().Open();
                command.CommandText = "SELECT COUNT(*), vrstaSobe"
                                + " FROM Izvjestaj  WHERE "
                + ((tip == 0) ? ("datumPrijave <= '" + PrijavaGosta.ToSQLDateTime(datum.Value)
                                + "' AND datumOdjave >= '" + PrijavaGosta.ToSQLDateTime(datum.Value) + "'")
                 : (" DATEPART(month, datumPrijave) = " + datum.Value.Month
                                + " AND DATEPART(year, datumPrijave) = " + datum.Value.Year))
                + "GROUP BY vrstaSobe;";
                int sum = 0;
                int numberOfRooms = 0;
                reader = command.ExecuteReader();
                System.Data.SqlServerCe.SqlCeDataReader subReader;
                while (reader.Read())
                {
                    command.CommandText = "SELECT naziv, cijena FROM Vrsta WHERE id = " + reader.GetInt32(1) + ";";
                    subReader = command.ExecuteReader();
                    if (subReader.Read())
                    {
                        tekst.Text += subReader.GetString(0) + " - " + reader.GetInt32(0) + "\n";
                        lijevo += subReader.GetString(0) + "\n";
                        desno += reader.GetInt32(0) + "\n";
                        numberOfRooms += reader.GetInt32(0);
                    }
                }
                command.CommandText = "SELECT vrstaSobe, paket"
                                + " FROM Izvjestaj  WHERE "
                + ((tip == 0) ? ("datumPrijave <= '" + PrijavaGosta.ToSQLDateTime(datum.Value)
                                + "' AND datumOdjave >= '" + PrijavaGosta.ToSQLDateTime(datum.Value) + "'")
                 : (" DATEPART(month, datumPrijave) = " + datum.Value.Month
                                + " AND DATEPART(year, datumPrijave) = " + datum.Value.Year)) + ";";
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if(reader.GetInt32(1) == 0)
                    {
                        command.CommandText = "SELECT cijena FROM Vrsta WHERE id = " + reader.GetInt32(1) + ";";
                        subReader = command.ExecuteReader();
                        if (subReader.Read())
                        {
                            sum += subReader.GetInt32(0);
                        }
                    }
                    else
                    {
                        sum += reader.GetInt32(1);
                    }
                }
                
                
                     
                tekst.Text += "\nUkupno soba zauzeto : " + numberOfRooms + "\nUkupni promet: " + sum;
                lijevo += "\nUkupno soba zauzeto : \n";
                desno += "\n" + numberOfRooms + "\n";
                lijevo += "Ukupni promet:\n";
                desno += sum + "\n";
                lines++;
                DatabaseClass.getConnection().Close();
            }
        }

        public void SetMyCustomFormat(int n)
        {
            // Set the Format type and the CustomFormat string.
            switch (n)
            {
                case 0:
                    datum.Format = DateTimePickerFormat.Custom;
                    datum.CustomFormat = "d. M. yyyy.";
                    break;
                case 1:

                    datum.Format = DateTimePickerFormat.Custom;
                    datum.CustomFormat = "M. yyyy.";
                    break;

                case 2:
                    datum.Format = DateTimePickerFormat.Custom;
                    datum.CustomFormat = "d. M. yyyy.";
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetMyCustomFormat(tip = 1);
            UpdateText();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            printBill();
         //   MessageBox.Show("FUNKCIJA ZA PRINTANJE");
        }

        void printBill()
        {
            StringFormat format = new StringFormat();
            //format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            System.Drawing.Printing.PrintDocument print = new System.Drawing.Printing.PrintDocument();
            Graphics g = print.PrinterSettings.CreateMeasurementGraphics();
            Font myFont = new Font("Times New Roman", 24, FontStyle.Regular, GraphicsUnit.Point);

            print.PrintPage += delegate(object sender1, System.Drawing.Printing.PrintPageEventArgs e1)
                {
                    e1.Graphics.DrawImage(image, 595/2 - image.Width/2 + 70, 0, image.Width,
                        image.Height);
             
                    e1.Graphics.DrawLine(new Pen(Color.Black), new Point(0, (++lines) * myFont.Height + 20), new Point(595, myFont.Height * (lines) + 20));                  
                        e1.Graphics.DrawString(lijevo, myFont, new SolidBrush(Color.Black),
                        new RectangleF(0, 0, print.DefaultPageSettings.PrintableArea.Width,
                        print.DefaultPageSettings.PrintableArea.Height));
                    e1.Graphics.DrawString(desno, myFont, new SolidBrush(Color.Black),
                                            new RectangleF(0, 0, print.DefaultPageSettings.PrintableArea.Width,
                                            print.DefaultPageSettings.PrintableArea.Height), format);

                };
            PrintPreviewDialog pdi = new PrintPreviewDialog();
            pdi.Document = print;
            //    pdi.ShowDialog();
                print.Print();
        }

        private void datum_ValueChanged(object sender, EventArgs e)
        {
            UpdateText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetMyCustomFormat(tip = 2);
            UpdateText();
        }
    }
}
