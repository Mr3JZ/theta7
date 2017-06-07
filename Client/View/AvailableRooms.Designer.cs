namespace Client.View
{
    partial class AvailableRooms
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
            this.labelName = new System.Windows.Forms.Label();
            this.labelCapacity = new System.Windows.Forms.Label();
            this.labelStreet = new System.Windows.Forms.Label();
            this.labelPostalCode = new System.Windows.Forms.Label();
            this.labelBeginDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxStreet = new System.Windows.Forms.TextBox();
            this.textBoxPostalCode = new System.Windows.Forms.TextBox();
            this.dateTimePickerBegin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.buttonAddRoom = new System.Windows.Forms.Button();
            this.dataGridViewAvailableRooms = new System.Windows.Forms.DataGridView();
            this.buttonAllRooms = new System.Windows.Forms.Button();
            this.numericUpDownCapacity = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAvailableRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCapacity)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(29, 24);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name";
            // 
            // labelCapacity
            // 
            this.labelCapacity.AutoSize = true;
            this.labelCapacity.Location = new System.Drawing.Point(29, 63);
            this.labelCapacity.Name = "labelCapacity";
            this.labelCapacity.Size = new System.Drawing.Size(48, 13);
            this.labelCapacity.TabIndex = 1;
            this.labelCapacity.Text = "Capacity";
            // 
            // labelStreet
            // 
            this.labelStreet.AutoSize = true;
            this.labelStreet.Location = new System.Drawing.Point(29, 108);
            this.labelStreet.Name = "labelStreet";
            this.labelStreet.Size = new System.Drawing.Size(35, 13);
            this.labelStreet.TabIndex = 2;
            this.labelStreet.Text = "Street";
            // 
            // labelPostalCode
            // 
            this.labelPostalCode.AutoSize = true;
            this.labelPostalCode.Location = new System.Drawing.Point(29, 151);
            this.labelPostalCode.Name = "labelPostalCode";
            this.labelPostalCode.Size = new System.Drawing.Size(64, 13);
            this.labelPostalCode.TabIndex = 3;
            this.labelPostalCode.Text = "Postal Code";
            // 
            // labelBeginDate
            // 
            this.labelBeginDate.AutoSize = true;
            this.labelBeginDate.Location = new System.Drawing.Point(32, 197);
            this.labelBeginDate.Name = "labelBeginDate";
            this.labelBeginDate.Size = new System.Drawing.Size(86, 13);
            this.labelBeginDate.TabIndex = 4;
            this.labelBeginDate.Text = "Begin Date Hour";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(32, 246);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(78, 13);
            this.labelEndDate.TabIndex = 5;
            this.labelEndDate.Text = "End Date Hour";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(142, 24);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(130, 20);
            this.textBoxName.TabIndex = 6;
            // 
            // textBoxStreet
            // 
            this.textBoxStreet.Location = new System.Drawing.Point(142, 108);
            this.textBoxStreet.Name = "textBoxStreet";
            this.textBoxStreet.Size = new System.Drawing.Size(130, 20);
            this.textBoxStreet.TabIndex = 9;
            // 
            // textBoxPostalCode
            // 
            this.textBoxPostalCode.Location = new System.Drawing.Point(142, 151);
            this.textBoxPostalCode.Name = "textBoxPostalCode";
            this.textBoxPostalCode.Size = new System.Drawing.Size(130, 20);
            this.textBoxPostalCode.TabIndex = 11;
            // 
            // dateTimePickerBegin
            // 
            this.dateTimePickerBegin.Location = new System.Drawing.Point(142, 197);
            this.dateTimePickerBegin.Name = "dateTimePickerBegin";
            this.dateTimePickerBegin.Size = new System.Drawing.Size(130, 20);
            this.dateTimePickerBegin.TabIndex = 12;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(142, 246);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(130, 20);
            this.dateTimePickerEnd.TabIndex = 13;
            // 
            // buttonAddRoom
            // 
            this.buttonAddRoom.Location = new System.Drawing.Point(295, 290);
            this.buttonAddRoom.Name = "buttonAddRoom";
            this.buttonAddRoom.Size = new System.Drawing.Size(124, 23);
            this.buttonAddRoom.TabIndex = 14;
            this.buttonAddRoom.Text = "Add Room";
            this.buttonAddRoom.UseVisualStyleBackColor = true;
            this.buttonAddRoom.Click += new System.EventHandler(this.buttonAddRoom_Click);
            // 
            // dataGridViewAvailableRooms
            // 
            this.dataGridViewAvailableRooms.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewAvailableRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAvailableRooms.Location = new System.Drawing.Point(295, 24);
            this.dataGridViewAvailableRooms.Name = "dataGridViewAvailableRooms";
            this.dataGridViewAvailableRooms.Size = new System.Drawing.Size(267, 242);
            this.dataGridViewAvailableRooms.TabIndex = 15;
            // 
            // buttonAllRooms
            // 
            this.buttonAllRooms.Location = new System.Drawing.Point(425, 290);
            this.buttonAllRooms.Name = "buttonAllRooms";
            this.buttonAllRooms.Size = new System.Drawing.Size(137, 23);
            this.buttonAllRooms.TabIndex = 16;
            this.buttonAllRooms.Text = "Submit";
            this.buttonAllRooms.UseVisualStyleBackColor = true;
            this.buttonAllRooms.Click += new System.EventHandler(this.buttonAllRooms_Click);
            // 
            // numericUpDownCapacity
            // 
            this.numericUpDownCapacity.Location = new System.Drawing.Point(142, 63);
            this.numericUpDownCapacity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownCapacity.Name = "numericUpDownCapacity";
            this.numericUpDownCapacity.Size = new System.Drawing.Size(130, 20);
            this.numericUpDownCapacity.TabIndex = 17;
            // 
            // AvailableRooms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 357);
            this.Controls.Add(this.numericUpDownCapacity);
            this.Controls.Add(this.buttonAllRooms);
            this.Controls.Add(this.dataGridViewAvailableRooms);
            this.Controls.Add(this.buttonAddRoom);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerBegin);
            this.Controls.Add(this.textBoxPostalCode);
            this.Controls.Add(this.textBoxStreet);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelBeginDate);
            this.Controls.Add(this.labelPostalCode);
            this.Controls.Add(this.labelStreet);
            this.Controls.Add(this.labelCapacity);
            this.Controls.Add(this.labelName);
            this.Name = "AvailableRooms";
            this.Text = "AvailableRooms";
            this.Load += new System.EventHandler(this.AvailableRooms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAvailableRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCapacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelCapacity;
        private System.Windows.Forms.Label labelStreet;
        private System.Windows.Forms.Label labelPostalCode;
        private System.Windows.Forms.Label labelBeginDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxStreet;
        private System.Windows.Forms.TextBox textBoxPostalCode;
        private System.Windows.Forms.DateTimePicker dateTimePickerBegin;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Button buttonAddRoom;
        private System.Windows.Forms.DataGridView dataGridViewAvailableRooms;
        private System.Windows.Forms.Button buttonAllRooms;
        private System.Windows.Forms.NumericUpDown numericUpDownCapacity;
    }
}