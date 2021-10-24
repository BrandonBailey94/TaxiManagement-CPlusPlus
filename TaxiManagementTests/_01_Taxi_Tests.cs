using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TaxiManagement;

namespace TaxiManagementTests
{
    [TestClass]
    public class _01_Taxi_Tests
    {
        /*
         * Uncomment from line 14
         */

        [TestMethod]
        public void _01_NewTaxiNumberIsSet()
        {
            Taxi t = new Taxi(1);
            Assert.AreEqual(1, t.Number);
        }

        [TestMethod]
        public void _02_NewTaxiCurrentFareIsZero()
        {
            Taxi t = new Taxi(1);
            Assert.AreEqual(0, t.CurrentFare);
        }

        [TestMethod]
        public void _03_NewTaxiDestinationIsEmpty()
        {
            Taxi t = new Taxi(1);
            Assert.AreEqual(0, t.Destination.Length);
        }

        [TestMethod]
        public void _04_NewTaxiLocationIsOnRoad()
        {
            Taxi t = new Taxi(1);
            Assert.AreEqual("on the road", t.Location);
        }

        [TestMethod]
        public void _05_NewTaxiRankIsNull()
        {
            Taxi t = new Taxi(1);
            Assert.IsNull(t.Rank);
        }

        [TestMethod]
        public void _06_NewTaxiTotalMoneyPaidIsZero()
        {
            Taxi t = new Taxi(1);
            Assert.AreEqual(0, t.TotalMoneyPaid);
        }

        [TestMethod]
        public void _07_SetRankToNullThrowsException()
        {
            Taxi t = new Taxi(1);
            Assert.ThrowsException<Exception>(() => t.Rank = null);
        }

        [TestMethod]
        public void _08_SetRankToNullGivesCorrectExceptionMessage()
        {
            Taxi t = new Taxi(1);
            try
            {
                t.Rank = null;
            }
            catch (Exception e)
            {
                Assert.AreEqual("Rank cannot be null", e.Message);
            }
        }

        [TestMethod]
        public void _09_SetRankWhenDestinationIsNotEmptyThrowsException()
        {
            Taxi t = new Taxi(1);
            t.AddFare("Somewhere", 0);
            Rank r = new Rank(1, 1);
            Assert.ThrowsException<Exception>(() => t.Rank = r);
        }

        [TestMethod]
        public void _10_SetRankWhenDestinationIsNotEmptyGivesCorrectExceptionMessage()
        {
            Taxi t = new Taxi(1);
            t.AddFare("Somewhere", 0);
            Rank r = new Rank(1, 1);
            try
            {
                t.Rank = r;
            }
            catch (Exception e)
            {
                Assert.AreEqual("Cannot join rank if fare has not been dropped", e.Message);
            }
        }

        [TestMethod]
        public void _11_SetRankChangesRankWhenDestinationIsEmpty()
        {
            Taxi t = new Taxi(1);
            Rank r = new Rank(1, 1);
            t.Rank = r;
            Assert.AreEqual(r, t.Rank);
        }

        [TestMethod]
        public void _12_SetRankChangesLocationToInRankWhenDestinationIsEmpty()
        {
            Taxi t = new Taxi(1);
            Rank r = new Rank(1, 1);
            t.Rank = r;
            Assert.AreEqual(Taxi.IN_RANK, t.Location);
        }

        [TestMethod]
        public void _13_AddFareChangesCurrentFare()
        {
            Taxi t = new Taxi(1);
            t.AddFare("", 1.23);
            Assert.AreEqual(1.23, t.CurrentFare);
        }

        [TestMethod]
        public void _14_AddFareChangesDestination()
        {
            Taxi t = new Taxi(1);
            t.AddFare("New destination", 0);
            Assert.AreEqual("New destination", t.Destination);
        }

        [TestMethod]
        public void _15_AddFareChangesLocationToOnRoad()
        {
            Taxi t = new Taxi(1);
            t.AddFare("", 0);
            Assert.AreEqual("on the road", t.Location);
        }

        [TestMethod]
        public void _16_AddFareChangesRankToNull()
        {
            Taxi t = new Taxi(1);
            Rank r = new Rank(1, 1);
            t.Rank = r;
            t.AddFare("", 0);
            Assert.IsNull(t.Rank);
        }

        [TestMethod]
        public void _17_DropFareClearsDestination()
        {
            Taxi t = new Taxi(1);
            t.AddFare("New destination", 0);
            t.DropFare(true);
            Assert.AreEqual("", t.Destination);
        }

        [TestMethod]
        public void _18_DropFareResetsCurrentFareToZero()
        {
            Taxi t = new Taxi(1);
            t.AddFare("", 1.23);
            t.DropFare(true);
            Assert.AreEqual(0, t.CurrentFare);
        }

        [TestMethod]
        public void _19_DropFareDoesNotChangeLocation()
        {
            Taxi t = new Taxi(1);
            t.AddFare("Here and there", 1.23);
            t.DropFare(true);
            Assert.AreEqual(Taxi.ON_ROAD, t.Location);
        }

        [TestMethod]
        public void _20_DropFareChangesTotalMoneyTakenWhenPriceWasPaid()
        {
            Taxi t = new Taxi(1);
            t.AddFare("", 1.23);
            t.DropFare(true);
            Assert.AreEqual(1.23, t.TotalMoneyPaid);
        }

        [TestMethod]
        public void _21_DropFareDoesNotChangeTotalMoneyTakenWhenPriceWasNotPaid()
        {
            Taxi t = new Taxi(1);
            t.AddFare("", 1.23);
            t.DropFare(false);
            Assert.AreEqual(0, t.TotalMoneyPaid);
        }
    }
}
