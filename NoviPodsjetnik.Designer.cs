namespace HotelBob
{
    partial class NoviPodsjetnik
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoviPodsjetnik));
            this.tekstPodsjetnika = new System.Windows.Forms.RichTextBox();
            this.Potvrdi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.sat = new System.Windows.Forms.ComboBox();
            this.minut = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.osobaComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sobaComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tekstPodsjetnika
            // 
            this.tekstPodsjetnika.Location = new System.Drawing.Point(0, 96);
            this.tekstPodsjetnika.Name = "tekstPodsjetnika";
            this.tekstPodsjetnika.Size = new System.Drawing.Size(350, 180);
            this.tekstPodsjetnika.TabIndex = 2;
            this.tekstPodsjetnika.Text = "";
            // 
            // Potvrdi
            // 
            this.Potvrdi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Potvrdi.Location = new System.Drawing.Point(0, 282);
            this.Potvrdi.Name = "Potvrdi";
            this.Potvrdi.Size = new System.Drawing.Size(350, 52);
            this.Potvrdi.TabIndex = 1;
            this.Potvrdi.Text = "Potvrdi";
            this.Potvrdi.UseVisualStyleBackColor = true;
            this.Potvrdi.Click += new System.EventHandler(this.Potvrdi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kada da se aktivira";
            // 
            // sat
            // 
            this.sat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sat.FormattingEnabled = true;
            this.sat.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.sat.Location = new System.Drawing.Point(116, 6);
            this.sat.Name = "sat";
            this.sat.Size = new System.Drawing.Size(41, 21);
            this.sat.TabIndex = 4;
            // 
            // minut
            // 
            this.minut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.minut.FormattingEnabled = true;
            this.minut.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.minut.Location = new System.Drawing.Point(163, 6);
            this.minut.Name = "minut";
            this.minut.Size = new System.Drawing.Size(46, 21);
            this.minut.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "d. M. yyyy.";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(215, 7);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(135, 20);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.Value = new System.DateTime(2017, 7, 16, 0, 0, 0, 0);
            // 
            // osobaComboBox
            // 
            this.osobaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.osobaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.osobaComboBox.FormattingEnabled = true;
            this.osobaComboBox.Location = new System.Drawing.Point(56, 33);
            this.osobaComboBox.Name = "osobaComboBox";
            this.osobaComboBox.Size = new System.Drawing.Size(153, 21);
            this.osobaComboBox.Sorted = true;
            this.osobaComboBox.TabIndex = 7;
            this.osobaComboBox.SelectedIndexChanged += new System.EventHandler(this.osobaComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Osoba";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Soba";
            // 
            // sobaComboBox
            // 
            this.sobaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.sobaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.sobaComboBox.Enabled = false;
            this.sobaComboBox.FormattingEnabled = true;
            this.sobaComboBox.Location = new System.Drawing.Point(56, 60);
            this.sobaComboBox.Name = "sobaComboBox";
            this.sobaComboBox.Size = new System.Drawing.Size(153, 21);
            this.sobaComboBox.Sorted = true;
            this.sobaComboBox.TabIndex = 9;
            this.sobaComboBox.SelectedIndexChanged += new System.EventHandler(this.sobaComboBox_SelectedIndexChanged);
            // 
            // NoviPodsjetnik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 334);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sobaComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.osobaComboBox);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.minut);
            this.Controls.Add(this.sat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Potvrdi);
            this.Controls.Add(this.tekstPodsjetnika);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NoviPodsjetnik";
            this.Text = "NoviPodsjetnik";
            this.Load += new System.EventHandler(this.NoviPodsjetnik_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox tekstPodsjetnika;
        private System.Windows.Forms.Button Potvrdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox sat;
        private System.Windows.Forms.ComboBox minut;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox osobaComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox sobaComboBox;
    }
}