using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace seeder_app_C_sharp
{
    internal class Config
    {
        public string groupId;
        public string hostname;
        public string gameLocation;
        public List<string> sendMessage;
        public string messageServer;
        public string messageStart;
        public string messageStop;
        public int messageTimeout;
        public bool allowShutdown;
        public bool sendMessageBool;
        public bool usableClient;
        public bool autoMinimizeOnJoin;
        public Guid guid;

        public Config()
        {
            string hostnameVar = Properties.Settings.Default.hostname;
            if (hostnameVar == "")
            {
                hostname = Environment.GetEnvironmentVariable("COMPUTERNAME");
            }
            else
            {
                hostname = hostnameVar;
            }
            groupId = Properties.Settings.Default.groupId;
            gameLocation = Properties.Settings.Default.gameLocation;
            this.RefreshMessages();
            messageServer = Properties.Settings.Default.messageServer;
            messageStart = Properties.Settings.Default.messageStart;
            messageStop = Properties.Settings.Default.messageStop;
            messageTimeout = Properties.Settings.Default.messageTimeout;
            allowShutdown = Properties.Settings.Default.allowShutdown;
            sendMessageBool = Properties.Settings.Default.sendMessageBool;
            usableClient = Properties.Settings.Default.usableClient;
            autoMinimizeOnJoin = Properties.Settings.Default.autoMinimizeOnJoin;

            guid = Properties.Settings.Default.Guid;
            if (guid == new Guid())
            {
                guid = Guid.NewGuid();
                Properties.Settings.Default.Guid = this.guid;
                Properties.Settings.Default.Save();
            }
        }
        public void RefreshMessages()
        {
            StringCollection message = Properties.Settings.Default.sendMessage;
            if (message != null)
            {
                sendMessage = message.Cast<string>().ToList();
            }
            else
            {
                sendMessage = new List<string>();
            }
            messageServer = Properties.Settings.Default.messageServer;
        }

        public void Update()
        {
            Properties.Settings.Default.groupId = groupId;
            Properties.Settings.Default.gameLocation = gameLocation;
            StringCollection collection = new StringCollection();
            collection.AddRange(sendMessage.ToArray());
            Properties.Settings.Default.sendMessage = collection;
            Properties.Settings.Default.messageServer = messageServer;
            Properties.Settings.Default.messageStart = messageStart;
            Properties.Settings.Default.messageStop = messageStop;
            Properties.Settings.Default.messageTimeout = messageTimeout;
            Properties.Settings.Default.allowShutdown = allowShutdown;
            Properties.Settings.Default.sendMessageBool = sendMessageBool;
            Properties.Settings.Default.usableClient = usableClient;
            Properties.Settings.Default.autoMinimizeOnJoin = autoMinimizeOnJoin;
            Properties.Settings.Default.Save();
        }
    }
}
 