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
        public static string downloadURL = "https://github.com/zekroTJA/zekros-recording-Tool/releases";

        public static void testForUpdate()
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://dl.dropboxusercontent.com/s/s6ib5g3go6xyk1j/zekrosrecordingtool_version.txt");
            StreamReader reader = new StreamReader(stream);
            string newestversion = reader.ReadToEnd();

            if (newestversion != Form1.buildVersion)
            {
                string message = "Es ist ein Update für das Tool verfügbar! (Deine Version: " + Form1.buildVersion + " / Neuste Version: " + newestversion + ") Möchtsest du jetzt das Update herunterladen?";
                const string caption = "Update verfügbar!";
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
