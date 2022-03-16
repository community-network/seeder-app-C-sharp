using System;
using System.Diagnostics;
using System.Linq;

namespace seeder_app_C_sharp.Actions
{
    internal class Origin
    {
        public static void Restart()
        {
            Process[] origin_process = Process.GetProcessesByName("Origin");
            if (origin_process.Length > 0)
            {
                origin_process.First().Kill();
            }
            Process.Start("C:\\Program Files (x86)\\Origin\\Origin.exe", "");
        }
    }
}
