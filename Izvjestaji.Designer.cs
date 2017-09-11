namespace HotelBob
{
    partial class Izvjestaji
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Izvjestaji));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tekst = new System.Windows.Forms.RichTextBox();
            this.datum = new System.Windows.Forms.DateTimePicker();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Soba korišteno na dan";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(111, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 43);
            this.button2.TabIndex = 1;
            this.button2.Text = "Popunjenost u mjesecu";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(209, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 43);
            this.button3.TabIndex = 2;
            this.button3.Text = "Bordero";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tekst
            // 
            this.tekst.Location = new System.Drawing.Point(12, 87);
            this.tekst.Name = "tekst";
            this.tekst.ReadOnly = true;
            this.tekst.Size = new System.Drawing.Size(173, 272);
            this.tekst.TabIndex = 3;
            this.tekst.Text = "Na dan 14-07-2016 je bilo\nsoba zauzeto: 15\nJednokrevetnih : 5\nDvokrevetnih: 4\nTro" +
                "krevetnih 4\nCetverokrevetnih: 2\nLux apartman: 0\nUkupni promet: 1035";
            // 
            // datum
            // 
            this.datum.CustomFormat = "d. MM. yyyy";
            this.datum.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datum.Location = new System.Drawing.Point(12, 61);
            this.datum.Name = "datum";
            this.datum.Size = new System.Drawing.Size(287, 20);
            this.datum.TabIndex = 4;
            this.datum.ValueChanged += new System.EventHandler(this.datum_ValueChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(191, 87);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 272);
            this.button4.TabIndex = 5;
            this.button4.Text = "Štampaj izvještaj";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Izvjestaji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 371);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.datum);
            this.Controls.Add(this.tekst);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Izvjestaji";
            this.Text = "Izvještaji";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox tekst;
        private System.Windows.Forms.DateTimePicker datum;
        private System.Windows.Forms.Button button4;
    }
}