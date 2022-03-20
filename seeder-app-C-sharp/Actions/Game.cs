using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace seeder_app_C_sharp
{
    internal class Game
    {
        public static Structs.GameInfo IsRunning()
        {
            // ansi:
            // IntPtr window_handle = FindWindow("Battlefield™ 1", null);

            // unicode: (for china support)
            IntPtr window_handle = IntPtr.Zero;
            Process[] processes = Process.GetProcessesByName("bf1");
            Process proc = null;

            // Cycle through all top-level windows
            EnumWindows(delegate (IntPtr hWnd, IntPtr lParam)
            {
                // Get PID of current window
                GetWindowThreadProcessId(hWnd, out int processId);

                // Get process matching PID
                proc = processes.FirstOrDefault(p => p.Id == processId);

                if (proc != null)
                {
                    window_handle = hWnd;
                }

                // return true so that we iterate through all windows
                return true;
            }, IntPtr.Zero);

            return new Structs.GameInfo
            {
                Is_Running = window_handle != IntPtr.Zero,
                Game_Process = window_handle
            };
        }

        public static void Quit()
        {
            Process[] game_process = Process.GetProcessesByName("bf1");
            if (game_process.Length > 0)
            {
                game_process.First().Kill();
            }
        }

        public static void Minimize(Structs.GameInfo game_info)
        {
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

        public static void Launch(Config config, string game_id, string role)
        {
            string command = "";
            if (!config.usableClient)
            {
                command += "-Window.Fullscreen false -RenderDevice.MinDriverRequired false -Core.HardwareGpuBias -1 -Core.HardwareCpuBias -1 -Core.HardwareProfile Hardware_Low -RenderDevice.CreateMinimalWindow true -RenderDevice.NullDriverEnable true -Texture.LoadingEnabled false -Texture.RenderTexturesEnabled false -Client.TerrainEnabled false -Decal.SystemEnable false ";
            }
            command += "-webMode MP -Origin_NoAppFocus --activate-webhelper -requestState State_ClaimReservation -gameId ";
            command += game_id;
            command += " -gameMode MP -role ";
            command += role;
            command += " -asSpectator ";
            command += (role == "spectator").ToString();
            try
            {
                Process.Start(config.gameLocation, command);
            }
            catch (FileNotFoundException)
            {

            }
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        // For Windows Mobile, replace user32.dll with coredll.dll
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern bool IsIconic(IntPtr handle);
    }

}
