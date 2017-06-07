﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.View
{
    public partial class AvailableRooms : Form
    {
        public BindingList<Persistence.AvailableRoom> availableRoom;
        public AvailableRooms(BindingList<Persistence.AvailableRoom> availableRoom)
        {
            InitializeComponent();
            // topicsListBox.DataSource = topics;
            this.availableRoom = availableRoom;
        }

        public AvailableRooms()
        {
            InitializeComponent();
        }

        private void buttonAllRooms_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddRoom_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBoxName.Text;
                int capacity = (int)numericUpDownCapacity.Value;
                string street = textBoxStreet.Text;
                string postalCode = textBoxPostalCode.Text;
                DateTime beginAvRoom = dateTimePickerBegin.Value;
                if ((beginAvRoom.Hour < 9)||(beginAvRoom.Hour>16)) {
                    throw new Exception("Invalid begin hour");
                }
                DateTime endAvRoom = dateTimePickerEnd.Value;
                if ((endAvRoom.Hour < 9) || (beginAvRoom.Hour > 17) || (beginAvRoom>endAvRoom))
                {
                    throw new Exception("Invalid end hour");
                }
                /*Urmeaza adaugarea in data grid view.Pot fi adaugate mai multe.
                 * Apoi toate trebuie adaugate o data prin celalt buton toate pt o conferinta.
                 * Asemanator cu addPcMembers.E o combinatie de addPcMembers cu topic a lu Tudor.Faceti dimineata voi.I'm out!*/


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AvailableRooms_Load(object sender, EventArgs e)
        {
            dateTimePickerBegin.Format = DateTimePickerFormat.Custom;
            //d-zi;m-luna;yyyy-an;HH-ora
            dateTimePickerBegin.CustomFormat = "d-M-yyyy - HH";
            dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
            dateTimePickerEnd.CustomFormat = "d-M-yyyy - HH";
        }
    }
}
