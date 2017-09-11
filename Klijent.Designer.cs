namespace HotelBob
{
    partial class Klijent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Klijent));
            this.ime_label = new System.Windows.Forms.Label();
            this.prezime_label = new System.Windows.Forms.Label();
            this.licna_label = new System.Windows.Forms.Label();
            this.imeText = new System.Windows.Forms.TextBox();
            this.prezimeText = new System.Windows.Forms.TextBox();
            this.BLKTekst = new System.Windows.Forms.TextBox();
            this.Drzavljanstvo = new System.Windows.Forms.TextBox();
            this.JMBG = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ime_label
            // 
            resources.ApplyResources(this.ime_label, "ime_label");
            this.ime_label.Name = "ime_label";
            // 
            // prezime_label
            // 
            resources.ApplyResources(this.prezime_label, "prezime_label");
            this.prezime_label.Name = "prezime_label";
            // 
            // licna_label
            // 
            resources.ApplyResources(this.licna_label, "licna_label");
            this.licna_label.Name = "licna_label";
            // 
            // imeText
            // 
            resources.ApplyResources(this.imeText, "imeText");
            this.imeText.Name = "imeText";
            // 
            // prezimeText
            // 
            resources.ApplyResources(this.prezimeText, "prezimeText");
            this.prezimeText.Name = "prezimeText";
            // 
            // BLKTekst
            // 
            resources.ApplyResources(this.BLKTekst, "BLKTekst");
            this.BLKTekst.Name = "BLKTekst";
            // 
            // Drzavljanstvo
            // 
            resources.ApplyResources(this.Drzavljanstvo, "Drzavljanstvo");
            this.Drzavljanstvo.Name = "Drzavljanstvo";
            // 
            // JMBG
            // 
            resources.ApplyResources(this.JMBG, "JMBG");
            this.JMBG.Name = "JMBG";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Klijent
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Drzavljanstvo);
            this.Controls.Add(this.JMBG);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BLKTekst);
            this.Controls.Add(this.prezimeText);
            this.Controls.Add(this.imeText);
            this.Controls.Add(this.licna_label);
            this.Controls.Add(this.prezime_label);
            this.Controls.Add(this.ime_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Klijent";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ime_label;
        private System.Windows.Forms.Label prezime_label;
        private System.Windows.Forms.Label licna_label;
        private System.Windows.Forms.TextBox imeText;
        private System.Windows.Forms.TextBox prezimeText;
        private System.Windows.Forms.TextBox BLKTekst;
        private System.Windows.Forms.TextBox Drzavljanstvo;
        private System.Windows.Forms.TextBox JMBG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}