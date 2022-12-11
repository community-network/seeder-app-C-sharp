using seeder_app_C_sharp.Actions;

namespace seeder_app_C_sharp.Threads.SeederTypes
{
    internal class JoinServer : State
    {
        public override void Handle(Init seeder_type)
        {
            if (this.old_game_id != this.current_game_id && this.old_server.action != "leaveServer" || this.states.message_running)
            {
                this.states.program_state = "Leaving old session";
                Game.Quit();
                this.states.message_running = false;
            }
            this.states.program_state = "Joining server with ID: " + this.current_game_id;
            Origin.LaunchGame(this.states, this.config, current_game_id, "soldier");
            this.states.minimized_on_start = false;
            this.states.game_running = true;
        }
    }
}
