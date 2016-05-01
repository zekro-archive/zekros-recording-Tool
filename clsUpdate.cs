using System.Windows.Forms;
using System.Net;
using System.IO;

namespace recTimer
{
    class clsUpdate
    {
        public static string downloadURL = "https://github.com/zekroTJA/zekros-recording-Tool/releases", newestversion;

        public static bool getUpdateStatus()
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://dl.dropboxusercontent.com/s/s6ib5g3go6xyk1j/zekrosrecordingtool_version.txt");
            StreamReader reader = new StreamReader(stream);
            newestversion = reader.ReadToEnd();

            if (newestversion != clsConst.buildVersion)
                return true;
            else
                return false;
        }

        public static void testForUpdate()
        {

            if (getUpdateStatus())
            {
                string message = "Es ist ein Update für das Tool verfügbar! (Deine Version: " + clsConst.buildVersion + " / Neuste Version: " + newestversion + ") Möchtsest du jetzt das Update herunterladen?";
                const string caption = "Update verfügbar!";
                var result = MessageBox.Show(message, caption,
                                  MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    //System.Diagnostics.Process.Start(downloadURL);
                    WebClient client = new WebClient();
                    client.DownloadFile(getUpdateUrl(), "recTimerUpdate.exe");
                    MessageBox.Show("Erfolgreich heruntergeladen! Das Programm wird jetzt neu gestartet um den Updatevorgang zu beenden.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    updateInstaller();
                    System.Diagnostics.Process.Start("update.bat");
                    Application.Exit();
                }
            }
        }

        public static string getUpdateUrl()
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("http://dl.dropboxusercontent.com/s/ta7aw0dm9okie8i/zekrosrecordingtool_updateURL.txt");
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        private static void updateInstaller()
        {
            StreamWriter writer = new StreamWriter("update.bat");
            writer.WriteLine("@echo off");
            writer.WriteLine("title updater");
            writer.WriteLine("if exist recTimer.exe (");
            writer.WriteLine("  del recTimer.exe");
            writer.WriteLine("  if exist recTimerUpdate.exe (");
            writer.WriteLine("	    ren recTimerUpdate.exe recTimer.exe )");
            writer.WriteLine("      start recTimer.exe");
            writer.WriteLine("      del update.bat");
            writer.WriteLine(") else (");
            writer.WriteLine("	echo ACHTUNG! Sie habe die Datei recTimer.exe höchst wahrscheinlich umbenannt!");
            writer.WriteLine("	echo Dies führt dazu, dass die Applikation nicht mit der Update-Datei ersetzt werden kann!");
            writer.WriteLine("	pause > nul");
            writer.WriteLine("  del update.bat )");
            writer.Close();
        }
    }
}
