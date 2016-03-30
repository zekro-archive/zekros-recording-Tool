namespace recTimer
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdEinstellungen = new System.Windows.Forms.Button();
            this.cmdSoftwareStarten = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btReset = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbTimerSS = new System.Windows.Forms.Label();
            this.lbTimerMM = new System.Windows.Forms.Label();
            this.lbRecInfo = new System.Windows.Forms.Label();
            this.lbTimerHH = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbSpace = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbDisks = new System.Windows.Forms.ProgressBar();
            this.lbDatenträger1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pbRAMload = new System.Windows.Forms.ProgressBar();
            this.lbRam = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pbCPUload = new System.Windows.Forms.ProgressBar();
            this.lbCpu = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.timerHH = new System.Windows.Forms.Timer(this.components);
            this.timerMM = new System.Windows.Forms.Timer(this.components);
            this.timerSS = new System.Windows.Forms.Timer(this.components);
            this.timerCPU = new System.Windows.Forms.Timer(this.components);
            this.pcCPU = new System.Diagnostics.PerformanceCounter();
            this.pcRAM = new System.Diagnostics.PerformanceCounter();
            this.timerKeyboardHook = new System.Windows.Forms.Timer(this.components);
            this.lbVersion = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcCPU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcRAM)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdEinstellungen);
            this.panel1.Controls.Add(this.cmdSoftwareStarten);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 40);
            this.panel1.TabIndex = 0;
            // 
            // cmdEinstellungen
            // 
            this.cmdEinstellungen.Location = new System.Drawing.Point(165, 6);
            this.cmdEinstellungen.Name = "cmdEinstellungen";
            this.cmdEinstellungen.Size = new System.Drawing.Size(135, 25);
            this.cmdEinstellungen.TabIndex = 1;
            this.cmdEinstellungen.Text = "Einstellungen";
            this.cmdEinstellungen.UseVisualStyleBackColor = true;
            this.cmdEinstellungen.Click += new System.EventHandler(this.cmdEinstellungen_Click);
            // 
            // cmdSoftwareStarten
            // 
            this.cmdSoftwareStarten.Enabled = false;
            this.cmdSoftwareStarten.Location = new System.Drawing.Point(9, 6);
            this.cmdSoftwareStarten.Name = "cmdSoftwareStarten";
            this.cmdSoftwareStarten.Size = new System.Drawing.Size(135, 25);
            this.cmdSoftwareStarten.TabIndex = 0;
            this.cmdSoftwareStarten.Text = "Software starten";
            this.cmdSoftwareStarten.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btReset);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lbTimerSS);
            this.panel2.Controls.Add(this.lbTimerMM);
            this.panel2.Controls.Add(this.lbRecInfo);
            this.panel2.Controls.Add(this.lbTimerHH);
            this.panel2.Location = new System.Drawing.Point(3, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(310, 115);
            this.panel2.TabIndex = 2;
            // 
            // btReset
            // 
            this.btReset.Location = new System.Drawing.Point(101, 86);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(109, 23);
            this.btReset.TabIndex = 6;
            this.btReset.Text = "Reset Timer";
            this.btReset.UseVisualStyleBackColor = true;
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Montserrat", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(185, 33);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 42);
            this.label5.TabIndex = 5;
            this.label5.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Montserrat", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(92, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 42);
            this.label4.TabIndex = 4;
            this.label4.Text = ":";
            // 
            // lbTimerSS
            // 
            this.lbTimerSS.AutoSize = true;
            this.lbTimerSS.Font = new System.Drawing.Font("Montserrat", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimerSS.Location = new System.Drawing.Point(199, 25);
            this.lbTimerSS.Name = "lbTimerSS";
            this.lbTimerSS.Size = new System.Drawing.Size(91, 58);
            this.lbTimerSS.TabIndex = 3;
            this.lbTimerSS.Text = "00";
            // 
            // lbTimerMM
            // 
            this.lbTimerMM.AutoSize = true;
            this.lbTimerMM.Font = new System.Drawing.Font("Montserrat", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimerMM.Location = new System.Drawing.Point(109, 25);
            this.lbTimerMM.Name = "lbTimerMM";
            this.lbTimerMM.Size = new System.Drawing.Size(91, 58);
            this.lbTimerMM.TabIndex = 2;
            this.lbTimerMM.Text = "00";
            // 
            // lbRecInfo
            // 
            this.lbRecInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecInfo.ForeColor = System.Drawing.Color.Red;
            this.lbRecInfo.Location = new System.Drawing.Point(3, 2);
            this.lbRecInfo.Name = "lbRecInfo";
            this.lbRecInfo.Size = new System.Drawing.Size(304, 23);
            this.lbRecInfo.TabIndex = 1;
            this.lbRecInfo.Text = "Aufnahme gestoppt";
            this.lbRecInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTimerHH
            // 
            this.lbTimerHH.AutoSize = true;
            this.lbTimerHH.Font = new System.Drawing.Font("Montserrat", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimerHH.Location = new System.Drawing.Point(12, 25);
            this.lbTimerHH.Name = "lbTimerHH";
            this.lbTimerHH.Size = new System.Drawing.Size(91, 58);
            this.lbTimerHH.TabIndex = 0;
            this.lbTimerHH.Text = "00";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbSpace);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.pbDisks);
            this.panel3.Controls.Add(this.lbDatenträger1);
            this.panel3.Location = new System.Drawing.Point(3, 164);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(307, 67);
            this.panel3.TabIndex = 3;
            // 
            // lbSpace
            // 
            this.lbSpace.AutoSize = true;
            this.lbSpace.Location = new System.Drawing.Point(160, 50);
            this.lbSpace.Name = "lbSpace";
            this.lbSpace.Size = new System.Drawing.Size(13, 13);
            this.lbSpace.TabIndex = 8;
            this.lbSpace.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Frei: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Voll in:";
            // 
            // pbDisks
            // 
            this.pbDisks.Location = new System.Drawing.Point(9, 24);
            this.pbDisks.Name = "pbDisks";
            this.pbDisks.Size = new System.Drawing.Size(291, 23);
            this.pbDisks.TabIndex = 5;
            this.pbDisks.Click += new System.EventHandler(this.pbDisks_Click);
            // 
            // lbDatenträger1
            // 
            this.lbDatenträger1.AutoSize = true;
            this.lbDatenträger1.Location = new System.Drawing.Point(9, 8);
            this.lbDatenträger1.Name = "lbDatenträger1";
            this.lbDatenträger1.Size = new System.Drawing.Size(138, 13);
            this.lbDatenträger1.TabIndex = 4;
            this.lbDatenträger1.Text = "Kein Datenträger gefunden!";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.pbRAMload);
            this.panel5.Controls.Add(this.lbRam);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.pbCPUload);
            this.panel5.Controls.Add(this.lbCpu);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Location = new System.Drawing.Point(3, 237);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(307, 78);
            this.panel5.TabIndex = 9;
            // 
            // pbRAMload
            // 
            this.pbRAMload.Location = new System.Drawing.Point(58, 43);
            this.pbRAMload.Name = "pbRAMload";
            this.pbRAMload.Size = new System.Drawing.Size(181, 20);
            this.pbRAMload.TabIndex = 11;
            // 
            // lbRam
            // 
            this.lbRam.AutoSize = true;
            this.lbRam.Location = new System.Drawing.Point(245, 48);
            this.lbRam.Name = "lbRam";
            this.lbRam.Size = new System.Drawing.Size(24, 13);
            this.lbRam.TabIndex = 10;
            this.lbRam.Text = "0 %";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.TabIndex = 9;
            this.label8.Text = "RAM:";
            // 
            // pbCPUload
            // 
            this.pbCPUload.Location = new System.Drawing.Point(58, 13);
            this.pbCPUload.Name = "pbCPUload";
            this.pbCPUload.Size = new System.Drawing.Size(181, 20);
            this.pbCPUload.TabIndex = 8;
            // 
            // lbCpu
            // 
            this.lbCpu.AutoSize = true;
            this.lbCpu.Location = new System.Drawing.Point(245, 18);
            this.lbCpu.Name = "lbCpu";
            this.lbCpu.Size = new System.Drawing.Size(24, 13);
            this.lbCpu.TabIndex = 7;
            this.lbCpu.Text = "0 %";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "CPU:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(12, 318);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "© 2016 zekro  | ";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(278, 318);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(25, 13);
            this.linkLabel2.TabIndex = 11;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Info";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // timerHH
            // 
            this.timerHH.Interval = 3600000;
            this.timerHH.Tick += new System.EventHandler(this.timerHH_Tick);
            // 
            // timerMM
            // 
            this.timerMM.Interval = 60000;
            this.timerMM.Tick += new System.EventHandler(this.timerMM_Tick);
            // 
            // timerSS
            // 
            this.timerSS.Interval = 1000;
            this.timerSS.Tick += new System.EventHandler(this.timerSS_Tick);
            // 
            // timerCPU
            // 
            this.timerCPU.Interval = 1000;
            this.timerCPU.Tick += new System.EventHandler(this.timerCPU_Tick);
            // 
            // pcCPU
            // 
            this.pcCPU.CategoryName = "Prozessor";
            this.pcCPU.CounterName = "Prozessorzeit (%)";
            this.pcCPU.InstanceName = "_Total";
            // 
            // pcRAM
            // 
            this.pcRAM.CategoryName = "Arbeitsspeicher";
            this.pcRAM.CounterName = "Zugesicherte verwendete Bytes (%)";
            // 
            // timerKeyboardHook
            // 
            this.timerKeyboardHook.Interval = 10;
            this.timerKeyboardHook.Tick += new System.EventHandler(this.timerKeyboardHook_Tick);
            // 
            // lbVersion
            // 
            this.lbVersion.AutoSize = true;
            this.lbVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbVersion.Location = new System.Drawing.Point(95, 318);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(83, 13);
            this.lbVersion.TabIndex = 12;
            this.lbVersion.Text = "© 2016 zekro  | ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 336);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "zekro\'s Recording Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcCPU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcRAM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdEinstellungen;
        private System.Windows.Forms.Button cmdSoftwareStarten;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbTimerHH;
        private System.Windows.Forms.Label lbRecInfo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ProgressBar pbDisks;
        private System.Windows.Forms.Label lbDatenträger1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbTimerSS;
        private System.Windows.Forms.Label lbTimerMM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timerHH;
        private System.Windows.Forms.Timer timerMM;
        private System.Windows.Forms.Timer timerSS;
        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.Label lbCpu;
        private System.Windows.Forms.Timer timerCPU;
        private System.Diagnostics.PerformanceCounter pcCPU;
        private System.Windows.Forms.ProgressBar pbCPUload;
        private System.Diagnostics.PerformanceCounter pcRAM;
        private System.Windows.Forms.ProgressBar pbRAMload;
        private System.Windows.Forms.Label lbRam;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbSpace;
        private System.Windows.Forms.Timer timerKeyboardHook;
        private System.Windows.Forms.Label lbVersion;
    }
}

