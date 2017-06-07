namespace Client.View
{
    partial class GeneralForm
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
            this.tabControlGeneral = new System.Windows.Forms.TabControl();
            this.tabPageAllConferences = new System.Windows.Forms.TabPage();
            this.btnRefreshAllConferences = new System.Windows.Forms.Button();
            this.buttonLogout1 = new System.Windows.Forms.Button();
            this.buttonViewDetails = new System.Windows.Forms.Button();
            this.buttonCreateConference = new System.Windows.Forms.Button();
            this.dataGridViewAllConferences = new System.Windows.Forms.DataGridView();
            this.tabPageNotificaions = new System.Windows.Forms.TabPage();
            this.buttonDeleteMessage = new System.Windows.Forms.Button();
            this.buttonReadMessage = new System.Windows.Forms.Button();
            this.buttonLogout2 = new System.Windows.Forms.Button();
            this.listBoxNotifications = new System.Windows.Forms.ListBox();
            this.tabPageMyConferences = new System.Windows.Forms.TabPage();
            this.btnRefreshMyConferences = new System.Windows.Forms.Button();
            this.buttonViewDetailsMy = new System.Windows.Forms.Button();
            this.buttonLogout3 = new System.Windows.Forms.Button();
            this.dataGridViewMyConferences = new System.Windows.Forms.DataGridView();
            this.tabControlGeneral.SuspendLayout();
            this.tabPageAllConferences.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllConferences)).BeginInit();
            this.tabPageNotificaions.SuspendLayout();
            this.tabPageMyConferences.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMyConferences)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlGeneral
            // 
            this.tabControlGeneral.Controls.Add(this.tabPageAllConferences);
            this.tabControlGeneral.Controls.Add(this.tabPageNotificaions);
            this.tabControlGeneral.Controls.Add(this.tabPageMyConferences);
            this.tabControlGeneral.Location = new System.Drawing.Point(0, 0);
            this.tabControlGeneral.Name = "tabControlGeneral";
            this.tabControlGeneral.SelectedIndex = 0;
            this.tabControlGeneral.Size = new System.Drawing.Size(600, 350);
            this.tabControlGeneral.TabIndex = 0;
            // 
            // tabPageAllConferences
            // 
            this.tabPageAllConferences.Controls.Add(this.btnRefreshAllConferences);
            this.tabPageAllConferences.Controls.Add(this.buttonLogout1);
            this.tabPageAllConferences.Controls.Add(this.buttonViewDetails);
            this.tabPageAllConferences.Controls.Add(this.buttonCreateConference);
            this.tabPageAllConferences.Controls.Add(this.dataGridViewAllConferences);
            this.tabPageAllConferences.Location = new System.Drawing.Point(4, 22);
            this.tabPageAllConferences.Name = "tabPageAllConferences";
            this.tabPageAllConferences.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAllConferences.Size = new System.Drawing.Size(592, 324);
            this.tabPageAllConferences.TabIndex = 0;
            this.tabPageAllConferences.Text = "All conferences";
            this.tabPageAllConferences.UseVisualStyleBackColor = true;
            this.tabPageAllConferences.Enter += new System.EventHandler(this.tabPageAllConferences_Enter);
            // 
            // btnRefreshAllConferences
            // 
            this.btnRefreshAllConferences.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshAllConferences.Location = new System.Drawing.Point(420, 41);
            this.btnRefreshAllConferences.Name = "btnRefreshAllConferences";
            this.btnRefreshAllConferences.Size = new System.Drawing.Size(162, 25);
            this.btnRefreshAllConferences.TabIndex = 1;
            this.btnRefreshAllConferences.Text = "Refresh";
            this.btnRefreshAllConferences.UseVisualStyleBackColor = true;
            this.btnRefreshAllConferences.Click += new System.EventHandler(this.btnRefreshAllConferences_Click);
            // 
            // buttonLogout1
            // 
            this.buttonLogout1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLogout1.Location = new System.Drawing.Point(420, 289);
            this.buttonLogout1.Name = "buttonLogout1";
            this.buttonLogout1.Size = new System.Drawing.Size(162, 25);
            this.buttonLogout1.TabIndex = 3;
            this.buttonLogout1.Text = "Logout";
            this.buttonLogout1.UseVisualStyleBackColor = true;
            this.buttonLogout1.Click += new System.EventHandler(this.buttonLogout1_Click);
            // 
            // buttonViewDetails
            // 
            this.buttonViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonViewDetails.Location = new System.Drawing.Point(420, 10);
            this.buttonViewDetails.Name = "buttonViewDetails";
            this.buttonViewDetails.Size = new System.Drawing.Size(162, 25);
            this.buttonViewDetails.TabIndex = 2;
            this.buttonViewDetails.Text = "View conference details";
            this.buttonViewDetails.UseVisualStyleBackColor = true;
            this.buttonViewDetails.Click += new System.EventHandler(this.buttonViewDetails_Click);
            // 
            // buttonCreateConference
            // 
            this.buttonCreateConference.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCreateConference.Location = new System.Drawing.Point(420, 10);
            this.buttonCreateConference.Name = "buttonCreateConference";
            this.buttonCreateConference.Size = new System.Drawing.Size(162, 25);
            this.buttonCreateConference.TabIndex = 1;
            this.buttonCreateConference.Text = "Create new conference";
            this.buttonCreateConference.UseVisualStyleBackColor = true;
            this.buttonCreateConference.Click += new System.EventHandler(this.buttonCreateConference_Click);
            // 
            // dataGridViewAllConferences
            // 
            this.dataGridViewAllConferences.AllowUserToAddRows = false;
            this.dataGridViewAllConferences.AllowUserToDeleteRows = false;
            this.dataGridViewAllConferences.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewAllConferences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllConferences.Location = new System.Drawing.Point(10, 10);
            this.dataGridViewAllConferences.MultiSelect = false;
            this.dataGridViewAllConferences.Name = "dataGridViewAllConferences";
            this.dataGridViewAllConferences.RowHeadersVisible = false;
            this.dataGridViewAllConferences.Size = new System.Drawing.Size(400, 304);
            this.dataGridViewAllConferences.TabIndex = 0;
            // 
            // tabPageNotificaions
            // 
            this.tabPageNotificaions.Controls.Add(this.buttonDeleteMessage);
            this.tabPageNotificaions.Controls.Add(this.buttonReadMessage);
            this.tabPageNotificaions.Controls.Add(this.buttonLogout2);
            this.tabPageNotificaions.Controls.Add(this.listBoxNotifications);
            this.tabPageNotificaions.Location = new System.Drawing.Point(4, 22);
            this.tabPageNotificaions.Name = "tabPageNotificaions";
            this.tabPageNotificaions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNotificaions.Size = new System.Drawing.Size(592, 324);
            this.tabPageNotificaions.TabIndex = 1;
            this.tabPageNotificaions.Text = "Notifications";
            this.tabPageNotificaions.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteMessage
            // 
            this.buttonDeleteMessage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDeleteMessage.Location = new System.Drawing.Point(420, 45);
            this.buttonDeleteMessage.Name = "buttonDeleteMessage";
            this.buttonDeleteMessage.Size = new System.Drawing.Size(162, 25);
            this.buttonDeleteMessage.TabIndex = 3;
            this.buttonDeleteMessage.Text = "Delete message";
            this.buttonDeleteMessage.UseVisualStyleBackColor = true;
            this.buttonDeleteMessage.Click += new System.EventHandler(this.buttonDeleteMessage_Click);
            // 
            // buttonReadMessage
            // 
            this.buttonReadMessage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonReadMessage.Location = new System.Drawing.Point(420, 10);
            this.buttonReadMessage.Name = "buttonReadMessage";
            this.buttonReadMessage.Size = new System.Drawing.Size(162, 25);
            this.buttonReadMessage.TabIndex = 2;
            this.buttonReadMessage.Text = "Read message";
            this.buttonReadMessage.UseVisualStyleBackColor = true;
            this.buttonReadMessage.Click += new System.EventHandler(this.buttonReadMessage_Click);
            // 
            // buttonLogout2
            // 
            this.buttonLogout2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLogout2.Location = new System.Drawing.Point(420, 288);
            this.buttonLogout2.Name = "buttonLogout2";
            this.buttonLogout2.Size = new System.Drawing.Size(162, 25);
            this.buttonLogout2.TabIndex = 1;
            this.buttonLogout2.Text = "Logout";
            this.buttonLogout2.UseVisualStyleBackColor = true;
            this.buttonLogout2.Click += new System.EventHandler(this.buttonLogout2_Click);
            // 
            // listBoxNotifications
            // 
            this.listBoxNotifications.FormattingEnabled = true;
            this.listBoxNotifications.Location = new System.Drawing.Point(10, 10);
            this.listBoxNotifications.Name = "listBoxNotifications";
            this.listBoxNotifications.Size = new System.Drawing.Size(400, 303);
            this.listBoxNotifications.TabIndex = 0;
            // 
            // tabPageMyConferences
            // 
            this.tabPageMyConferences.Controls.Add(this.btnRefreshMyConferences);
            this.tabPageMyConferences.Controls.Add(this.buttonViewDetailsMy);
            this.tabPageMyConferences.Controls.Add(this.buttonLogout3);
            this.tabPageMyConferences.Controls.Add(this.dataGridViewMyConferences);
            this.tabPageMyConferences.Location = new System.Drawing.Point(4, 22);
            this.tabPageMyConferences.Name = "tabPageMyConferences";
            this.tabPageMyConferences.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMyConferences.Size = new System.Drawing.Size(592, 324);
            this.tabPageMyConferences.TabIndex = 2;
            this.tabPageMyConferences.Text = "MyConferences";
            this.tabPageMyConferences.UseVisualStyleBackColor = true;
            this.tabPageMyConferences.Enter += new System.EventHandler(this.tabPageMyConferences_Enter);
            // 
            // btnRefreshMyConferences
            // 
            this.btnRefreshMyConferences.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshMyConferences.Location = new System.Drawing.Point(420, 41);
            this.btnRefreshMyConferences.Name = "btnRefreshMyConferences";
            this.btnRefreshMyConferences.Size = new System.Drawing.Size(162, 25);
            this.btnRefreshMyConferences.TabIndex = 3;
            this.btnRefreshMyConferences.Text = "Refresh";
            this.btnRefreshMyConferences.UseVisualStyleBackColor = true;
            this.btnRefreshMyConferences.Click += new System.EventHandler(this.btnRefreshMyConferences_Click);
            // 
            // buttonViewDetailsMy
            // 
            this.buttonViewDetailsMy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonViewDetailsMy.Location = new System.Drawing.Point(420, 10);
            this.buttonViewDetailsMy.Name = "buttonViewDetailsMy";
            this.buttonViewDetailsMy.Size = new System.Drawing.Size(162, 25);
            this.buttonViewDetailsMy.TabIndex = 2;
            this.buttonViewDetailsMy.Text = "View conference details";
            this.buttonViewDetailsMy.UseVisualStyleBackColor = true;
            this.buttonViewDetailsMy.Click += new System.EventHandler(this.buttonViewDetailsMy_Click);
            // 
            // buttonLogout3
            // 
            this.buttonLogout3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLogout3.Location = new System.Drawing.Point(420, 289);
            this.buttonLogout3.Name = "buttonLogout3";
            this.buttonLogout3.Size = new System.Drawing.Size(162, 25);
            this.buttonLogout3.TabIndex = 1;
            this.buttonLogout3.Text = "Logout";
            this.buttonLogout3.UseVisualStyleBackColor = true;
            this.buttonLogout3.Click += new System.EventHandler(this.buttonLogout3_Click);
            // 
            // dataGridViewMyConferences
            // 
            this.dataGridViewMyConferences.AllowUserToAddRows = false;
            this.dataGridViewMyConferences.AllowUserToDeleteRows = false;
            this.dataGridViewMyConferences.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewMyConferences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMyConferences.Location = new System.Drawing.Point(10, 10);
            this.dataGridViewMyConferences.Name = "dataGridViewMyConferences";
            this.dataGridViewMyConferences.RowHeadersVisible = false;
            this.dataGridViewMyConferences.Size = new System.Drawing.Size(400, 304);
            this.dataGridViewMyConferences.TabIndex = 0;
            this.dataGridViewMyConferences.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMyConferences_CellContentClick);
            // 
            // GeneralForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(this.tabControlGeneral);
            this.Name = "GeneralForm";
            this.Text = "GeneralForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GeneralForm_FormClosed);
            this.tabControlGeneral.ResumeLayout(false);
            this.tabPageAllConferences.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllConferences)).EndInit();
            this.tabPageNotificaions.ResumeLayout(false);
            this.tabPageMyConferences.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMyConferences)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlGeneral;
        private System.Windows.Forms.TabPage tabPageAllConferences;
        private System.Windows.Forms.Button buttonLogout1;
        private System.Windows.Forms.Button buttonViewDetails;
        private System.Windows.Forms.Button buttonCreateConference;
        private System.Windows.Forms.DataGridView dataGridViewAllConferences;
        private System.Windows.Forms.TabPage tabPageNotificaions;
        private System.Windows.Forms.Button buttonDeleteMessage;
        private System.Windows.Forms.Button buttonReadMessage;
        private System.Windows.Forms.Button buttonLogout2;
        private System.Windows.Forms.ListBox listBoxNotifications;
        private System.Windows.Forms.TabPage tabPageMyConferences;
        private System.Windows.Forms.Button buttonViewDetailsMy;
        private System.Windows.Forms.Button buttonLogout3;
        private System.Windows.Forms.DataGridView dataGridViewMyConferences;
        private System.Windows.Forms.Button btnRefreshAllConferences;
        private System.Windows.Forms.Button btnRefreshMyConferences;
    }
}