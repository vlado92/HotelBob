using System;
using System.Windows.Forms;

namespace HotelBob
{
    public partial class DialogBox : Form
    {
        public DialogBox(string text, string title)
        {
            InitializeComponent();
            label1.Text = text;
            this.Text = title;
        }

        private void prijavi_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Dispose();
        }

        private void pregled_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            this.Dispose();
        }
    }
}
