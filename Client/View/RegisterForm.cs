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
    public partial class RegisterForm : Form
    {
        private bool waterMarkUsernameActive;
        private bool waterMarkPasswordActive;
        private bool waterMarkNameActive;
        private bool waterMarkAffiliationActive;
        private bool waterMarkEmailActive;
        private bool waterMarkWebsiteActive;
        private ClientController ctrl;
        public RegisterForm(ClientController ctrl)
        {
            this.ctrl = ctrl;

            InitializeComponent();
            initUsernameTextBox();
            initPasswordTextBox();
            initNameTextBox();
            initAffiliationTextBox();
            initEmailTextBox();
            initWebsiteTextBox();
        }
        private void initUsernameTextBox()
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
        private void initPasswordTextBox()
        {
            waterMarkPasswordActive = true;
            passwordLabel.Hide();
            passwordTextBox.ForeColor = Color.Gray;
            passwordTextBox.PasswordChar = '\0';
            passwordTextBox.Text = "Password";
            passwordTextBox.GotFocus += (source, e) =>
            {
                if (waterMarkPasswordActive)
                {
                    waterMarkPasswordActive = false;
                    passwordLabel.Show();
                    passwordTextBox.PasswordChar = '*';
                    passwordTextBox.Text = "";
                    passwordTextBox.ForeColor = Color.Black;
                }
            };
            passwordTextBox.LostFocus += (source, e) =>
            {
                if (!waterMarkPasswordActive && string.IsNullOrEmpty(passwordTextBox.Text))
                {
                    waterMarkPasswordActive = true;
                    passwordLabel.Hide();
                    passwordTextBox.PasswordChar = '\0';
                    passwordTextBox.Text = "Password";
                    passwordTextBox.ForeColor = Color.Gray;
                }
            };
        }
        private void initNameTextBox()
        {
            waterMarkNameActive = true;
            nameLabel.Hide();
            nameTextBox.ForeColor = Color.Gray;
            nameTextBox.Text = "Name";
            nameTextBox.GotFocus += (source, e) =>
            {
                if (waterMarkNameActive)
                {
                    waterMarkNameActive = false;
                    nameLabel.Show();
                    nameTextBox.Text = "";
                    nameTextBox.ForeColor = Color.Black;
                }
            };
            nameTextBox.LostFocus += (source, e) =>
            {
                if (!waterMarkNameActive && string.IsNullOrEmpty(nameTextBox.Text))
                {
                    waterMarkNameActive = true;
                    nameLabel.Hide();
                    nameTextBox.Text = "Name";
                    nameTextBox.ForeColor = Color.Gray;
                }
            };
        }
        private void initAffiliationTextBox()
        {
            waterMarkAffiliationActive = true;
            affiliationLabel.Hide();
            affiliationTextBox.ForeColor = Color.Gray;
            affiliationTextBox.Text = "Affiliation";
            affiliationTextBox.GotFocus += (source, e) =>
            {
                if (waterMarkAffiliationActive)
                {
                    waterMarkAffiliationActive = false;
                    affiliationLabel.Show();
                    affiliationTextBox.Text = "";
                    affiliationTextBox.ForeColor = Color.Black;
                }
            };
            affiliationTextBox.LostFocus += (source, e) =>
            {
                if (!waterMarkAffiliationActive && string.IsNullOrEmpty(affiliationTextBox.Text))
                {
                    waterMarkAffiliationActive = true;
                    affiliationLabel.Hide();
                    affiliationTextBox.Text = "Affiliation";
                    affiliationTextBox.ForeColor = Color.Gray;
                }
            };
        }
        private void initEmailTextBox()
        {
            waterMarkEmailActive = true;
            emailLabel.Hide();
            emailTextBox.ForeColor = Color.Gray;
            emailTextBox.Text = "Email";
            emailTextBox.GotFocus += (source, e) =>
            {
                if (waterMarkEmailActive)
                {
                    waterMarkEmailActive = false;
                    emailLabel.Show();
                    emailTextBox.Text = "";
                    emailTextBox.ForeColor = Color.Black;
                }
            };
            emailTextBox.LostFocus += (source, e) =>
            {
                if (!waterMarkEmailActive && string.IsNullOrEmpty(emailTextBox.Text))
                {
                    waterMarkEmailActive = true;
                    emailLabel.Hide();
                    emailTextBox.Text = "Email";
                    emailTextBox.ForeColor = Color.Gray;
                }
            };
        }
        private void initWebsiteTextBox()
        {
            waterMarkWebsiteActive = true;
            websiteLabel.Hide();
            websiteTextBox.ForeColor = Color.Gray;
            websiteTextBox.Text = "Website";
            websiteTextBox.GotFocus += (source, e) =>
            {
                if (waterMarkWebsiteActive)
                {
                    waterMarkWebsiteActive = false;
                    websiteLabel.Show();
                    websiteTextBox.Text = "";
                    websiteTextBox.ForeColor = Color.Black;
                }
            };
            websiteTextBox.LostFocus += (source, e) =>
            {
                if (!waterMarkWebsiteActive && string.IsNullOrEmpty(websiteTextBox.Text))
                {
                    waterMarkWebsiteActive = true;
                    websiteLabel.Hide();
                    websiteTextBox.Text = "Website";
                    websiteTextBox.ForeColor = Color.Gray;
                }
            };
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            bool PCMember = false;
            if (PCMemberCheckBox.CheckState == CheckState.Checked)
                PCMember = true;

            if (ValidateRegisterText())
            {
                if(ctrl.register(usernameTextBox.Text, passwordTextBox.Text,nameTextBox.Text,affiliationTextBox.Text,emailTextBox.Text,websiteTextBox.Text,PCMember))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid account");
                }
            }
        }
        private bool ValidateRegisterText()
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
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Please enter a valid name");
                return false;
            }
            if (string.IsNullOrEmpty(affiliationTextBox.Text))
            {
                MessageBox.Show("Please enter a valid affiliation");
                return false;
            }
            if (string.IsNullOrEmpty(emailTextBox.Text))
            {
                MessageBox.Show("Please enter a valid email");
                return false;
            }
            if (string.IsNullOrEmpty(websiteTextBox.Text))
            {
                MessageBox.Show("Please enter a valid website");
                return false;
            }
            return true;
        }
    }
}
