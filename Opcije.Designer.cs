namespace HotelBob
{
    partial class Opcije
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Opcije));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.JMBG1 = new System.Windows.Forms.ComboBox();
            this.JMBG2 = new System.Windows.Forms.ComboBox();
            this.ime2 = new System.Windows.Forms.ComboBox();
            this.ime1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trenutno = new System.Windows.Forms.TextBox();
            this.kolicina = new System.Windows.Forms.TextBox();
            this.potvrdi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gost sa kog treba prebaciti";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gost na kog treba prebaciti";
            // 
            // JMBG1
            // 
            this.JMBG1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.JMBG1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.JMBG1.FormattingEnabled = true;
            this.JMBG1.Location = new System.Drawing.Point(12, 25);
            this.JMBG1.Name = "JMBG1";
            this.JMBG1.Size = new System.Drawing.Size(104, 21);
            this.JMBG1.TabIndex = 2;
            this.JMBG1.SelectedIndexChanged += new System.EventHandler(this.JMBG1_SelectedIndexChanged);
            // 
            // JMBG2
            // 
            this.JMBG2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.JMBG2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.JMBG2.FormattingEnabled = true;
            this.JMBG2.Location = new System.Drawing.Point(11, 79);
            this.JMBG2.Name = "JMBG2";
            this.JMBG2.Size = new System.Drawing.Size(104, 21);
            this.JMBG2.TabIndex = 3;
            this.JMBG2.SelectedIndexChanged += new System.EventHandler(this.JMBG2_SelectedIndexChanged);
            // 
            // ime2
            // 
            this.ime2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ime2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ime2.FormattingEnabled = true;
            this.ime2.Location = new System.Drawing.Point(122, 79);
            this.ime2.Name = "ime2";
            this.ime2.Size = new System.Drawing.Size(140, 21);
            this.ime2.TabIndex = 5;
            this.ime2.SelectedIndexChanged += new System.EventHandler(this.ime2_SelectedIndexChanged);
            // 
            // ime1
            // 
            this.ime1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ime1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ime1.FormattingEnabled = true;
            this.ime1.Location = new System.Drawing.Point(122, 25);
            this.ime1.Name = "ime1";
            this.ime1.Size = new System.Drawing.Size(140, 21);
            this.ime1.TabIndex = 4;
            this.ime1.SelectedIndexChanged += new System.EventHandler(this.ime1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Trenutno stanje";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Količina za prebaciti";
            // 
            // trenutno
            // 
            this.trenutno.Enabled = false;
            this.trenutno.Location = new System.Drawing.Point(11, 119);
            this.trenutno.Name = "trenutno";
            this.trenutno.Size = new System.Drawing.Size(100, 20);
            this.trenutno.TabIndex = 8;
            // 
            // kolicina
            // 
            this.kolicina.Location = new System.Drawing.Point(122, 119);
            this.kolicina.Name = "kolicina";
            this.kolicina.Size = new System.Drawing.Size(140, 20);
            this.kolicina.TabIndex = 9;
            this.kolicina.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // potvrdi
            // 
            this.potvrdi.Location = new System.Drawing.Point(11, 148);
            this.potvrdi.Name = "potvrdi";
            this.potvrdi.Size = new System.Drawing.Size(251, 29);
            this.potvrdi.TabIndex = 10;
            this.potvrdi.Text = "Potvrdi transakciju";
            this.potvrdi.UseVisualStyleBackColor = true;
            this.potvrdi.Click += new System.EventHandler(this.potvrdi_Click);
            // 
            // Opcije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 183);
            this.Controls.Add(this.potvrdi);
            this.Controls.Add(this.kolicina);
            this.Controls.Add(this.trenutno);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ime2);
            this.Controls.Add(this.ime1);
            this.Controls.Add(this.JMBG2);
            this.Controls.Add(this.JMBG1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Opcije";
            this.Text = "Opcije";
            this.Load += new System.EventHandler(this.Opcije_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox JMBG1;
        private System.Windows.Forms.ComboBox JMBG2;
        private System.Windows.Forms.ComboBox ime2;
        private System.Windows.Forms.ComboBox ime1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox trenutno;
        private System.Windows.Forms.TextBox kolicina;
        private System.Windows.Forms.Button potvrdi;
    }
}