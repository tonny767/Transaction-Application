using System;
using System.Collections.Generic;
using NUnit.Framework;

/// <summary>
/// Admin test, Test many classes at once..
/// </summary>
namespace PT13{
    [TestFixture]
    public class AdminTest{
        /// <summary>
        /// Test for Customer for its message when it is available or not
        /// </summary>
        [Test]
        public void ViewCustomerCheckifNotAvailable(){
            Admin admin = new Admin();
            Assert.AreEqual(0, admin.ViewCustomers());
        }
        [Test]
        public void ViewCustomerCheckifAvailable(){
            Admin admin = new Admin();
            Customer cust = new Customer(0, "", "", DateTime.ParseExact("01/01/0001","dd/MM/yyyy", null));
            admin.TestAddCust(cust);
            Assert.AreEqual(1, admin.ViewCustomers());
        }
        /// <summary>
        /// Test for Booking for its message when it is available or not
        /// </summary>
        [Test]
        public void ViewBookingCheckifNotAvailable(){
            Admin admin = new Admin();
            Assert.AreEqual(0, admin.ViewBookings());
        }
        [Test]
        public void ViewBookingCheckifAvailable(){
            Admin admin = new Admin();
            Booking booking = new Booking("",DateTime.ParseExact("01/01/0001","dd/MM/yyyy", null),0,"");
            admin.TestAddBooking(booking);
            Assert.AreEqual(1, admin.ViewBookings());
        }
        /// <summary>
        /// Test for Card for its message when it is available or not
        /// </summary>
        [Test]
        public void ViewCardCheckifNotAvailable(){
            Admin admin = new Admin();
            Assert.AreEqual(0, admin.ViewInventory());
        }
        [Test]
        public void ViewCardCheckifAvailable(){
            Admin admin = new Admin();
            Card card = new Card(0,"", "", "", Foil.Foil, 0, 0);
            admin.TestAddCard(card);
            Assert.AreEqual(1, admin.ViewInventory());
        }
        /// <summary>
        /// Test for Delete methods(all 3)
        /// </summary>
        [Test]
        public void TestDelete(){
            Admin admin = new Admin();
            Card card = new Card(0,"", "", "", Foil.Foil, 0, 0);
            Booking booking = new Booking("",DateTime.ParseExact("01/01/0001","dd/MM/yyyy", null),0,"");
            Customer cust = new Customer(0, "", "", DateTime.ParseExact("01/01/0001","dd/MM/yyyy", null));
            admin.TestAddBooking(booking);
            admin.TestAddCust(cust);
            admin.TestAddCard(card);
            //No Delete for booking, hence its 1
            admin.TestDeleteCust(cust);
            admin.TestDeleteCard(card);
            Assert.AreEqual(0, admin.ViewInventory());
            Assert.AreEqual(1, admin.ViewBookings());
            Assert.AreEqual(0, admin.ViewCustomers());
        }
        /// <summary>
        /// Test for Search Method. The methods for other search, filter or view daily monthly are the almost the same.
        /// </summary>
        [Test]
        public void TestSearchifAvailable(){
            int i = 0;
            string ff = "Test";// Test Name
            string nf = "Test2"; //Test Rarity
            Admin admin = new Admin();
            Card card = new Card(0,"", "", "", Foil.Foil, 0, 0);
            card.Name = "test";
            card.Rarity = "notrare";
            admin.TestAddCard(card);
            //Find Name
            if(admin.Card.Find(y => y.Name.ToLower() == ff.ToLower()) != null){
            Console.WriteLine("There is a Card with name "+ ff);
                if(card.Name.ToLower() == ff.ToLower()){
                    i++;
                    Console.WriteLine("This is/are the card\n");
                    card.ViewInventoryDetails();
                }
            }else{
                Console.WriteLine("There is no Card with name "+ ff);
            }
            //Find Rarity
            if(admin.Card.Find(y => y.Rarity.ToLower() == nf.ToLower()) != null){
            Console.WriteLine("There is a Card with Rarity "+ nf);
                if(card.Rarity.ToLower() == nf.ToLower()){
                    i++;
                    Console.WriteLine("This is/are the card\n");
                    card.ViewInventoryDetails();
                }
            }else{
                Console.WriteLine("There is no Card with Rarity "+ nf);
            }
            Assert.AreEqual(1, i);
        }
        ///<return> i = 1 if card is available, i = 0 when not available</return>
    }
}