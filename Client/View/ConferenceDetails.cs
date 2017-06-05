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
        }

        private void AdjustOverview()
        {
            int size;
            labelConferenceDuration.Text = conf.BeginDate.ToString() + "-" + conf.BeginDate.ToString();
            labelConferecePlace.Text = conf.City + " , " + conf.Country;
            labelAbstractDeadline.Text = conf.DeadlineAbstract.ToString();
            labelParticipationDeadline.Text = conf.DeadlineParticipation.ToString();
            labelConferenceFee.Text = "$"+conf.AdmissionPrice.ToString();
            labelConferenceName.Text = conf.Name;
            size = labelConferenceName.Width;
            labelConferenceName.SetBounds((592-size)/2,0,size,29);
            labelConferenceEdition.Text = conf.Edition;
            size = labelConferenceEdition.Width;
            labelConferenceName.SetBounds((592 - size) / 2, 40, size, 24);
            BindingList<Participant> chairs = new BindingList<Participant>(ctrl.getChairs(conf));
            dataGridViewConferenceChairs.DataSource = chairs;
            BindingList<Participant> pcmembers = new BindingList<Participant>(ctrl.getPCMembers(conf));
            dataGridViewConferencePCMembers.DataSource = pcmembers;
            BindingList<string> topics = new BindingList<string>(conf.Topics);
            listBoxConferenceTopics.DataSource = topics;
            if(DateTime.Now<conf.DeadlineEvaluation || DateTime.Now > conf.EndDate)
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

        private void dataGridViewMyPapers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string title = dataGridViewMyPapers.CurrentRow.Cells[0].ToString();
            BindingList<Review> myreviews = new BindingList<Review>(ctrl.getReviewsByPaper(title));
            dataGridViewMyReviews.DataSource = myreviews;
        }
    }
}
