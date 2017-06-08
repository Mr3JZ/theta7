using System;
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
        public BindingList<Model.AvailableRoom> availableRoom;
        public AvailableRooms(BindingList<Model.AvailableRoom> rooms)
        {
            InitializeComponent();
            // topicsListBox.DataSource = topics;
            availableRoom = rooms;
            dataGridViewAvailableRooms.DataSource = availableRoom;
            dataGridViewAvailableRooms.Columns.Remove("ConfId");
        }



        private void buttonAllRooms_Click(object sender, EventArgs e)
        {
            if (dataGridViewAvailableRooms.CurrentRow.Index != null)
                if (dataGridViewAvailableRooms.CurrentRow.Index != -1)
                {
                    availableRoom.Remove((Model.AvailableRoom)dataGridViewAvailableRooms.CurrentRow.DataBoundItem);
                }
                else
                {
                    MessageBox.Show("No item was selected");
                }
        }

        private void buttonAddRoom_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBoxName.Text;
                int capacity = (int)numericUpDownCapacity.Value;
                string street = textBoxStreet.Text;
                string city = tbCity.Text;
                string postalCode = textBoxPostalCode.Text;
                DateTime beginAvRoom = dateTimePickerBegin.Value;
                if ((beginAvRoom.Hour < 9) || (beginAvRoom.Hour > 16))
                {
                    throw new Exception("Invalid begin hour");
                }
                DateTime endAvRoom = dateTimePickerEnd.Value;
                if ((endAvRoom.Hour < 9) || (beginAvRoom.Hour > 17) || (beginAvRoom > endAvRoom))
                {
                    throw new Exception("Invalid end hour");
                }
                Model.AvailableRoom ar = new Model.AvailableRoom(0, name, capacity, street, city, postalCode, beginAvRoom, endAvRoom);
                availableRoom.Add(ar);            

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
