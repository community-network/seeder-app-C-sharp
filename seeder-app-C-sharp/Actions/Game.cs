using seeder_app_C_sharp.Actions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace seeder_app_C_sharp;

internal class Game
{
    public static Structs.GameInfo IsRunning()
    {
        IntPtr window_handle = FindWindow(null, "Battlefield™ 1");
        return new Structs.GameInfo
        {
            Is_Running = window_handle != IntPtr.Zero,
            Game_Process = window_handle
        };
    }

    public static void Quit()
    {
        Console.WriteLine("Leaving server...");
        Process[] game_process = Process.GetProcessesByName("bf1");
        if (game_process.Length > 0)
        {
            game_process.First().Kill();
        }
    }

    public static void Minimize(Structs.GameInfo game_info)
    {
        Console.WriteLine("Minimizing game...");
        if (game_info.Is_Running && !IsIconic(game_info.Game_Process))
        {
            ShowWindow(game_info.Game_Process, 6);
        }
    }

    public static void SendMessage(string to_send)
    {
        Structs.GameInfo game_info = IsRunning();
        if (game_info.Is_Running)
        {
            SetForegroundWindow(game_info.Game_Process);
            ShowWindow(game_info.Game_Process, 9);
            Thread.Sleep(5000);
            SendKeys.KeyEnter(0x24, 80);
            Thread.Sleep(2000);
            List<Tuple<Chars.DXCode, ushort>> message = new List<Tuple<Chars.DXCode, ushort>>();
            foreach (var current_char in to_send.ToCharArray()) {
                var dx_char = Chars.CharToDXCODES(current_char);
                if (dx_char != null)
                {
                    message.Add(dx_char);
                }
            };
            SendKeys.SendString(message);
            Thread.Sleep(100);
            SendKeys.KeyEnter(0x1C, 80);
            Thread.Sleep(2500);
            ShowWindow(game_info.Game_Process, 6);
        }
    }

    public static void Launch(States states, Config config, string game_id, string role)
    {
        if (config.useEaDesktop) {
            Debug.WriteLine("Launching game after EA Desktop startup...");
            EaDesktop.LaunchGame(states, config, game_id, role);
            return;
        }
        Origin.LaunchGame(states, config, game_id, role);
    }

    public static void RestartLauncher(Config config)
    {
        if (config.useEaDesktop)
            EaDesktop.Restart();

        Origin.Restart();
    }

    // For Windows Mobile, replace user32.dll with coredll.dll
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll")]
    static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll")]
    public static extern bool IsIconic(IntPtr handle);
}
