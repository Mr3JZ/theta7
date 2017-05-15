namespace Client.View
{
    partial class RegisterForm
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
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.affiliationTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.websiteTextBox = new System.Windows.Forms.TextBox();
            this.PCMemberCheckBox = new System.Windows.Forms.CheckBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.affiliationLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.websiteLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(65, 56);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(199, 20);
            this.usernameTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(65, 95);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(199, 20);
            this.passwordTextBox.TabIndex = 1;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(65, 134);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(199, 20);
            this.nameTextBox.TabIndex = 2;
            // 
            // affiliationTextBox
            // 
            this.affiliationTextBox.Location = new System.Drawing.Point(65, 173);
            this.affiliationTextBox.Name = "affiliationTextBox";
            this.affiliationTextBox.Size = new System.Drawing.Size(199, 20);
            this.affiliationTextBox.TabIndex = 3;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(65, 212);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(199, 20);
            this.emailTextBox.TabIndex = 4;
            // 
            // websiteTextBox
            // 
            this.websiteTextBox.Location = new System.Drawing.Point(65, 251);
            this.websiteTextBox.Name = "websiteTextBox";
            this.websiteTextBox.Size = new System.Drawing.Size(199, 20);
            this.websiteTextBox.TabIndex = 5;
            // 
            // PCMemberCheckBox
            // 
            this.PCMemberCheckBox.AutoSize = true;
            this.PCMemberCheckBox.Location = new System.Drawing.Point(65, 281);
            this.PCMemberCheckBox.Name = "PCMemberCheckBox";
            this.PCMemberCheckBox.Size = new System.Drawing.Size(78, 17);
            this.PCMemberCheckBox.TabIndex = 7;
            this.PCMemberCheckBox.Text = "PCMember";
            this.PCMemberCheckBox.UseVisualStyleBackColor = true;
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(164, 277);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(100, 23);
            this.registerButton.TabIndex = 8;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(62, 40);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 13);
            this.usernameLabel.TabIndex = 9;
            this.usernameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(62, 79);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 10;
            this.passwordLabel.Text = "Password";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(62, 118);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 11;
            this.nameLabel.Text = "Name";
            // 
            // affiliationLabel
            // 
            this.affiliationLabel.AutoSize = true;
            this.affiliationLabel.Location = new System.Drawing.Point(61, 157);
            this.affiliationLabel.Name = "affiliationLabel";
            this.affiliationLabel.Size = new System.Drawing.Size(49, 13);
            this.affiliationLabel.TabIndex = 12;
            this.affiliationLabel.Text = "Affiliation";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(62, 196);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(32, 13);
            this.emailLabel.TabIndex = 13;
            this.emailLabel.Text = "Email";
            // 
            // websiteLabel
            // 
            this.websiteLabel.AutoSize = true;
            this.websiteLabel.Location = new System.Drawing.Point(62, 235);
            this.websiteLabel.Name = "websiteLabel";
            this.websiteLabel.Size = new System.Drawing.Size(46, 13);
            this.websiteLabel.TabIndex = 14;
            this.websiteLabel.Text = "Website";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 345);
            this.Controls.Add(this.websiteLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.affiliationLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.PCMemberCheckBox);
            this.Controls.Add(this.websiteTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.affiliationTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox affiliationTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox websiteTextBox;
        private System.Windows.Forms.CheckBox PCMemberCheckBox;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label affiliationLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label websiteLabel;
    }
}