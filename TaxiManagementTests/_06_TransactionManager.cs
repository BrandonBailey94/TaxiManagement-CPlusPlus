using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxiManagement;

namespace TaxiManagementTests
{
    [TestClass]
    public class _06_TransactionManager
    {
        /*
         * Uncomment from line 13
         */

        [TestMethod]
        public void _01_RecordJoinCreatesJoinTransaction()
        {
            TransactionManager tm = new TransactionManager();
            tm.RecordJoin(1, 1);
            Assert.AreEqual("JoinTransaction", tm.GetAllTransactions()[0].GetType().Name);
        }

        [TestMethod]
        public void _02_RecordLeaveCreatesLeaveTransaction()
        {
            TransactionManager tm = new TransactionManager();
            tm.RecordLeave(1, new Taxi(1));
            Assert.AreEqual("LeaveTransaction", tm.GetAllTransactions()[0].GetType().Name);
        }

            [TestMethod]
        public void _03_RecordDropCreatesDropTransaction()
        {
            TransactionManager tm = new TransactionManager();
            tm.RecordDrop(1, true);
            Assert.AreEqual("DropTransaction", tm.GetAllTransactions()[0].GetType().Name);
        }
    }
}
