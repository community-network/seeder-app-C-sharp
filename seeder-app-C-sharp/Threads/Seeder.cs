using System;
using System.Collections.Generic;
using System.Threading;
using Newtonsoft.Json;
using seeder_app_C_sharp.Actions;

namespace seeder_app_C_sharp.Threads
{
    internal class Seeder
    {
        private bool _disposed;
        private Config config;
        private States states;
        private Structs.CurrentServer old_server;
        private Structs.GameInfo game_info;
        private GameReader.CurrentServerReader current_server_reader;
        string joiningServer = "";

        public Seeder(States states, Config config)
        {
            this._disposed = false;
            this.states = states;
            this.config = config;
            Int64 now = (Int64)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            this.old_server = new Structs.CurrentServer { gameId = "", action = "leaveServer", groupId = config.groupId, timeStamp = now, keepAliveSeeders = { }, seederArr = new List<string>(), rejoin = true };
        }

        public void Start()
        {
            while (!this._disposed)
            {
                this.game_info = Game.IsRunning();
                try
                {
                    // show server state
                    current_server_reader = new GameReader.CurrentServerReader();
                    if (current_server_reader.HasResults && current_server_reader.ServerName != "")
                    {
                        int stringLength = current_server_reader.ServerName.Length > 20 ? 20 : current_server_reader.ServerName.Length;
                        this.states.current_server = $"{current_server_reader.ServerName.Substring(0, stringLength)} - {current_server_reader.PlayerListsAll.Count} players";
                    } else if (this.game_info.Is_Running)
                    {
                        this.states.current_server = $"Joining id {this.joiningServer}";
                    } else
                    {
                        this.states.current_server = "N/A";
                    }

                    // handle seeder
                    PrepareSeeder();
                    Actions.Api.PingBackend(this.config, this.game_info, current_server_reader);
                }
                catch (Exception)
                {
                    this.states.program_state = "Connection error";
                }

                // print state
                Console.WriteLine(JsonConvert.SerializeObject(this.states));
                Thread.Sleep(10000);
            }
        }

        public void Cancel()
        {
            this._disposed = true;
        }

        private void PrepareSeeder()
        {
            Structs.CurrentServer new_server = Actions.Api.Gather(this.config);
            SeederTypes.Init seeder_type = new SeederTypes.Init(new SeederTypes.LeaveServer());

            Int64 now = (Int64)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            bool a_hour = new_server.timeStamp < now - 3600;
            bool a_minute = new_server.timeStamp < now - 60;

            // current == current server, new == on new seedercheck
            string current_game_id; string new_game_id;
            (current_game_id, new_game_id, seeder_type) = TypeSelector(seeder_type, new_server);
            this.joiningServer = new_game_id;
            seeder_type.Setup(this.states, new_server, old_server, this.config, this.game_info, a_hour, a_minute, current_game_id, new_game_id);
            SeedServer(new_server, seeder_type, new_game_id, a_hour);
        }

        private (string, string, SeederTypes.Init) TypeSelector(SeederTypes.Init seeder_type, Structs.CurrentServer new_server)
        {
            string new_game_id = new_server.gameId;
            string current_game_id = current_server_reader.GameId.ToString();
            if (new_server.keepAliveSeeders != null && new_server.keepAliveSeeders.ContainsKey(this.config.hostname))
            {
                seeder_type = new SeederTypes.Init(new SeederTypes.KeepAlive());
                new_game_id = new_server.keepAliveSeeders[this.config.hostname]["gameId"];
            }

            // Action selector
            if (new_server.action == "joinServer")
            {
                seeder_type = new SeederTypes.Init(new SeederTypes.JoinServer());
            } else if (new_server.action == "restartOrigin")
            {
                seeder_type = new SeederTypes.Init(new SeederTypes.RestartOrigin());
            } else if (new_server.action == "shutdownPC")
            {
                seeder_type = new SeederTypes.Init(new SeederTypes.ShutdownPc());
            } else if (new_server.action == "rebootPC")
            {
                seeder_type = new SeederTypes.Init(new SeederTypes.RebootPc());
            } else if (new_server.action == "broadcastMessage")
            {
                seeder_type = new SeederTypes.Init(new SeederTypes.BroadcastMessage());
            }

            return (current_game_id, new_game_id, seeder_type);
        }

        private void SeedServer(Structs.CurrentServer new_server, SeederTypes.Init seeder_type, string new_game_id, bool a_hour)
        {
            // run once
            if (new_server.timeStamp != old_server.timeStamp && !a_hour)
            {
                seeder_type.Run();
            }
            // run once but request is older than 1 hour
            else if (new_server.timeStamp != old_server.timeStamp && a_hour)
            {

            }
            else
            {
                // after that
                // if failed to launch:
                if (!game_info.Is_Running && ((new_server.action == "joinServer" && new_server.rejoin) || seeder_type.State.GetType().Name == "KeepAlive"))
                {
                    this.states.program_state = "Relaunching the game...";
                    Game.Launch(this.states, this.config, new_game_id, "soldier");
                // minimize after launch
                } else if (game_info.Is_Running && !this.states.minimized_on_start)
                {
                    this.states.program_state = "Minimized the game";
                    Game.Minimize(game_info);
                    this.states.minimized_on_start = true;
                }
            }
            this.old_server = new_server;
        }
    }
}
