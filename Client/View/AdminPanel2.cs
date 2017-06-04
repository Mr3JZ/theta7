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
    public partial class AdminPanel2 : Form
    {
        ClientController ctrl;
        public AdminPanel2(ClientController c)
        {
            ctrl = c;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
                int price = (int)numericUpDownPrice.Value;
                DateTime abs = dateTimePicker1.Value;
                DateTime complete = dateTimePicker2.Value;
                DateTime participation = dateTimePicker3.Value;
                DateTime bidding = dateTimePicker4.Value;
                DateTime evaluation = dateTimePicker5.Value;
                DateTime begin = dateTimePicker6.Value;
                DateTime end = dateTimePicker7.Value;
                List<String> topics = new List<string>();
                ctrl.AddConference(name, edition, topics, abs, complete, bidding, evaluation, participation, city, country, website, price, begin, end);
            }
            catch (RepositoryException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input!");
            }

            this.Close();
        }

    }
    }

