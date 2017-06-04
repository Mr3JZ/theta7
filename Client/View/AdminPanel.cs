using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Persistence.Repository;
namespace Client.View
{
    public partial class AdminPanel : Form
    {
        ClientController ctrl;

        public AdminPanel(ClientController c)
        {
            ctrl = c;
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBoxConferenceName.Text;
                string edition = textBoxConferenceEdition.Text;
                string website = textBoxConferenceWebsite.Text;
                string city = textBoxConferenceCity.Text;
                string country = textBoxConferenceCountry.Text;
                int price = Convert.ToInt32(textBoxPrice.Text);
                DateTime begin = new DateTime(
                    Convert.ToInt32(textBoxBeginYear.Text),
                    Convert.ToInt32(textBoxBeginMonth.Text),
                    Convert.ToInt32(textBoxBeginDay.Text));
                DateTime end = new DateTime(
                    Convert.ToInt32(textBoxEndYear.Text),
                    Convert.ToInt32(textBoxEndMonth.Text),
                    Convert.ToInt32(textBoxEndDay.Text));
                DateTime abs = new DateTime(
                    Convert.ToInt32(textBoxAbstractYear.Text),
                    Convert.ToInt32(textBoxAbstractMonth.Text),
                    Convert.ToInt32(textBoxAbstractDay.Text));
                DateTime complete = new DateTime(
                    Convert.ToInt32(textBoxCompleteYear.Text),
                    Convert.ToInt32(textBoxCompleteMonth.Text),
                    Convert.ToInt32(textBoxCompleteDay.Text));
                DateTime bidding = new DateTime(
                    Convert.ToInt32(textBoxBiddingYear.Text),
                    Convert.ToInt32(textBoxBiddingMonth.Text),
                    Convert.ToInt32(textBoxBiddingDay.Text));
                DateTime evaluation = new DateTime(
                    Convert.ToInt32(textBoxEvaluationYear.Text),
                    Convert.ToInt32(textBoxEvaluationMonth.Text),
                    Convert.ToInt32(textBoxEvaluationDay.Text));
                DateTime participation = new DateTime(
                    Convert.ToInt32(textBoxParticipationYear.Text),
                    Convert.ToInt32(textBoxParticipationMonth.Text),
                    Convert.ToInt32(textBoxParticipationDay.Text));
                List<String> topics = new List<string>();
                ctrl.AddConference(name,edition,topics,abs,complete,bidding,evaluation,participation,city,country,website,price,begin,end);
            }
            catch(RepositoryException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show("Invalid input!");
            }

            this.Close();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
