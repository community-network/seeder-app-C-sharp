﻿namespace seeder_app_C_sharp.Threads.SeederTypes;

internal class KeepAlive : State
{
    public override void Handle(Init seeder_type)
    {
        if (this.game_info.Is_Running && (this.old_game_id != current_game_id && this.old_server.action != "leaveServer") || this.states.message_running)
        {
            this.states.program_state = "Leaving old session";
            Game.Quit();
            this.states.message_running = false;
        }
        if (!this.game_info.Is_Running)
        {
            this.states.program_state = "Joining keepalive server with ID: " + this.current_game_id;
            Game.Launch(this.states, this.config, current_game_id, "soldier");
        }
        this.states.game_running = true;
    }
}
