using System;
using System.Diagnostics;
using System.Linq;

namespace seeder_app_C_sharp.Actions;

internal class Origin
{
    public static void Restart()
    {
        Process[] origin_process = Process.GetProcessesByName("Origin");
        if (origin_process.Length > 0)
            origin_process.First().Kill();
        Process.Start("C:\\Program Files (x86)\\Origin\\Origin.exe", "");
    }


    public static void LaunchGame(States states, Config config, string game_id, string role)
    {
        Console.WriteLine("Launching game...");
        string command = "";
        if (!config.usableClient)
            command += "-Window.Fullscreen false -RenderDevice.MinDriverRequired false -Core.HardwareGpuBias -1 -Core.HardwareCpuBias -1 -Core.HardwareProfile Hardware_Low -RenderDevice.CreateMinimalWindow true -RenderDevice.NullDriverEnable true -Texture.LoadingEnabled false -Texture.RenderTexturesEnabled false -Client.TerrainEnabled false -Decal.SystemEnable false ";
        command += "-webMode MP -Origin_NoAppFocus --activate-webhelper -requestState State_ClaimReservation -gameId ";
        command += game_id;
        command += " -gameMode MP -role ";
        command += role;
        command += " -asSpectator ";
        command += (role == "spectator").ToString().ToLower();
        try
        {
            Process.Start(config.gameLocation, command);
        }
        catch (Exception)
        {
            states.program_state = "Game not found at location!";
        }
    }
}
