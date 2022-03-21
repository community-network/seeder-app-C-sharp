using System;
using System.Threading;

namespace seeder_app_C_sharp.Threads
{
    internal class AutoMessage
    {
        private Config config;
        private States states;
        private string currentServerId;

        public AutoMessage(States states, Config config)
        {
            this.config = config;
            this.states = states;
            this.currentServerId = "";
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
                            try 
                            {
                                Structs.ServerList server_list = Actions.Api.FindServer(config);
                                if (server_list != null && server_list.servers.Count != 0)
                                {
                                    this.states.program_state = "Joining for automessage with ID: " + server_list.servers[0].gameId;
                                    Game.Launch(this.states, this.config, server_list.servers[0].gameId, "spectator");
                                    this.currentServerId = server_list.servers[0].gameId;
                                } else
                                {
                                    this.states.program_state = "No server found with that name!";
                                }
                            } catch (Exception)
                            {
                                this.states.program_state = "Error finding server for message!";
                            }

                        } else
                        {
                            GameReader.CurrentServerReader current_server_reader = new GameReader.CurrentServerReader();
                            if (current_server_reader.hasResults)
                            {
                                if (current_server_reader.PlayerLists_All.Count > 0 && current_server_reader.ServerName != "")
                                {
                                    try
                                    {
                                        Actions.Api.PostPlayerlist(current_server_reader, this.currentServerId, this.config.guid);
                                    } catch (Exception)
                                    {

                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        this.currentServerId = "";
                        this.states.message_running = false;
                    }
                } else
                {
                    this.currentServerId = "";
                }
            }
        }
    }
}
