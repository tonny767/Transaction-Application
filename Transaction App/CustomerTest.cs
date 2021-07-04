using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace PT13{
    [TestFixture]
    public class CustomerTest{
        [Test]
        public void MemberDetailsActive(){
            Customer cust1 = new Customer(0, "", "", DateTime.ParseExact("01/01/0001","dd/MM/yyyy", null));
            cust1.Status = true;
            Assert.AreEqual("Member status : Active", cust1.MemberDetails());
        }
        [Test]
        public void MemberDetailsNonActive(){
            Customer cust1 = new Customer(0, "", "", DateTime.ParseExact("01/01/0001","dd/MM/yyyy", null));
            cust1.Status = false;
            Assert.AreEqual("Member status : Not Active", cust1.MemberDetails());
        }
        [Test]
        public void CustomerTotal(){
            int total;
            Customer cust1 = new Customer(0, "", "", DateTime.ParseExact("01/01/0001","dd/MM/yyyy", null));
            Transaction trans1= new Transaction(0, DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", null), 0);
            Transaction trans2 = new Transaction(0, DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", null), 0);
            trans1.Amounts = 2000;
            trans2.Amounts = 1000;
            cust1.Add(trans1);
            cust1.Add(trans2);
            total = cust1.Total();
            Assert.AreEqual(total, 3000);
        }
        [Test]
        public void CustomerTotalPoints(){
            int total;
            Customer cust1 = new Customer(0, "", "", DateTime.ParseExact("","dd/MM/yyyy", null));
            Transaction trans1= new Transaction(0, DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", null), 0);
            Transaction trans2 = new Transaction(0, DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", null), 0);
            trans1.Amounts = 2000;
            trans2.Amounts = 1000;
            cust1.Add(trans1);
            cust1.Add(trans2);
            total = cust1.UpdateTotalPoints();
            Assert.AreEqual(total, 1500);
        }
    }
}