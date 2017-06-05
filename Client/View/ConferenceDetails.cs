using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Persistence.Repository;
using Client.Controller;

namespace Client.View
{
    public partial class ConferenceDetails : Form
    {
        ClientController ctrl;
        Conference conf;
        string rank;
        public ConferenceDetails(ClientController c, Conference co, string r)
        {
            ctrl = c;
            conf = co;
            rank = r;
            InitializeComponent();
            AdjustView();
        }

        private void AdjustView()
        {
            AdjustOverview();
            if (rank.Equals("Unregistered"))
            {
                buttonRegisterConference.Visible = true;
                buttonRegisterConference.Enabled = true;
                tabControl1.TabPages.RemoveAt(2);
                tabControl1.TabPages.RemoveAt(1);
            }
            else if (rank.Equals("NormalUser"))
            {
                tabControl1.TabPages.RemoveAt(2);
                AdjustParticipant();
            }
            else
            {
                if (rank.Equals("Chair"))
                {
                    tabControl1.TabPages.RemoveAt(1);
                }
                else
                {
                    AdjustParticipant();
                }
                AdjustPCMember();
            }
        }

        private void AdjustOverview()
        {
            int size;
            labelConferenceDuration.Text = conf.BeginDate.ToShortDateString().ToString() + "-" + conf.BeginDate.ToShortDateString().ToString();
            labelConferecePlace.Text = conf.City + " , " + conf.Country;
            labelAbstractDeadline.Text = conf.DeadlineAbstract.ToShortDateString().ToString();
            labelParticipationDeadline.Text = conf.DeadlineParticipation.ToShortDateString().ToString();
            labelConferenceFee.Text = "$" + conf.AdmissionPrice.ToString();
            labelConferenceName.Text = conf.Name;
            size = labelConferenceName.Width;
            labelConferenceName.SetBounds((592 - size) / 2, 0, size, 29);
            labelConferenceEdition.Text = conf.Edition;
            size = labelConferenceEdition.Width;
            labelConferenceName.SetBounds((592 - size) / 2, 40, size, 24);
            BindingList<Participant> chairs = new BindingList<Participant>(ctrl.getChairs(conf));
            dataGridViewConferenceChairs.DataSource = chairs;
            BindingList<Participant> pcmembers = new BindingList<Participant>(ctrl.getPCMembers(conf));
            dataGridViewConferencePCMembers.DataSource = pcmembers;
            BindingList<string> topics = new BindingList<string>(conf.Topics);
            listBoxConferenceTopics.DataSource = topics;
            if (DateTime.Now < conf.DeadlineEvaluation || DateTime.Now > conf.EndDate)
            {
                buttonSchedule.Enabled = false;
                buttonSchedule.Visible = false;
            }
        }

        private void AdjustParticipant()
        {
            BindingList<Paper> mypapers = new BindingList<Paper>(ctrl.getPapers(conf));
            dataGridViewMyPapers.DataSource = mypapers;
        }

        private void AdjustPCMember()
        {
            if (rank.Equals("Chair") && DateTime.Now<conf.BeginDate)
            {
                labelPushDeadlines.Visible = true;
                comboBoxDeadlines.Visible = true;
                comboBoxDeadlines.Enabled = true;
                labeloldDeadline.Visible = true;
                labelNewDeadline.Visible = true;
                dateTimePickerOldDeadline.Visible = true;
                dateTimePickerOldDeadline.Enabled = true;
                dateTimePickerNewDeadline.Visible = true;
                dateTimePickerNewDeadline.Enabled = true;
                buttonPushDeadline.Visible = true;
                buttonPushDeadline.Enabled = true;
            }
            if (DateTime.Now < conf.DeadlineBidding && DateTime.Now > conf.DeadlineComplet)
            {
                labelBidEvaluate.Text = "Bidding";
                comboBoxBidding.Visible = true;
                comboBoxBidding.Enabled = true;
                buttonBidding.Visible = true;
                buttonBidding.Enabled = true;
                comboBoxEvaluation.Visible = false;
                comboBoxEvaluation.Enabled = false;
                buttonEvaluate.Visible = false;
                buttonEvaluate.Enabled = false;
            }
            else if (DateTime.Now < conf.DeadlineEvaluation && DateTime.Now > conf.DeadlineBidding)
            {
                labelBidEvaluate.Text = "Evaluation";
                comboBoxBidding.Visible = false;
                comboBoxBidding.Enabled = false;
                buttonBidding.Visible = false;
                buttonBidding.Enabled = false;
                comboBoxEvaluation.Visible = true;
                comboBoxEvaluation.Enabled = true;
                buttonEvaluate.Visible = true;
                buttonEvaluate.Enabled = true;
            }
            else
            {
                labelBidEvaluate.Visible = false;
                comboBoxBidding.Visible = false;
                comboBoxBidding.Enabled = false;
                buttonBidding.Visible = false;
                buttonBidding.Enabled = false;
                comboBoxEvaluation.Visible = false;
                comboBoxEvaluation.Enabled = false;
                buttonEvaluate.Visible = false;
                buttonEvaluate.Enabled = false;
            }
            if (DateTime.Now < conf.DeadlineBidding)
            {
                labelUploadedToReview.Text = "Uploaded papers";
            }
            else
            {
                labelUploadedToReview.Text = "Papers to evaluate";
            }
        }

        private void dataGridViewMyPapers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string title = dataGridViewMyPapers.CurrentRow.Cells[0].ToString();
            BindingList<Review> myreviews = new BindingList<Review>(ctrl.getReviewsByPaper(title));
            dataGridViewMyReviews.DataSource = myreviews;
        }

        private void buttonRegisterConference_Click(object sender, EventArgs e)
        {
            try
            {
                int nrTickets = (int)numericUpDownPaidSum.Value;
                //Only listeners have to pay->so he has to be normalUser
                Participant p = new Participant(ctrl.getCurrentUser(), conf.Id, false, false, false, true);
                double x = conf.AdmissionPrice * nrTickets;
                if (MessageBox.Show( "Price to pay: "+x.ToString(),"Price", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    ctrl.addPayment(p, nrTickets, conf);
                }
                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tabPageConferenceDetailed_Click(object sender, EventArgs e)
        {


        }

        private void comboBoxDeadlines_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonAddWithAbs_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddPaper_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "PDF files|*.pdf|Microsoft Word files|*.doc;*.docx|Power Point files|*.ppt;*.pptx";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = theDialog.FileName.ToString();
                FTPOperations.createFolder(conf.Id);
                FTPOperations.createFile(conf.Id,filepath);
            }
        }

        private void dataGridViewConferencePCMembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}