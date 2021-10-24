using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagement
{
    public class TaxiManager
    {
        private SortedDictionary<int, Taxi> taxis = new SortedDictionary<int, Taxi>();

        public Taxi CreateTaxi(int taxiNum)
        {
            if(taxis.ContainsKey(taxiNum))
            {
                return taxis[taxiNum];
            } else {
                taxis.Add(taxiNum, new Taxi(taxiNum));
                return taxis[taxiNum];
            }
        }
        public Taxi FindTaxi(int taxiNum)
        {
            Taxi taxi;
            return taxis.TryGetValue(taxiNum, out taxi) ? taxi : null;
        }
        public SortedDictionary<int, Taxi> GetAllTaxis()
        {
            return taxis;
        }
    }
}
