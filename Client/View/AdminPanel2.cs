﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Persistence.Repository;
using Model;

namespace Client.View
{
    public partial class AdminPanel2 : Form
    {
        private BindingList<Model.User> addedChairs;
        private BindingList<Model.User> addedPCMembers;

        ClientController ctrl;
        public AdminPanel2(ClientController c)
        {
            ctrl = c;
            InitializeComponent();
            BindingList<Model.User> possiblePcMembers = new BindingList<Model.User>(ctrl.GetSpecialUsers());
            dataGridViewComitee.DataSource = possiblePcMembers;

            addedChairs = new BindingList<Model.User>();
            addedPCMembers = new BindingList<Model.User>();

            dataGridViewAddedChairs.DataSource = addedChairs;
            dataGridViewAddedPCMembers.DataSource = addedPCMembers;
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
                Conference addedConf = ctrl.getConference(name, edition, city);


                if (addedChairs.Count == 1)
                {
                    Participant chair = new Participant(addedChairs[0], addedConf.Id, true, false, true, false);
                    ctrl.addParticipant(chair);
                }
                else
                {
                    foreach(var c in addedChairs)
                    {
                        Participant chair = new Participant(c, addedConf.Id, false, true, true, false);
                        ctrl.addParticipant(chair);
                    }
                }

                foreach(var p in addedPCMembers)
                {
                    Participant pcm = new Participant(p, addedConf.Id, false, false, true,false);
                    ctrl.addParticipant(pcm);
                }
                
            }           
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            this.Close();
        }

        private void buttonAddChair_Click(object sender, EventArgs e)
        {
            if (dataGridViewComitee.CurrentRow.Index != -1)
            {
                addedChairs.Add((Model.User)dataGridViewComitee.CurrentRow.DataBoundItem);
            }
        }

        private void buttonAddPCMember_Click(object sender, EventArgs e)
        {
            if (dataGridViewComitee.CurrentRow.Index != -1)
            {
                addedPCMembers.Add((Model.User)dataGridViewComitee.CurrentRow.DataBoundItem);
            }
        }

        private void buttonRemoveChair_Click(object sender, EventArgs e)
        {
            if (dataGridViewAddedChairs.CurrentRow.Index != -1)
            {
                addedChairs.Remove((Model.User)dataGridViewAddedChairs.CurrentRow.DataBoundItem);
            }
        }

        private void buttonRemovePCMember_Click(object sender, EventArgs e)
        {
            if (dataGridViewAddedPCMembers.CurrentRow.Index != -1)
            {
                addedChairs.Remove((Model.User)dataGridViewAddedPCMembers.CurrentRow.DataBoundItem);
            }
        }
    }
    }