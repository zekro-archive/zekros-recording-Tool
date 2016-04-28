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

namespace recTimer
{
    public partial class frmPrPro : Form
    {
        public static string path;
        public static string outputPath;
        public static string FPS;

        public frmPrPro()
        {
            InitializeComponent();
        }

        private void frmPrPro_Load(object sender, EventArgs e)
        {
            if (Settings.Default["inputPath"].ToString() != "")
                tbProjPath.Text = Settings.Default["inputPath"].ToString();

            if (Settings.Default["outputPath"].ToString() != "")
                tbOutputPath.Text = Settings.Default["outputPath"].ToString();

            if (Settings.Default["FPS"].ToString() != "")
                cbFPS.Text = Settings.Default["FPS"].ToString();
        }

        private void btProjPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                tbProjPath.Text = path;

                Settings.Default["inputPath"] = path;
                Settings.Default.Save();
            }
        }

        private void btOutputPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                outputPath = folder.SelectedPath;
                tbOutputPath.Text = outputPath;

                Settings.Default["outputPath"] = outputPath;
                Settings.Default.Save();
            }
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbProjPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbFPS_SelectedIndexChanged(object sender, EventArgs e)
        {
            FPS = cbFPS.Text.ToString();

            Settings.Default["FPS"] = FPS;
            Settings.Default.Save();
        }
    }
}
