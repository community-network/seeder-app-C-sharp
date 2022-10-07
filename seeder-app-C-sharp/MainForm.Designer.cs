namespace seeder_app_C_sharp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupId = new System.Windows.Forms.TextBox();
            this.groupIdLabel = new System.Windows.Forms.Label();
            this.gameLocationLabel = new System.Windows.Forms.Label();
            this.gameLocation = new System.Windows.Forms.TextBox();
            this.allowShutdown = new System.Windows.Forms.CheckBox();
            this.sendMessage = new System.Windows.Forms.CheckBox();
            this.usableClient = new System.Windows.Forms.CheckBox();
            this.autoMinimizeOnJoin = new System.Windows.Forms.CheckBox();
            this.seedingProgress = new System.Windows.Forms.ProgressBar();
            this.messageProgress = new System.Windows.Forms.ProgressBar();
            this.nextAntiAfkProgress = new System.Windows.Forms.ProgressBar();
            this.waitProgress = new System.Windows.Forms.ProgressBar();
            this.serverToJoinLabel = new System.Windows.Forms.Label();
            this.messageServer = new System.Windows.Forms.TextBox();
            this.sendingMessageTitle = new System.Windows.Forms.Label();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.messageStart = new System.Windows.Forms.TextBox();
            this.stopTimeLabel = new System.Windows.Forms.Label();
            this.messageStop = new System.Windows.Forms.TextBox();
            this.timoutLabel = new System.Windows.Forms.Label();
            this.waitForActionLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.seedingLabel = new System.Windows.Forms.Label();
            this.sendingMessageLabel = new System.Windows.Forms.Label();
            this.antiAfkLabel = new System.Windows.Forms.Label();
            this.hostname = new System.Windows.Forms.TextBox();
            this.hostnameLabel = new System.Windows.Forms.Label();
            this.saveText = new System.Windows.Forms.Label();
            this.messageTimeout = new System.Windows.Forms.NumericUpDown();
            this.StateTitle = new System.Windows.Forms.Label();
            this.StateLabel = new System.Windows.Forms.Label();
            this.EditMessageButton = new System.Windows.Forms.Button();
            this.IdLabel = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.CurrentServerLabel = new System.Windows.Forms.Label();
            this.CurrentServerText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.messageTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // groupId
            // 
            this.groupId.Location = new System.Drawing.Point(94, 8);
            this.groupId.Margin = new System.Windows.Forms.Padding(2);
            this.groupId.Name = "groupId";
            this.groupId.Size = new System.Drawing.Size(174, 23);
            this.groupId.TabIndex = 0;
            // 
            // groupIdLabel
            // 
            this.groupIdLabel.AutoSize = true;
            this.groupIdLabel.Location = new System.Drawing.Point(35, 11);
            this.groupIdLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.groupIdLabel.Name = "groupIdLabel";
            this.groupIdLabel.Size = new System.Drawing.Size(56, 15);
            this.groupIdLabel.TabIndex = 1;
            this.groupIdLabel.Text = "Group id:";
            this.groupIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gameLocationLabel
            // 
            this.gameLocationLabel.AutoSize = true;
            this.gameLocationLabel.Location = new System.Drawing.Point(4, 31);
            this.gameLocationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gameLocationLabel.Name = "gameLocationLabel";
            this.gameLocationLabel.Size = new System.Drawing.Size(87, 15);
            this.gameLocationLabel.TabIndex = 2;
            this.gameLocationLabel.Text = "Game location:";
            this.gameLocationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gameLocation
            // 
            this.gameLocation.Location = new System.Drawing.Point(94, 30);
            this.gameLocation.Margin = new System.Windows.Forms.Padding(2);
            this.gameLocation.Name = "gameLocation";
            this.gameLocation.Size = new System.Drawing.Size(174, 23);
            this.gameLocation.TabIndex = 3;
            // 
            // allowShutdown
            // 
            this.allowShutdown.AutoSize = true;
            this.allowShutdown.Location = new System.Drawing.Point(94, 79);
            this.allowShutdown.Margin = new System.Windows.Forms.Padding(2);
            this.allowShutdown.Name = "allowShutdown";
            this.allowShutdown.Size = new System.Drawing.Size(112, 19);
            this.allowShutdown.TabIndex = 4;
            this.allowShutdown.Text = "Allow shutdown";
            this.allowShutdown.UseVisualStyleBackColor = true;
            // 
            // sendMessage
            // 
            this.sendMessage.AutoSize = true;
            this.sendMessage.Location = new System.Drawing.Point(94, 97);
            this.sendMessage.Margin = new System.Windows.Forms.Padding(2);
            this.sendMessage.Name = "sendMessage";
            this.sendMessage.Size = new System.Drawing.Size(106, 19);
            this.sendMessage.TabIndex = 5;
            this.sendMessage.Text = "Send messages";
            this.sendMessage.UseVisualStyleBackColor = true;
            // 
            // usableClient
            // 
            this.usableClient.AutoSize = true;
            this.usableClient.Location = new System.Drawing.Point(94, 114);
            this.usableClient.Margin = new System.Windows.Forms.Padding(2);
            this.usableClient.Name = "usableClient";
            this.usableClient.Size = new System.Drawing.Size(127, 19);
            this.usableClient.TabIndex = 6;
            this.usableClient.Text = "Usable client mode";
            this.usableClient.UseVisualStyleBackColor = true;
            // 
            // autoMinimizeOnJoin
            // 
            this.autoMinimizeOnJoin.AutoSize = true;
            this.autoMinimizeOnJoin.Location = new System.Drawing.Point(94, 131);
            this.autoMinimizeOnJoin.Margin = new System.Windows.Forms.Padding(2);
            this.autoMinimizeOnJoin.Name = "autoMinimizeOnJoin";
            this.autoMinimizeOnJoin.Size = new System.Drawing.Size(144, 19);
            this.autoMinimizeOnJoin.TabIndex = 7;
            this.autoMinimizeOnJoin.Text = "Auto minimize on join";
            this.autoMinimizeOnJoin.UseVisualStyleBackColor = true;
            // 
            // seedingProgress
            // 
            this.seedingProgress.Location = new System.Drawing.Point(352, 160);
            this.seedingProgress.Margin = new System.Windows.Forms.Padding(2);
            this.seedingProgress.Name = "seedingProgress";
            this.seedingProgress.Size = new System.Drawing.Size(13, 12);
            this.seedingProgress.TabIndex = 10;
            // 
            // messageProgress
            // 
            this.messageProgress.Location = new System.Drawing.Point(352, 175);
            this.messageProgress.Margin = new System.Windows.Forms.Padding(2);
            this.messageProgress.Name = "messageProgress";
            this.messageProgress.Size = new System.Drawing.Size(13, 12);
            this.messageProgress.TabIndex = 11;
            // 
            // nextAntiAfkProgress
            // 
            this.nextAntiAfkProgress.Location = new System.Drawing.Point(378, 194);
            this.nextAntiAfkProgress.Margin = new System.Windows.Forms.Padding(2);
            this.nextAntiAfkProgress.Name = "nextAntiAfkProgress";
            this.nextAntiAfkProgress.Size = new System.Drawing.Size(172, 12);
            this.nextAntiAfkProgress.TabIndex = 12;
            // 
            // waitProgress
            // 
            this.waitProgress.Location = new System.Drawing.Point(352, 146);
            this.waitProgress.Margin = new System.Windows.Forms.Padding(2);
            this.waitProgress.Name = "waitProgress";
            this.waitProgress.Size = new System.Drawing.Size(13, 12);
            this.waitProgress.TabIndex = 13;
            // 
            // serverToJoinLabel
            // 
            this.serverToJoinLabel.AutoSize = true;
            this.serverToJoinLabel.Location = new System.Drawing.Point(292, 27);
            this.serverToJoinLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.serverToJoinLabel.Name = "serverToJoinLabel";
            this.serverToJoinLabel.Size = new System.Drawing.Size(79, 15);
            this.serverToJoinLabel.TabIndex = 17;
            this.serverToJoinLabel.Text = "Server to join:";
            this.serverToJoinLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // messageServer
            // 
            this.messageServer.Location = new System.Drawing.Point(372, 24);
            this.messageServer.Margin = new System.Windows.Forms.Padding(2);
            this.messageServer.Name = "messageServer";
            this.messageServer.Size = new System.Drawing.Size(174, 23);
            this.messageServer.TabIndex = 16;
            // 
            // sendingMessageTitle
            // 
            this.sendingMessageTitle.AutoSize = true;
            this.sendingMessageTitle.Location = new System.Drawing.Point(378, 8);
            this.sendingMessageTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sendingMessageTitle.Name = "sendingMessageTitle";
            this.sendingMessageTitle.Size = new System.Drawing.Size(104, 15);
            this.sendingMessageTitle.TabIndex = 18;
            this.sendingMessageTitle.Text = "Sending messages";
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(310, 49);
            this.startTimeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(61, 15);
            this.startTimeLabel.TabIndex = 20;
            this.startTimeLabel.Text = "Start time:";
            this.startTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // messageStart
            // 
            this.messageStart.Location = new System.Drawing.Point(372, 46);
            this.messageStart.Margin = new System.Windows.Forms.Padding(2);
            this.messageStart.Name = "messageStart";
            this.messageStart.Size = new System.Drawing.Size(174, 23);
            this.messageStart.TabIndex = 19;
            // 
            // stopTimeLabel
            // 
            this.stopTimeLabel.AutoSize = true;
            this.stopTimeLabel.Location = new System.Drawing.Point(310, 71);
            this.stopTimeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.stopTimeLabel.Name = "stopTimeLabel";
            this.stopTimeLabel.Size = new System.Drawing.Size(61, 15);
            this.stopTimeLabel.TabIndex = 22;
            this.stopTimeLabel.Text = "Stop time:";
            this.stopTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // messageStop
            // 
            this.messageStop.Location = new System.Drawing.Point(372, 68);
            this.messageStop.Margin = new System.Windows.Forms.Padding(2);
            this.messageStop.Name = "messageStop";
            this.messageStop.Size = new System.Drawing.Size(174, 23);
            this.messageStop.TabIndex = 21;
            // 
            // timoutLabel
            // 
            this.timoutLabel.AutoSize = true;
            this.timoutLabel.Location = new System.Drawing.Point(323, 94);
            this.timoutLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timoutLabel.Name = "timoutLabel";
            this.timoutLabel.Size = new System.Drawing.Size(48, 15);
            this.timoutLabel.TabIndex = 24;
            this.timoutLabel.Text = "Timout:";
            this.timoutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // waitForActionLabel
            // 
            this.waitForActionLabel.AutoSize = true;
            this.waitForActionLabel.Location = new System.Drawing.Point(369, 144);
            this.waitForActionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.waitForActionLabel.Name = "waitForActionLabel";
            this.waitForActionLabel.Size = new System.Drawing.Size(102, 15);
            this.waitForActionLabel.TabIndex = 25;
            this.waitForActionLabel.Text = "Waiting for action";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(128, 153);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(56, 21);
            this.saveButton.TabIndex = 26;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // seedingLabel
            // 
            this.seedingLabel.AutoSize = true;
            this.seedingLabel.Location = new System.Drawing.Point(369, 158);
            this.seedingLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.seedingLabel.Name = "seedingLabel";
            this.seedingLabel.Size = new System.Drawing.Size(49, 15);
            this.seedingLabel.TabIndex = 27;
            this.seedingLabel.Text = "Seeding";
            // 
            // sendingMessageLabel
            // 
            this.sendingMessageLabel.AutoSize = true;
            this.sendingMessageLabel.Location = new System.Drawing.Point(369, 173);
            this.sendingMessageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sendingMessageLabel.Name = "sendingMessageLabel";
            this.sendingMessageLabel.Size = new System.Drawing.Size(99, 15);
            this.sendingMessageLabel.TabIndex = 28;
            this.sendingMessageLabel.Text = "Sending message";
            // 
            // antiAfkLabel
            // 
            this.antiAfkLabel.AutoSize = true;
            this.antiAfkLabel.Location = new System.Drawing.Point(299, 192);
            this.antiAfkLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.antiAfkLabel.Name = "antiAfkLabel";
            this.antiAfkLabel.Size = new System.Drawing.Size(79, 15);
            this.antiAfkLabel.TabIndex = 29;
            this.antiAfkLabel.Text = "Next anti-afk:";
            this.antiAfkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hostname
            // 
            this.hostname.Location = new System.Drawing.Point(94, 52);
            this.hostname.Margin = new System.Windows.Forms.Padding(2);
            this.hostname.Name = "hostname";
            this.hostname.Size = new System.Drawing.Size(174, 23);
            this.hostname.TabIndex = 30;
            // 
            // hostnameLabel
            // 
            this.hostnameLabel.AutoSize = true;
            this.hostnameLabel.Location = new System.Drawing.Point(27, 56);
            this.hostnameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hostnameLabel.Name = "hostnameLabel";
            this.hostnameLabel.Size = new System.Drawing.Size(65, 15);
            this.hostnameLabel.TabIndex = 31;
            this.hostnameLabel.Text = "Hostname:";
            this.hostnameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // saveText
            // 
            this.saveText.Location = new System.Drawing.Point(0, 0);
            this.saveText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.saveText.Name = "saveText";
            this.saveText.Size = new System.Drawing.Size(50, 12);
            this.saveText.TabIndex = 0;
            // 
            // messageTimeout
            // 
            this.messageTimeout.Location = new System.Drawing.Point(372, 91);
            this.messageTimeout.Margin = new System.Windows.Forms.Padding(2);
            this.messageTimeout.Name = "messageTimeout";
            this.messageTimeout.Size = new System.Drawing.Size(172, 23);
            this.messageTimeout.TabIndex = 32;
            // 
            // StateTitle
            // 
            this.StateTitle.AutoSize = true;
            this.StateTitle.Location = new System.Drawing.Point(5, 206);
            this.StateTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StateTitle.Name = "StateTitle";
            this.StateTitle.Size = new System.Drawing.Size(36, 15);
            this.StateTitle.TabIndex = 33;
            this.StateTitle.Text = "State:";
            this.StateTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StateLabel
            // 
            this.StateLabel.AutoSize = true;
            this.StateLabel.Location = new System.Drawing.Point(35, 206);
            this.StateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StateLabel.Name = "StateLabel";
            this.StateLabel.Size = new System.Drawing.Size(26, 15);
            this.StateLabel.TabIndex = 34;
            this.StateLabel.Text = "Idle";
            this.StateLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // EditMessageButton
            // 
            this.EditMessageButton.Location = new System.Drawing.Point(371, 119);
            this.EditMessageButton.Margin = new System.Windows.Forms.Padding(2);
            this.EditMessageButton.Name = "EditMessageButton";
            this.EditMessageButton.Size = new System.Drawing.Size(92, 22);
            this.EditMessageButton.TabIndex = 35;
            this.EditMessageButton.Text = "Edit messages";
            this.EditMessageButton.UseVisualStyleBackColor = true;
            this.EditMessageButton.Click += new System.EventHandler(this.EditMessageButton_Click);
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Location = new System.Drawing.Point(61, 192);
            this.IdLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(219, 15);
            this.IdLabel.TabIndex = 36;
            this.IdLabel.TabStop = true;
            this.IdLabel.Text = "00000000-0000-0000-0000-000000000000";
            this.IdLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.IdLabel_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 192);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 37;
            this.label1.Text = "Seeder ID:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentServerLabel
            // 
            this.CurrentServerLabel.AutoSize = true;
            this.CurrentServerLabel.Location = new System.Drawing.Point(299, 208);
            this.CurrentServerLabel.Name = "CurrentServerLabel";
            this.CurrentServerLabel.Size = new System.Drawing.Size(84, 15);
            this.CurrentServerLabel.TabIndex = 38;
            this.CurrentServerLabel.Text = "Current server:";
            // 
            // CurrentServerText
            // 
            this.CurrentServerText.AutoSize = true;
            this.CurrentServerText.Location = new System.Drawing.Point(379, 209);
            this.CurrentServerText.Name = "CurrentServerText";
            this.CurrentServerText.Size = new System.Drawing.Size(29, 15);
            this.CurrentServerText.TabIndex = 39;
            this.CurrentServerText.Text = "N/A";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(558, 226);
            this.Controls.Add(this.CurrentServerText);
            this.Controls.Add(this.CurrentServerLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IdLabel);
            this.Controls.Add(this.EditMessageButton);
            this.Controls.Add(this.StateLabel);
            this.Controls.Add(this.StateTitle);
            this.Controls.Add(this.messageTimeout);
            this.Controls.Add(this.saveText);
            this.Controls.Add(this.hostnameLabel);
            this.Controls.Add(this.hostname);
            this.Controls.Add(this.antiAfkLabel);
            this.Controls.Add(this.sendingMessageLabel);
            this.Controls.Add(this.seedingLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.waitForActionLabel);
            this.Controls.Add(this.timoutLabel);
            this.Controls.Add(this.stopTimeLabel);
            this.Controls.Add(this.messageStop);
            this.Controls.Add(this.startTimeLabel);
            this.Controls.Add(this.messageStart);
            this.Controls.Add(this.sendingMessageTitle);
            this.Controls.Add(this.serverToJoinLabel);
            this.Controls.Add(this.messageServer);
            this.Controls.Add(this.waitProgress);
            this.Controls.Add(this.nextAntiAfkProgress);
            this.Controls.Add(this.messageProgress);
            this.Controls.Add(this.seedingProgress);
            this.Controls.Add(this.autoMinimizeOnJoin);
            this.Controls.Add(this.usableClient);
            this.Controls.Add(this.sendMessage);
            this.Controls.Add(this.allowShutdown);
            this.Controls.Add(this.gameLocation);
            this.Controls.Add(this.gameLocationLabel);
            this.Controls.Add(this.groupIdLabel);
            this.Controls.Add(this.groupId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Battlefield 1 seeder";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.messageTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox groupId;
        private System.Windows.Forms.Label groupIdLabel;
        private System.Windows.Forms.Label gameLocationLabel;
        private System.Windows.Forms.TextBox gameLocation;
        private System.Windows.Forms.CheckBox allowShutdown;
        private System.Windows.Forms.CheckBox sendMessage;
        private System.Windows.Forms.CheckBox usableClient;
        private System.Windows.Forms.CheckBox autoMinimizeOnJoin;
        private System.Windows.Forms.ProgressBar seedingProgress;
        private System.Windows.Forms.ProgressBar messageProgress;
        private System.Windows.Forms.ProgressBar nextAntiAfkProgress;
        private System.Windows.Forms.ProgressBar waitProgress;
        private System.Windows.Forms.Label serverToJoinLabel;
        private System.Windows.Forms.TextBox messageServer;
        private System.Windows.Forms.Label sendingMessageTitle;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.TextBox messageStart;
        private System.Windows.Forms.Label stopTimeLabel;
        private System.Windows.Forms.TextBox messageStop;
        private System.Windows.Forms.Label timoutLabel;
        private System.Windows.Forms.Label waitForActionLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label seedingLabel;
        private System.Windows.Forms.Label sendingMessageLabel;
        private System.Windows.Forms.Label antiAfkLabel;
        private System.Windows.Forms.TextBox hostname;
        private System.Windows.Forms.Label hostnameLabel;
        private System.Windows.Forms.Label saveText;
        private System.Windows.Forms.NumericUpDown messageTimeout;
        private System.Windows.Forms.Label StateTitle;
        private System.Windows.Forms.Label StateLabel;
        private System.Windows.Forms.Button EditMessageButton;
        private System.Windows.Forms.LinkLabel IdLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CurrentServerLabel;
        private System.Windows.Forms.Label CurrentServerText;
    }
}

