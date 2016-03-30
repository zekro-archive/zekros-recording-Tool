using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using recTimer.Properties;


namespace recTimer
{
    public partial class Form1 : Form
    {

        #region vars
        public static string buildVersion = "0.2.0127";

        int tSS = 0;
        int tMM = 0;
        int tHH = 0;
        int numbMarks = 1;
        bool keyWasPressed = false; 
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timerCPU.Start();
            timerKeyboardHook.Start();
            lbVersion.Text = "preAlpha v." + buildVersion + "a";

            if (Convert.ToBoolean(Settings.Default["updates"]))
            {
                clsUpdate.testForUpdate();
            } else
            {
                lbUpdateWarn.Text = "WARNUNG!";
            }
        }

        private void progressBar4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cmdEinstellungen_Click(object sender, EventArgs e)
        {
            Form settings = new frmSettings();
            settings.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btReset_Click(object sender, EventArgs e)
        {
            tSS = 0;
            tMM = 0;
            tHH = 0;
            lbTimerSS.Text = "00";
            lbTimerMM.Text = "00";
            lbTimerHH.Text = "00";
        }

        private void pbDisks_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form info = new frmInfo();
            info.ShowDialog();
        }

        #region timer
        private void timerSS_Tick(object sender, EventArgs e)
        {
            tSS = tSS + 1;
            if (tSS == 60)
            {
                tSS = 0;
            }
            lbTimerSS.Text = tSS.ToString();
        }

        private void timerMM_Tick(object sender, EventArgs e)
        {
            tMM = tMM + 1;
            if (tMM == 60)
            {
                tMM = 0;
            }
            lbTimerMM.Text = tMM.ToString();
        }

        private void timerHH_Tick(object sender, EventArgs e)
        {
            tHH = tHH + 1;
            lbTimerHH.Text = tHH.ToString();
        }

        private void timerCPU_Tick(object sender, EventArgs e)
        {
            int CPUload = Convert.ToInt16(pcCPU.NextValue());
            lbCpu.Text = CPUload.ToString() + " %";
            pbCPUload.Value = CPUload;

            int RAMLoad = Convert.ToInt16(pcRAM.NextValue());
            lbRam.Text = RAMLoad.ToString() + " %";
            pbRAMload.Value = RAMLoad;

            string recHDDload = Settings.Default["recHDD"].ToString();

            lbDatenträger1.ForeColor = Color.Black;
            lbDatenträger1.Text = "Datenträger " + recHDDload + ":";
            DriveInfo[] Drives = DriveInfo.GetDrives();
            foreach (DriveInfo d in Drives)
            {
                if (d.Name == recHDDload + ":\\")
                {
                    var totalUsedSpace = (d.TotalSize - d.TotalFreeSpace) / (1024F * 1024F * 1024F);
                    var totalFreeSpace = d.TotalFreeSpace / (1024F * 1024F * 1024F);
                    var totalSize = d.TotalSize / (1024F * 1024F * 1024F);

                    var partOfSpace = (totalUsedSpace / totalSize) * 100;

                    lbSpace.Text = totalFreeSpace.ToString() + " GB";
                    pbDisks.Value = Convert.ToInt16((totalUsedSpace / totalSize) * 100);
                }
                else
                {
                    lbDatenträger1.ForeColor = Color.Black;
                    lbDatenträger1.Text = "Datenträger " + recHDDload + ":";
                }
            }
        }

        private void timerKeyboardHook_Tick(object sender, EventArgs e)
        {
            recKeyHook();
            markKeyHook();
        }
        #endregion

        private void recKeyHook()
        {
            globalKeyboardHook hook = new globalKeyboardHook();
            string recKeyload = Settings.Default["recKey"].ToString();

            #region IfHellOfDOOM
            if (recKeyload == "F1")
            {
                hook.HookedKeys.Add(Keys.F1);
            }
            else if (recKeyload == "F2")
            {
                hook.HookedKeys.Add(Keys.F2);
            }
            else if (recKeyload == "F3")
            {
                hook.HookedKeys.Add(Keys.F3);
            }
            else if (recKeyload == "F4")
            {
                hook.HookedKeys.Add(Keys.F4);
            }
            else if (recKeyload == "F5")
            {
                hook.HookedKeys.Add(Keys.F5);
            }
            else if (recKeyload == "F6")
            {
                hook.HookedKeys.Add(Keys.F6);
            }
            else if (recKeyload == "F7")
            {
                hook.HookedKeys.Add(Keys.F7);
            }
            else if (recKeyload == "F8")
            {
                hook.HookedKeys.Add(Keys.F8);
            }
            else if (recKeyload == "F9")
            {
                hook.HookedKeys.Add(Keys.F9);
            }
            else if (recKeyload == "F10")
            {
                hook.HookedKeys.Add(Keys.F10);
            }
            else if (recKeyload == "F11")
            {
                hook.HookedKeys.Add(Keys.F11);
            }
            else if (recKeyload == "F12")
            {
                hook.HookedKeys.Add(Keys.F12);
            }

            else if (recKeyload == "A")
            {
                hook.HookedKeys.Add(Keys.A);
            }
            else if (recKeyload == "B")
            {
                hook.HookedKeys.Add(Keys.B);
            }
            else if (recKeyload == "C")
            {
                hook.HookedKeys.Add(Keys.Z);
            }
            else if (recKeyload == "D")
            {
                hook.HookedKeys.Add(Keys.D);
            }
            else if (recKeyload == "E")
            {
                hook.HookedKeys.Add(Keys.E);
            }
            else if (recKeyload == "F")
            {
                hook.HookedKeys.Add(Keys.F);
            }
            else if (recKeyload == "G")
            {
                hook.HookedKeys.Add(Keys.G);
            }
            else if (recKeyload == "H")
            {
                hook.HookedKeys.Add(Keys.H);
            }
            else if (recKeyload == "I")
            {
                hook.HookedKeys.Add(Keys.I);
            }
            else if (recKeyload == "J")
            {
                hook.HookedKeys.Add(Keys.J);
            }
            else if (recKeyload == "K")
            {
                hook.HookedKeys.Add(Keys.K);
            }
            else if (recKeyload == "L")
            {
                hook.HookedKeys.Add(Keys.L);
            }
            else if (recKeyload == "M")
            {
                hook.HookedKeys.Add(Keys.M);
            }
            else if (recKeyload == "N")
            {
                hook.HookedKeys.Add(Keys.N);
            }
            else if (recKeyload == "O")
            {
                hook.HookedKeys.Add(Keys.O);
            }
            else if (recKeyload == "P")
            {
                hook.HookedKeys.Add(Keys.P);
            }
            else if (recKeyload == "Q")
            {
                hook.HookedKeys.Add(Keys.Q);
            }
            else if (recKeyload == "R")
            {
                hook.HookedKeys.Add(Keys.R);
            }
            else if (recKeyload == "S")
            {
                hook.HookedKeys.Add(Keys.S);
            }
            else if (recKeyload == "T")
            {
                hook.HookedKeys.Add(Keys.T);
            }
            else if (recKeyload == "U")
            {
                hook.HookedKeys.Add(Keys.U);
            }
            else if (recKeyload == "V")
            {
                hook.HookedKeys.Add(Keys.V);
            }
            else if (recKeyload == "W")
            {
                hook.HookedKeys.Add(Keys.W);
            }
            else if (recKeyload == "X")
            {
                hook.HookedKeys.Add(Keys.X);
            }
            else if (recKeyload == "Y")
            {
                hook.HookedKeys.Add(Keys.Y);
            }
            else if (recKeyload == "Z")
            {
                hook.HookedKeys.Add(Keys.C);
            }

            else if (recKeyload == "NumPad1")
            {
                hook.HookedKeys.Add(Keys.NumPad1);
            }
            else if (recKeyload == "NumPad2")
            {
                hook.HookedKeys.Add(Keys.NumPad2);
            }
            else if (recKeyload == "NumPad3")
            {
                hook.HookedKeys.Add(Keys.NumPad3);
            }
            else if (recKeyload == "NumPad4")
            {
                hook.HookedKeys.Add(Keys.NumPad4);
            }
            else if (recKeyload == "NumPad5")
            {
                hook.HookedKeys.Add(Keys.NumPad5);
            }
            else if (recKeyload == "NumPad6")
            {
                hook.HookedKeys.Add(Keys.NumPad6);
            }
            else if (recKeyload == "NumPad7")
            {
                hook.HookedKeys.Add(Keys.NumPad7);
            }
            else if (recKeyload == "NumPad18")
            {
                hook.HookedKeys.Add(Keys.NumPad8);
            }
            else if (recKeyload == "NumPad9")
            {
                hook.HookedKeys.Add(Keys.NumPad9);
            }
            else if (recKeyload == "NumPad0")
            {
                hook.HookedKeys.Add(Keys.NumPad0);
            }

            else if (recKeyload == "Add")
            {
                hook.HookedKeys.Add(Keys.Add);
            }
            else if (recKeyload == "Substract")
            {
                hook.HookedKeys.Add(Keys.Subtract);
            }
            else if (recKeyload == "Multiply")
            {
                hook.HookedKeys.Add(Keys.Multiply);
            }

            else
            {
                hook.HookedKeys.Add(Keys.F4);
            }
            #endregion

            hook.KeyUp += new KeyEventHandler(hook_keyUp);
        }

        private void markKeyHook()
        {
            globalKeyboardHook hook = new globalKeyboardHook();
            string recKeyload = Settings.Default["markKey"].ToString();

            #region IfHellOfDOOM
            if (recKeyload == "F1")
            {
                hook.HookedKeys.Add(Keys.F1);
            }
            else if (recKeyload == "F2")
            {
                hook.HookedKeys.Add(Keys.F2);
            }
            else if (recKeyload == "F3")
            {
                hook.HookedKeys.Add(Keys.F3);
            }
            else if (recKeyload == "F4")
            {
                hook.HookedKeys.Add(Keys.F4);
            }
            else if (recKeyload == "F5")
            {
                hook.HookedKeys.Add(Keys.F5);
            }
            else if (recKeyload == "F6")
            {
                hook.HookedKeys.Add(Keys.F6);
            }
            else if (recKeyload == "F7")
            {
                hook.HookedKeys.Add(Keys.F7);
            }
            else if (recKeyload == "F8")
            {
                hook.HookedKeys.Add(Keys.F8);
            }
            else if (recKeyload == "F9")
            {
                hook.HookedKeys.Add(Keys.F9);
            }
            else if (recKeyload == "F10")
            {
                hook.HookedKeys.Add(Keys.F10);
            }
            else if (recKeyload == "F11")
            {
                hook.HookedKeys.Add(Keys.F11);
            }
            else if (recKeyload == "F12")
            {
                hook.HookedKeys.Add(Keys.F12);
            }

            else if (recKeyload == "A")
            {
                hook.HookedKeys.Add(Keys.A);
            }
            else if (recKeyload == "B")
            {
                hook.HookedKeys.Add(Keys.B);
            }
            else if (recKeyload == "C")
            {
                hook.HookedKeys.Add(Keys.Z);
            }
            else if (recKeyload == "D")
            {
                hook.HookedKeys.Add(Keys.D);
            }
            else if (recKeyload == "E")
            {
                hook.HookedKeys.Add(Keys.E);
            }
            else if (recKeyload == "F")
            {
                hook.HookedKeys.Add(Keys.F);
            }
            else if (recKeyload == "G")
            {
                hook.HookedKeys.Add(Keys.G);
            }
            else if (recKeyload == "H")
            {
                hook.HookedKeys.Add(Keys.H);
            }
            else if (recKeyload == "I")
            {
                hook.HookedKeys.Add(Keys.I);
            }
            else if (recKeyload == "J")
            {
                hook.HookedKeys.Add(Keys.J);
            }
            else if (recKeyload == "K")
            {
                hook.HookedKeys.Add(Keys.K);
            }
            else if (recKeyload == "L")
            {
                hook.HookedKeys.Add(Keys.L);
            }
            else if (recKeyload == "M")
            {
                hook.HookedKeys.Add(Keys.M);
            }
            else if (recKeyload == "N")
            {
                hook.HookedKeys.Add(Keys.N);
            }
            else if (recKeyload == "O")
            {
                hook.HookedKeys.Add(Keys.O);
            }
            else if (recKeyload == "P")
            {
                hook.HookedKeys.Add(Keys.P);
            }
            else if (recKeyload == "Q")
            {
                hook.HookedKeys.Add(Keys.Q);
            }
            else if (recKeyload == "R")
            {
                hook.HookedKeys.Add(Keys.R);
            }
            else if (recKeyload == "S")
            {
                hook.HookedKeys.Add(Keys.S);
            }
            else if (recKeyload == "T")
            {
                hook.HookedKeys.Add(Keys.T);
            }
            else if (recKeyload == "U")
            {
                hook.HookedKeys.Add(Keys.U);
            }
            else if (recKeyload == "V")
            {
                hook.HookedKeys.Add(Keys.V);
            }
            else if (recKeyload == "W")
            {
                hook.HookedKeys.Add(Keys.W);
            }
            else if (recKeyload == "X")
            {
                hook.HookedKeys.Add(Keys.X);
            }
            else if (recKeyload == "Y")
            {
                hook.HookedKeys.Add(Keys.Y);
            }
            else if (recKeyload == "Z")
            {
                hook.HookedKeys.Add(Keys.C);
            }

            else if (recKeyload == "NumPad1")
            {
                hook.HookedKeys.Add(Keys.NumPad1);
            }
            else if (recKeyload == "NumPad2")
            {
                hook.HookedKeys.Add(Keys.NumPad2);
            }
            else if (recKeyload == "NumPad3")
            {
                hook.HookedKeys.Add(Keys.NumPad3);
            }
            else if (recKeyload == "NumPad4")
            {
                hook.HookedKeys.Add(Keys.NumPad4);
            }
            else if (recKeyload == "NumPad5")
            {
                hook.HookedKeys.Add(Keys.NumPad5);
            }
            else if (recKeyload == "NumPad6")
            {
                hook.HookedKeys.Add(Keys.NumPad6);
            }
            else if (recKeyload == "NumPad7")
            {
                hook.HookedKeys.Add(Keys.NumPad7);
            }
            else if (recKeyload == "NumPad18")
            {
                hook.HookedKeys.Add(Keys.NumPad8);
            }
            else if (recKeyload == "NumPad9")
            {
                hook.HookedKeys.Add(Keys.NumPad9);
            }
            else if (recKeyload == "NumPad0")
            {
                hook.HookedKeys.Add(Keys.NumPad0);
            }

            else if (recKeyload == "Add")
            {
                hook.HookedKeys.Add(Keys.Add);
            }
            else if (recKeyload == "Substract")
            {
                hook.HookedKeys.Add(Keys.Subtract);
            }
            else if (recKeyload == "Multiply")
            {
                hook.HookedKeys.Add(Keys.Multiply);
            }

            else
            {
                hook.HookedKeys.Add(Keys.F4);
            }
            #endregion

            hook.KeyUp += new KeyEventHandler(hook_keyUpMark);
        }

        //HOOK KEYDOWN EVENT RECORDING
        private void hook_keyUp(object sender, KeyEventArgs e)
        {
            if (keyWasPressed)
            {
                keyWasPressed = false;
                lbRecInfo.Text = "Aufnahme gestoppt.";
                lbRecInfo.ForeColor = Color.Red;

                timerHH.Stop();
                timerMM.Stop();
                timerSS.Stop();
            }
            else
            {
                timerHH.Start();
                timerMM.Start();
                timerSS.Start();

                lbRecInfo.Text = "Aufnahme läuft.";
                lbRecInfo.ForeColor = Color.Green;
                keyWasPressed = true;
            }

            e.Handled = true;
        }

        //HOOK KEYDOWN EVENT MARKING
        private void hook_keyUpMark(object sender, KeyEventArgs e)
        {
            listMarker.Items.Add(numbMarks + " - " + lbTimerHH.Text + ":" + lbTimerMM.Text + ":" + lbTimerSS.Text);
            numbMarks++;

            e.Handled = true;
        }

        private void btResetMarks_Click(object sender, EventArgs e)
        {
            listMarker.Items.Clear();
            numbMarks = 1;
        }

        private void btSaveMarks_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();

            StreamWriter Writer = new StreamWriter(folderBrowserDialog1.SelectedPath + @"\saved_marks.txt");

            foreach(var item in listMarker.Items)
            {
                Writer.WriteLine(item.ToString());
            }
            Writer.Close();

            MessageBox.Show("Datei gespeichert!");
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
        }

        private void cmdSoftwareStarten_Click(object sender, EventArgs e)
        {
            if (Settings.Default["programm1"].ToString() != "")
            {
                Process.Start(Settings.Default["programm1"].ToString());
            }
            if (Settings.Default["programm2"].ToString() != "")
            {
                Process.Start(Settings.Default["programm2"].ToString());
            }
            if (Settings.Default["programm3"].ToString() != "")
            {
                Process.Start(Settings.Default["programm3"].ToString());
            }
            if (Settings.Default["programm4"].ToString() != "")
            {
                Process.Start(Settings.Default["programm4"].ToString());
            }
            if (Settings.Default["programm5"].ToString() != "")
            {
                Process.Start(Settings.Default["programm5"].ToString());
            }
        }

        private void lbUpdateWarn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("ACHTUNG! Die Benachichtigung für Updates ist deaktiviert! Wenn sie dies ändern wollen gehen sie in die Einstellungen und aktivieren sie die Update-Benachichtigung!");
            lbUpdateWarn.Text = "";
        }
    }
}
