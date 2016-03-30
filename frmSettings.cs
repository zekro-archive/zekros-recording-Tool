using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using recTimer.Properties;
using System.Windows.Forms;

namespace recTimer
{
    public partial class frmSettings : Form
    {

        public static string recHDD;
        public static string recKey;
        public static string recFolder;
        globalKeyboardHook hook = new globalKeyboardHook();

        public frmSettings()
        {

            InitializeComponent();
            if (Settings.Default["recHDD"].ToString() != "")
            {
                tbRecHDD.Text = Settings.Default["recHDD"].ToString();
            }

            if (Settings.Default["recKey"].ToString() != "")
            {
                cbRecKey.Text = Settings.Default["recKey"].ToString();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void tbRecHDD_TextChanged(object sender, EventArgs e)
        {
            tbRecHDD.Text = clsConst.recHDD;
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

        private void saveAll()
        {
            recHDD = tbRecHDD.Text;
            Settings.Default["recHDD"] = tbRecHDD.Text;
            Settings.Default["recKey"] = cbRecKey.Text;
            Settings.Default["recFolder"] = tbRecFolder.Text;
            Settings.Default.Save();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Start();
            folderBrowserDialog1.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tbRecFolder.Text = folderBrowserDialog1.SelectedPath;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            folderBrowserDialog2.ShowDialog();
        }
    }
}
