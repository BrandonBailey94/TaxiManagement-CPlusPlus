using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagement
{
    public class LeaveTransaction : Transaction
    {

        private int TaxiNum { get; set; }
        private int RankId { get; set; }
        private string Destination { get; set; }
        private double AgreedPrice { get; set; }
        public LeaveTransaction(DateTime transactionDateTime, int rankId, Taxi t) : base("Leave", transactionDateTime)
        {
            TaxiNum = t.Number;
            RankId = rankId;
            Destination = t.Destination;
            AgreedPrice = t.CurrentFare;
        }

        public override string ToString()
        {
            return string.Format("{0} Leave     - Taxi {1} from rank {2} to {3} for £{4}", TransactionDatetime.ToString("dd/MM/yyyy HH:mm"), TaxiNum, RankId, Destination, AgreedPrice);
        }
    }
}
