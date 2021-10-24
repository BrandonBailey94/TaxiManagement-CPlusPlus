using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxiManagement;

namespace TaxiManagementTests
{
    [TestClass]
    public class _05_RankManager_Tests
    {
        /*
         * Uncomment from line 13
         */

        [TestMethod]
        public void _01_ConstructorCreatesRank1()
        {
            RankManager rm = new RankManager();
            Assert.IsNotNull(rm.FindRank(1));
        }

        [TestMethod]
        public void _02_Rank1CanAcceptFiveTaxis()
        {
            RankManager rm = new RankManager();
            Rank r = rm.FindRank(1);
            r.AddTaxi(new Taxi(1));
            r.AddTaxi(new Taxi(2));
            r.AddTaxi(new Taxi(3));
            r.AddTaxi(new Taxi(4));
            Assert.IsTrue(r.AddTaxi(new Taxi(5)));
        }

        [TestMethod]
        public void _03_Rank1CannotAcceptSixthTaxi()
        {
            RankManager rm = new RankManager();
            Rank r = rm.FindRank(1);
            r.AddTaxi(new Taxi(1));
            r.AddTaxi(new Taxi(2));
            r.AddTaxi(new Taxi(3));
            r.AddTaxi(new Taxi(4));
            r.AddTaxi(new Taxi(5));
            Assert.IsFalse(r.AddTaxi(new Taxi(6)));
        }

        [TestMethod]
        public void _04_ConstructorCreatesRank2()
        {
            RankManager rm = new RankManager();
            Assert.IsNotNull(rm.FindRank(2));
        }

        [TestMethod]
        public void _05_Rank2CanAcceptTwoTaxis()
        {
            RankManager rm = new RankManager();
            Rank r = rm.FindRank(2);
            r.AddTaxi(new Taxi(1));
            Assert.IsTrue(r.AddTaxi(new Taxi(2)));
        }

        [TestMethod]
        public void _06_Rank2CannotAcceptThirdTaxi()
        {
            RankManager rm = new RankManager();
            Rank r = rm.FindRank(2);
            r.AddTaxi(new Taxi(1));
            r.AddTaxi(new Taxi(2));
            Assert.IsFalse(r.AddTaxi(new Taxi(3)));
        }

        [TestMethod]
        public void _07_ConstructorCreatesRank3()
        {
            RankManager rm = new RankManager();
            Assert.IsNotNull(rm.FindRank(3));
        }

        [TestMethod]
        public void _08_Rank3CanAcceptFourTaxis()
        {
            RankManager rm = new RankManager();
            Rank r = rm.FindRank(3);
            r.AddTaxi(new Taxi(1));
            r.AddTaxi(new Taxi(2));
            r.AddTaxi(new Taxi(3));
            Assert.IsTrue(r.AddTaxi(new Taxi(4)));
        }

        [TestMethod]
        public void _09_Rank3CannotAcceptFifthTaxi()
        {
            RankManager rm = new RankManager();
            Rank r = rm.FindRank(3);
            r.AddTaxi(new Taxi(1));
            r.AddTaxi(new Taxi(2));
            r.AddTaxi(new Taxi(3));
            r.AddTaxi(new Taxi(4));
            Assert.IsFalse(r.AddTaxi(new Taxi(5)));
        }

        [TestMethod]
        public void _10_FindRankReturnsNullWhenRankNotFound()
        {
            RankManager rm = new RankManager();
            Assert.IsNull(rm.FindRank(4));
        }

        [TestMethod]
        public void _11_FindRankReturnsCorrectRank()
        {
            RankManager rm = new RankManager();
            Assert.AreEqual(1, rm.FindRank(1).Id);
        }

        [TestMethod]
        public void _12_AddTaxiToRankReturnsFalseWhenTaxiAlreadyInThatRank()
        {
            RankManager rm = new RankManager();
            Taxi t = new Taxi(14);
            rm.AddTaxiToRank(t, 1);
            Assert.IsFalse(rm.AddTaxiToRank(t, 1));
        }

        [TestMethod]
        public void _13_AddTaxiToRankReturnsFalseWhenTaxiAlreadyInAnotherRank()
        {
            RankManager rm = new RankManager();
            Taxi t = new Taxi(1);
            rm.AddTaxiToRank(t, 1);
            Assert.IsFalse(rm.AddTaxiToRank(t, 2));
        }

        [TestMethod]
        public void _14_AddTaxiToRankReturnsFalseWhenRankDoesNotExist()
        {
            RankManager rm = new RankManager();
            Assert.IsFalse(rm.AddTaxiToRank(new Taxi(3), 4));
        }

        [TestMethod]
        public void _15_AddTaxiToRankReturnsFalseWhenTaxiHasDestination()
        {
            RankManager rm = new RankManager();
            Taxi t = new Taxi(1);
            t.AddFare("Somewhere", 1.23);
            Assert.IsFalse(rm.AddTaxiToRank(t, 1));
        }

        [TestMethod]
        public void _16_AddTaxiToRankReturnsFalseWhenSpaceIsNotAvailable()
        {
            RankManager rm = new RankManager();
            rm.AddTaxiToRank(new Taxi(1), 2);
            rm.AddTaxiToRank(new Taxi(2), 2);
            Assert.IsFalse(rm.AddTaxiToRank(new Taxi(3), 2));
        }

        [TestMethod]
        public void _17_AddTaxiToRankReturnsTrueWhenSpaceIsAvailable()
        {
            RankManager rm = new RankManager();
            Assert.IsTrue(rm.AddTaxiToRank(new Taxi(2), 1));
        }

        [TestMethod]
        public void _18_FrontTaxiInRankTakesFareReturnsCorrectTaxi()
        {
            RankManager rm = new RankManager();
            Taxi t = new Taxi(2);
            rm.AddTaxiToRank(t, 1);
            rm.AddTaxiToRank(new Taxi(5), 1);
            Assert.AreEqual(t, rm.FrontTaxiInRankTakesFare(1, "Anywhere", 1.23));
        }

        [TestMethod]
        public void _19_FrontTaxiInRankTakesFareReturnsNullWhenRankIsEmpty()
        {
            RankManager rm = new RankManager();
            Assert.IsNull(rm.FrontTaxiInRankTakesFare(1, "Anywhere", 1.23));
        }

        [TestMethod]
        public void _20_FrontTaxiInRankTakesFareReturnsNullWhenRankNonexistent()
        {
            RankManager rm = new RankManager();
            Assert.IsNull(rm.FrontTaxiInRankTakesFare(4, "Anywhere", 1.23));
        }
    }
}
