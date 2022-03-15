namespace seeder_app_C_sharp.Threads.SeederTypes
{
    internal class BroadcastMessage : State
    {
        public override void Handle(Init seeder_type)
        {
            if (this.config.sendMessageBool)
            {
                this.states.program_state = "Broadcasting message to current server";
                Game.SendMessage(this.current_server.gameId);
            }
        }
    }
}
