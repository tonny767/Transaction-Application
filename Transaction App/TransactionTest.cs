using System;
using NUnit.Framework;

namespace PT13{
    [TestFixture()]
    public class TestPoints{
        [Test()]
        /// <summary>
        /// Testing UpdatePoints() in transaction
        /// </summary>
        public void Points(){
            int result;
            Transaction trans= new Transaction(0, DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", null), 0);
            trans.Amounts = 2000;
            result = trans.UpdatePoints();
            Assert.AreEqual(result, 1000);
        }
        [Test()]
        /// <summary>
        /// Testing DateTime in Transaction and making sure the format was correct
        /// </summary>
        public void Date(){
            string result;
            Transaction trans= new Transaction(0, DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", null), 0);
            trans.TransDate = DateTime.ParseExact("20/03/2021", "dd/MM/yyyy", null);
            result = trans.TransDate.ToString("dd/MM/yyyy");
            Assert.AreEqual(result, "20/03/2021");
        }
    }
}