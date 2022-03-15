namespace seeder_app_C_sharp
{
    internal class States
    {
        public bool game_running = false;
        public bool message_running = false;
        public bool minimized_on_start = false;
        public int anti_afk_next = 0;
        public int message_timeout = 0;
        public int current_message_id = 0;
        public string program_state = "Idle";
    }
}
