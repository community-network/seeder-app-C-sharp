using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.DataFormats;

namespace seeder_app_C_sharp.Actions
{
    internal class EaDesktop
    {
        public static void StopLauncher()
        {
            Console.WriteLine("Leaving server...");
            Process[] game_process = Process.GetProcessesByName("EADesktop.exe");
            if (game_process.Length > 0)
                game_process.First().Kill();
        }

        public static void EditLauncher(string launch_settings) {
            if (launch_settings == "") 
                Console.WriteLine("Resetting EA Desktop config...");
            else
                Console.WriteLine("Changing EA Desktop config...");



        }

        public static void LaunchGame(States states, Config config, string game_id, string role)
        {
            StopLauncher();
            Thread.Sleep(5000);

            string join_config = "";
            if (!config.usableClient)
                join_config += "-Window.Fullscreen false -RenderDevice.MinDriverRequired false -Core.HardwareGpuBias -1 -Core.HardwareCpuBias -1 -Core.HardwareProfile Hardware_Low -RenderDevice.CreateMinimalWindow true -RenderDevice.NullDriverEnable true -Texture.LoadingEnabled false -Texture.RenderTexturesEnabled false -Client.TerrainEnabled false -Decal.SystemEnable false ";
            join_config += string.Format("-webMode MP -Origin_NoAppFocus --activate-webhelper -requestState State_ClaimReservation -gameId {0} -gameMode MP -role {1} -asSpectator {2}", game_id, role, (role == "spectator").ToString().ToLower());
            EditLauncher(join_config);

            Console.WriteLine("Launching game...");
            try
            {
                Process.Start(config.gameLocation);
            }
            catch (Exception)
            {
                states.program_state = "Game not found at location!";
            }
        }
    }
}
