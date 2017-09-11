namespace HotelBob
{
    public partial class Klijent : System.Windows.Forms.Form
    {
        public Klijent(string[] read)
        {
            InitializeComponent();
            imeText.Text = read[1];
            BLKTekst.Text = read[3];
            prezimeText.Text = read[2];
            JMBG.Text = read[0];
            Drzavljanstvo.Text = read[4];
        }
    }
}
