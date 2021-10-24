using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TaxiManagement;

namespace TaxiManagementTests
{
    [TestClass]
    public class _03_Transactions_Tests
    {
        /*
         * Uncomment from line 14
         */

        [TestMethod]
        public void _01_InJoinTransaction_TransactionDateTimeIsCorrect()
        {
            DateTime now = DateTime.Now;
            Transaction t = new JoinTransaction(now, 1, 1);
            Assert.AreEqual(now, t.TransactionDatetime);
        }

        [TestMethod]
        public void _02_InJoinTransaction_TransactionTypeIsCorrect()
        {
            DateTime now = DateTime.Now;
            Transaction t = new JoinTransaction(now, 1, 1);
            Assert.AreEqual("Join", t.TransactionType);
        }

        [TestMethod]
        public void _03_InJoinTransaction_ToStringReturnsCorrectString()
        {
            DateTime now = DateTime.Now;
            string dateStr = now.ToString("dd/MM/yyyy HH:mm");
            JoinTransaction t = new JoinTransaction(now, 1, 2);
            Assert.AreEqual(
                dateStr + " Join      - Taxi 1 in rank 2",
                t.ToString());
        }

        [TestMethod]
        public void _04_InLeaveTransaction_TransactionDateTimeIsCorrect()
        {
            DateTime now = DateTime.Now;
            Taxi t = new Taxi(1);
            Transaction lt = new LeaveTransaction(now, 1, t);
            Assert.AreEqual(now, lt.TransactionDatetime);
        }

        [TestMethod]
        public void _05_InLeaveTransaction_TransactionTypeIsCorrect()
        {
            DateTime now = DateTime.Now;
            Taxi t = new Taxi(1);
            Transaction lt = new LeaveTransaction(now, 1, t);
            Assert.AreEqual("Leave", lt.TransactionType);
        }

        [TestMethod]
        public void _06_InLeaveTransaction_ToStringReturnsCorrectString()
        {
            DateTime now = DateTime.Now;
            string dateStr = now.ToString("dd/MM/yyyy HH:mm");
            Taxi t = new Taxi(1);
            t.AddFare("Somewhere nice", 1.23);

            LeaveTransaction lt = new LeaveTransaction(now, 2, t);
            Assert.AreEqual(
                dateStr + " Leave     - Taxi 1 from rank 2 to Somewhere nice for £1.23",
                lt.ToString());
        }

        [TestMethod]
        public void _07_InDropTransaction_TransactionDateTimeIsCorrect()
        {
            DateTime now = DateTime.Now;
            Transaction t = new DropTransaction(now, 1, true);
            Assert.AreEqual(now, t.TransactionDatetime);
        }

        [TestMethod]
        public void _08_InDropTransaction_TransactionTypeIsCorrect()
        {
            DateTime now = DateTime.Now;
            Transaction t = new DropTransaction(now, 1, true);
            Assert.AreEqual("Drop fare", t.TransactionType);
        }

        [TestMethod]
        public void _09_InDropTransaction_ToStringReturnsCorrectStringWhenPriceWasPaid()
        {
            DateTime now = DateTime.Now;
            string dateStr = now.ToString("dd/MM/yyyy HH:mm");
            DropTransaction t = new DropTransaction(now, 1, true);
            Assert.AreEqual(
                dateStr + " Drop fare - Taxi 1, price was paid",
                t.ToString());
        }

        [TestMethod]
        public void _10_InDropTransaction_ToStringReturnsCorrectStringWhenPriceWasNotPaid()
        {
            DateTime now = DateTime.Now;
            string dateStr = now.ToString("dd/MM/yyyy HH:mm");
            DropTransaction t = new DropTransaction(now, 1, false);
            Assert.AreEqual(
                dateStr + " Drop fare - Taxi 1, price was not paid",
                t.ToString());
        }
    }
}
