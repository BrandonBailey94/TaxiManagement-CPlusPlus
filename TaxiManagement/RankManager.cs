using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagement
{
    public class RankManager
    {
        private Dictionary<int, Rank> ranks = new Dictionary<int, Rank>();

        public RankManager()
        {
            ranks.Add(1, new Rank(1, 5));
            ranks.Add(2, new Rank(2, 2));
            ranks.Add(3, new Rank(3, 4));

        }

        public bool AddTaxiToRank(Taxi t, int RankId)
        {
            if (!ranks.ContainsKey(RankId) || t.Rank != null)
            {
                return false;
            }
            else
            {
                return ranks[RankId].AddTaxi(t);
            }
        }

        public Rank FindRank(int rankId)
        {
            if (ranks.ContainsKey(rankId))
            {
                return ranks[rankId];
            }
            return null;
        }

        public Taxi FrontTaxiInRankTakesFare(int rankId, string destination, double agreedPrice)
        {
            if (!ranks.ContainsKey(rankId))
            {
                return null;
            }
            else
            {
                return ranks[rankId].FrontTaxiTakesFare(destination, agreedPrice);
            }
        }
    }
}
