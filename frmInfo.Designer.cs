namespace recTimer
{
    partial class frmInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbVersionInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.btBugReport = new System.Windows.Forms.Button();
            this.btChangeLogs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "zekro\'s Recording Tool";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbVersionInfo
            // 
            this.lbVersionInfo.Location = new System.Drawing.Point(16, 45);
            this.lbVersionInfo.Name = "lbVersionInfo";
            this.lbVersionInfo.Size = new System.Drawing.Size(380, 19);
            this.lbVersionInfo.TabIndex = 1;
            this.lbVersionInfo.Text = "label2";
            this.lbVersionInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(380, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "©2016 zekro";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(13, 105);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(380, 23);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Website - zekro.jimdo-com";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(380, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "WEBSITE AND SOCIAL NETWORK";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // linkLabel2
            // 
            this.linkLabel2.Location = new System.Drawing.Point(16, 128);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(380, 23);
            this.linkLabel2.TabIndex = 5;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "YouTube - /zekrommaster110";
            this.linkLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.Location = new System.Drawing.Point(13, 152);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(380, 23);
            this.linkLabel3.TabIndex = 6;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Twitter - @zekrommaster110";
            this.linkLabel3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkLabel4
            // 
            this.linkLabel4.Location = new System.Drawing.Point(13, 175);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(380, 23);
            this.linkLabel4.TabIndex = 7;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "GitHub - /zekroTJA";
            this.linkLabel4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // btBugReport
            // 
            this.btBugReport.Location = new System.Drawing.Point(25, 212);
            this.btBugReport.Name = "btBugReport";
            this.btBugReport.Size = new System.Drawing.Size(174, 47);
            this.btBugReport.TabIndex = 8;
            this.btBugReport.Text = "Report A Bug?";
            this.btBugReport.UseVisualStyleBackColor = true;
            this.btBugReport.Click += new System.EventHandler(this.btBugReport_Click);
            // 
            // btChangeLogs
            // 
            this.btChangeLogs.Location = new System.Drawing.Point(205, 212);
            this.btChangeLogs.Name = "btChangeLogs";
            this.btChangeLogs.Size = new System.Drawing.Size(174, 47);
            this.btChangeLogs.TabIndex = 9;
            this.btChangeLogs.Text = "Alle Changelogs";
            this.btChangeLogs.UseVisualStyleBackColor = true;
            this.btChangeLogs.Click += new System.EventHandler(this.btChangeLogs_Click);
            // 
            // frmInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 311);
            this.Controls.Add(this.btChangeLogs);
            this.Controls.Add(this.btBugReport);
            this.Controls.Add(this.linkLabel4);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbVersionInfo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmInfo";
            this.Text = "Info";
            this.Load += new System.EventHandler(this.frmInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbVersionInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.Button btBugReport;
        private System.Windows.Forms.Button btChangeLogs;
    }
}