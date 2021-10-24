using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagement
{
    public class JoinTransaction : Transaction
    {

        private int TaxiNum { get; set; }
        private int RankId { get; set; }

        public JoinTransaction(DateTime transactionDateTime, int taxiNum, int rankId) : base("Join", transactionDateTime)
        {
            TaxiNum = taxiNum;
            RankId = rankId;

        }
        public override string ToString()
        {
            return string.Format("{0} Join      - Taxi {1} in rank {2}", TransactionDatetime.ToString("dd/MM/yyyy HH:mm"), TaxiNum, RankId);
        }
    }
}
