using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagement
{
    public class Rank
    {
        public int Id { get; set; }
        public int NumberOfTaxiSpaces { get; set; }
        public List<Taxi> taxiSpace = new List<Taxi>();

        public Rank(int rankId, int numberOfTaxiSpaces)
        {
            Id = rankId;
            NumberOfTaxiSpaces = numberOfTaxiSpaces;
        }

        public bool AddTaxi(Taxi t)
        {
            if (taxiSpace.Count < NumberOfTaxiSpaces)
            {
                try
                {
                    t.Rank = this;
                    taxiSpace.Add(t);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }
        public Taxi FrontTaxiTakesFare(string destination, double agreedPrice)
        {
            if (taxiSpace.Count > 0)
            {
                Taxi firstTaxi = taxiSpace[0];
                firstTaxi.AddFare(destination, agreedPrice);
                taxiSpace.Remove(firstTaxi);
                return firstTaxi;
            } else {
                return null;
            }    
        }
    }
}
