﻿using System;
using System.Threading;

namespace seeder_app_C_sharp.Threads
{
    internal class AutoMessage
    {
        private Config config;
        private States states;
        public AutoMessage(States states, Config config)
        {
            this.config = config;
            this.states = states;
        }
        public void Start()
        {
            while (true)
            {
                Thread.Sleep(10000);
                if (!this.states.game_running && this.config.sendMessageBool)
                {
                    TimeSpan time_of_day = DateTime.Now.TimeOfDay;
                    string[] start_time = this.config.messageStart.Split(':');
                    string[] stop_time = this.config.messageStop.Split(':');
                    TimeSpan low = new TimeSpan(int.Parse(start_time[0]), int.Parse(start_time[1]), 0);
                    TimeSpan high = new TimeSpan(int.Parse(stop_time[0]), int.Parse(stop_time[1]), 0);
                    if (time_of_day > low && time_of_day < high)
                    {
                        this.states.message_running = true;
                        Structs.GameInfo game_info = Game.IsRunning();
                        if (!game_info.Is_Running)
                        {
                            Structs.ServerList server_list = Actions.Api.FindServer(config);
                            if (server_list != null && server_list.servers.Count != 0)
                            {
                                this.states.program_state = "Joining for automessage with ID: " + server_list.servers[0].gameId;
                                Game.Launch(config, server_list.servers[0].gameId, "spectator");
                            }
                        }
                    }
                    else
                    {
                        this.states.message_running = false;
                    }
                }
            }
        }
    }
}