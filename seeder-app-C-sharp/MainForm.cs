using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace seeder_app_C_sharp
{
    public partial class MainForm : Form
    {
        private Config config;
        private Thread anti_afk_thread;
        private Thread seeder_thread;
        private Thread auto_message_thread;
        private Thread interface_thread;
        private States states;

        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.FormClosing += Form1_FormClosing;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Initialize_Form();
            this.states = new States();
            this.interface_thread = new Thread(new ThreadStart(UpdateInterface));
            this.interface_thread.Start();

            Threads.AntiAfk anti_afk = new Threads.AntiAfk(states, config);
            this.anti_afk_thread = new Thread(new ThreadStart(anti_afk.Start));
            this.anti_afk_thread.Start();

            Threads.AutoMessage auto_message = new Threads.AutoMessage(states, config);
            this.auto_message_thread = new Thread(new ThreadStart(auto_message.Start));
            this.auto_message_thread.Start();

            Threads.Seeder seeder = new Threads.Seeder(states, config);
            this.seeder_thread = new Thread(new ThreadStart(seeder.Start));
            this.seeder_thread.Start();
        }

        private void UpdateInterface()
        {
            while (true)
            {
                SetValues(this.states);
                Thread.Sleep(1000);
            }
        }

        delegate void SetTextCallback(States states);

        private void SetValues(States states)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.seedingProgress.InvokeRequired || this.messageProgress.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetValues);
                this.Invoke(d, new object[] { states });
            }
            else
            {
                waitProgress.Value = ProgressBool(!(states.game_running || states.message_running));
                seedingProgress.Value = ProgressBool(states.game_running);
                messageProgress.Value = ProgressBool(states.message_running);
                StateLabel.Text = states.program_state;
                if (states.game_running || states.message_running)
                {
                    nextAntiAfkProgress.Value = states.anti_afk_next;
                } else
                {
                    nextAntiAfkProgress.Value = 0;
                }
            }
        }

        private static int ProgressBool(bool boolean)
        {
            if (boolean)
            {
                return 100;
            }
            return 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!(hostname.Text == config.hostname && groupId.Text == config.groupId && gameLocation.Text == config.gameLocation && messageServer.Text == config.messageServer && messageStart.Text == config.messageStart && messageStop.Text == config.messageStop && messageTimeout.Value == config.messageTimeout && allowShutdown.Checked == config.allowShutdown && sendMessage.Checked == config.sendMessageBool && usableClient.Checked == config.usableClient && autoMinimizeOnJoin.Checked == config.autoMinimizeOnJoin))
            {
                DialogResult dialogResult = MessageBox.Show("You have unsaved changes, do want to save them?", "Battlefield 1 seeder", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Save();
                }
            }
            this.interface_thread.Abort();
            this.anti_afk_thread.Abort();
            this.auto_message_thread.Abort();
            this.seeder_thread.Abort();
        }

        private void Initialize_Form()
        {
            config = new Config();
            hostname.Text = config.hostname;
            groupId.Text = config.groupId;
            gameLocation.Text = config.gameLocation;
            messageServer.Text = config.messageServer;
            messageStart.Text = config.messageStart;
            messageStop.Text = config.messageStop;
            messageTimeout.Value = config.messageTimeout;
            allowShutdown.Checked = config.allowShutdown;
            sendMessage.Checked = config.sendMessageBool;
            usableClient.Checked = config.usableClient;
            autoMinimizeOnJoin.Checked = config.autoMinimizeOnJoin;
            IdLabel.Text = config.guid.ToString();
        }

        private void Save()
        {
            config.hostname = hostname.Text;
            config.groupId = groupId.Text;
            config.gameLocation = gameLocation.Text;
            config.messageServer = messageServer.Text;
            config.messageStart = messageStart.Text;
            config.messageStop = messageStop.Text;
            config.messageTimeout = (int)messageTimeout.Value;
            config.allowShutdown = allowShutdown.Checked;
            config.sendMessageBool = sendMessage.Checked;
            config.usableClient = usableClient.Checked;
            config.autoMinimizeOnJoin = autoMinimizeOnJoin.Checked;
            config.Update();
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            this.Save();
            saveButton.Text = "Saved!";
            await Task.Delay(1000);
            saveButton.Text = "Save";
        }

        private void EditMessageButton_Click(object sender, EventArgs e)
        {
            using (var edit_message = new EditMessages())
            {
                DialogResult result = edit_message.ShowDialog();
                config.RefreshMessages();
            }
        }

        private void IdLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(IdLabel.Text);
        }
    }
}
