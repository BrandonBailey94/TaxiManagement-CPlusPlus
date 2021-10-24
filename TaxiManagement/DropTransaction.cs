using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagement
{
    public class DropTransaction : Transaction
    {
        private int TaxiNum { get; set; }
        private bool PriceWasPaid { get; set; }
        public DropTransaction(DateTime transactionDateTime, int taxiNum, bool priceWasPaid) : base("Drop fare", transactionDateTime)
        {
            TaxiNum = taxiNum;
            PriceWasPaid = priceWasPaid;
        }

        public override string ToString()
        {
            if (PriceWasPaid)
            {
                return string.Format("{0} Drop fare - Taxi {1}, price was paid", TransactionDatetime.ToString("dd/MM/yyyy HH:mm"), TaxiNum);
            }
            return string.Format("{0} Drop fare - Taxi {1}, price was not paid", TransactionDatetime.ToString("dd/MM/yyyy HH:mm"), TaxiNum);
        }
    }
}
