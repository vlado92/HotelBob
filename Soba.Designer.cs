namespace HotelBob
{
    partial class Soba
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Soba));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.datumPrijave = new System.Windows.Forms.DateTimePicker();
            this.OK = new System.Windows.Forms.Button();
            this.datumOdjave = new System.Windows.Forms.DateTimePicker();
            this.imeTextBox = new System.Windows.Forms.TextBox();
            this.informacije = new System.Windows.Forms.Button();
            this.odjavaButton = new System.Windows.Forms.Button();
            this.izmjeniButton = new System.Windows.Forms.Button();
            this.boravisna = new System.Windows.Forms.CheckBox();
            this.veserajCheckBox = new System.Windows.Forms.CheckBox();
            this.veserajText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.kvarovi = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dodatniCeh = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.popust = new System.Windows.Forms.TextBox();
            this.popust2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
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
            // datumPrijave
            // 
            resources.ApplyResources(this.datumPrijave, "datumPrijave");
            this.datumPrijave.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datumPrijave.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.datumPrijave.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.datumPrijave.Name = "datumPrijave";
            this.datumPrijave.TabStop = false;
            // 
            // OK
            // 
            resources.ApplyResources(this.OK, "OK");
            this.OK.Name = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.button1_Click);
            // 
            // datumOdjave
            // 
            resources.ApplyResources(this.datumOdjave, "datumOdjave");
            this.datumOdjave.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datumOdjave.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.datumOdjave.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.datumOdjave.Name = "datumOdjave";
            this.datumOdjave.TabStop = false;
            // 
            // imeTextBox
            // 
            resources.ApplyResources(this.imeTextBox, "imeTextBox");
            this.imeTextBox.Name = "imeTextBox";
            this.imeTextBox.TabStop = false;
            // 
            // informacije
            // 
            resources.ApplyResources(this.informacije, "informacije");
            this.informacije.Name = "informacije";
            this.informacije.TabStop = false;
            this.informacije.UseVisualStyleBackColor = true;
            this.informacije.Click += new System.EventHandler(this.button2_Click);
            // 
            // odjavaButton
            // 
            resources.ApplyResources(this.odjavaButton, "odjavaButton");
            this.odjavaButton.Name = "odjavaButton";
            this.odjavaButton.UseVisualStyleBackColor = true;
            this.odjavaButton.Click += new System.EventHandler(this.odjava_Click);
            // 
            // izmjeniButton
            // 
            resources.ApplyResources(this.izmjeniButton, "izmjeniButton");
            this.izmjeniButton.Name = "izmjeniButton";
            this.izmjeniButton.UseVisualStyleBackColor = true;
            this.izmjeniButton.Click += new System.EventHandler(this.izmjeni_Click);
            // 
            // boravisna
            // 
            resources.ApplyResources(this.boravisna, "boravisna");
            this.boravisna.Name = "boravisna";
            this.boravisna.UseVisualStyleBackColor = true;
            // 
            // veserajCheckBox
            // 
            resources.ApplyResources(this.veserajCheckBox, "veserajCheckBox");
            this.veserajCheckBox.Name = "veserajCheckBox";
            this.veserajCheckBox.UseVisualStyleBackColor = true;
            this.veserajCheckBox.CheckedChanged += new System.EventHandler(this.veserajCheckBox_CheckedChanged);
            // 
            // veserajText
            // 
            resources.ApplyResources(this.veserajText, "veserajText");
            this.veserajText.Name = "veserajText";
            this.veserajText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.veserajText_KeyDown);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // kvarovi
            // 
            this.kvarovi.CheckOnClick = true;
            this.kvarovi.FormattingEnabled = true;
            this.kvarovi.Items.AddRange(new object[] {
            resources.GetString("kvarovi.Items"),
            resources.GetString("kvarovi.Items1"),
            resources.GetString("kvarovi.Items2"),
            resources.GetString("kvarovi.Items3"),
            resources.GetString("kvarovi.Items4")});
            resources.ApplyResources(this.kvarovi, "kvarovi");
            this.kvarovi.MultiColumn = true;
            this.kvarovi.Name = "kvarovi";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // dodatniCeh
            // 
            resources.ApplyResources(this.dodatniCeh, "dodatniCeh");
            this.dodatniCeh.Name = "dodatniCeh";
            this.dodatniCeh.TabStop = false;
            this.dodatniCeh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // popust
            // 
            resources.ApplyResources(this.popust, "popust");
            this.popust.Name = "popust";
            this.popust.TabStop = false;
            this.popust.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // popust2
            // 
            resources.ApplyResources(this.popust2, "popust2");
            this.popust2.Name = "popust2";
            // 
            // Soba
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.popust);
            this.Controls.Add(this.popust2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dodatniCeh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.kvarovi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.veserajText);
            this.Controls.Add(this.veserajCheckBox);
            this.Controls.Add(this.boravisna);
            this.Controls.Add(this.izmjeniButton);
            this.Controls.Add(this.odjavaButton);
            this.Controls.Add(this.informacije);
            this.Controls.Add(this.imeTextBox);
            this.Controls.Add(this.datumOdjave);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.datumPrijave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Soba";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Soba_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker datumPrijave;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.DateTimePicker datumOdjave;
        private System.Windows.Forms.TextBox imeTextBox;
        private System.Windows.Forms.Button informacije;
        private System.Windows.Forms.Button odjavaButton;
        private System.Windows.Forms.Button izmjeniButton;
        private System.Windows.Forms.CheckBox boravisna;
        private System.Windows.Forms.CheckBox veserajCheckBox;
        private System.Windows.Forms.TextBox veserajText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox kvarovi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dodatniCeh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox popust;
        private System.Windows.Forms.Label popust2;
    }
}