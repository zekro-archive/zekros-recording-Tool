using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace recTimer
{
    public partial class frmInfo : Form
    {
        public frmInfo()
        {
            InitializeComponent();
            lbVersionInfo.Text = "Version: preAlpha v." + Form1.buildVersion + "a";
        }

        private void frmInfo_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://zekro.jimdo.com");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://youtube.com/zekrommaster110");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://twitter.com/zekrommaster110");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://github.com/zekroTJA");
        }

        private void btBugReport_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:zekroyt@outlook.de?subject=zekrosRecordingTool%20BugReport");
        }
    }
}
