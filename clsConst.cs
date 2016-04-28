using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recTimer
{
    static class clsConst
    {
        public static bool DEVELOPERMODE = false;

        public static string buildVersion = "0.6.0451";

        public static String settingsPath = AppDomain.CurrentDomain.BaseDirectory + @"\settings.xml";
        public static String recHDD;
    }
}
