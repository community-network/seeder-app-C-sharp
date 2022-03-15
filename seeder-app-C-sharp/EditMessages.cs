using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace seeder_app_C_sharp
{
    public partial class EditMessages : Form
    {
        private Config config;
        private List<string> UnsavedMessageList = new List<string>();

        public EditMessages()
        {
            InitializeComponent();
            this.config = new Config();
            this.UnsavedMessageList = new List<string>(this.config.sendMessage); ;
            this.RefreshListBox();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.FormClosing += EditFormClosing;
        }

        private void EditFormClosing(object sender, FormClosingEventArgs e)
        {
            if (!UnsavedMessageList.SequenceEqual(config.sendMessage))
            {
                DialogResult dialogResult = MessageBox.Show("You have unsaved changes, do want to save them?", "Message editor", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Save();
                }
            }
        }

        private void Save()
        {
            config.sendMessage = UnsavedMessageList;
            config.Update();
        }

        private void RefreshListBox()
        {
            MessageList.DataSource = null;
            MessageList.DataSource = UnsavedMessageList;
            UpdateButtons();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string add = CurrentMessage.Text;

            // Avoid adding same item twice
            if (!UnsavedMessageList.Contains(add))
            {
                UnsavedMessageList.Add(add);
                RefreshListBox();
            }
        }

        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            for (int i = MessageList.SelectedIndices.Count - 1; i >= 0; i--)
            {
                int index = MessageList.SelectedIndices[i];
                string item = UnsavedMessageList[index];
                UnsavedMessageList.RemoveAt(index);
                UnsavedMessageList.Insert(index - 1, item);
                RefreshListBox();
                MessageList.SelectedIndex = index - 1;
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            // Delete the selected items.
            // Delete in reverse order, otherwise the indices of not yet deleted items will change
            // and not reflect the indices returned by SelectedIndices collection anymore.
            for (int i = MessageList.SelectedIndices.Count - 1; i >= 0; i--)
            {
                int index = MessageList.SelectedIndices[i];
                UnsavedMessageList.RemoveAt(MessageList.SelectedIndices[i]);
                MessageList.SelectedIndex = index - 1;
            }
            RefreshListBox();
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            for (int i = MessageList.SelectedIndices.Count - 1; i >= 0; i--)
            {
                int index = MessageList.SelectedIndices[i];
                string item = UnsavedMessageList[index];
                UnsavedMessageList.RemoveAt(index);
                UnsavedMessageList.Insert(index + 1, item);
                RefreshListBox();
                MessageList.SelectedIndex = index + 1;
            }
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MessageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            MoveUpButton.Enabled = (MessageList.SelectedIndex > 0);
            MoveDownButton.Enabled = (MessageList.SelectedIndex < MessageList.Items.Count - 1);
            RemoveButton.Enabled = MessageList.Items.Count > 0;
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            this.Save();
            SaveButton.Text = "Saved!";
            await Task.Delay(1000);
            SaveButton.Text = "Save";
        }
    }
}
