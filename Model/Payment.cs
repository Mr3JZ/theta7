using System;

namespace Model
{
    [Serializable]
    public class Payment
    {
        public Payment(int id,double paidSum, int nrOfTickets, DateTime paymentDate, bool successfulTransaction, Participant buyer)
        {
            this.Id = id;
            this.PaidSum = paidSum;
            this.NrOfTickets = nrOfTickets;
            this.SuccessfulTransaction = successfulTransaction;
            this.PaymentDate = paymentDate;
            Buyer = buyer;
        }

        public int Id { get;set; }

        public double PaidSum { get; set; }

        public int NrOfTickets { get; set; }

        public DateTime PaymentDate { get; set; }

        public bool SuccessfulTransaction { get; set; }

        public Participant Buyer { get; set; }
    }
}
