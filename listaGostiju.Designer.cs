namespace HotelBob
{
    partial class listaGostiju
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(listaGostiju));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Ime_Gosta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soba = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prijava = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.odjava = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JMBG_Gosta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detalji = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ime_Gosta,
            this.soba,
            this.prijava,
            this.odjava,
            this.JMBG_Gosta});
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // Ime_Gosta
            // 
            resources.ApplyResources(this.Ime_Gosta, "Ime_Gosta");
            this.Ime_Gosta.Name = "Ime_Gosta";
            this.Ime_Gosta.ReadOnly = true;
            // 
            // soba
            // 
            resources.ApplyResources(this.soba, "soba");
            this.soba.Name = "soba";
            this.soba.ReadOnly = true;
            // 
            // prijava
            // 
            resources.ApplyResources(this.prijava, "prijava");
            this.prijava.Name = "prijava";
            this.prijava.ReadOnly = true;
            // 
            // odjava
            // 
            resources.ApplyResources(this.odjava, "odjava");
            this.odjava.Name = "odjava";
            this.odjava.ReadOnly = true;
            // 
            // JMBG_Gosta
            // 
            resources.ApplyResources(this.JMBG_Gosta, "JMBG_Gosta");
            this.JMBG_Gosta.Name = "JMBG_Gosta";
            this.JMBG_Gosta.ReadOnly = true;
            this.JMBG_Gosta.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // detalji
            // 
            resources.ApplyResources(this.detalji, "detalji");
            this.detalji.Name = "detalji";
            this.detalji.UseVisualStyleBackColor = true;
            this.detalji.Click += new System.EventHandler(this.detalji_Click);
            // 
            // listaGostiju
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.detalji);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "listaGostiju";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.listaGostiju_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button detalji;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime_Gosta;
        private System.Windows.Forms.DataGridViewTextBoxColumn soba;
        private System.Windows.Forms.DataGridViewTextBoxColumn prijava;
        private System.Windows.Forms.DataGridViewTextBoxColumn odjava;
        private System.Windows.Forms.DataGridViewTextBoxColumn JMBG_Gosta;
    }
}