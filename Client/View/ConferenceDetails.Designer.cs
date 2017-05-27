namespace Client.View
{
    partial class ConferenceDetails
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageParticipant = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonRemovePaper = new System.Windows.Forms.Button();
            this.buttonUpdatePaper = new System.Windows.Forms.Button();
            this.buttonAddComplete = new System.Windows.Forms.Button();
            this.buttonAddWithAbs = new System.Windows.Forms.Button();
            this.buttonUploadAbstract = new System.Windows.Forms.Button();
            this.textBoxPaperFilepath = new System.Windows.Forms.TextBox();
            this.textBoxPaperSubdomain = new System.Windows.Forms.TextBox();
            this.textBoxPaperDomain = new System.Windows.Forms.TextBox();
            this.textBoxPaperName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxTopic = new System.Windows.Forms.ComboBox();
            this.dataGridViewMyReviews = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewMyPapers = new System.Windows.Forms.DataGridView();
            this.tabPagePCMember = new System.Windows.Forms.TabPage();
            this.buttonReadFullPaper = new System.Windows.Forms.Button();
            this.buttonReadPaperAbstract = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridViewUploadedPapers = new System.Windows.Forms.DataGridView();
            this.tabPageChair = new System.Windows.Forms.TabPage();
            this.comboBoxBidding = new System.Windows.Forms.ComboBox();
            this.buttonBidding = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxEvaluation = new System.Windows.Forms.ComboBox();
            this.buttonEvaluate = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPageConferenceDetailed = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPageParticipant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMyReviews)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMyPapers)).BeginInit();
            this.tabPagePCMember.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUploadedPapers)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageParticipant);
            this.tabControl1.Controls.Add(this.tabPagePCMember);
            this.tabControl1.Controls.Add(this.tabPageChair);
            this.tabControl1.Controls.Add(this.tabPageConferenceDetailed);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(600, 400);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageParticipant
            // 
            this.tabPageParticipant.Controls.Add(this.label7);
            this.tabPageParticipant.Controls.Add(this.label6);
            this.tabPageParticipant.Controls.Add(this.label5);
            this.tabPageParticipant.Controls.Add(this.label4);
            this.tabPageParticipant.Controls.Add(this.buttonRemovePaper);
            this.tabPageParticipant.Controls.Add(this.buttonUpdatePaper);
            this.tabPageParticipant.Controls.Add(this.buttonAddComplete);
            this.tabPageParticipant.Controls.Add(this.buttonAddWithAbs);
            this.tabPageParticipant.Controls.Add(this.buttonUploadAbstract);
            this.tabPageParticipant.Controls.Add(this.textBoxPaperFilepath);
            this.tabPageParticipant.Controls.Add(this.textBoxPaperSubdomain);
            this.tabPageParticipant.Controls.Add(this.textBoxPaperDomain);
            this.tabPageParticipant.Controls.Add(this.textBoxPaperName);
            this.tabPageParticipant.Controls.Add(this.label3);
            this.tabPageParticipant.Controls.Add(this.comboBoxTopic);
            this.tabPageParticipant.Controls.Add(this.dataGridViewMyReviews);
            this.tabPageParticipant.Controls.Add(this.label2);
            this.tabPageParticipant.Controls.Add(this.label1);
            this.tabPageParticipant.Controls.Add(this.dataGridViewMyPapers);
            this.tabPageParticipant.Location = new System.Drawing.Point(4, 22);
            this.tabPageParticipant.Name = "tabPageParticipant";
            this.tabPageParticipant.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageParticipant.Size = new System.Drawing.Size(592, 374);
            this.tabPageParticipant.TabIndex = 0;
            this.tabPageParticipant.Text = "Participant";
            this.tabPageParticipant.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(390, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Complete paper filepath:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(405, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Paper subdomain:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(412, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Paper domain:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(417, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Paper name:";
            // 
            // buttonRemovePaper
            // 
            this.buttonRemovePaper.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRemovePaper.Location = new System.Drawing.Point(456, 342);
            this.buttonRemovePaper.Name = "buttonRemovePaper";
            this.buttonRemovePaper.Size = new System.Drawing.Size(126, 22);
            this.buttonRemovePaper.TabIndex = 14;
            this.buttonRemovePaper.Text = "Remove paper";
            this.buttonRemovePaper.UseVisualStyleBackColor = true;
            // 
            // buttonUpdatePaper
            // 
            this.buttonUpdatePaper.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonUpdatePaper.Location = new System.Drawing.Point(320, 342);
            this.buttonUpdatePaper.Name = "buttonUpdatePaper";
            this.buttonUpdatePaper.Size = new System.Drawing.Size(126, 22);
            this.buttonUpdatePaper.TabIndex = 13;
            this.buttonUpdatePaper.Text = "Update paper";
            this.buttonUpdatePaper.UseVisualStyleBackColor = true;
            // 
            // buttonAddComplete
            // 
            this.buttonAddComplete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAddComplete.Location = new System.Drawing.Point(456, 310);
            this.buttonAddComplete.Name = "buttonAddComplete";
            this.buttonAddComplete.Size = new System.Drawing.Size(126, 22);
            this.buttonAddComplete.TabIndex = 12;
            this.buttonAddComplete.Text = "Add complete paper";
            this.buttonAddComplete.UseVisualStyleBackColor = true;
            // 
            // buttonAddWithAbs
            // 
            this.buttonAddWithAbs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAddWithAbs.Location = new System.Drawing.Point(320, 310);
            this.buttonAddWithAbs.Name = "buttonAddWithAbs";
            this.buttonAddWithAbs.Size = new System.Drawing.Size(126, 22);
            this.buttonAddWithAbs.TabIndex = 11;
            this.buttonAddWithAbs.Text = "Add abstract only";
            this.buttonAddWithAbs.UseVisualStyleBackColor = true;
            // 
            // buttonUploadAbstract
            // 
            this.buttonUploadAbstract.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonUploadAbstract.Location = new System.Drawing.Point(320, 260);
            this.buttonUploadAbstract.Name = "buttonUploadAbstract";
            this.buttonUploadAbstract.Size = new System.Drawing.Size(262, 22);
            this.buttonUploadAbstract.TabIndex = 10;
            this.buttonUploadAbstract.Text = "Upload abstract";
            this.buttonUploadAbstract.UseVisualStyleBackColor = true;
            // 
            // textBoxPaperFilepath
            // 
            this.textBoxPaperFilepath.Location = new System.Drawing.Point(320, 230);
            this.textBoxPaperFilepath.Name = "textBoxPaperFilepath";
            this.textBoxPaperFilepath.Size = new System.Drawing.Size(262, 20);
            this.textBoxPaperFilepath.TabIndex = 9;
            // 
            // textBoxPaperSubdomain
            // 
            this.textBoxPaperSubdomain.Location = new System.Drawing.Point(320, 180);
            this.textBoxPaperSubdomain.Name = "textBoxPaperSubdomain";
            this.textBoxPaperSubdomain.Size = new System.Drawing.Size(262, 20);
            this.textBoxPaperSubdomain.TabIndex = 8;
            // 
            // textBoxPaperDomain
            // 
            this.textBoxPaperDomain.Location = new System.Drawing.Point(320, 130);
            this.textBoxPaperDomain.Name = "textBoxPaperDomain";
            this.textBoxPaperDomain.Size = new System.Drawing.Size(262, 20);
            this.textBoxPaperDomain.TabIndex = 7;
            // 
            // textBoxPaperName
            // 
            this.textBoxPaperName.Location = new System.Drawing.Point(320, 80);
            this.textBoxPaperName.Name = "textBoxPaperName";
            this.textBoxPaperName.Size = new System.Drawing.Size(262, 20);
            this.textBoxPaperName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(432, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Topic:";
            // 
            // comboBoxTopic
            // 
            this.comboBoxTopic.FormattingEnabled = true;
            this.comboBoxTopic.Location = new System.Drawing.Point(320, 30);
            this.comboBoxTopic.Name = "comboBoxTopic";
            this.comboBoxTopic.Size = new System.Drawing.Size(262, 21);
            this.comboBoxTopic.TabIndex = 4;
            // 
            // dataGridViewMyReviews
            // 
            this.dataGridViewMyReviews.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewMyReviews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMyReviews.Location = new System.Drawing.Point(10, 180);
            this.dataGridViewMyReviews.Name = "dataGridViewMyReviews";
            this.dataGridViewMyReviews.Size = new System.Drawing.Size(300, 184);
            this.dataGridViewMyReviews.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Reviews:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "My papers:";
            // 
            // dataGridViewMyPapers
            // 
            this.dataGridViewMyPapers.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewMyPapers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMyPapers.Location = new System.Drawing.Point(10, 30);
            this.dataGridViewMyPapers.Name = "dataGridViewMyPapers";
            this.dataGridViewMyPapers.Size = new System.Drawing.Size(300, 120);
            this.dataGridViewMyPapers.TabIndex = 0;
            // 
            // tabPagePCMember
            // 
            this.tabPagePCMember.Controls.Add(this.label10);
            this.tabPagePCMember.Controls.Add(this.buttonEvaluate);
            this.tabPagePCMember.Controls.Add(this.comboBoxEvaluation);
            this.tabPagePCMember.Controls.Add(this.label9);
            this.tabPagePCMember.Controls.Add(this.buttonBidding);
            this.tabPagePCMember.Controls.Add(this.comboBoxBidding);
            this.tabPagePCMember.Controls.Add(this.buttonReadFullPaper);
            this.tabPagePCMember.Controls.Add(this.buttonReadPaperAbstract);
            this.tabPagePCMember.Controls.Add(this.label8);
            this.tabPagePCMember.Controls.Add(this.dataGridViewUploadedPapers);
            this.tabPagePCMember.Location = new System.Drawing.Point(4, 22);
            this.tabPagePCMember.Name = "tabPagePCMember";
            this.tabPagePCMember.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePCMember.Size = new System.Drawing.Size(592, 374);
            this.tabPagePCMember.TabIndex = 1;
            this.tabPagePCMember.Text = "PC Member";
            this.tabPagePCMember.UseVisualStyleBackColor = true;
            // 
            // buttonReadFullPaper
            // 
            this.buttonReadFullPaper.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonReadFullPaper.Location = new System.Drawing.Point(456, 30);
            this.buttonReadFullPaper.Name = "buttonReadFullPaper";
            this.buttonReadFullPaper.Size = new System.Drawing.Size(126, 30);
            this.buttonReadFullPaper.TabIndex = 3;
            this.buttonReadFullPaper.Text = "Read full paper";
            this.buttonReadFullPaper.UseVisualStyleBackColor = true;
            // 
            // buttonReadPaperAbstract
            // 
            this.buttonReadPaperAbstract.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonReadPaperAbstract.Location = new System.Drawing.Point(320, 30);
            this.buttonReadPaperAbstract.Name = "buttonReadPaperAbstract";
            this.buttonReadPaperAbstract.Size = new System.Drawing.Size(126, 30);
            this.buttonReadPaperAbstract.TabIndex = 2;
            this.buttonReadPaperAbstract.Text = "Read paper abstract";
            this.buttonReadPaperAbstract.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(115, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Uploaded papers:";
            // 
            // dataGridViewUploadedPapers
            // 
            this.dataGridViewUploadedPapers.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewUploadedPapers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUploadedPapers.Location = new System.Drawing.Point(10, 30);
            this.dataGridViewUploadedPapers.Name = "dataGridViewUploadedPapers";
            this.dataGridViewUploadedPapers.Size = new System.Drawing.Size(300, 334);
            this.dataGridViewUploadedPapers.TabIndex = 0;
            // 
            // tabPageChair
            // 
            this.tabPageChair.Location = new System.Drawing.Point(4, 22);
            this.tabPageChair.Name = "tabPageChair";
            this.tabPageChair.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChair.Size = new System.Drawing.Size(592, 374);
            this.tabPageChair.TabIndex = 2;
            this.tabPageChair.Text = "Chair";
            this.tabPageChair.UseVisualStyleBackColor = true;
            // 
            // comboBoxBidding
            // 
            this.comboBoxBidding.FormattingEnabled = true;
            this.comboBoxBidding.Items.AddRange(new object[] {
            "Neutral",
            "Want to evaluate",
            "Don\'t want to evaluate"});
            this.comboBoxBidding.Location = new System.Drawing.Point(320, 90);
            this.comboBoxBidding.Name = "comboBoxBidding";
            this.comboBoxBidding.Size = new System.Drawing.Size(126, 21);
            this.comboBoxBidding.TabIndex = 4;
            // 
            // buttonBidding
            // 
            this.buttonBidding.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonBidding.Location = new System.Drawing.Point(456, 90);
            this.buttonBidding.Name = "buttonBidding";
            this.buttonBidding.Size = new System.Drawing.Size(126, 21);
            this.buttonBidding.TabIndex = 5;
            this.buttonBidding.Text = "Bid for paper";
            this.buttonBidding.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(428, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Bidding:";
            // 
            // comboBoxEvaluation
            // 
            this.comboBoxEvaluation.FormattingEnabled = true;
            this.comboBoxEvaluation.Location = new System.Drawing.Point(320, 140);
            this.comboBoxEvaluation.Name = "comboBoxEvaluation";
            this.comboBoxEvaluation.Size = new System.Drawing.Size(126, 21);
            this.comboBoxEvaluation.TabIndex = 7;
            // 
            // buttonEvaluate
            // 
            this.buttonEvaluate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEvaluate.Location = new System.Drawing.Point(456, 140);
            this.buttonEvaluate.Name = "buttonEvaluate";
            this.buttonEvaluate.Size = new System.Drawing.Size(126, 21);
            this.buttonEvaluate.TabIndex = 8;
            this.buttonEvaluate.Text = "Evaluate paper";
            this.buttonEvaluate.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(421, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Evaluation:";
            // 
            // tabPageConferenceDetailed
            // 
            this.tabPageConferenceDetailed.Location = new System.Drawing.Point(4, 22);
            this.tabPageConferenceDetailed.Name = "tabPageConferenceDetailed";
            this.tabPageConferenceDetailed.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConferenceDetailed.Size = new System.Drawing.Size(592, 374);
            this.tabPageConferenceDetailed.TabIndex = 3;
            this.tabPageConferenceDetailed.Text = "Overview";
            this.tabPageConferenceDetailed.UseVisualStyleBackColor = true;
            // 
            // ConferenceDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.tabControl1);
            this.Name = "ConferenceDetails";
            this.Text = "ConferenceDetails";
            this.tabControl1.ResumeLayout(false);
            this.tabPageParticipant.ResumeLayout(false);
            this.tabPageParticipant.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMyReviews)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMyPapers)).EndInit();
            this.tabPagePCMember.ResumeLayout(false);
            this.tabPagePCMember.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUploadedPapers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageParticipant;
        private System.Windows.Forms.TabPage tabPagePCMember;
        private System.Windows.Forms.TabPage tabPageChair;
        private System.Windows.Forms.TextBox textBoxPaperSubdomain;
        private System.Windows.Forms.TextBox textBoxPaperDomain;
        private System.Windows.Forms.TextBox textBoxPaperName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxTopic;
        private System.Windows.Forms.DataGridView dataGridViewMyReviews;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewMyPapers;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonRemovePaper;
        private System.Windows.Forms.Button buttonUpdatePaper;
        private System.Windows.Forms.Button buttonAddComplete;
        private System.Windows.Forms.Button buttonAddWithAbs;
        private System.Windows.Forms.Button buttonUploadAbstract;
        private System.Windows.Forms.TextBox textBoxPaperFilepath;
        private System.Windows.Forms.Button buttonReadPaperAbstract;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridViewUploadedPapers;
        private System.Windows.Forms.Button buttonReadFullPaper;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonEvaluate;
        private System.Windows.Forms.ComboBox comboBoxEvaluation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonBidding;
        private System.Windows.Forms.ComboBox comboBoxBidding;
        private System.Windows.Forms.TabPage tabPageConferenceDetailed;
    }
}