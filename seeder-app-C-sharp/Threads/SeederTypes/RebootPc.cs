using System.Diagnostics;

namespace seeder_app_C_sharp.Threads.SeederTypes
{
    internal class RebootPc : State
    {
        public override void Handle(Init seeder_type)
        {
            if (this.config.allowShutdown && !this.a_minute)
            {
                this.states.program_state = "Reboot request received";
                var psi = new ProcessStartInfo("shutdown", "-r -t 0");
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                Process.Start(psi);
            }
        }
    }
}
