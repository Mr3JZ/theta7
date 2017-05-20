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
        /*
        List<Model.Payment> payments=new List<Model.Payment>();

        public RepoPayment()
        {

        }
        /*Function which add a new payment for a conference.
         * IN:Participant,paidSum from form
         * Out:New Payment with current date,nrTickets,success of transaction
         * Condition:Participant is normal user
         * Id doesn't matter?
         
        public void addPayment(Participant participant, int paidSum)
        {
            if (participant.IsNormalUser)
            {
                Model.Conference conference = participant.Conference;
                int priceTicketForConference = conference.AdmissionPrice;
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
                Model.Payment payment = new Model.Payment(10, paidSum, nrTickets, PaymentDate, SuccessfulTransaction, participant);
                
                using (var context = new ISSEntities2(Util.ConnectionStringWithPassword.doIt()))
                {
                    Payment payment1 = new Payment();
                    payment1.PaymentId = 201;
                    DateTime t = new DateTime(2000, 1, 1);
                    payment1.PaymentDate =payment.PaymentDate;
                    payment1.NrOfTickets = payment.NrOfTickets;
                    payment1.PaidSum = payment.PaidSum;
                    payment1.SuccessfulTransaction = payment.SuccessfulTransaction;
                    context.Payments.Add(payment1);
                    context.SaveChanges();


                    /*Nu merge inca*/
                    foreach (ConferenceParticipant conf in payment1.ConferenceParticipants)
                    {
                        if (context.ConferenceParticipants.Find(conf.PaymentId) == null)
                        {
                            Console.WriteLine("aici");
                            ConferenceParticipant con = new ConferenceParticipant();
                            con.UserId = participant.User.IdUser;//WTF??
                            con.ConferenceId = conference.Id;
                            con.PaymentId = payment1.PaymentId;
                           
                            context.ConferenceParticipants.Add(con);

                        }
                    }
                    context.SaveChanges();
        
                    

                    
                }


                }
            }       
        /*Getter for the list of payments
         * To be used by conference managers to see incomes
        
        public List<Model.Payment> getPayments()
        {
            return payments;
        }


        */
    }
}
