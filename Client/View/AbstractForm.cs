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
    public partial class AbstractForm : Form
    {
        public string absMessage = "";
        public AbstractForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (abstractTextBox.TextLength >= 500)
            {
                MessageBox.Show("Abstrast must be less than 500 characters");
                absMessage = "";
                return;
            }
            this.absMessage = abstractTextBox.Text;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
