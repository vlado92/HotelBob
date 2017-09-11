namespace HotelBob
{
    partial class PrijavaGosta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrijavaGosta));
            this.datumOdjave = new System.Windows.Forms.DateTimePicker();
            this.datumPrijave = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BLKTekst = new System.Windows.Forms.TextBox();
            this.prezimeText = new System.Windows.Forms.TextBox();
            this.imeText = new System.Windows.Forms.TextBox();
            this.licna_label = new System.Windows.Forms.Label();
            this.prezime_label = new System.Windows.Forms.Label();
            this.ime_label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rezervisana_soba = new System.Windows.Forms.TextBox();
            this.JMBG = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.drzavaComboBox = new System.Windows.Forms.ComboBox();
            this.taksa = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.popust = new System.Windows.Forms.TextBox();
            this.pansion = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.odjavaComboBox = new System.Windows.Forms.CheckBox();
            this.bivsiComboBox = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.posebnaCijena = new System.Windows.Forms.CheckBox();
            this.posebnaTekst = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // datumOdjave
            // 
            this.datumOdjave.CustomFormat = "d. M. yyyy.";
            this.datumOdjave.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datumOdjave.Location = new System.Drawing.Point(91, 199);
            this.datumOdjave.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.datumOdjave.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.datumOdjave.Name = "datumOdjave";
            this.datumOdjave.Size = new System.Drawing.Size(204, 20);
            this.datumOdjave.TabIndex = 9;
            this.datumOdjave.TabStop = false;
            // 
            // datumPrijave
            // 
            this.datumPrijave.CustomFormat = "d. M. yyyy.";
            this.datumPrijave.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datumPrijave.Location = new System.Drawing.Point(90, 140);
            this.datumPrijave.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.datumPrijave.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.datumPrijave.Name = "datumPrijave";
            this.datumPrijave.Size = new System.Drawing.Size(213, 20);
            this.datumPrijave.TabIndex = 8;
            this.datumPrijave.TabStop = false;
            this.datumPrijave.ValueChanged += new System.EventHandler(this.datumPrijave_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Datum odjave";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Datum prijave";
            // 
            // BLKTekst
            // 
            this.BLKTekst.Location = new System.Drawing.Point(95, 54);
            this.BLKTekst.Name = "BLKTekst";
            this.BLKTekst.Size = new System.Drawing.Size(208, 20);
            this.BLKTekst.TabIndex = 15;
            // 
            // prezimeText
            // 
            this.prezimeText.Location = new System.Drawing.Point(95, 28);
            this.prezimeText.Name = "prezimeText";
            this.prezimeText.Size = new System.Drawing.Size(208, 20);
            this.prezimeText.TabIndex = 14;
            // 
            // imeText
            // 
            this.imeText.Location = new System.Drawing.Point(95, 2);
            this.imeText.Name = "imeText";
            this.imeText.Size = new System.Drawing.Size(208, 20);
            this.imeText.TabIndex = 13;
            // 
            // licna_label
            // 
            this.licna_label.AutoSize = true;
            this.licna_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.licna_label.Location = new System.Drawing.Point(12, 61);
            this.licna_label.Name = "licna_label";
            this.licna_label.Size = new System.Drawing.Size(79, 13);
            this.licna_label.TabIndex = 12;
            this.licna_label.Text = "Lični dokument";
            // 
            // prezime_label
            // 
            this.prezime_label.AutoSize = true;
            this.prezime_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.prezime_label.Location = new System.Drawing.Point(12, 35);
            this.prezime_label.Name = "prezime_label";
            this.prezime_label.Size = new System.Drawing.Size(44, 13);
            this.prezime_label.TabIndex = 11;
            this.prezime_label.Text = "Prezime";
            // 
            // ime_label
            // 
            this.ime_label.AutoSize = true;
            this.ime_label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ime_label.Location = new System.Drawing.Point(12, 9);
            this.ime_label.Name = "ime_label";
            this.ime_label.Size = new System.Drawing.Size(24, 13);
            this.ime_label.TabIndex = 10;
            this.ime_label.Text = "Ime";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 385);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(307, 32);
            this.button1.TabIndex = 99;
            this.button1.Text = "Potvrdi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Rezervisana soba:";
            // 
            // rezervisana_soba
            // 
            this.rezervisana_soba.Enabled = false;
            this.rezervisana_soba.Location = new System.Drawing.Point(104, 293);
            this.rezervisana_soba.Name = "rezervisana_soba";
            this.rezervisana_soba.Size = new System.Drawing.Size(191, 20);
            this.rezervisana_soba.TabIndex = 18;
            // 
            // JMBG
            // 
            this.JMBG.Location = new System.Drawing.Point(95, 80);
            this.JMBG.Name = "JMBG";
            this.JMBG.Size = new System.Drawing.Size(208, 20);
            this.JMBG.TabIndex = 27;
            this.JMBG.TextChanged += new System.EventHandler(this.JMBG_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(12, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Drzavljanstvo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(12, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "JMBG";
            // 
            // drzavaComboBox
            // 
            this.drzavaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.drzavaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drzavaComboBox.FormattingEnabled = true;
            this.drzavaComboBox.Location = new System.Drawing.Point(95, 113);
            this.drzavaComboBox.Name = "drzavaComboBox";
            this.drzavaComboBox.Size = new System.Drawing.Size(208, 21);
            this.drzavaComboBox.TabIndex = 28;
            // 
            // taksa
            // 
            this.taksa.AutoSize = true;
            this.taksa.Location = new System.Drawing.Point(12, 239);
            this.taksa.Name = "taksa";
            this.taksa.Size = new System.Drawing.Size(102, 17);
            this.taksa.TabIndex = 29;
            this.taksa.Text = "Boravišna taksa";
            this.taksa.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(149, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Popust";
            // 
            // popust
            // 
            this.popust.Location = new System.Drawing.Point(195, 240);
            this.popust.Name = "popust";
            this.popust.Size = new System.Drawing.Size(100, 20);
            this.popust.TabIndex = 31;
            this.popust.Text = "0";
            // 
            // pansion
            // 
            this.pansion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.pansion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.pansion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pansion.FormattingEnabled = true;
            this.pansion.Location = new System.Drawing.Point(95, 266);
            this.pansion.Name = "pansion";
            this.pansion.Size = new System.Drawing.Size(208, 21);
            this.pansion.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(12, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Vrsta pansiona";
            // 
            // odjavaComboBox
            // 
            this.odjavaComboBox.AutoSize = true;
            this.odjavaComboBox.Location = new System.Drawing.Point(15, 173);
            this.odjavaComboBox.Name = "odjavaComboBox";
            this.odjavaComboBox.Size = new System.Drawing.Size(121, 17);
            this.odjavaComboBox.TabIndex = 34;
            this.odjavaComboBox.Text = "Nema datum odjave";
            this.odjavaComboBox.UseVisualStyleBackColor = true;
            this.odjavaComboBox.CheckedChanged += new System.EventHandler(this.odjavaComboBox_CheckedChanged);
            // 
            // bivsiComboBox
            // 
            this.bivsiComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.bivsiComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.bivsiComboBox.FormattingEnabled = true;
            this.bivsiComboBox.Location = new System.Drawing.Point(104, 345);
            this.bivsiComboBox.Name = "bivsiComboBox";
            this.bivsiComboBox.Size = new System.Drawing.Size(199, 21);
            this.bivsiComboBox.TabIndex = 35;
            this.bivsiComboBox.TabStop = false;
            this.bivsiComboBox.SelectedIndexChanged += new System.EventHandler(this.bivsiComboBox_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 347);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(71, 17);
            this.checkBox1.TabIndex = 36;
            this.checkBox1.Text = "Bivši gost";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // posebnaCijena
            // 
            this.posebnaCijena.AutoSize = true;
            this.posebnaCijena.Location = new System.Drawing.Point(6, 319);
            this.posebnaCijena.Name = "posebnaCijena";
            this.posebnaCijena.Size = new System.Drawing.Size(99, 17);
            this.posebnaCijena.TabIndex = 37;
            this.posebnaCijena.Text = "Posebna cijena";
            this.posebnaCijena.UseVisualStyleBackColor = true;
            // 
            // posebnaTekst
            // 
            this.posebnaTekst.Location = new System.Drawing.Point(104, 319);
            this.posebnaTekst.Name = "posebnaTekst";
            this.posebnaTekst.Size = new System.Drawing.Size(191, 20);
            this.posebnaTekst.TabIndex = 100;
            this.posebnaTekst.KeyDown += new System.Windows.Forms.KeyEventHandler(this.posebnaTekst_KeyDown);
            // 
            // PrijavaGosta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 417);
            this.Controls.Add(this.posebnaTekst);
            this.Controls.Add(this.posebnaCijena);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.bivsiComboBox);
            this.Controls.Add(this.odjavaComboBox);
            this.Controls.Add(this.pansion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.popust);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.taksa);
            this.Controls.Add(this.drzavaComboBox);
            this.Controls.Add(this.JMBG);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rezervisana_soba);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BLKTekst);
            this.Controls.Add(this.prezimeText);
            this.Controls.Add(this.imeText);
            this.Controls.Add(this.licna_label);
            this.Controls.Add(this.prezime_label);
            this.Controls.Add(this.ime_label);
            this.Controls.Add(this.datumOdjave);
            this.Controls.Add(this.datumPrijave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrijavaGosta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Rezervacija";
            this.Load += new System.EventHandler(this.Rezervacija_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datumOdjave;
        private System.Windows.Forms.DateTimePicker datumPrijave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BLKTekst;
        private System.Windows.Forms.TextBox prezimeText;
        private System.Windows.Forms.TextBox imeText;
        private System.Windows.Forms.Label licna_label;
        private System.Windows.Forms.Label prezime_label;
        private System.Windows.Forms.Label ime_label;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox rezervisana_soba;
        private System.Windows.Forms.TextBox JMBG;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox drzavaComboBox;
        private System.Windows.Forms.CheckBox taksa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox popust;
        private System.Windows.Forms.ComboBox pansion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox odjavaComboBox;
        private System.Windows.Forms.ComboBox bivsiComboBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox posebnaCijena;
        private System.Windows.Forms.TextBox posebnaTekst;
    }
}