using System;

namespace TaxiManagement
{
    public abstract class Transaction
    {

        public DateTime TransactionDatetime { get; }

        public string TransactionType { get; }

        public Transaction(string transactionType, DateTime transactionDatetime)
        {
            TransactionDatetime = transactionDatetime;
            TransactionType = transactionType;
        }
    }
}
