//using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagement
{
    public class UserUI
    {
        private RankManager rankMgr;
        private TaxiManager taxiMgr;
        private TransactionManager transactionMgr;
        public UserUI(RankManager rkMgr, TaxiManager txMgr, TransactionManager trMgr)
        {
            this.rankMgr = rkMgr;
            this.taxiMgr = txMgr;
            this.transactionMgr = trMgr;
        }

        public List<string> TaxiJoinsRank(int taxiNum, int rankId)
        {
            List<string> outputLines = new List<string>();

            if (rankMgr.AddTaxiToRank(taxiMgr.CreateTaxi(taxiNum), rankId))
            {
                transactionMgr.RecordJoin(taxiNum, rankId);
                outputLines.Add(string.Format("Taxi {0} has joined rank {1}.", taxiNum, rankId));
            }
            else
            {
                outputLines.Add(string.Format("Taxi {0} has not joined rank {1}.", taxiNum, rankId));
            }
            return outputLines;
        }

        public List<string> TaxiLeavesRank(int rankId, string destination, double agreedPrice)
        {
            List<string> outputLines = new List<string>();
            Taxi t = rankMgr.FrontTaxiInRankTakesFare(rankId, destination, agreedPrice);
            if (t != null)
            {
                outputLines.Add(string.Format("Taxi {0} has left rank {1} to take a fare to {2} for £{3}.", t.Number, rankId, destination, agreedPrice));
                transactionMgr.RecordLeave(rankId, t);
            } else {
                outputLines.Add(string.Format("Taxi has not left rank {0}.", rankId));
            }
            return outputLines;
        }

        public List<string> TaxiDropsFare(int taxiNum, bool pricePaid)
        {
            List<string> outputLines = new List<string>();
            Taxi t = taxiMgr.FindTaxi(taxiNum);

            if (t.Rank != null)
            {
                outputLines.Add(string.Format("Taxi {0} has not dropped its fare.", taxiNum));
            }
            else
            {
                if (pricePaid)
                {
                    t.DropFare(pricePaid);
                    outputLines.Add(string.Format("Taxi {0} has dropped its fare and the price was paid.", taxiNum));
                }
                else
                {
                    outputLines.Add(string.Format("Taxi {0} has dropped its fare and the price was not paid.", taxiNum));
                }
                transactionMgr.RecordDrop(taxiNum, pricePaid);
            }
            return outputLines;
        }

        public List<string> ViewTaxiLocations()
        {
            SortedDictionary<int, Taxi> taxis = taxiMgr.GetAllTaxis();
            List<string> outputLines = new List<string>();
            outputLines.Add("Taxi locations");
            outputLines.Add("==============");
            if (taxis.Count == 0)
            {
                outputLines.Add("No taxis");
            }
            else
            {
                foreach (Taxi t in taxis.Values)
                {
                    if (t.Rank == null)
                    {
                        //on the road
                        if (t.Destination != "")
                        {
                            outputLines.Add(string.Format("Taxi {0} is on the road to {1}", t.Number, t.Destination));
                        }
                        else 
                        {
                            outputLines.Add(string.Format("Taxi {0} is on the road", t.Number));

                        }
                    } else {
                        outputLines.Add(string.Format("Taxi {0} is in rank {1}", t.Number, t.Rank.Id));
                    }
                }
            }
            return outputLines;
        }

        public List<string> ViewFinancialReport()
        {
            SortedDictionary<int, Taxi> taxis = taxiMgr.GetAllTaxis();
            List<string> outputLines = new List<string>();
            double total = 0;
            outputLines.Add("Financial report");
            outputLines.Add("================");
            if (taxis.Count == 0)
            {
                outputLines.Add("No taxis, so no money taken");
            } else {
                foreach (Taxi t in taxis.Values)
                {
                    total += t.TotalMoneyPaid;
                    outputLines.Add(string.Format("Taxi {0}      {1}", t.Number, t.TotalMoneyPaid.ToString("0.00")));
                }
                outputLines.Add(string.Format("           ======"));
                outputLines.Add(string.Format("Total:       {0}", total.ToString("0.00")));
                outputLines.Add(string.Format("           ======"));
            }
            return outputLines;
        }

        public List<string> ViewTransactionLog()
        {
            List<Transaction> transactions = transactionMgr.GetAllTransactions();
            List<string> outputLines = new List<string>();
            outputLines.Add("Transaction report");
            outputLines.Add("==================");
            if (transactions.Count == 0)
            {
                outputLines.Add("No transactions");
            }
            else
            {
                foreach (Transaction t in transactions)
                {
                    outputLines.Add(t.ToString());
                }
            }
            return outputLines;
        }
    }
}
