﻿using System;

namespace Model
{
    [Serializable]
    public class Payment
    {
        public Payment(int id,float paidSum, int nrOfTickets, DateTime paymentDate, bool successfulTransaction)
        {
            this.Id = id;
            this.PaidSum = paidSum;
            this.NrOfTickets = nrOfTickets;
            this.PaidSum = paidSum;
            this.SuccessfulTransaction = successfulTransaction;
        }

        public int Id { get;set; }

        public float PaidSum { get; set; }

        public int NrOfTickets { get; set; }

        public DateTime PaymentDate { get; set; }

        public bool SuccessfulTransaction { get; set; }
    }
}
