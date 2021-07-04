using System;
using System.Collections.Generic;

namespace PT13{
    public class Manager:User{
        private int _selected;
        private Admin _admin;
        public Manager(Admin Admin){
            _admin = Admin;
        }
        public override void Selected()
        {
            Console.WriteLine("Select Option: ");
            _selected = Convert.ToInt16(Console.ReadLine());
        }
        /// <summary>
        /// Override for View Loyal Customer
        /// </summary>
        public override int ViewCustomers(){
            int i = 0;
            foreach(Customer cust in _admin.Cust){
                if (cust is Customer && cust.Total() > 1000){
                    i++;
					Console.WriteLine("\nCustomer Loyal" + i + "\n");
					cust.ViewCustomerDetails();
                }
            }
            if (i == 0){
				Console.WriteLine("\nThere is no loyal customers yet\n");
			}
			return i;
        }
        /// <return>"There is no loyal customers yet" if suceed</return>
        /// <summary>
        /// View Bookings by inputting Date
        /// </summary>
        public void ViewBookingsbyDate(){
            int i = 0;
            string pattern= "dd/MM/yyyy";
            Console.Write("Input Date (dd/MM/yyyy) to search: ");
            pattern = Console.ReadLine();
            if(_admin.Booking.Find(y => y.Date.ToString("dd/MM/yyyy") == pattern) != null){
                Console.WriteLine("There is/are booking with Date {0}", pattern);
                foreach(Booking booking in _admin.Booking){
                    if (pattern == booking.Date.ToString("dd/MM/yyyy")){
                        i++;
                        Console.WriteLine("\nBooking " + i + "\n");
                        booking.ViewBookingDetails();
                    }
                }
            }else{
                Console.WriteLine("This date does not have booking in it");
            }
        }
        /// <summary>
        /// Filtering Card Games
        /// </summary>
        public void FilterInventory(){
            string x;
            int z;
            Console.WriteLine("What are you Filtering?");
            Console.WriteLine("1. Card Name\n2. Series Number\n3. Rarity\n4. Colour\n5. Foil");
            Selected();
            /// <summary>
            /// Asking for category to be filtered then give complete details of the card after searching 
            /// </summary>
            switch(_selected){
                case 1:
                Console.Write("Enter search for Card Name: ");
                x = Console.ReadLine();
                if(_admin.Card.Find(y => y.Name.ToLower() == x.ToLower()) != null){
                    Console.WriteLine("There is a Card Name: {0}", x);
                    foreach(Card card in _admin.Card){
                        if(x.ToLower() == card.Name.ToLower()){
                            Console.WriteLine("This is/are the card\n");
                            card.ViewInventoryDetails();
                        }
                    }
                }else{
                    Console.WriteLine("There is no Card Name: {0}\n", x);
                }
                break;
                case 2:
                Console.Write("Enter search for Card Number Series: ");
                z = Convert.ToInt32(Console.ReadLine());
                if(_admin.Card.Find(y => y.Series == z) != null){
                    Console.WriteLine("There is a Card with Number Series: {0}", z);
                    foreach(Card card in _admin.Card){
                        if(z == card.Series){
                            Console.WriteLine("This is/are the card\n");
                            card.ViewInventoryDetails();
                        }
                    }
                }else{
                    Console.WriteLine("There is no Card with Series Number: {0}\n", z);
                }
                break;
                case 3:
                Console.Write("Enter search for Rarity: ");
                x = Console.ReadLine();
                if(_admin.Card.Find(y => y.Rarity.ToLower() == x.ToLower()) != null){
                    Console.WriteLine("There is a Card with Rarity: {0}", x);
                    foreach(Card card in _admin.Card){
                        if(x.ToLower() == card.Rarity.ToLower()){
                            Console.WriteLine("This is/are the card\n");
                            card.ViewInventoryDetails();
                        }
                    }
                }else{
                    Console.WriteLine("There is no Card with Rarity: {0}\n", x);
                }
                break;
                case 4:
                Console.Write("Enter search for Colour: ");
                x = Console.ReadLine();
                if(_admin.Card.Find(y => y.Colour.ToLower() == x.ToLower()) != null){
                    Console.WriteLine("There is a Card with Colour: {0}", x);
                    foreach(Card card in _admin.Card){
                        if(x.ToLower() == card.Colour.ToLower()){
                            Console.WriteLine("This is/are the card\n");
                            card.ViewInventoryDetails();
                        }
                    }
                }else{
                    Console.WriteLine("There is no Card with Colour: {0}\n", x);
                }
                break;
                case 5:
                Console.Write("Enter search for Foil/Non-Foil (y/n): ");
                Foil ff = Foil.Foil;
                Foil nf = Foil.NonFoil;
                x = Console.ReadLine();
                while(x != "y" | x != "n"){
                    if(x.ToLower() == "y"){
                        if(_admin.Card.Find(y => y.Foil == ff) != null){
                        Console.WriteLine("There is a Card with Foil");
                            foreach(Card card in _admin.Card){
                                if(card.Foil == ff){
                                    Console.WriteLine("This is/are the card\n");
                                    card.ViewInventoryDetails();
                                }
                            }
                        }else{
                            Console.WriteLine("There is no Card with Foil");
                        }
                    break;
                    }
                    else if(x.ToLower() == "n"){
                        if(_admin.Card.Find(y => y.Foil == nf) != null){
                        Console.WriteLine("There is a Card with Non-Foil");
                            foreach(Card card in _admin.Card){
                                if(card.Foil == nf){
                                    Console.WriteLine("This is/are the card\n");
                                    card.ViewInventoryDetails();
                                }
                            }
                        }else{
                            Console.WriteLine("There is no Card with Non-Foil"); 
                        }
                    break;
                    }
                Console.WriteLine("Wrong input");
                Console.Write("Enter Again: ");
                x = Console.ReadLine();
                }
                break;
            }
        }
        /// <summary>
        /// View Transaction by inputting daily date or monthly date, need to create customer and add transaction before being able to be used
        /// </summary>
        public void ViewTransactionsDailyMonthly(){
            int i = 0;
            int d = 0;
            string pattern = "dd/MM/yyyy";
            string pattern2 = "MM/yy";
            Console.WriteLine("1. Daily Transaction");
            Console.WriteLine("2. Monthly Transaction");
            Selected();
            if(_selected == 1){
                Console.Write("Input Date (dd/MM/yyyy) to search: ");
                pattern = Console.ReadLine();
                foreach(Customer cust in _admin.Cust){
                    i++;
                    if(cust.Trans.Find(y => y.TransDate.ToString("dd/MM/yyyy") == pattern) != null){
                        d++;
                        foreach(Transaction trans in cust.Trans){
                            
                            if (pattern == trans.TransDate.ToString("dd/MM/yyyy")){
                                trans.PrintInfo();
                            }
                        }
                    }
                }if(i == 0){
                    Console.WriteLine("No customers yet, you need to create customer account and add transaction before ");
                }
            }else if(_selected == 2){
                Console.Write("Input Date (MM/yy) to search: ");
                pattern2 = Console.ReadLine();
                foreach(Customer cust in _admin.Cust){
                    i++;
                    if(cust.Trans.Find(y => y.TransDate.ToString("MM/yy") == pattern2) != null){
                        d++;
                        foreach(Transaction trans in cust.Trans){
                            if (pattern2 == trans.TransDate.ToString("MM/yy")){
                                trans.PrintInfo();
                            }
                        }
                    }
                }if(i == 0){
                    Console.WriteLine("No customers yet, you need to create customer account and add transaction before ");
                }
            }
        }
    }
}