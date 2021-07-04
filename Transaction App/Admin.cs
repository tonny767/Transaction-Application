using System;
using System.Collections.Generic;

namespace PT13{
    public class Admin:User{
        /// <summary>
        /// Card, Booking, Customers are all declared in Parent Class User.
        /// </summary>
        private int _selected;
        /// <summary>
        /// override selected void from User Parent Class
        /// </summary>
        public override void Selected(){
            Console.WriteLine("Select Option: ");
            _selected = Convert.ToInt16(Console.ReadLine());
        }
        /// <summary>
        /// override ViewCustomers() from User parent class
        /// </summary>
        public override int ViewCustomers(){
			int i = 0;
			foreach (Customer customer in Cust)
			{
				if (customer is Customer)
				{
					i++;
					Console.WriteLine("\nCustomer " + i + "\n");
					customer.ViewCustomerDetails();
				}
			}
			if (i == 0)
			{
				Console.WriteLine("\nThere is no customers yet\n");
			}
			return i;
        }
        /// <summary>
        /// View Inventory function to show every card games available
        /// </summary>
        public int ViewInventory(){
            int i = 0;
            foreach(Card cards in Card){
                if (cards is Card)
				{
					i++;
					Console.WriteLine("\nCard " + i + "\n");
					cards.ViewInventoryDetails();
				}
			}
			if (i == 0)
			{
				Console.WriteLine("\nThere is no cards yet\n");
            }
            return i;
        }
        /// <summary>
        /// View Bookings function to show every booking details if available
        /// </summary>
        public int ViewBookings(){
            int i = 0;
            foreach(Booking bookings in Booking){
                if (bookings is Booking)
				{
					i++;
					Console.WriteLine("Booking " + i + "\n");
					bookings.ViewBookingDetails();
				}
			}
			if (i == 0)
			{
				Console.WriteLine("\nThere is no bookings yet\n");
            }
            return i;
        }
        /// <return>There is no bookings yet if no bookings made yet</return>

        /// <summary>
        /// View Bookings function by inputting correct name or date.<!-- if "1" is pressed, Name input will be asked. if "2" is pressed, Date input will be asked -->
        /// </summary>
        public void ViewBookingsbyNameDate(){
            int i = 0;
            string find;
            string pattern= "dd/MM/yyyy";
            Console.WriteLine("View Booking by Customer Name/Date");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Date");
            Selected();
            if(_selected == 1){
                Console.Write("Name to search: ");
                find = Console.ReadLine();
                if(Booking.Find(y => y.Name.ToLower() == find.ToLower()) != null){
                    Console.WriteLine("There is/are booking with Name {0}", find);
                    foreach(Booking booking in Booking){
                        if (find.ToLower() == booking.Name.ToLower()){
                            i++;
                            Console.WriteLine("\nBooking" + i + "\n");
                            booking.ViewBookingDetails();
                        }
                    }
                }else{
                    Console.WriteLine("There is/are no booking with Name {0}", find);
                }
            }else if(_selected == 2){
                Console.Write("Input Date (dd/MM/yyyy) to search: ");
                pattern = Console.ReadLine();
                if(Booking.Find(y => y.Date.ToString("dd/MM/yyyy") == pattern) != null){
                    Console.WriteLine("There is/are booking with Date {0}", pattern);
                    foreach(Booking booking in Booking){
                        if (pattern == booking.Date.ToString("dd/MM/yyyy")){
                            i++;
                            Console.WriteLine("\nBooking" + i + "\n");
                            booking.ViewBookingDetails();
                        }
                    }
                }else{
                    Console.WriteLine("There is/are no booking with Date {0}", pattern);
                }
            }
        }
        /// <returns>will return "There is/are no booking with Name/Date blabla" if no bookings are available with the relevant input</returns>
        
        /// <summary>
        /// This function will give Complete details of cards with quantity less than 50
        /// </summary>
        public int ViewLowInventory(){
            int i = 0;
            foreach(Card card in Card){
                if (card is Card && card.Quantity < 50){
                    i++;
                    Console.WriteLine("\nCard " + i +" Low Inventory\n");
					card.ViewInventoryDetails();
                }
            }
            if (i == 0)
			{
				Console.WriteLine("\nThere is no cards yet\n");
            }
            return i;
        }
        /// <returns>will return "There is no cards yet" if no cards are available</returns>
        
        /// <summary>
        /// Add Customer will ask input for all needed information for Customer class
        /// </summary>
        public void AddCustomer(){
            string pattern = "mm/yy";
            string status = "";
            Customer cust = new Customer(0, "", "", DateTime.ParseExact("01/01", pattern, null));
            Cust.Add(cust);
            Console.WriteLine("Input the ID: ");
            cust.ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input the Name: ");
            cust.Name = Console.ReadLine();
            Console.WriteLine("Input the Contact Number: ");
            cust.Contact = Console.ReadLine();
            Console.WriteLine("Input the Date (MM/yy): ");
            cust.Date = DateTime.ParseExact(Console.ReadLine(), pattern, null);
            Console.WriteLine("Register for Membership? (y/n)");
            status = Console.ReadLine();
            while(status != "y" | status != "n"){
                if(status.ToLower() == "y"){
                    cust.Status = true;
                    Console.WriteLine("you are member now");
                    break;
                }else if(status.ToLower() == "n"){
                    cust.Status = false;
                    break;
                }
                Console.WriteLine("Wrong input");
                Console.Write("Enter Again: ");
                status = Console.ReadLine();
            }
            Console.WriteLine("\nCustomer Added Successfully\n");
            cust.ViewCustomerDetails();
        }
        /// <return>Added Successfully </return>
        
        /// <summary>
        /// Add card will ask input for all needed information for Card class
        /// </summary>
        public void AddCard(){
            string status;
            Card card = new Card(0,"", "", "", Foil.Foil, 0, 0);
            Card.Add(card);
            Console.WriteLine("Input the Series Number: ");
            card.Series = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input the Card Name: ");
            card.Name = Console.ReadLine();
            Console.WriteLine("Input the Rarity: ");
            card.Rarity = Console.ReadLine();
            Console.WriteLine("Input the Colour: ");
            card.Colour = Console.ReadLine();
            Console.WriteLine("Foil or Non-Foil? (y/n)");
            status = Console.ReadLine();
            while(status != "y" | status != "n"){
                if(status.ToLower() == "y"){
                    card.Foil = Foil.Foil;
                    break;
                }else if(status.ToLower() == "n"){
                    card.Foil = Foil.NonFoil;
                    break;
                }
                Console.WriteLine("Wrong input");
                Console.Write("Enter Again: ");
                status = Console.ReadLine();
            }
            Console.WriteLine("Input the Card Quantity: ");
            card.Quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input the Card Price");
            card.Price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nCard Added Successfully\n");
            card.ViewInventoryDetails();
        }
        /// <return>Card Added Successfully if succeed</return>
        
        /// <summary>
        /// Add booking will ask input for all needed information for Booking class
        /// </summary>
        public void AddBooking(){
            string pattern = "dd/MM/yyyy";
            Booking booking = new Booking("",DateTime.ParseExact("01/01/0001",pattern, null),0,"");
            Booking.Add(booking);
            Console.WriteLine("Input the Customer Name for booking: ");
            booking.Name = Console.ReadLine();
            Console.WriteLine("Input the Booking Date(dd/MM/yyyy): ");
            booking.Date = DateTime.ParseExact(Console.ReadLine(), pattern, null);
            Console.WriteLine("How many hours is the booking: ");
            booking.Hours = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Input the Booking Description: ");
            booking.Description = Console.ReadLine();
            Console.WriteLine("\nBooking Added Successfully\n");
            booking.ViewBookingDetails();
        }
        /// <return>Booking Added Successfully if succeed</return>
        public void EditCustomer(){
            string status;
            int i = 0;
            if(ViewCustomers() != 0){
                Console.WriteLine("\nWhich customers are you editing?");
                Selected();
                foreach(Customer customer in Cust){
                    i++;
                    if(i == _selected){
                        Console.WriteLine("Select which one to be edited");
                        Console.WriteLine("1. Customer ID\n2. Name\n3. Contact\n4.Member Status");
                        Selected();
                        switch(_selected){
                            case 1:
                            Console.Write("Enter new Customer ID: ");
                            customer.ID = Convert.ToInt32(Console.ReadLine());
                            Console.Write("ID changed successfully\n");
                            break;
                            case 2:
                            Console.Write("Enter new Name: ");
                            customer.Name = Console.ReadLine();
                            Console.Write("Name changed successfully\n");
                            break;
                            case 3:
                            Console.Write("Enter new contact number: ");
                            customer.Contact = Console.ReadLine();
                            Console.Write("Contact Number changed successfully\n");
                            break;
                            /// Date joined cannot be changed
                            case 4:
                            Console.Write("Enter new Status(y/n): ");
                            status = Console.ReadLine();
                            while(status != "y" | status != "n"){
                                if(status.ToLower() == "y"){
                                    customer.Status = true;
                                    Console.WriteLine("you are member now");
                                    break;
                                }else if(status.ToLower() == "n"){
                                    customer.Status = false;
                                    break;
                                }
                                Console.WriteLine("Wrong input");
                                Console.Write("Enter Again: ");
                                status = Console.ReadLine();
                            }
                            break;
                        }
                    }
                }
            }
        }
        public void EditCard(){
            int i = 0;
            if(ViewInventory() != 0){
                Console.WriteLine("\nWhich card are you editing?");
                Selected();
                foreach(Card card in Card){
                    i++;
                    if(i == _selected){
                        Console.WriteLine("Select which one to be edited");
                        Console.WriteLine("1. Card Name\n2. Series Number\n3. Rarity\n4.Colour\n5. Quantity\n6. Price");
                        Selected();
                        switch(_selected){
                            case 1:
                            Console.Write("Enter new Card Name: ");
                            card.Name = Console.ReadLine();
                            Console.Write("Name changed successfully\n");
                            break;
                            case 2:
                            Console.Write("Enter new Series Number: ");
                            card.Series = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Series Number changed successfully\n");
                            break;
                            case 3:
                            Console.Write("Enter new Rarity: ");
                            card.Rarity = Console.ReadLine();
                            Console.Write("Rarity changed successfully\n");
                            break;
                            case 4:
                            Console.Write("Enter new Colour: ");
                            card.Colour = Console.ReadLine();
                            Console.Write("Colour changed successfully\n");
                            break;
                            case 5:
                            Console.Write("Enter new Quantity: ");
                            card.Quantity = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Quantity changed successfully\n");
                            break;
                            case 6:
                            Console.Write("Enter new Price: ");
                            card.Price = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Price changed successfully\n");
                            break;
                        }
                    }
                }
            }    
        }
        public void EditBooking(){
            string pattern = "dd/MM/yyyy";
            int i = 0;
            if(ViewBookings() != 0){
                Console.WriteLine("\nWhich booking are you editing?");
                Selected();
                foreach(Booking booking in Booking){
                    i++;
                    if(i == _selected){
                        Console.WriteLine("Select which one to be edited");
                        Console.WriteLine("1. Customer ID\n2. Name\n3. Contact\n4.Member Status");
                        Selected();
                        switch(_selected){
                            case 1:
                            Console.Write("Enter new Name: ");
                            booking.Name = Console.ReadLine();
                            Console.Write("Name changed successfully\n");
                            break;
                            case 2:
                            Console.Write("Enter new Date (dd/MM/yyyy): ");
                            booking.Date = DateTime.ParseExact(Console.ReadLine(), pattern, null);
                            Console.Write("Date changed successfully\n");
                            break;
                            case 3:
                            Console.Write("Enter new hours: ");
                            booking.Hours = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Number of hours changed successfully\n");
                            break;
                            case 4:
                            Console.Write("Enter new Description: ");
                            booking.Description = Console.ReadLine();
                            Console.Write("Description changed successfully\n");
                            break;
                        }
                    }
                }
            }
        }
        public void DeleteCustomer(){
            if(ViewCustomers() != 0){
                int i = 0;
                Console.WriteLine("Which customer are you deleting?");
                Selected();
                foreach(Customer customer in Cust){
                    i++;
                    if(i == _selected){
                        Cust.Remove(customer);
                        Console.WriteLine("Customer " + i +" deleted successfully");;
                        break;
                    }
                }
            }else{
                Console.WriteLine("No Customer yet");
            }
        }
        public void DeleteCard(){
            int i = 0;
            if(ViewInventory() != 0){
                Console.WriteLine("Which card are you deleting?");
                Selected();
                foreach(Card card in Card){
                    i++;
                    if(i == _selected){
                        Card.Remove(card);
                        Console.WriteLine("Card " + i +" deleted successfully");;
                        break;
                    }
                }
            }else{
                Console.WriteLine("No Card yet");
            }
        }
        public void DeleteBooking(){
            int i = 0;
            if(ViewBookings() != 0){
                Console.WriteLine("Which booking are you deleting? Only booking 24 hours before the booking date can be changed");
                Selected();
                foreach(Booking booking in Booking){
                    i++;
                    if(i == _selected){
                        Booking.Remove(booking);
                        Console.WriteLine("Booking " + i +" deleted successfully");
                        break;
                    }
                }
            }else{
                Console.WriteLine("No Booking yet");
            }
        }
        public void SearchInventory(){
            string x;
            int z;
            Console.WriteLine("What are you searching?");
            Console.WriteLine("1. Card Name\n2. Series Number\n3. Rarity\n4. Colour\n");
            Selected();
            switch(_selected){
                case 1:
                Console.Write("Enter search for Card Name: ");
                x = Console.ReadLine();
                if(Card.Find(y => y.Name.ToLower() == x.ToLower()) != null){
                    Console.WriteLine("There is a Card Name: {0}", x);
                    foreach(Card card in Card){
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
                if(Card.Find(y => y.Series == z) != null){
                    Console.WriteLine("There is a Card with Number Series: {0}", z);
                    foreach(Card card in Card){
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
                if(Card.Find(y => y.Rarity.ToLower() == x.ToLower()) != null){
                    Console.WriteLine("There is a Card with Rarity: {0}", x);
                    foreach(Card card in Card){
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
                if(Card.Find(y => y.Colour.ToLower() == x.ToLower()) != null){
                    Console.WriteLine("There is a Card with Colour: {0}", x);
                    foreach(Card card in Card){
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
                        if(Card.Find(y => y.Foil == ff) != null){
                        Console.WriteLine("There is a Card with Foil");
                            foreach(Card card in Card){
                                if(card.Foil == ff){
                                    Console.WriteLine("This is/are the card\n");
                                    card.ViewInventoryDetails();
                                }
                            }
                        }
                    break;
                    }
                    else if(x.ToLower() == "n"){
                        if(Card.Find(y => y.Foil == nf) != null){
                        Console.WriteLine("There is a Card with Non-Foil");
                            foreach(Card card in Card){
                                if(card.Foil == nf){
                                    Console.WriteLine("This is/are the card\n");
                                    card.ViewInventoryDetails();
                                }
                            }
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
        /// Customer must be available before this method can be executed. This is to record customer's transactions.
        /// </summary>
        public void RecordTransaction(){
            int i = 0;
            if(ViewCustomers() != 0){
                Console.WriteLine("Which customer is having the transaction?");
                Selected();
                foreach(Customer customer in Cust){
                    i++;
                    if(i == _selected){
                        customer.AddTransaction();
                    }
                }
            }
        }
        /// <summary>
        /// !!!!! THESE METHODS BELOW ARE STRICTLY FOR TESTS ONLY !!!!!
        /// </summary>
        public void TestAddCust(Customer _cust){
            Cust.Add(_cust);
        }
        public void TestAddBooking(Booking _book){
            Booking.Add(_book);
        }
        public void TestAddCard(Card _cards){
            Card.Add(_cards);
        }
        public void TestDeleteCust(Customer _cust){
            Cust.Remove(_cust);
        }
        public void TestDeleteBooking(Booking _book){
            Booking.Remove(_book);
        }
        public void TestDeleteCard(Card _cards){
            Card.Remove(_cards);
        }
        /// <return>End of testing methods. It will not appear in UML Diagram</return>
    }
}