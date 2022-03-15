namespace seeder_app_C_sharp.Threads.SeederTypes
{
    internal class RestartOrigin : State
    {
        public override void Handle(Init seeder_type)
        {
            if (!this.a_minute)
            {
                if (this.game_info.Is_Running)
                {
                    this.states.program_state = "Leaving old session";
                    Game.Quit();
                    this.states.game_running = false;
                }
                this.states.program_state = "Restarting origin...";
                Actions.Origin.Restart();
            }
        }
    }
}
