using System;
using System.Windows.Forms;
using System.Diagnostics;
using recTimer.Properties;
using System.Xml;
using System.Xml.Linq;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;

using static recTimer.clsConst;

namespace recTimer
{
    public partial class frmSettings : Form
    {

        public static string recHDD;
        public static string recKey;
        public static string recFolder;
        public static bool updates;
        public static string leftToTextPATH;
        public static string rightToTextPATH;
        public static int timerMarkAfter;
        public static string timerToTextPATH;

        public static Keys KEY_REC, KEY_MARK;

        public static long rightCounter;
        public static long leftCounter;

        globalKeyboardHook hook = new globalKeyboardHook();

        //CHECKS
        public frmSettings()
        {
            InitializeComponent();

            if (Settings.Default["recHDD"].ToString() != "")
                tbRecHDD.Text = Settings.Default["recHDD"].ToString();

            if (Settings.Default["programm1"].ToString() != "")
                tbProgramm1.Text = Settings.Default["programm1"].ToString();

            if (Settings.Default["programm2"].ToString() != "")
                tbProgramm2.Text = Settings.Default["programm2"].ToString();

            if (Settings.Default["programm3"].ToString() != "")
                tbProgramm3.Text = Settings.Default["programm3"].ToString();

            if (Settings.Default["programm4"].ToString() != "")
                tbProgramm4.Text = Settings.Default["programm4"].ToString();

            if (Settings.Default["programm5"].ToString() != "")
                tbProgramm5.Text = Settings.Default["programm5"].ToString();

            if (Convert.ToBoolean(Settings.Default["updates"]))
                cbUpdates.Checked = true;
            else
                cbUpdates.Checked = false;

            if (Convert.ToBoolean(Settings.Default["alternateHook"]))
                cbAlternateHook.Checked = true;
            else
                cbAlternateHook.Checked = false;

            if (Convert.ToBoolean(Settings.Default["alwaysOnTop"]))
                cbAlwaysOnTop.Checked = true;
            else
                cbAlwaysOnTop.Checked = false;

            if (Settings.Default["recFolder"].ToString() != "")
                tbRecFolder.Text = Settings.Default["recFolder"].ToString();

            if (Convert.ToBoolean(Settings.Default["autoSave"]))
                cbAutoSave.Checked = true;
            else
                cbAutoSave.Checked = false;

            if (Settings.Default["timerToTXT"].ToString() != "")
                tbTimerToTXT.Text = Settings.Default["timerToTXT"].ToString();

            if (Settings.Default["leftToTXT"].ToString() != "")
                tbLeftToTXT.Text = Settings.Default["leftToTXT"].ToString();

            if (Settings.Default["rightToTXT"].ToString() != "")
                tbRightToTXT.Text = Settings.Default["rightToTXT"].ToString();

            if (Convert.ToBoolean(Settings.Default["timerToTXTtoggle"]))
                cbTimerToTXT.Checked = true;
            else
                cbTimerToTXT.Checked = false;

            if (Convert.ToBoolean(Settings.Default["leftToTXTtoggle"]))
                cbLeftToTXT.Checked = true;
            else
                cbLeftToTXT.Checked = false;

            if (Convert.ToBoolean(Settings.Default["rightToTXTtoggle"]))
                cbRightToTXT.Checked = true;
            else
                cbRightToTXT.Checked = false;

            if (Convert.ToBoolean(Settings.Default["DEVELOPER"]))
                cbDEVELOPER.Checked = true;
            else
                cbDEVELOPER.Checked = false;

            if (Settings.Default.KEY_REC.ToString() != "None")
                btRecKey.Text = Settings.Default.KEY_REC.ToString();
            else
                btRecKey.Text = "Undefiniert.";

            if (Settings.Default.KEY_MARK.ToString() != "None")
                btMarkKey.Text = Settings.Default.KEY_MARK.ToString();
            else
                btMarkKey.Text = "Undefiniert.";

            cbRecKeySTRG.Checked = Settings.Default.recKeySTRG;
            cbRecKeySHIFT.Checked = Settings.Default.recKeySHIFT;
            cbMarkKeySTRG.Checked = Settings.Default.markKeySTRG;
            cbMarkKeySHIFT.Checked = Settings.Default.markKeySHIFT;

            tbTimer.Value = Convert.ToInt16(Settings.Default["timerMarker"]);
            lbTimerMarker.Text = Convert.ToInt16(Settings.Default["timerMarker"]).ToString() + " Minuten" ;
            timerMarkAfter = Convert.ToInt32(Settings.Default["timerMarker"]);

            timerRefresher.Start();

            //Counter
            lbLeftCounter.Text = Settings.Default["leftCounter"].ToString();
            lbRightCounter.Text = Settings.Default["rightCounter"].ToString();
        }

        //SAVE ALL
        private void saveAll()
        {
            recHDD = tbRecHDD.Text;
            Settings.Default["recHDD"] = tbRecHDD.Text;
            Settings.Default["recFolder"] = tbRecFolder.Text;

            Settings.Default["programm1"] = tbProgramm1.Text;
            Settings.Default["programm2"] = tbProgramm2.Text;
            Settings.Default["programm3"] = tbProgramm3.Text;
            Settings.Default["programm4"] = tbProgramm4.Text;
            Settings.Default["programm5"] = tbProgramm5.Text;

            Settings.Default["recFolder"] = tbRecFolder.Text;

            Settings.Default["timerToTXT"] = tbTimerToTXT.Text;
            Settings.Default["leftToTXT"] = tbLeftToTXT.Text;
            Settings.Default["rightToTXT"] = tbRightToTXT.Text;

            Settings.Default["updates"] = cbUpdates.Checked;
            Settings.Default["autoSave"] = cbAutoSave.Checked;
            Settings.Default["alternateHook"] = cbAlternateHook.Checked;
            Settings.Default["alwaysOnTop"] = cbAlwaysOnTop.Checked;

            Settings.Default["timerToTXTtoggle"] = cbTimerToTXT.Checked;
            Settings.Default["leftToTXTtoggle"] = cbLeftToTXT.Checked;
            Settings.Default["rightToTXTtoggle"] = cbRightToTXT.Checked;

            Settings.Default["timerMarker"] = Convert.ToInt32(tbTimer.Value);
            timerMarkAfter = Convert.ToInt32(Settings.Default["timerMarker"]);

            Settings.Default["DEVELOPER"] = cbDEVELOPER.Checked;

            Settings.Default.KEY_REC = KEY_REC;
            Settings.Default.KEY_MARK = KEY_MARK;

            Settings.Default.recKeySTRG = cbRecKeySTRG.Checked;
            Settings.Default.recKeySHIFT = cbRecKeySHIFT.Checked;
            Settings.Default.markKeySTRG = cbMarkKeySTRG.Checked;
            Settings.Default.markKeySHIFT = cbMarkKeySHIFT.Checked;

            Settings.Default.Save();
        }

        private void cbAutoSave_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btTimerToTXT_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            tbTimerToTXT.Text = folderBrowserDialog1.SelectedPath.ToString();
            timerToTextPATH = folderBrowserDialog1.SelectedPath.ToString();
        }

        private void btLeftToTXT_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            tbLeftToTXT.Text = folderBrowserDialog1.SelectedPath.ToString();
            leftToTextPATH = folderBrowserDialog1.SelectedPath.ToString();
        }

        private void btRightToTXT_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            tbRightToTXT.Text = folderBrowserDialog1.SelectedPath.ToString();
            rightToTextPATH = folderBrowserDialog1.SelectedPath.ToString();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void tbRecHDD_TextChanged(object sender, EventArgs e)
        {
            tbRecHDD.Text = recHDD;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbRecHDD_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveAll();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveAll();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            Console.WriteLine("> SELECTED REC PATH: " + folderBrowserDialog1.SelectedPath);
            tbRecFolder.Text = folderBrowserDialog1.SelectedPath;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2.ShowDialog();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            tbProgramm1.Text = "";
            tbProgramm2.Text = "";
            tbProgramm3.Text = "";
            tbProgramm4.Text = "";
            tbProgramm5.Text = "";
        }

        private void cbAlternateHook_CheckedChanged(object sender, EventArgs e)
        {
            /*
            Form currentform = Application.OpenForms["frmSettings"];
            if (currentform != null && showMessageCheckAlternateHookSetting)
            {
                string message = "Um die Änderung wirksam zu machen ist es erforderlich das Programm neu zu starten!";
                const string caption = "ACHTUNG!";
                var result = MessageBox.Show(message, caption,
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                showMessageCheckAlternateHookSetting = false;
            }
            */

        }

        private void btResetLeft_Click(object sender, EventArgs e)
        {
            leftCounter = 0;
            lbLeftCounter.Text = "0";
            Settings.Default["leftCounter"] = leftCounter;

            StreamWriter Writer = new StreamWriter(Settings.Default["leftToTXT"].ToString() + @"\leftCounter.txt");
            Writer.WriteLine(frmSettings.leftCounter);
            Writer.Close();
        }

        private void btResetRight_Click(object sender, EventArgs e)
        {
            rightCounter = 0;
            lbRightCounter.Text = "0";
            Settings.Default["rightCounter"] = rightCounter;

            StreamWriter Writer = new StreamWriter(Settings.Default["rightToTXT"].ToString() + @"\rightCounter.txt");
            Writer.WriteLine(frmSettings.rightCounter);
            Writer.Close();
        }

        private void lbLeftCounter_Click(object sender, EventArgs e)
        {

        }

        private void tbTimer_Scroll(object sender, EventArgs e)
        {
            lbTimerMarker.Text = Convert.ToInt16(tbTimer.Value).ToString() + " Minuten";
        }

        private void cbMarkKey_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timerRefresher_Tick(object sender, EventArgs e)
        {
            lbLeftCounter.Text = leftCounter.ToString();
            lbRightCounter.Text = rightCounter.ToString();
        }

        private void cbDEVELOPER_CheckedChanged(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["frmSettings"];
            if (cbDEVELOPER.Checked && form != null)
                MessageBox.Show("Dieser Modus ist eigentlich nur für den Entwickler! Durch die Aktivierung startet beim Start die Console mit in der 'sinnlose' Dinge stehen die eh keinen jucken. Kannste also wieder aus machen wenn es dich nervt. :^)");
        }

        private void btRecKey_Click(object sender, EventArgs e)
        {
            btRecKey.Text = "Press a Button...";
            btRecKey.KeyDown += recKey_keyDown;
        }

        private void btMarkKey_Click(object sender, EventArgs e)
        {
            btMarkKey.Text = "Press a Button...";
            btMarkKey.KeyDown += markKey_keyDown;
        }

        private void recKey_keyDown(object sender, KeyEventArgs e)
        {
            btRecKey.Text = e.KeyCode.ToString();
            btRecKey.KeyDown -= recKey_keyDown;
            KEY_REC = e.KeyCode;
        }

        private void markKey_keyDown(object sender, KeyEventArgs e)
        {
            btMarkKey.Text = e.KeyCode.ToString();
            btMarkKey.KeyDown -= markKey_keyDown;
            KEY_MARK = e.KeyCode;
        }
    }
}
