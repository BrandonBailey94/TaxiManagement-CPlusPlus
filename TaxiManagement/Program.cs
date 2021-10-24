using System;
using System.Collections.Generic;

namespace TaxiManagement
{
    class Program
    {
        public static RankManager rankMgr = new RankManager();
        public static TaxiManager taxiMgr = new TaxiManager();
        public static TransactionManager transactionMgr = new TransactionManager();
        public static UserUI UI = new UserUI(rankMgr, taxiMgr, transactionMgr);
        static void Main(string[] args)
        {
            int selection = 0;

            Console.WriteLine("Welcome to the Taxi Rank system.");
            do
            {
                DisplayMenu();
                selection = ReadInteger("Insert selection: ");

                switch (selection)
                {
                    case 1:
                        TaxiDropsFare();
                        break;
                    case 2:
                        TaxiJoinsRank();
                        break;
                    case 3:
                        TaxiLeavesRank();
                        break;
                    case 4:
                        DisplayResults(UI.ViewFinancialReport());
                        break;
                    case 5:
                        DisplayResults(UI.ViewTaxiLocations());
                        break;
                    case 6:
                        DisplayResults(UI.ViewTransactionLog());
                        break;
                    case -1:
                        Console.WriteLine("System Closing!");
                        break;
                    default:
                        Console.WriteLine("Invalid selection.");
                        break;
                }
            } while (selection != -1);
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("1) Taxi Drops Fare");
            Console.WriteLine("2) Taxi Joins Rank");
            Console.WriteLine("3) Taxi Leaves Rank");
            Console.WriteLine("4) View Financial Report");
            Console.WriteLine("5) View Taxi Locations");
            Console.WriteLine("6) View Transaction Log");
            Console.WriteLine("-1) Quit");
            Console.WriteLine("");
        }

        public static void TaxiDropsFare()
        {
            UI.TaxiDropsFare(
            ReadInteger("Please enter a taxi number: "),
            ReadString("Was the price paid? y/n").ToLower().StartsWith('y'));
        }

        public static void TaxiJoinsRank()
        {
            UI.TaxiJoinsRank(ReadInteger("Please enter a taxi number: "), ReadInteger("Please enter a rank number: "));
        }

        public static void TaxiLeavesRank()
        {
            UI.TaxiLeavesRank(ReadInteger("Please enter a taxi number: "), ReadString("Please enter a destination: "), ReadDouble("Please enter the fare price: "));
        }

        private static void DisplayResults(List<string> results)
        {
            Console.WriteLine("");
            foreach (string s in results)
            {
                Console.WriteLine("'" + s + "'" + "\n");
            }
        }

        private static double ReadDouble(string prompt)
        {
            Console.WriteLine(prompt);
            return Convert.ToDouble(Console.ReadLine());
        }

        private static int ReadInteger(string prompt)
        {
            Console.WriteLine(prompt);
            return Convert.ToInt32(Console.ReadLine());
        }

        private static string ReadString(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
    }
}
