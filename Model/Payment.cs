using System;

namespace Model
{
    [Serializable]
    public class Payment
    {
        public Payment(int id,int paidSum, int nrOfTickets, DateTime paymentDate, bool successfulTransaction, Participant buyer)
        {
            this.Id = id;
            this.PaidSum = paidSum;
            this.NrOfTickets = nrOfTickets;
            this.SuccessfulTransaction = successfulTransaction;
            this.PaymentDate = paymentDate;
            Buyer = buyer;
        }

        public int Id { get;set; }

        public int PaidSum { get; set; }

        public int NrOfTickets { get; set; }

        public DateTime PaymentDate { get; set; }

        public bool SuccessfulTransaction { get; set; }

        public Participant Buyer { get; set; }
    }
}
