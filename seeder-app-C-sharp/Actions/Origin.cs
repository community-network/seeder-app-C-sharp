using System;
using System.Diagnostics;
using System.Linq;

namespace seeder_app_C_sharp.Actions
{
    internal class Origin
    {
        public static void Restart()
        {
            try
            {
                Process origin_process = Process.GetProcessesByName("Origin").First();
                origin_process.Kill();
            }
            catch (InvalidOperationException)
            {

            }
            Process.Start("C:\\Program Files (x86)\\Origin\\Origin.exe", "");
        }
    }
}
