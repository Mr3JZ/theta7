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
            populateAllConferencesView();
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

        private void buttonCreateConference_Click(object sender, EventArgs e)
        {
            AdminPanel ap = new AdminPanel(ctrl);
            ap.Show();
        }
        private void populateAllConferencesView()
        {
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

            dataGridViewAllConferences.Columns.Add(colFileName);
            dataGridViewAllConferences.Columns.Add(colFileNameEdition);
            dataGridViewAllConferences.Columns.Add(colFileNameCity);

            var filelist = ctrl.getAllConferences().ToList();
            var filenamesList = new BindingList<Model.Conference>(filelist); // <-- BindingList

            dataGridViewAllConferences.DataSource = filenamesList;
        }
    }
}
