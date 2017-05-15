using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class Repo
    {
        List<Payment> payments;
        List<Conference> conferences;
        public Repo() {
            
        }
        /*Function which add a new payment for a conference.
         * IN:Participant,paidSum from form
         * Out:New Payment with current date,nrTickets,success of transaction
         * Condition:Participant is normal user
         * Id doesn't matter?
         */
        public void addPayment(Participant participant,int paidSum)
        {
            if (participant.IsNormalUser)
            {
                Conference conference = participant.Conference;
                float priceTicketForConference = conference.AdmissionPrice;
                int nrTickets = 0 ;
                if (priceTicketForConference != 0)
                {
                     nrTickets = (int)(paidSum / priceTicketForConference);
                }
                else
                {
                    //throw exception mai bine.!
                    nrTickets = (int)paidSum;
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


        /*Function which adds a new conference.
         * In:Conference details
         * Out:new conference in the list
         * Conditions which are checked in repository:
         * DeadlineAbstract < DeadlineComplet < DeadlineParticipation < DeadlineBidding < DeadlineEvaluation < BeginDate < EndDate
         * AdmissionPrice>0
         * Id-unique
         */
        public void addConference(Conference c)
        {
            if (c.AdmissionPrice < 1)
            {
                throw new NotImplementedException("Conference admission price must be >=1!");//RepositoryException
            }
            if ((DateTime.Compare(c.DeadlineAbstract, c.DeadlineComplet) < 0) && (DateTime.Compare(c.DeadlineComplet, c.DeadlineParticipation) < 0) && (DateTime.Compare(c.DeadlineParticipation, c.DeadlineBidding) < 0))
            {
                if ((DateTime.Compare(c.DeadlineBidding, c.DeadlineEvaluation) < 0) && (DateTime.Compare(c.DeadlineEvaluation, c.BeginDate) < 0) && (DateTime.Compare(c.BeginDate, c.EndDate) < 0))
                {
                    foreach (Conference conf in getConferences()) {
                        if (conf.Id == c.Id)
                        {
                            throw new NotImplementedException("Conference already exist!");//RepositoryException
                        }
                    }

                    conferences.Add(c);
                }
                else
                {
                    throw new NotImplementedException("Dates must be in chronological order!");//RepositoryException
                }
            }
            else
            {
                throw new NotImplementedException("Dates must be in chronological order!");//RepositoryException
            }
        }

        public List<Conference> getConferences()
        {
            return conferences;
        }
    }


}
