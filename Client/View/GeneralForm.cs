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
        }

        private void GeneralForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ctrl.logout();
            Application.Exit();
        }

        private void buttonViewDetails_Click(object sender, EventArgs e)
        {
            string name = dataGridViewAllConferences.CurrentRow.Cells[0].ToString();
            string edition = dataGridViewAllConferences.CurrentRow.Cells[1].ToString();
            string city = dataGridViewAllConferences.CurrentRow.Cells[2].ToString();
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
    }
}
