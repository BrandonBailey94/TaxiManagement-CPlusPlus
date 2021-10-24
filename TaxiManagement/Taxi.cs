using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagement
{
    public class Taxi
    {
        public static string IN_RANK = "in rank";
        public static string ON_ROAD = "on the road";
        public double CurrentFare { get; set; }
        public string Destination { get; set; } = "";
        public string Location { get; set; } = ON_ROAD;
        public int Number { get; }

        private Rank rank;
        public Rank Rank
        {
            get { return rank; }
            set { SetRank(value); }
        }
        public double TotalMoneyPaid { get; set; } = 0;
        public Taxi(int taxiNum)
        {
            Number = taxiNum;
        }

        public void AddFare(string destination, double agreedPrice)
        {
            Destination = destination;
            CurrentFare = agreedPrice;
            Location = ON_ROAD;
            rank = null;
        }
        
        public void DropFare(bool priceWasPaid)
        {
            if(priceWasPaid)
            {
                TotalMoneyPaid += CurrentFare;
            }
            Destination = "";
            CurrentFare = 0;
        }

        public void SetRank(Rank r)
        {
            //When rank is null/not set throw exception
            if (r == null)
            {
                throw new Exception("Rank cannot be null");
            }

            //When destination is not empty or null throw exception
            if (!String.IsNullOrEmpty(Destination))
            {
                throw new Exception("Cannot join rank if fare has not been dropped");
            } else {
                Location = IN_RANK;
            }
            rank = r;
        }
    }
}

