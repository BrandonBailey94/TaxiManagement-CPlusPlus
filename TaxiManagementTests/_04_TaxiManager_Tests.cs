using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TaxiManagement;

namespace TaxiManagementTests
{
    [TestClass]
    public class _04_TaxiManager_Tests
    {
        /*
         * Uncomment from line 14
         */

        [TestMethod]
        public void _01_NewTaxiManagerHasEmptyTaxiCollection()
        {
            TaxiManager tm = new TaxiManager();
            Assert.AreEqual(0, tm.GetAllTaxis().Count);
        }

        [TestMethod]
        public void _02_FindTaxiReturnsNullWhenTaxiNotFound()
        {
            TaxiManager tm = new TaxiManager();
            Assert.IsNull(tm.FindTaxi(1));
        }

        [TestMethod]
        public void _03_FindTaxiReturnsCorrectTaxi()
        {
            TaxiManager tm = new TaxiManager();
            SortedDictionary<int, Taxi> taxis = tm.GetAllTaxis();
            Taxi t = new Taxi(2);
            taxis.Add(1, new Taxi(1));
            taxis.Add(2, t);
            taxis.Add(3, new Taxi(3));
            Assert.AreEqual(t, tm.FindTaxi(2));
        }

        [TestMethod]
        public void _04_CreateTaxiReturnsNewTaxi()
        {
            TaxiManager tm = new TaxiManager();
            Taxi t = new Taxi(2);
            Assert.AreNotSame(t, tm.CreateTaxi(2));
        }

        [TestMethod]
        public void _05_CreateTaxiReturnsNewTaxiWithCorrectNumber()
        {
            TaxiManager tm = new TaxiManager();
            Assert.AreEqual(2, tm.CreateTaxi(2).Number);
        }

        [TestMethod]
        public void _06_CreateTaxiAddsNewTaxiToCollectionWhenTaxiNumberNotAlreadyInUse()
        {
            TaxiManager tm = new TaxiManager();
            tm.CreateTaxi(2);
            Assert.AreEqual(2, tm.FindTaxi(2).Number);
        }

        [TestMethod]
        public void _07_CreateTaxiReturnsExistingTaxiWhenTaxiNumberAlreadyInUse()
        {
            TaxiManager tm = new TaxiManager();
            SortedDictionary<int, Taxi> taxis = tm.GetAllTaxis();
            Taxi t = new Taxi(1);
            taxis.Add(1, t);
            Assert.AreEqual(t, tm.CreateTaxi(1));
        }
    }
}
