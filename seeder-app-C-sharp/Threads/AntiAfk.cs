using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace seeder_app_C_sharp.Threads;

internal class AntiAfk
{
    private bool _disposed;
    private States states;
    private Config config;

    public AntiAfk(States states, Config config)
    {
        this._disposed = false;
        this.states = states;
        this.config = config;
    }
    public void Start()
    {
        while (!_disposed)
        {
            if (this.states.game_running)
            {
                RunAfk();
            }
            if (this.states.message_running)
            {
                if (this.states.message_timeout >= (config.messageTimeout) && this.config.sendMessage.Count > 0)
                {
                    List<string> messages = this.config.sendMessage;
                    string message = messages[states.current_message_id];

                    this.states.program_state = "Sending: " + message;
                    Game.SendMessage(message);
                    states.message_timeout = 0;
                    this.states.program_state = "Idle in message server";

                    if (this.states.current_message_id + 1 >= messages.Count)
                    {
                        this.states.current_message_id = 0;
                    } else
                    {
                        this.states.current_message_id++;
                    }
                } else
                {
                    this.states.program_state = this.config.sendMessage.Count > 0 ? "Idle in message server" : "No messages set!";
                    this.states.message_timeout++;
                    RunAfk();
                }
            }
            for (this.states.anti_afk_next = 0; this.states.anti_afk_next < 100; this.states.anti_afk_next++)
            {
                Thread.Sleep(600);
            }
        }
    }

    public void Cancel()
    {
        this._disposed = true;
    }

    private void RunAfk()
    {
        Structs.GameInfo game_info = Game.IsRunning();
        if (game_info.Is_Running)
        {
            Console.WriteLine("Running anti-afk");
            IntPtr current_forground_window = GetForegroundWindow();
            int l_param = MakeLParam(20, 20);
            SendMessageW(game_info.Game_Process, 0x201, 0, l_param);
            SendMessageW(game_info.Game_Process, 0x202, 0, l_param);
            SetForegroundWindow(current_forground_window);
        }
    }

    private int MakeLParam(int LoWord, int HiWord)
    {
        return ((HiWord << 16) | (LoWord & 0xffff));
    }

    // For Windows Mobile, replace user32.dll with coredll.dll
    [DllImport("user32.dll")]
    static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
    public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, int wParam, int lParam);
}
