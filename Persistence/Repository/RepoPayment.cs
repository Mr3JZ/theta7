using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Persistence.Repository
{
    public class RepoPayment
    {
        
        List<Model.Payment> payments=new List<Model.Payment>();

        public RepoPayment()
        {

        }
        private readonly ISSEntities2 _context;
        public RepoPayment(ISSEntities2 context)
        {
            _context = context;
        }
        /*Function which add a new payment for a conference.
         * IN:Participant,paidSum from form
         * Out:New Payment with current date,nrTickets,success of transaction
         * Condition:Participant is normal user
         * Id doesn't matter?
         */
        public void addPayment(Participant participant, int nrTickets,Model.Conference conference)
        {
            if (participant.IsNormalUser)
            {
                int conferenceId = participant.ConferenceId;
                RepoConference repo = new RepoConference(_context);
                double priceTicketForConference = conference.AdmissionPrice;
                double paidSum = 0;
                if (priceTicketForConference != 0)
                {
                    paidSum =nrTickets * priceTicketForConference;
                }
                else
                {
                    throw new Exception("You can participate for free.Enjoy!");
                }
                DateTime PaymentDate = DateTime.Now;
                bool SuccessfulTransaction = true;
                Model.Payment payment = new Model.Payment(10, paidSum, nrTickets, PaymentDate, SuccessfulTransaction, participant);
                
                
                    Payment payment1 = new Payment();
                    payment1.PaymentId = payment.Id;                 
                    payment1.PaymentDate =payment.PaymentDate;
                    payment1.NrOfTickets = payment.NrOfTickets;
                    payment1.PaidSum = payment.PaidSum;
                    payment1.SuccessfulTransaction = payment.SuccessfulTransaction;
                _context.Payments.Add(payment1);
                _context.SaveChanges();
                    
                    ConferenceParticipant confP = new ConferenceParticipant();//daca a facut plata devine un participant la conferinta.
                    if (_context.ConferenceParticipants.Find(payment.Buyer.User.IdUser, conference.Id, payment1.PaymentId) == null)
                    {
                        MessageBox.Show(payment.Buyer.User.IdUser.ToString());
                        confP.UserId = participant.User.IdUser;
                        confP.ConferenceId = conference.Id;
                        confP.PaymentId = payment1.PaymentId;
                    _context.ConferenceParticipants.Add(confP);
                    _context.SaveChanges();
                    }


                }
            }       
    }
}
