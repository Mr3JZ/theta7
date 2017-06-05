namespace Client.View
{
    partial class ReviewForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.CBVerdict = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TBComments = new System.Windows.Forms.RichTextBox();
            this.BtnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Verdict";
            // 
            // CBVerdict
            // 
            this.CBVerdict.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBVerdict.FormattingEnabled = true;
            this.CBVerdict.Location = new System.Drawing.Point(12, 25);
            this.CBVerdict.Name = "CBVerdict";
            this.CBVerdict.Size = new System.Drawing.Size(291, 21);
            this.CBVerdict.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Comments";
            // 
            // TBComments
            // 
            this.TBComments.Location = new System.Drawing.Point(12, 84);
            this.TBComments.Name = "TBComments";
            this.TBComments.Size = new System.Drawing.Size(291, 130);
            this.TBComments.TabIndex = 3;
            this.TBComments.Text = "";
            // 
            // BtnSubmit
            // 
            this.BtnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSubmit.Location = new System.Drawing.Point(115, 223);
            this.BtnSubmit.Name = "BtnSubmit";
            this.BtnSubmit.Size = new System.Drawing.Size(90, 25);
            this.BtnSubmit.TabIndex = 4;
            this.BtnSubmit.Text = "Submit";
            this.BtnSubmit.UseVisualStyleBackColor = true;
            this.BtnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // ReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 255);
            this.Controls.Add(this.BtnSubmit);
            this.Controls.Add(this.TBComments);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CBVerdict);
            this.Controls.Add(this.label1);
            this.Name = "ReviewForm";
            this.Text = "ReviewForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBVerdict;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox TBComments;
        private System.Windows.Forms.Button BtnSubmit;
        private System.Windows.Forms.Label label1;
    }
}