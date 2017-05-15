using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class RepoPayment
    {
        List<Payment> payments=new List<Payment>();

        public RepoPayment()
        {

        }
        /*Function which add a new payment for a conference.
         * IN:Participant,paidSum from form
         * Out:New Payment with current date,nrTickets,success of transaction
         * Condition:Participant is normal user
         * Id doesn't matter?
         */
        public void addPayment(Participant participant, int paidSum)
        {
            if (participant.IsNormalUser)
            {
                Conference conference = participant.Conference;
                float priceTicketForConference = conference.AdmissionPrice;
                int nrTickets = 0;
                if (priceTicketForConference != 0)
                {
                    nrTickets = (int)(paidSum / priceTicketForConference);
                }
                else
                {
                    throw new RepositoryException("You can participate for free.Enjoy!");
                }
                DateTime PaymentDate = DateTime.Now;
                bool SuccessfulTransaction = true;
                Payment payment = new Payment(1, paidSum, nrTickets, PaymentDate, SuccessfulTransaction, participant);
                payments.Add(payment);
            }
        }
        /*Getter for the list of payments
         * To be used by conference managers to see incomes
         */
        public List<Payment> getPayments()
        {
            return payments;
        }



    }
}
