using System;
using System.Windows.Forms;

namespace HotelBob
{
    public partial class EnterPass : Form
    {
        public EnterPass()
        {
            InitializeComponent();
            textBox1.Focus();
            textBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        /*    if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Unesite šifru!", "Upozorenje!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
            }
            else
            {
          */      string pass = textBox1.Text;
           //     System.Data.SqlServerCe.SqlCeDataReader reader = new System.Data.SqlServerCe.SqlCeCommand("SELECT id, tip  FROM Zaposleni WHERE sifra = '" + pass + "';", PocetnaForma.conn).ExecuteReader();
           //     if (reader.Read())
              //  {
                    if(pass.Equals(Startni.password))
                    {
                        DialogResult = System.Windows.Forms.DialogResult.Yes;
                    }
                    else if (string.IsNullOrEmpty(pass))
                    {
                        DialogResult = System.Windows.Forms.DialogResult.No;
                    }
                    else
                    {
                        MessageBox.Show("Unesite ispravnu šifru!", "Upozorenje!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
               //     }
                /*}
                else
                {
                    MessageBox.Show("Unesite ispravnu šifru!", "Upozorenje!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
                    textBox1.Clear();
                    textBox1.Focus();
                }
                */
            //}
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }
    }
}
