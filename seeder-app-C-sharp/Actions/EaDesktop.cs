using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace seeder_app_C_sharp.Actions;

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

        string appdata_local = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        DirectoryInfo config_path = new DirectoryInfo(Path.GetFullPath(Path.Combine(appdata_local, @"Electronic Arts\EA Desktop")));

        Regex file_regex = new Regex(@"^user_.*.ini$");
        FileInfo file = config_path.GetFiles()
            .OrderByDescending(f => f.LastWriteTime)
            .Where(f => file_regex.IsMatch(f.Name)).First();

        if (file == null)
        {
            Console.WriteLine("Failed to find config file for ea launcher, please login first!");
            return;
        }

        if (launch_settings != "")
            Console.WriteLine("Using EA Desktop config file: {0}", file.FullName);

        iniParser config_ini = new iniParser(file.FullName);
        config_ini.Set("", "user.gamecommandline.origin.ofr.50.0000557", launch_settings);
        config_ini.Save();
    }

    public static void Restart()
    {
        Debug.WriteLine("Restarting EA Desktop");
        StopLauncher();
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

        var timeout = 0;
        var not_running = true;
        while (not_running)
        {
            if (timeout > 10) { // give up on to many tries waiting and continue anyway
                Debug.WriteLine("waiting to long, continueing..");
                break;
            }

            not_running = Game.IsRunning().Is_Running;
            Thread.Sleep(5000);
            timeout += 1;
        }

        EditLauncher("");
        Thread.Sleep(10000);
    }
}
