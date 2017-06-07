using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.View
{
    public partial class AddTopicsForm : Form
    {
        public BindingList<string> topics;
        public AddTopicsForm(BindingList<string> topics)
        {
            InitializeComponent();
            topicsListBox.DataSource = topics;
            this.topics = topics;
        }

        private void AddTopicsForm_Load(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void topicTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (topicTextBox.Text.Length <= 1)
                MessageBox.Show("Topic name too short!");
            else
            {
                topics.Add(topicTextBox.Text);
                topicTextBox.Text = "";
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (topicsListBox.SelectedItem == null)
                MessageBox.Show("No item was selected");
            else
            {
                topics.Remove(topicsListBox.SelectedItem.ToString());
                topicTextBox.Text = "";
            }
        }
    }
}
