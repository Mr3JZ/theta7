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
    public partial class GeneralForm : Form
    {
        private ClientController ctrl;
        private string mode;
        public GeneralForm(ClientController c, string m)
        {
            ctrl = c;
            mode = m;
            InitializeComponent();
            if (m.Equals("admin"))
            {
                tabControlGeneral.TabPages.Remove(tabPageNotificaions);
                tabControlGeneral.TabPages.Remove(tabPageMyConferences);
                buttonViewDetails.Enabled = false;
                buttonViewDetails.Visible = false;
            }
            else
            {
                buttonCreateConference.Visible = false;
                buttonCreateConference.Enabled = false;
            }

            dataGridViewAllConferences.AutoGenerateColumns = false;
            
            //create the colum programically
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            DataGridViewCell cellEdition = new DataGridViewTextBoxCell();
            DataGridViewCell cellCity = new DataGridViewTextBoxCell();
            DataGridViewTextBoxColumn colFileName = new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell,
                Name = "Name",
                HeaderText = "Conference name",
                DataPropertyName = "Name" // Tell the column which property of FileName it should use
            };
            DataGridViewTextBoxColumn colFileNameEdition = new DataGridViewTextBoxColumn()
            {
                CellTemplate = cellEdition,
                Name = "Edition",
                HeaderText = "Edition",
                DataPropertyName = "Edition" // Tell the column which property of FileName it should use
            };
            DataGridViewTextBoxColumn colFileNameCity = new DataGridViewTextBoxColumn()
            {
                CellTemplate = cellCity,
                Name = "City",
                HeaderText = "City",
                DataPropertyName = "City" // Tell the column which property of FileName it should use
            };
            dataGridViewAllConferences.AutoResizeColumns();
            colFileName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFileNameEdition.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFileNameCity.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridViewAllConferences.Columns.Add(colFileName);
            dataGridViewAllConferences.Columns.Add(colFileNameEdition);
            dataGridViewAllConferences.Columns.Add(colFileNameCity);

            dataGridViewMyConferences.AutoGenerateColumns = false;

            //create the colum programically
            DataGridViewCell cell2 = new DataGridViewTextBoxCell();
            DataGridViewCell cellEdition2 = new DataGridViewTextBoxCell();
            DataGridViewCell cellCity2 = new DataGridViewTextBoxCell();
            DataGridViewTextBoxColumn colFileName2 = new DataGridViewTextBoxColumn()
            {
                CellTemplate = cell2,
                Name = "Name",
                HeaderText = "Conference name",
                DataPropertyName = "Name" // Tell the column which property of FileName it should use
            };
            DataGridViewTextBoxColumn colFileNameEdition2 = new DataGridViewTextBoxColumn()
            {
                CellTemplate = cellEdition2,
                Name = "Edition",
                HeaderText = "Edition",
                DataPropertyName = "Edition" // Tell the column which property of FileName it should use
            };
            DataGridViewTextBoxColumn colFileNameCity2 = new DataGridViewTextBoxColumn()
            {
                CellTemplate = cellCity2,
                Name = "City",
                HeaderText = "City",
                DataPropertyName = "City" // Tell the column which property of FileName it should use
            };
            colFileName2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFileNameEdition2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFileNameCity2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewMyConferences.Columns.Add(colFileName2);
            dataGridViewMyConferences.Columns.Add(colFileNameEdition2);
            dataGridViewMyConferences.Columns.Add(colFileNameCity2);



            populateAllConferencesView();
            populateMyConferencesView();
            populateNotifications();
        }

        private void populateNotifications()
        {
            BindingList<Model.Message> messages = new BindingList<Model.Message>(ctrl.GetMyMessages());
            listBoxNotifications.DataSource = messages;
        }

        private void GeneralForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ctrl.logout();
            Application.Exit();
        }

        private void buttonViewDetails_Click(object sender, EventArgs e)
        {
            string name = dataGridViewAllConferences.CurrentRow.Cells[0].Value.ToString();
            string edition = dataGridViewAllConferences.CurrentRow.Cells[1].Value.ToString();
            string city = dataGridViewAllConferences.CurrentRow.Cells[2].Value.ToString();
            Conference conf = ctrl.getConference(name, edition, city);
            string rank = ctrl.getMyRank(name, edition, city);
            ConferenceDetails cf = new ConferenceDetails(ctrl, conf, rank);
            cf.Show();
        }

        private void buttonViewDetailsMy_Click(object sender, EventArgs e)
        {
            /*
            string name = dataGridViewMyConferences.CurrentRow.Cells[0].ToString();
            string edition = dataGridViewMyConferences.CurrentRow.Cells[1].ToString();
            string city = dataGridViewMyConferences.CurrentRow.Cells[2].ToString();
            Conference conf = ctrl.getConference(name, edition, city);
            */
            int confId = ((Conference)dataGridViewMyConferences.CurrentRow.DataBoundItem).Id;
            Conference conf = ctrl.getConferenceById(confId);
            string rank = ctrl.getMyRank(confId);
            ConferenceDetails cf = new ConferenceDetails(ctrl, conf, rank);
            cf.Show();
        }

        private void buttonCreateConference_Click(object sender, EventArgs e)
        {
            AdminPanel2 ap = new AdminPanel2(ctrl);
            ap.Show();
        }
        private void populateAllConferencesView()
        {
            
            var filelist = ctrl.getAllConferences().ToList();
            var filenamesList = new BindingList<Model.Conference>(filelist); // <-- BindingList
            dataGridViewAllConferences.DataSource = filenamesList;
        }



        private void buttonReadMessage_Click(object sender, EventArgs e)
        {
            if (listBoxNotifications.SelectedItems.Count > 0)
            {
                MessageBox.Show(listBoxNotifications.SelectedItems[0].ToString());
            }
        }

        private void buttonDeleteMessage_Click(object sender, EventArgs e)
        {
            if (listBoxNotifications.SelectedItems.Count > 0)
            {
                int index = listBoxNotifications.SelectedIndex;
                List<Model.Message> messages = ctrl.GetMyMessages();
                ctrl.DeleteMessage(messages[index]);
            }
        }

        private void buttonLogout1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogout2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogout3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridViewMyConferences_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void populateMyConferencesView()
        {
            

            var filelist = ctrl.getMyConferences().ToList();
            var filenamesList = new BindingList<Model.Conference>(filelist); // <-- BindingList

            dataGridViewMyConferences.DataSource = filenamesList;
        }

        private void btnRefreshAllConferences_Click(object sender, EventArgs e)
        {
            dataGridViewAllConferences.DataSource = null;
            populateAllConferencesView();
        }

        private void btnRefreshMyConferences_Click(object sender, EventArgs e)
        {
            dataGridViewMyConferences.DataSource = null;
            populateMyConferencesView();
        }

        private void tabPageAllConferences_Enter(object sender, EventArgs e)
        {
            dataGridViewAllConferences.DataSource = null;
            populateAllConferencesView();
        }

        private void tabPageMyConferences_Enter(object sender, EventArgs e)
        {
            dataGridViewMyConferences.DataSource = null;
            populateMyConferencesView();
        }
    }
}
