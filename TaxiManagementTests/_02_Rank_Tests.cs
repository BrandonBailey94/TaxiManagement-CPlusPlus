using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxiManagement;

namespace TaxiManagementTests
{
    [TestClass]
    public class _02_Rank_Tests
    {
        /*
         * Uncomment from line 13
         */

        [TestMethod]
        public void _01_RankIdIsSet()
        {
            Rank r = new Rank(1, 1);
            Assert.AreEqual(1, r.Id);
        }

        [TestMethod]
        public void _02_AddTaxiSetsRankInTaxi()
        {
            Rank r = new Rank(1, 1);
            Taxi t = new Taxi(1);
            r.AddTaxi(t);
            Assert.AreEqual(r, t.Rank);
        }

        [TestMethod]
        public void _03_AddTaxiReturnsFalseWhenRankHasNoSpareSpace()
        {
            Rank r = new Rank(1, 1);
            r.AddTaxi(new Taxi(1));
            Assert.IsFalse(r.AddTaxi(new Taxi(2)));
        }

        [TestMethod]
        public void _04_AddTaxiReturnsTrueWhenRankHasOneSpareSpace()
        {
            Rank r = new Rank(1, 1);
            Assert.IsTrue(r.AddTaxi(new Taxi(1)));
        }

        [TestMethod]
        public void _05_FirstTaxiInIsFirstOut()
        {
            Rank r = new Rank(1, 2);
            Taxi t = new Taxi(1);
            r.AddTaxi(t);
            r.AddTaxi(new Taxi(2));
            Assert.AreEqual(t, r.FrontTaxiTakesFare("Somewhere", 1.23));
        }

        [TestMethod]
        public void _06_FrontTaxiTakesFareReturnsCorrectTaxiWhenRankIsNotEmpty()
        {
            Taxi t = new Taxi(1);
            Rank r = new Rank(1, 1);
            r.AddTaxi(t);
            Assert.AreEqual(t, r.FrontTaxiTakesFare("Somewhere", 1.23));
        }

        [TestMethod]
        public void _07_FrontTaxiTakesFareRemovesTaxiFromRank()
        {
            Rank r = new Rank(1, 2);
            Taxi t = new Taxi(1);
            r.AddTaxi(t);
            r.AddTaxi(new Taxi(2));
            Taxi t2 = r.FrontTaxiTakesFare("Somewhere", 1.23);
            t2.DropFare(true);
            Assert.IsTrue(r.AddTaxi(t));
        }

        [TestMethod]
        public void _08_FrontTaxiTakesFareReturnsNullWhenRankIsEmpty()
        {
            Rank r = new Rank(1, 1);
            Assert.IsNull(r.FrontTaxiTakesFare("Nowhere", 1.23));
        }
    }
}
