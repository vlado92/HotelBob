namespace HotelBob
{
    partial class SobeZaCiscenje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SobeZaCiscenje));
            this.lista = new System.Windows.Forms.CheckedListBox();
            this.button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lista
            // 
            this.lista.CheckOnClick = true;
            this.lista.FormattingEnabled = true;
            this.lista.Location = new System.Drawing.Point(2, 0);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(149, 259);
            this.lista.TabIndex = 0;
            // 
            // button
            // 
            this.button.Dock = System.Windows.Forms.DockStyle.Right;
            this.button.Location = new System.Drawing.Point(153, 0);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(109, 262);
            this.button.TabIndex = 1;
            this.button.Text = "Potvrdi";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // SobeZaCiscenje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 262);
            this.Controls.Add(this.button);
            this.Controls.Add(this.lista);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SobeZaCiscenje";
            this.Text = "SobeZaCiscenje";
            this.Load += new System.EventHandler(this.SobeZaCiscenje_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox lista;
        private System.Windows.Forms.Button button;

    }
}