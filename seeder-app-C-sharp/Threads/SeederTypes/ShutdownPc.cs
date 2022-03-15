using System.Diagnostics;

namespace seeder_app_C_sharp.Threads.SeederTypes
{
    internal class ShutdownPc : State
    {
        public override void Handle(Init seeder_type)
        {
            if (this.config.allowShutdown && !this.a_minute)
            {
                this.states.program_state = "Shutdown request received";
                var psi = new ProcessStartInfo("shutdown", "/s /t 0");
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                Process.Start(psi);
            }
        }
    }
}
