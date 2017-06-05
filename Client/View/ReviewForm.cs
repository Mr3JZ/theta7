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
    public partial class ReviewForm : Form
    {
        private ClientController cont;
        private Model.Participant part;
        private int paperId;

        public ReviewForm(ClientController c, Model.Participant reviewer, int paperId)
        {
            InitializeComponent();
            cont = c;
            part = reviewer;
            this.paperId = paperId;

            List<Model.NamedVerdict> options = new List<Model.NamedVerdict>();
            options.Add(new Model.NamedVerdict("Strong Accept", Model.Verdict.STRONG_ACCEPT));
            options.Add(new Model.NamedVerdict("Accept", Model.Verdict.ACCEPT));
            options.Add(new Model.NamedVerdict("Weak Accept", Model.Verdict.WEAK_ACCEPT));
            options.Add(new Model.NamedVerdict("Borderline", Model.Verdict.BORDERLINE));
            options.Add(new Model.NamedVerdict("Weak Reject", Model.Verdict.WEAK_REJECT));
            options.Add(new Model.NamedVerdict("Reject", Model.Verdict.REJECT));
            options.Add(new Model.NamedVerdict("Strong Reject", Model.Verdict.STRONG_REJECT));

            CBVerdict.DataSource = options;
            CBVerdict.DisplayMember = "Name";
            CBVerdict.ValueMember = "Verdict";
            CBVerdict.DropDownStyle = ComboBoxStyle.DropDownList;


        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            Model.Verdict v = (Model.Verdict)CBVerdict.SelectedValue;
            Model.Review review = new Model.Review(0, part, v, TBComments.Text);
            cont.addReview(paperId, review);
            this.Close();
        }
    }
}
