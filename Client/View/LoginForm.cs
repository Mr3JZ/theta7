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
        private bool waterMarkUsernameActive;
        private bool waterMarkPasswordActive;
        private ClientController ctrl;


        public LoginForm(ClientController ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
            initUsernameView();
            initPasswordView();
        }

        private void initUsernameView()
        {
            waterMarkUsernameActive = true;
            usernameLabel.Hide();
            usernameTextBox.ForeColor = Color.Gray;
            usernameTextBox.Text = "Username";
            usernameTextBox.GotFocus += (source, e) =>
            {
                if (waterMarkUsernameActive)
                {
                    waterMarkUsernameActive = false;
                    usernameLabel.Show();
                    usernameTextBox.Text = "";
                    usernameTextBox.ForeColor = Color.Black;
                }
            };
            usernameTextBox.LostFocus += (source, e) =>
            {
                if (!waterMarkUsernameActive && string.IsNullOrEmpty(usernameTextBox.Text))
                {
                    waterMarkUsernameActive = true;
                    usernameLabel.Hide();
                    usernameTextBox.Text = "Username";
                    usernameTextBox.ForeColor = Color.Gray;
                }
            };
        }
        private void initPasswordView()
        {
            waterMarkPasswordActive = true;
            passwordLabel.Hide();
            passwordTextBox.ForeColor = Color.Gray;
            passwordTextBox.Text = "Password";
            passwordTextBox.PasswordChar = '\0';
            passwordTextBox.GotFocus += (source, e) =>
            {
                if (waterMarkPasswordActive)
                {
                    waterMarkPasswordActive = false;
                    passwordLabel.Show();
                    passwordTextBox.Text = "";
                    passwordTextBox.PasswordChar = '*';
                    passwordTextBox.ForeColor = Color.Black;
                }
            };
            passwordTextBox.LostFocus += (source, e) =>
            {
                if (!waterMarkPasswordActive && string.IsNullOrEmpty(passwordTextBox.Text))
                {
                    waterMarkPasswordActive = true;
                    passwordLabel.Hide();
                    passwordTextBox.Text = "Password";
                    passwordTextBox.PasswordChar = '\0';
                    passwordTextBox.ForeColor = Color.Gray;
                }
            };
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            loginButton.Enabled = false;
            registerLabel.Enabled = false;
            if (ValidateLoginText())
            {
                if(ctrl.login(usernameTextBox.Text, passwordTextBox.Text))
                {
                    
                    if (usernameTextBox.Text.Equals("admin"))
                    {
                        GeneralForm gf = new GeneralForm(ctrl, "admin");
                        gf.Show();
                        this.Hide();
                    }
                    else
                    {
                        GeneralForm gf = new GeneralForm(ctrl, "normal");
                        gf.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid account!");
                }
            }
            loginButton.Enabled = true;
            registerLabel.Enabled = true;
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            //new RegisterForm(ctrl).ShowDialog();
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "PDF files|*.pdf|Microsoft Word files|*.doc;*.docx|Power Point files|*.ppt;*.pptx";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(theDialog.FileName.ToString());
            }
        }
        private bool ValidateLoginText()
        {
            if (string.IsNullOrEmpty(usernameTextBox.Text))
            {
                MessageBox.Show("Please enter a valid username");
                return false;
            }
            if (string.IsNullOrEmpty(passwordTextBox.Text))
            {
                MessageBox.Show("Please enter a valid password");
                return false;
            }
            return true;
        }
    }
}
