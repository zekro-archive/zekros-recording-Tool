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
using System.Threading;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Linq;
using System.Net;

using static recTimer.clsConst;

namespace recTimer
{
    public partial class Form1 : Form
    {

        #region vars
        int tSS = 0, tMM = 0, tHH = 0;
        public static int globalSS = 0;
        public static int numbMarks = 1;
        bool keyWasPressed = false;

        public static string dlBytes, dlTotalBytes, dlProgress;

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern uint SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        globalKeyboardHook hook = new globalKeyboardHook();

        const int MOD_CONTROL = 0x0002;
        const int MOD_SHIFT = 0x0004;
        const int WM_HOTKEY = 0x0312;

        int markerAfterTime;
        #endregion

        public Form1()
        {
            InitializeComponent();

            clsMouseHookLEFT.Start();
            clsMouseHookLEFT.MouseAction += new EventHandler(EventMouseLEFT);
            clsMouseHookRIGHT.Start();
            clsMouseHookRIGHT.MouseAction += new EventHandler(EventMouseRIGHT);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DEVELOPERMODE();
            ShowToolTip();

            //Settings.Default["BUILDCOUNTER"] = 565;

            frmSettings.timerToTextPATH = Settings.Default["timerToTXT"].ToString();

            timerKeyboardHook.Start();
            timerCPU.Start();
            timerAutoSave.Start();
            lbVersion.Text = "Beta v." + buildVersion;

            //Wenn Updatenotification aktiviert ist wird der Updatetestausgeführt, sonst Warnung.
            if ((bool)Settings.Default["updates"])
                clsUpdate.testForUpdate();
            else
                if (clsUpdate.getUpdateStatus())
                    lbUpdateWarn.Text = "UPDATE";

            buildCounter();

            //COUNTERS
            frmSettings.leftCounter = Convert.ToInt64(Settings.Default["leftCounter"]);
            frmSettings.rightCounter = Convert.ToInt64(Settings.Default["rightCounter"]);

        }

        //Alternative Hotkey Hook
        protected override void WndProc(ref Message m)
        {

            if ((bool)Settings.Default["alternateHook"])
            {

                if (m.Msg == WM_HOTKEY && (int)m.WParam == 1)
                {
                    hookAlt_keyUp();
                }
                if (m.Msg == WM_HOTKEY && (int)m.WParam == 2)
                {
                    hookAlt_keyUpMark();
                }
                base.WndProc(ref m);

            } else
            {
                base.WndProc(ref m);
            }

        }

        private void cmdEinstellungen_Click(object sender, EventArgs e)
        {
            Form settings = new frmSettings();
            settings.ShowDialog();
        }

        //Timer Reset bei Aktivieren des Buttons
        private void btReset_Click(object sender, EventArgs e)
        {
            tSS = 0;
            tMM = 0;
            tHH = 0;
            lbTimerSS.Text = "00";
            lbTimerMM.Text = "00";
            lbTimerHH.Text = "00";
            globalSS = 0;

            timerColorBlack();
        }

        //Offen der Infopage bei aktivieren des "Info"-Linklables
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form info = new frmInfo();
            info.ShowDialog();
        }

        #region timer
        //Timer für Timer Sekunden
        private void timerSS_Tick(object sender, EventArgs e)
        {
            tSS++;
            if (tSS == 60)
            {
                tSS = 0;
                tMM++;
            }

            if (tSS < 10)
                lbTimerSS.Text = "0" + tSS.ToString();
            else
                lbTimerSS.Text = tSS.ToString();

            if (tMM < 10)
                lbTimerMM.Text = "0" + tMM.ToString();
            else
                lbTimerMM.Text = tMM.ToString();

            if (tHH < 10)
                lbTimerHH.Text = "0" + tHH.ToString();
            else
                lbTimerHH.Text = tHH.ToString();

            if ((bool)Settings.Default["timerToTXTtoggle"])
                timerToTXT();

            markerAfterTime = Convert.ToInt32(Settings.Default["timerMarker"]);
            if (tMM == markerAfterTime
                || tMM / 2 == markerAfterTime
                || tMM / 3 == markerAfterTime
                || tMM / 4 == markerAfterTime
                || tMM / 5 == markerAfterTime
                || tMM / 6 == markerAfterTime)
            {
                lbTimerHH.ForeColor = Color.Red;
                lbTimerMM.ForeColor = Color.Red;
                lbTimerSS.ForeColor = Color.Red;
            }

            hddWritingValue();

            globalSS++;
        }
        /*
        //Timer für Timer Minuten
        private void timerMM_Tick(object sender, EventArgs e)
        {
            tMM = tMM + 1;
            if (tMM == 60)
            {
                tMM = 0;
            }

            if (tMM < 10)
            {
                lbTimerMM.Text = "0" + tMM.ToString();
            }
            else
            {
                lbTimerMM.Text = tMM.ToString();
            }

            if (tMM == frmSettings.timerMarkAfter
                || tMM / 2 == frmSettings.timerMarkAfter
                || tMM / 3 == frmSettings.timerMarkAfter
                || tMM / 4 == frmSettings.timerMarkAfter
                || tMM / 5 == frmSettings.timerMarkAfter
                || tMM / 6 == frmSettings.timerMarkAfter)
            {
                lbTimerHH.ForeColor = Color.Red;
                lbTimerMM.ForeColor = Color.Red;
                lbTimerSS.ForeColor = Color.Red;
            }

        }
        //Timer für Timer Stunden
        private void timerHH_Tick(object sender, EventArgs e)
        {
            tHH = tHH + 1;

            if (tHH < 10)
            {
                lbTimerHH.Text = "0" + tHH.ToString();
            }
            else
            {
                lbTimerHH.Text = tHH.ToString();
            }

        }
        */

        /// <summary>
        /// Timer für Aktualisierug und Anzeige der PC-Stats.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            if ((bool)Settings.Default["alwaysOnTop"])
            {
                if (TopMost == false)
                {
                    TopMost = true;
                }
            }
            else
            {
                if (TopMost == true)
                {
                    TopMost = false;
                }
            }
        }

        /// <summary>
        /// Timer und aktualisierung der Regestrierung des eingestellten Keyboard-Hotkeys und der Keyboard Hook.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerKeyboardHook_Tick(object sender, EventArgs e)
        {
            if ((bool)Settings.Default["alternateHook"])
            {
                recAltKeyHook();
                markAltKeyHook();
            }
            else {
                //timerKeyboardHook.Start();
                recKeyHook();
                markKeyHook();
            }




            
        }

        private void timerAutoSave_Tick(object sender, EventArgs e)
        {
            if ((bool)Settings.Default["autoSave"])
            {
                StreamWriter Writer = new StreamWriter(@"[AUTOSAVE] saved_marks.txt");

                foreach (var item in listMarker.Items)
                {
                    Writer.WriteLine(item.ToString());
                }
                Writer.Close();

                Console.WriteLine("AUTOSAVED MARKERS.");
            }
        }
        #endregion

        /// <summary>
        /// Bei Aktivierung des Hotkeys für Timer.
        /// [Für die standart Keyboard Hook]
        /// </summary>
        private void recAltKeyHook()
        {
            string recKeyload = Settings.Default["recKey"].ToString();

            #region IfHellOfDOOM

            if (recKeyload == "F1")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.F1);
            }
            else if (recKeyload == "F2")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.F2);
            }
            else if (recKeyload == "F3")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.F3);
            }
            else if (recKeyload == "F4")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.F4);
            }
            else if (recKeyload == "F5")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.F5);
            }
            else if (recKeyload == "F6")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.F6);
            }
            else if (recKeyload == "F7")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.F7);
            }
            else if (recKeyload == "F8")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.F8);
            }
            else if (recKeyload == "F9")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.F9);
            }
            else if (recKeyload == "F10")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.F10);
            }
            else if (recKeyload == "F11")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.F11);
            }
            else if (recKeyload == "F12")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.F12);
            }

            else if (recKeyload == "A")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.A);
            }
            else if (recKeyload == "B")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.B);
            }
            else if (recKeyload == "C")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.Z);
            }
            else if (recKeyload == "D")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.D);
            }
            else if (recKeyload == "E")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.E);
            }
            else if (recKeyload == "F")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.F);
            }
            else if (recKeyload == "G")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.G);
            }
            else if (recKeyload == "H")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.H);
            }
            else if (recKeyload == "I")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.I);
            }
            else if (recKeyload == "J")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.J);
            }
            else if (recKeyload == "K")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.K);
            }
            else if (recKeyload == "L")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.L);
            }
            else if (recKeyload == "M")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.M);
            }
            else if (recKeyload == "N")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.N);
            }
            else if (recKeyload == "O")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.O);
            }
            else if (recKeyload == "P")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.P);
            }
            else if (recKeyload == "Q")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.Q);
            }
            else if (recKeyload == "R")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.R);
            }
            else if (recKeyload == "S")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.S);
            }
            else if (recKeyload == "T")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.T);
            }
            else if (recKeyload == "U")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.U);
            }
            else if (recKeyload == "V")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.V);
            }
            else if (recKeyload == "W")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.W);
            }
            else if (recKeyload == "X")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.X);
            }
            else if (recKeyload == "Y")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.Y);
            }
            else if (recKeyload == "Z")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.C);
            }

            else if (recKeyload == "NumPad1")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.NumPad1);
            }
            else if (recKeyload == "NumPad2")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.NumPad2);
            }
            else if (recKeyload == "NumPad3")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.NumPad3);
            }
            else if (recKeyload == "NumPad4")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.NumPad4);
            }
            else if (recKeyload == "NumPad5")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.NumPad5);
            }
            else if (recKeyload == "NumPad6")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.NumPad6);
            }
            else if (recKeyload == "NumPad7")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.NumPad7);
            }
            else if (recKeyload == "NumPad18")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.NumPad8);
            }
            else if (recKeyload == "NumPad9")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.NumPad9);
            }
            else if (recKeyload == "NumPad0")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.NumPad0);
            }

            else if (recKeyload == "Add")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.Add);
            }
            else if (recKeyload == "Substract")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.Subtract);
            }
            else if (recKeyload == "Multiply")
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.Multiply);
            }

            else
            {
                RegisterHotKey(this.Handle, 1, MOD_CONTROL, (int)Keys.F4);
            }
            #endregion
        }

        /// <summary>
        /// Bei Aktivierung des Hotkeys für Timer.
        /// [Für die alternative Keyboard Hook]
        /// </summary>
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

        /// <summary>
        /// Bei Aktivierung des Hotkeys für Marker setzten.
        /// [Für die standart Keyboard Hook]
        /// </summary>
        private void markAltKeyHook()
        {
            string recKeyload = Settings.Default["markKey"].ToString();

            #region IfHellOfDOOM_2

            if (recKeyload == "F1")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.F1);
            }
            else if (recKeyload == "F2")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.F2);
            }
            else if (recKeyload == "F3")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.F3);
            }
            else if (recKeyload == "F4")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.F4);
            }
            else if (recKeyload == "F5")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.F5);
            }
            else if (recKeyload == "F6")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.F6);
            }
            else if (recKeyload == "F7")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.F7);
            }
            else if (recKeyload == "F8")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.F8);
            }
            else if (recKeyload == "F9")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.F9);
            }
            else if (recKeyload == "F10")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.F10);
            }
            else if (recKeyload == "F11")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.F11);
            }
            else if (recKeyload == "F12")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.F12);
            }

            else if (recKeyload == "A")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.A);
            }
            else if (recKeyload == "B")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.B);
            }
            else if (recKeyload == "C")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.Z);
            }
            else if (recKeyload == "D")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.D);
            }
            else if (recKeyload == "E")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.E);
            }
            else if (recKeyload == "F")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.F);
            }
            else if (recKeyload == "G")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.G);
            }
            else if (recKeyload == "H")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.H);
            }
            else if (recKeyload == "I")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.I);
            }
            else if (recKeyload == "J")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.J);
            }
            else if (recKeyload == "K")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.K);
            }
            else if (recKeyload == "L")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.L);
            }
            else if (recKeyload == "M")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.M);
            }
            else if (recKeyload == "N")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.N);
            }
            else if (recKeyload == "O")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.O);
            }
            else if (recKeyload == "P")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.P);
            }
            else if (recKeyload == "Q")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.Q);
            }
            else if (recKeyload == "R")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.R);
            }
            else if (recKeyload == "S")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.S);
            }
            else if (recKeyload == "T")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.T);
            }
            else if (recKeyload == "U")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.U);
            }
            else if (recKeyload == "V")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.V);
            }
            else if (recKeyload == "W")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.W);
            }
            else if (recKeyload == "X")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.X);
            }
            else if (recKeyload == "Y")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.Y);
            }
            else if (recKeyload == "Z")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.C);
            }

            else if (recKeyload == "NumPad1")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.NumPad1);
            }
            else if (recKeyload == "NumPad2")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.NumPad2);
            }
            else if (recKeyload == "NumPad3")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.NumPad3);
            }
            else if (recKeyload == "NumPad4")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.NumPad4);
            }
            else if (recKeyload == "NumPad5")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.NumPad5);
            }
            else if (recKeyload == "NumPad6")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.NumPad6);
            }
            else if (recKeyload == "NumPad7")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.NumPad7);
            }
            else if (recKeyload == "NumPad18")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.NumPad8);
            }
            else if (recKeyload == "NumPad9")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.NumPad9);
            }
            else if (recKeyload == "NumPad0")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.NumPad0);
            }

            else if (recKeyload == "Add")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.Add);
            }
            else if (recKeyload == "Substract")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.Subtract);
            }
            else if (recKeyload == "Multiply")
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.Multiply);
            }

            else
            {
                RegisterHotKey(this.Handle, 2, MOD_CONTROL, (int)Keys.F4);
            }
            #endregion
        }

        /// <summary>
        /// Bei Aktivierung des Hotkeys für Marker setzten.
        /// [Für die alternative Keyboard Hook]
        /// </summary>
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

        /// <summary>
        /// HOOK KEYDOWN EVENT RECORDING
        /// [STANDART KEY HOOK]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hook_keyUp(object sender, KeyEventArgs e)
        {
            if (keyWasPressed)
            {
                keyWasPressed = false;
                lbRecInfo.Text = "Aufnahme gestoppt.";
                lbRecInfo.ForeColor = Color.Red;

                timerSS.Stop();
            }
            else
            {

                timerSS.Start();

                lbRecInfo.Text = "Aufnahme läuft.";
                lbRecInfo.ForeColor = Color.Green;
                keyWasPressed = true;
            }

            e.Handled = true;
        }

        /// <summary>
        /// HOOK KEYDOWN EVENT RECORDING
        /// [ALTERNATIVE KEY HOOK]
        /// </summary>
        private void hookAlt_keyUp()
        {
            if (keyWasPressed)
            {
                keyWasPressed = false;
                lbRecInfo.Text = "Aufnahme gestoppt.";
                lbRecInfo.ForeColor = Color.Red;

                timerSS.Stop();
            }
            else
            {

                timerSS.Start();

                lbRecInfo.Text = "Aufnahme läuft.";
                lbRecInfo.ForeColor = Color.Green;
                keyWasPressed = true;
            }
        }

        /// <summary>
        /// HOOK KEYDOWN EVENT MARKING
        /// [STANDART KEY HOOK]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hook_keyUpMark(object sender, KeyEventArgs e)
        {
            listMarker.Items.Add(numbMarks + " - " + lbTimerHH.Text + ":" + lbTimerMM.Text + ":" + lbTimerSS.Text);
            numbMarks++;

            lbGlobalSS.Items.Add(globalSS);

            timerColorBlack();

            e.Handled = true;
        }

        /// <summary>
        /// HOOK KEYDOWN EVENT MARKING
        /// [ALTERNATE KEY HOOK]
        /// </summary>
        private void hookAlt_keyUpMark()
        {
            listMarker.Items.Add(numbMarks + " - " + lbTimerHH.Text + ":" + lbTimerMM.Text + ":" + lbTimerSS.Text);
            numbMarks++;

            
            lbGlobalSS.Items.Add(globalSS);

            timerColorBlack();
        }

        private void btResetMarks_Click(object sender, EventArgs e)
        {
            listMarker.Items.Clear();
            numbMarks = 1;
            lbGlobalSS.Items.Clear();
        }

        private void btPrPro_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (Settings.Default["inputPath"].ToString() == "" || Settings.Default["outputPath"].ToString() == "" || Settings.Default["FPS"].ToString() == "")
                {
                    MessageBox.Show("Bitte tätigen sie erst die Einstellungen zu dieser Funktion [Durchsuchen...] um fortfahren zu können!");
                }
                else
                {
                    xmlInjector(Settings.Default["inputPath"].ToString(), Settings.Default["outputPath"].ToString(), Convert.ToInt16(Settings.Default["FPS"]));
                }
                
            }
            catch (Exception ex)
            {
                customExcBox("Es ist ein kritischer Fehler beim lesen der XML-Datei bzw. beim extrahieren der Daten aufgetreten.\r\nBitte überprüfen sie ihre Einstellungen und versuchen sie es erneut!\r\n\r\nFalls ein Bug vorliegt, bitte folgende Exception in den Report einbetten!", "Kritischer Ferhler", ex);
                //throw;
            }

            
        }

        private void cmdRecFolder_Click(object sender, EventArgs e)
        {
            string rf = Settings.Default["recFolder"].ToString();

            if (Directory.Exists(rf))
            {
                Process.Start("explorer.exe", rf);
            }
            else
                MessageBox.Show("Der eingestellte Aufnahmepfad existiert nicht oder es wurde noch kein Aufnahmepfad eingestellt!");
        }

        private void btSaveMarks_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();

            StreamWriter Writer = new StreamWriter(folderBrowserDialog1.SelectedPath + @"\saved_marks.txt");

            foreach (var item in listMarker.Items)
            {
                Writer.WriteLine(item.ToString());
            }
            Writer.Close();

            MessageBox.Show("Datei gespeichert!");
        }

        private void cmdSoftwareStarten_Click(object sender, EventArgs e)
        {
            if (Settings.Default["programm1"].ToString() != ""
                && Settings.Default["programm2"].ToString() != ""
                && Settings.Default["programm3"].ToString() != ""
                && Settings.Default["programm4"].ToString() != ""
                && Settings.Default["programm5"].ToString() != "")
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
            else
                MessageBox.Show("Es wurde keine Aufnahmeprogramme eingestellt!");

            
        }

        private void lbUpdateWarn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsUpdate.testForUpdate();

            /*
            MessageBox.Show("ACHTUNG! Die Benachichtigung für Updates ist deaktiviert! Wenn sie dies ändern wollen gehen sie in die Einstellungen und aktivieren sie die Update-Benachichtigung!");
            lbUpdateWarn.Text = "";
            */
        }

        private void timerColorBlack()
        {
            lbTimerHH.ForeColor = Color.Black;
            lbTimerMM.ForeColor = Color.Black;
            lbTimerSS.ForeColor = Color.Black;
        }

        private void DEVELOPERMODE()
        {
            if ((bool)Settings.Default["DEVELOPER"])
            {
                AllocConsole();
                Console.WriteLine("DEVELOPERMODE ACTIVATED");
            }
        }

        private void buildCounter()
        {
            int BUILDCOUNTER = Convert.ToInt32(Settings.Default["BUILDCOUNTER"]);
            BUILDCOUNTER++;
            Console.WriteLine("BUILD #" + BUILDCOUNTER);
            Settings.Default["BUILDCOUNTER"] = BUILDCOUNTER;

            Settings.Default.Save();
        }

        private void ShowToolTip()
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.btReset, "Resetet den Timer.");
            toolTip1.SetToolTip(this.cmdEinstellungen, "RÖffnet die Einstellungen.");
            toolTip1.SetToolTip(this.cmdSoftwareStarten, "Öffnet die eingestellte Software mit nur eimen Klick! ;D");
            toolTip1.SetToolTip(this.cmdRecFolder, "Öffnet den eingestellten Aufnahmeordner.");
        }

        private void timerToTXT()
        {
            string HH, MM, SS;

            if (tSS < 10)
                SS = "0" + tSS.ToString();
            else
                SS = tSS.ToString();

            if (tMM < 10)
                MM = "0" + tMM.ToString();
            else
                MM = tMM.ToString();

            if (tHH < 10)
                HH = "0" + tHH.ToString();
            else
                HH = tHH.ToString();

            if (frmSettings.timerToTextPATH != "")
            {
                StreamWriter Writer = new StreamWriter(frmSettings.timerToTextPATH + @"\timer.txt");
                Writer.WriteLine(HH + ":" + MM + ":" + SS);
                Writer.Close();
            }            
        }

        private void EventMouseLEFT(object sender, EventArgs e)
        {
            //Console.WriteLine("> REGISTERED: Left Mouse Button");
            frmSettings.leftCounter++;
            Settings.Default["leftCounter"] = frmSettings.leftCounter;
            Settings.Default.Save();

            if ((bool)Settings.Default["rightToTXTtoggle"])
            {
                StreamWriter Writer = new StreamWriter(Settings.Default["leftToTXT"].ToString() + @"\leftCounter.txt");
                Writer.WriteLine(frmSettings.leftCounter);
                Writer.Close();
            }
        }

        private void EventMouseRIGHT(object sender, EventArgs e)
        {
            //Console.WriteLine("> REGISTERED: Right Mouse Button");
            frmSettings.rightCounter++;
            Settings.Default["rightCounter"] = frmSettings.rightCounter;
            Settings.Default.Save();

            if ((bool)Settings.Default["rightToTXTtoggle"])
            {
                StreamWriter Writer = new StreamWriter(Settings.Default["rightToTXT"].ToString() + @"\rightCounter.txt");
                Writer.WriteLine(frmSettings.rightCounter);
                Writer.Close();
            }
        }

        private void xmlInjector(string inputPath, string outputPath, int FPS)
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(inputPath);
                XmlNode Node = doc.DocumentElement;
                XmlNode root = doc.SelectSingleNode("/xmeml/sequence");

                foreach (var item in lbGlobalSS.Items)
                {
                    //Console.WriteLine(item);

                    int itemC = Convert.ToInt16(item) * FPS;

                    XmlElement marker = doc.CreateElement("marker");
                    root.AppendChild(marker);
                    XmlElement comment = doc.CreateElement("comment");
                    comment.InnerText = itemC.ToString();
                    marker.AppendChild(comment);
                    XmlElement name = doc.CreateElement("name");
                    name.InnerText = itemC.ToString();
                    marker.AppendChild(name);
                    XmlElement inn = doc.CreateElement("in");
                    inn.InnerText = itemC.ToString();
                    marker.AppendChild(inn);
                    XmlElement outt = doc.CreateElement("out");
                    outt.InnerText = "-1";
                    marker.AppendChild(outt);
                }
            }
            catch (Exception f)
            {
                Console.Write(f.Message);
                throw;
            }

            doc.Save(outputPath + @"\project.xml");
        }

        /// <summary>
        /// Öffnet einen custom Exception Dialog "recTimer.frmCustomExcDialog.cs" mit o.g.Variablen.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="exception"></param>
        private void customExcBox(string message, string title, System.Exception exception)
        {
            CEXB_MESSAGE = message;
            CEXB_EXCEPTION = exception.ToString();
            CEXB_TITLE = title;

            frmCustomExcBox msg = new frmCustomExcBox();
            msg.ShowDialog();
        }

        long tfs_T1, tfs_T2, delta;
        private void hddWritingValue()
        {
            DriveInfo[] Drives = DriveInfo.GetDrives();

            string recHDD = Settings.Default["recHDD"].ToString();
            
            foreach (DriveInfo d in Drives)
            {
                if (d.Name == recHDD)
                {
                    tfs_T1 = d.TotalFreeSpace;

                    delta = tfs_T1;
                    lbRecTimeLeft.Text = tfs_T1.ToString();
                }
            }
        }

        #region EMPTY METHODS

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void lbGlobalSS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form PrPro = new frmPrPro();
            PrPro.ShowDialog();
        }

        private void pbDisks_Click(object sender, EventArgs e)
        {
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
        }
        #endregion
    }
}
