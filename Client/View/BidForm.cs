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
    public partial class BidForm : Form
    {
        private ClientController ctrl;
        private Model.Participant bidder;
        private int selectedPaper;
        private Model.Conference conf;
        public BidForm(ClientController c, Model.Participant b, int sp, Model.Conference co)
        {
            ctrl = c;
            bidder = b;
            selectedPaper = sp;
            conf = co;
            InitializeComponent();
        }

        private void buttonPlaceBid_Click(object sender, EventArgs e)
        {
            int bidValue;
            if (comboBox1.SelectedText.Equals("Neutral"))
            {
                bidValue = 1;
            }
            else if (comboBox1.SelectedText.Equals("Want to evaluate"))
            {
                bidValue = 2;
            }
            else
            {
                bidValue = 0;
            }
            ctrl.AddBid(bidder, conf.Id, selectedPaper, bidValue);
            this.Close();
        }
    }
}
