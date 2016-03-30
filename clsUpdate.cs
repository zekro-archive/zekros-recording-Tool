using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace recTimer
{
    class clsUpdate
    {
        public static string downloadURL = "http://github.com/zekroTJA";
        public static void testForUpdate()
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://dl.dropboxusercontent.com/s/s6ib5g3go6xyk1j/zekrosrecordingtool_version.txt");
            StreamReader reader = new StreamReader(stream);
            string newestversion = reader.ReadToEnd();

            if (newestversion != Form1.buildVersion)
            {
                const string message = "Your version of this Tool is outdated! Would you like download the latest version now?";
                const string caption = "Update available!";
                var result = MessageBox.Show(message, caption,
                                  MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(downloadURL);
                }
            }
        }
    }
}
