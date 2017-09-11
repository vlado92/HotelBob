namespace HotelBob
{
    partial class DialogBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogBox));
            this.prijavi = new System.Windows.Forms.Button();
            this.informacije = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // prijavi
            // 
            resources.ApplyResources(this.prijavi, "prijavi");
            this.prijavi.Name = "prijavi";
            this.prijavi.UseVisualStyleBackColor = true;
            this.prijavi.Click += new System.EventHandler(this.prijavi_Click);
            // 
            // informacije
            // 
            resources.ApplyResources(this.informacije, "informacije");
            this.informacije.Name = "informacije";
            this.informacije.UseVisualStyleBackColor = true;
            this.informacije.Click += new System.EventHandler(this.pregled_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // DialogBox
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.informacije);
            this.Controls.Add(this.prijavi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogBox";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button prijavi;
        private System.Windows.Forms.Button informacije;
        private System.Windows.Forms.Label label1;
    }
}