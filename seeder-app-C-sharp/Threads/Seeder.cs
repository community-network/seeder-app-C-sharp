using System;
using System.Collections.Generic;
using System.Threading;

namespace seeder_app_C_sharp.Threads
{
    internal class Seeder
    {
        private Config config;
        private States states;
        private Structs.CurrentServer old_server;
        private Structs.GameInfo game_info;

        public Seeder(States states, Config config)
        {
            this.states = states;
            this.config = config;
            Int64 now = (Int64)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            this.old_server = new Structs.CurrentServer{ gameId = "", action = "leaveServer", groupId = config.groupId, timeStamp = now, keepAliveSeeders = { }, seederArr = new List<string>(), rejoin = true };
        }

        public void Start()
        {
            while (true)
            {
                this.game_info = Game.IsRunning();
                try
                {
                    PrepareSeeder();
                    Actions.Api.PingBackend(this.config, this.game_info);
                }
                catch (Exception)
                {

                }
                Thread.Sleep(10000);
            }
        }

        private void PrepareSeeder()
        {
            Structs.CurrentServer current_server = Actions.Api.Gather(this.config);
            SeederTypes.Init seeder_type = new SeederTypes.Init(new SeederTypes.LeaveServer());

            Int64 now = (Int64)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            bool a_hour = current_server.timeStamp < now - 3600;
            bool a_minute = current_server.timeStamp < now - 60;

            string old_game_id; string current_game_id;
            (old_game_id, current_game_id, seeder_type) = TypeSelector(seeder_type, current_server);
            seeder_type.Setup(this.states, current_server, old_server, this.config, this.game_info, a_hour, a_minute, old_game_id, current_game_id);
            SeedServer(current_server, seeder_type, current_game_id, a_hour);
        }

        private (string, string, SeederTypes.Init) TypeSelector(SeederTypes.Init seeder_type, Structs.CurrentServer current_server)
        {
            string current_game_id = current_server.gameId;
            string old_game_id = old_server.gameId;
            if (current_server.keepAliveSeeders != null && current_server.keepAliveSeeders.ContainsKey(this.config.hostname))
            {
                seeder_type = new SeederTypes.Init(new SeederTypes.KeepAlive());
                current_game_id = current_server.keepAliveSeeders[this.config.hostname]["gameId"];
            }
            if (old_server.keepAliveSeeders != null && old_server.keepAliveSeeders.ContainsKey(this.config.hostname))
            {
                old_game_id = old_server.keepAliveSeeders[this.config.hostname]["gameId"];
            }

            // Action selector
            if (current_server.action == "joinServer")
            {
                seeder_type = new SeederTypes.Init(new SeederTypes.JoinServer());
            } else if (current_server.action == "restartOrigin")
            {
                seeder_type = new SeederTypes.Init(new SeederTypes.RestartOrigin());
            } else if (current_server.action == "shutdownPC")
            {
                seeder_type = new SeederTypes.Init(new SeederTypes.ShutdownPc());
            } else if (current_server.action == "rebootPC")
            {
                seeder_type = new SeederTypes.Init(new SeederTypes.RebootPc());
            } else if (current_server.action == "broadcastMessage")
            {
                seeder_type = new SeederTypes.Init(new SeederTypes.BroadcastMessage());
            }

            return (old_game_id, current_game_id, seeder_type);
        }

        private void SeedServer(Structs.CurrentServer current_server, SeederTypes.Init seeder_type, string current_game_id, bool a_hour)
        {
            // run once
            if (current_server.timeStamp != old_server.timeStamp && !a_hour)
            {
                seeder_type.Run();
            }
            // run once but request is older than 1 hour
            else if (current_server.timeStamp != old_server.timeStamp && a_hour)
            {

            }
            else
            {
                // after that
                // if failed to launch:
                if (!game_info.Is_Running && ((current_server.action == "joinServer" && current_server.rejoin) || seeder_type.State.GetType().Name == "KeepAlive"))
                {
                    this.states.program_state = "Relaunching the game...";
                    Game.Launch(this.config, current_game_id, "soldier");
                // minimize after launch
                } else if (game_info.Is_Running && !this.states.minimized_on_start)
                {
                    this.states.program_state = "Minimized the game";
                    Game.Minimize(game_info);
                    this.states.minimized_on_start = true;
                }
            }
            this.old_server = current_server;
        }
    }
}
