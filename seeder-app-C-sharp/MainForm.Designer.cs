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
            ((System.ComponentModel.ISupportInitialize)(this.messageTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // groupId
            // 
            this.groupId.Location = new System.Drawing.Point(188, 17);
            this.groupId.Name = "groupId";
            this.groupId.Size = new System.Drawing.Size(345, 31);
            this.groupId.TabIndex = 0;
            // 
            // groupIdLabel
            // 
            this.groupIdLabel.AutoSize = true;
            this.groupIdLabel.Location = new System.Drawing.Point(82, 19);
            this.groupIdLabel.Name = "groupIdLabel";
            this.groupIdLabel.Size = new System.Drawing.Size(100, 25);
            this.groupIdLabel.TabIndex = 1;
            this.groupIdLabel.Text = "Group id:";
            this.groupIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gameLocationLabel
            // 
            this.gameLocationLabel.AutoSize = true;
            this.gameLocationLabel.Location = new System.Drawing.Point(26, 57);
            this.gameLocationLabel.Name = "gameLocationLabel";
            this.gameLocationLabel.Size = new System.Drawing.Size(156, 25);
            this.gameLocationLabel.TabIndex = 2;
            this.gameLocationLabel.Text = "Game location:";
            this.gameLocationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gameLocation
            // 
            this.gameLocation.Location = new System.Drawing.Point(188, 54);
            this.gameLocation.Name = "gameLocation";
            this.gameLocation.Size = new System.Drawing.Size(345, 31);
            this.gameLocation.TabIndex = 3;
            // 
            // allowShutdown
            // 
            this.allowShutdown.AutoSize = true;
            this.allowShutdown.Location = new System.Drawing.Point(188, 140);
            this.allowShutdown.Name = "allowShutdown";
            this.allowShutdown.Size = new System.Drawing.Size(193, 29);
            this.allowShutdown.TabIndex = 4;
            this.allowShutdown.Text = "Allow shutdown";
            this.allowShutdown.UseVisualStyleBackColor = true;
            // 
            // sendMessage
            // 
            this.sendMessage.AutoSize = true;
            this.sendMessage.Location = new System.Drawing.Point(188, 175);
            this.sendMessage.Name = "sendMessage";
            this.sendMessage.Size = new System.Drawing.Size(198, 29);
            this.sendMessage.TabIndex = 5;
            this.sendMessage.Text = "Send messages";
            this.sendMessage.UseVisualStyleBackColor = true;
            // 
            // usableClient
            // 
            this.usableClient.AutoSize = true;
            this.usableClient.Location = new System.Drawing.Point(188, 210);
            this.usableClient.Name = "usableClient";
            this.usableClient.Size = new System.Drawing.Size(227, 29);
            this.usableClient.TabIndex = 6;
            this.usableClient.Text = "Usable client mode";
            this.usableClient.UseVisualStyleBackColor = true;
            // 
            // autoMinimizeOnJoin
            // 
            this.autoMinimizeOnJoin.AutoSize = true;
            this.autoMinimizeOnJoin.Location = new System.Drawing.Point(188, 245);
            this.autoMinimizeOnJoin.Name = "autoMinimizeOnJoin";
            this.autoMinimizeOnJoin.Size = new System.Drawing.Size(248, 29);
            this.autoMinimizeOnJoin.TabIndex = 7;
            this.autoMinimizeOnJoin.Text = "Auto minimize on join";
            this.autoMinimizeOnJoin.UseVisualStyleBackColor = true;
            // 
            // seedingProgress
            // 
            this.seedingProgress.Location = new System.Drawing.Point(705, 277);
            this.seedingProgress.Name = "seedingProgress";
            this.seedingProgress.Size = new System.Drawing.Size(26, 23);
            this.seedingProgress.TabIndex = 10;
            // 
            // messageProgress
            // 
            this.messageProgress.Location = new System.Drawing.Point(705, 306);
            this.messageProgress.Name = "messageProgress";
            this.messageProgress.Size = new System.Drawing.Size(26, 23);
            this.messageProgress.TabIndex = 11;
            // 
            // nextAntiAfkProgress
            // 
            this.nextAntiAfkProgress.Location = new System.Drawing.Point(743, 345);
            this.nextAntiAfkProgress.Name = "nextAntiAfkProgress";
            this.nextAntiAfkProgress.Size = new System.Drawing.Size(345, 23);
            this.nextAntiAfkProgress.TabIndex = 12;
            // 
            // waitProgress
            // 
            this.waitProgress.Location = new System.Drawing.Point(705, 248);
            this.waitProgress.Name = "waitProgress";
            this.waitProgress.Size = new System.Drawing.Size(26, 23);
            this.waitProgress.TabIndex = 13;
            // 
            // serverToJoinLabel
            // 
            this.serverToJoinLabel.AutoSize = true;
            this.serverToJoinLabel.Location = new System.Drawing.Point(592, 48);
            this.serverToJoinLabel.Name = "serverToJoinLabel";
            this.serverToJoinLabel.Size = new System.Drawing.Size(145, 25);
            this.serverToJoinLabel.TabIndex = 17;
            this.serverToJoinLabel.Text = "Server to join:";
            this.serverToJoinLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // messageServer
            // 
            this.messageServer.Location = new System.Drawing.Point(743, 48);
            this.messageServer.Name = "messageServer";
            this.messageServer.Size = new System.Drawing.Size(345, 31);
            this.messageServer.TabIndex = 16;
            // 
            // sendingMessageTitle
            // 
            this.sendingMessageTitle.AutoSize = true;
            this.sendingMessageTitle.Location = new System.Drawing.Point(757, 17);
            this.sendingMessageTitle.Name = "sendingMessageTitle";
            this.sendingMessageTitle.Size = new System.Drawing.Size(195, 25);
            this.sendingMessageTitle.TabIndex = 18;
            this.sendingMessageTitle.Text = "Sending messages";
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(628, 85);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(109, 25);
            this.startTimeLabel.TabIndex = 20;
            this.startTimeLabel.Text = "Start time:";
            this.startTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // messageStart
            // 
            this.messageStart.Location = new System.Drawing.Point(743, 85);
            this.messageStart.Name = "messageStart";
            this.messageStart.Size = new System.Drawing.Size(345, 31);
            this.messageStart.TabIndex = 19;
            // 
            // stopTimeLabel
            // 
            this.stopTimeLabel.AutoSize = true;
            this.stopTimeLabel.Location = new System.Drawing.Point(629, 122);
            this.stopTimeLabel.Name = "stopTimeLabel";
            this.stopTimeLabel.Size = new System.Drawing.Size(108, 25);
            this.stopTimeLabel.TabIndex = 22;
            this.stopTimeLabel.Text = "Stop time:";
            this.stopTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // messageStop
            // 
            this.messageStop.Location = new System.Drawing.Point(743, 122);
            this.messageStop.Name = "messageStop";
            this.messageStop.Size = new System.Drawing.Size(345, 31);
            this.messageStop.TabIndex = 21;
            // 
            // timoutLabel
            // 
            this.timoutLabel.AutoSize = true;
            this.timoutLabel.Location = new System.Drawing.Point(654, 159);
            this.timoutLabel.Name = "timoutLabel";
            this.timoutLabel.Size = new System.Drawing.Size(83, 25);
            this.timoutLabel.TabIndex = 24;
            this.timoutLabel.Text = "Timout:";
            this.timoutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // waitForActionLabel
            // 
            this.waitForActionLabel.AutoSize = true;
            this.waitForActionLabel.Location = new System.Drawing.Point(738, 247);
            this.waitForActionLabel.Name = "waitForActionLabel";
            this.waitForActionLabel.Size = new System.Drawing.Size(179, 25);
            this.waitForActionLabel.TabIndex = 25;
            this.waitForActionLabel.Text = "Waiting for action";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(255, 287);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(113, 42);
            this.saveButton.TabIndex = 26;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // seedingLabel
            // 
            this.seedingLabel.AutoSize = true;
            this.seedingLabel.Location = new System.Drawing.Point(738, 277);
            this.seedingLabel.Name = "seedingLabel";
            this.seedingLabel.Size = new System.Drawing.Size(91, 25);
            this.seedingLabel.TabIndex = 27;
            this.seedingLabel.Text = "Seeding";
            // 
            // sendingMessageLabel
            // 
            this.sendingMessageLabel.AutoSize = true;
            this.sendingMessageLabel.Location = new System.Drawing.Point(738, 306);
            this.sendingMessageLabel.Name = "sendingMessageLabel";
            this.sendingMessageLabel.Size = new System.Drawing.Size(184, 25);
            this.sendingMessageLabel.TabIndex = 28;
            this.sendingMessageLabel.Text = "Sending message";
            // 
            // antiAfkLabel
            // 
            this.antiAfkLabel.AutoSize = true;
            this.antiAfkLabel.Location = new System.Drawing.Point(598, 343);
            this.antiAfkLabel.Name = "antiAfkLabel";
            this.antiAfkLabel.Size = new System.Drawing.Size(139, 25);
            this.antiAfkLabel.TabIndex = 29;
            this.antiAfkLabel.Text = "Next anti-afk:";
            this.antiAfkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hostname
            // 
            this.hostname.Location = new System.Drawing.Point(188, 91);
            this.hostname.Name = "hostname";
            this.hostname.Size = new System.Drawing.Size(345, 31);
            this.hostname.TabIndex = 30;
            // 
            // hostnameLabel
            // 
            this.hostnameLabel.AutoSize = true;
            this.hostnameLabel.Location = new System.Drawing.Point(67, 91);
            this.hostnameLabel.Name = "hostnameLabel";
            this.hostnameLabel.Size = new System.Drawing.Size(115, 25);
            this.hostnameLabel.TabIndex = 31;
            this.hostnameLabel.Text = "Hostname:";
            this.hostnameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // saveText
            // 
            this.saveText.Location = new System.Drawing.Point(0, 0);
            this.saveText.Name = "saveText";
            this.saveText.Size = new System.Drawing.Size(100, 23);
            this.saveText.TabIndex = 0;
            // 
            // messageTimeout
            // 
            this.messageTimeout.Location = new System.Drawing.Point(743, 157);
            this.messageTimeout.Name = "messageTimeout";
            this.messageTimeout.Size = new System.Drawing.Size(345, 31);
            this.messageTimeout.TabIndex = 32;
            // 
            // StateTitle
            // 
            this.StateTitle.AutoSize = true;
            this.StateTitle.Location = new System.Drawing.Point(32, 368);
            this.StateTitle.Name = "StateTitle";
            this.StateTitle.Size = new System.Drawing.Size(68, 25);
            this.StateTitle.TabIndex = 33;
            this.StateTitle.Text = "State:";
            this.StateTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StateLabel
            // 
            this.StateLabel.AutoSize = true;
            this.StateLabel.Location = new System.Drawing.Point(91, 368);
            this.StateLabel.Name = "StateLabel";
            this.StateLabel.Size = new System.Drawing.Size(46, 25);
            this.StateLabel.TabIndex = 34;
            this.StateLabel.Text = "Idle";
            this.StateLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // EditMessageButton
            // 
            this.EditMessageButton.Location = new System.Drawing.Point(743, 195);
            this.EditMessageButton.Name = "EditMessageButton";
            this.EditMessageButton.Size = new System.Drawing.Size(184, 44);
            this.EditMessageButton.TabIndex = 35;
            this.EditMessageButton.Text = "Edit messages";
            this.EditMessageButton.UseVisualStyleBackColor = true;
            this.EditMessageButton.Click += new System.EventHandler(this.EditMessageButton_Click);
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Location = new System.Drawing.Point(143, 343);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(424, 25);
            this.IdLabel.TabIndex = 36;
            this.IdLabel.TabStop = true;
            this.IdLabel.Text = "00000000-0000-0000-0000-000000000000";
            this.IdLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.IdLabel_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 25);
            this.label1.TabIndex = 37;
            this.label1.Text = "Seeder ID:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1115, 412);
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
    }
}

