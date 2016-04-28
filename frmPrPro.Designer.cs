namespace recTimer
{
    partial class frmPrPro
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
            this.btProjPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbProjPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbOutputPath = new System.Windows.Forms.TextBox();
            this.btOutputPath = new System.Windows.Forms.Button();
            this.btImport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFPS = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btProjPath
            // 
            this.btProjPath.Location = new System.Drawing.Point(463, 35);
            this.btProjPath.Name = "btProjPath";
            this.btProjPath.Size = new System.Drawing.Size(93, 23);
            this.btProjPath.TabIndex = 0;
            this.btProjPath.Text = "Durchsuchen...";
            this.btProjPath.UseVisualStyleBackColor = true;
            this.btProjPath.Click += new System.EventHandler(this.btProjPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "PremierePro-Projekt als XML:";
            // 
            // tbProjPath
            // 
            this.tbProjPath.Location = new System.Drawing.Point(15, 37);
            this.tbProjPath.Name = "tbProjPath";
            this.tbProjPath.Size = new System.Drawing.Size(437, 20);
            this.tbProjPath.TabIndex = 2;
            this.tbProjPath.TextChanged += new System.EventHandler(this.tbProjPath_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output-Ordner der konfigurierten XML:";
            // 
            // tbOutputPath
            // 
            this.tbOutputPath.Location = new System.Drawing.Point(15, 98);
            this.tbOutputPath.Name = "tbOutputPath";
            this.tbOutputPath.Size = new System.Drawing.Size(437, 20);
            this.tbOutputPath.TabIndex = 5;
            // 
            // btOutputPath
            // 
            this.btOutputPath.Location = new System.Drawing.Point(463, 96);
            this.btOutputPath.Name = "btOutputPath";
            this.btOutputPath.Size = new System.Drawing.Size(93, 23);
            this.btOutputPath.TabIndex = 4;
            this.btOutputPath.Text = "Durchsuchen...";
            this.btOutputPath.UseVisualStyleBackColor = true;
            this.btOutputPath.Click += new System.EventHandler(this.btOutputPath_Click);
            // 
            // btImport
            // 
            this.btImport.Location = new System.Drawing.Point(16, 193);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(541, 37);
            this.btImport.TabIndex = 6;
            this.btImport.Text = "Einstellungen bestätigen.";
            this.btImport.UseVisualStyleBackColor = true;
            this.btImport.Click += new System.EventHandler(this.btImport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Timecode des Projekts (Frames/Sekunde):";
            // 
            // cbFPS
            // 
            this.cbFPS.FormattingEnabled = true;
            this.cbFPS.Items.AddRange(new object[] {
            "25",
            "30",
            "40",
            "50",
            "60"});
            this.cbFPS.Location = new System.Drawing.Point(238, 148);
            this.cbFPS.Name = "cbFPS";
            this.cbFPS.Size = new System.Drawing.Size(121, 21);
            this.cbFPS.TabIndex = 8;
            this.cbFPS.SelectedIndexChanged += new System.EventHandler(this.cbFPS_SelectedIndexChanged);
            // 
            // frmPrPro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 251);
            this.Controls.Add(this.cbFPS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btImport);
            this.Controls.Add(this.tbOutputPath);
            this.Controls.Add(this.btOutputPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbProjPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btProjPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrPro";
            this.Text = "Marken speichern für PremierePro-Projekt";
            this.Load += new System.EventHandler(this.frmPrPro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btProjPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbProjPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbOutputPath;
        private System.Windows.Forms.Button btOutputPath;
        private System.Windows.Forms.Button btImport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFPS;
    }
}