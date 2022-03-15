namespace seeder_app_C_sharp.Threads.SeederTypes
{
    internal class LeaveServer : State
    {
        public override void Handle(Init seeder_type)
        {
            this.states.program_state = "Leave request received";
            Game.Quit();
            this.states.game_running = false;
        }
    }
}
