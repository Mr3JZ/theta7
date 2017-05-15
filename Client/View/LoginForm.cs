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
    public partial class LoginForm : Form
    {
        private bool waterMarkActive;

        public LoginForm()
        {
            InitializeComponent();
            initView();
        }

        private void initView()
        {
            this.waterMarkActive = true;

            this.usernameTextBox.ForeColor = Color.Gray;
            this.usernameTextBox.Text = "Username";
            this.usernameTextBox.GotFocus += (source, e) =>
            {
                if (this.waterMarkActive)
                {
                    this.waterMarkActive = false;
                    this.usernameTextBox.Text = "";
                    this.usernameTextBox.ForeColor = Color.Black;
                }
            };
            this.usernameTextBox.LostFocus += (source, e) =>
            {
                if (!this.waterMarkActive && string.IsNullOrEmpty(this.usernameTextBox.Text))
                {
                    this.waterMarkActive = true;
                    this.usernameTextBox.Text = "Username";
                    this.usernameTextBox.ForeColor = Color.Gray;
                }
            };
        }
    }
}
