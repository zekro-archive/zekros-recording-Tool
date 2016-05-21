using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static recTimer.clsConst;

namespace recTimer
{
    public partial class frmCustomExcBox : Form
    {
        public frmCustomExcBox()
        {
            InitializeComponent();
        }

        private void frmCustomExcBox_Load(object sender, EventArgs e)
        {
            this.Text = CEXB_TITLE;
            lbMessage.Text = CEXB_MESSAGE;
            rtbExc.Text = CEXB_EXCEPTION;

        }

        private void btOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
