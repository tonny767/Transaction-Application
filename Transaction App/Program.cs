using System;
using SplashKitSDK;

namespace PT13{
    public class Program
    {
        /// <summary>
        /// To properly use Manager class, user need to input information in Admin class first
        /// </summary>
        public static void MainMenuAdmin(Admin login1, Manager login2){///<param>login1, login2</param>///
            while(true){
                int _selected;
                Console.WriteLine("Here are the list of commands you can do.");
                Console.WriteLine("1.Customer Inquiries");
                Console.WriteLine("2.Inventory Inquiries");
                Console.WriteLine("3.Booking Inquiries");
                Console.WriteLine("4.View Low Inventory");
                Console.WriteLine("5.Record Customer Transaction");
                Console.WriteLine("6.Search for Related Inventory");
                Console.WriteLine("9.Switch to Manager");
                Console.WriteLine("0.Quit the program");
                Console.Write("Select Option: ");
                _selected = Convert.ToInt16(Console.ReadLine());
                if(_selected == 1){
                    Console.WriteLine("1. Add Customer\n2. Edit Customer\n3. Delete Customer");
                    Console.Write("Select Option: ");
                    _selected = Convert.ToInt16(Console.ReadLine());
                    if(_selected == 1){
                        login1.AddCustomer();
                    }else if(_selected == 2){
                        login1.EditCustomer();
                    }else if(_selected == 3){
                        login1.DeleteCustomer();
                    }
                }
                else if(_selected == 2){
                    Console.WriteLine("1. Add Inventory\n2. Edit Inventory\n3. Delete Inventory");
                    Console.Write("Select Option: ");
                    _selected = Convert.ToInt16(Console.ReadLine());
                    if(_selected == 1){
                        login1.AddCard();
                    }else if(_selected == 2){
                        login1.EditCard();
                    }else if(_selected == 3){
                        login1.DeleteCard();
                    }
                }
                else if(_selected == 3){
                    Console.WriteLine("1. Add Booking\n2. Edit Booking\n3. Delete Booking\n4. View All Bookings\n5. View Booking By Name/Date");
                    Console.Write("Select Option: ");
                    _selected = Convert.ToInt16(Console.ReadLine());
                    if(_selected == 1){
                        login1.AddBooking();
                    }else if(_selected == 2){
                        login1.EditBooking();
                    }else if(_selected == 3){
                        login1.DeleteBooking();
                    }else if(_selected == 4){
                        login1.ViewBookings();
                    }else if(_selected == 5){
                        login1.ViewBookingsbyNameDate();
                    }
                }
                else if(_selected == 4){
                    login1.ViewLowInventory();
                }
                else if(_selected == 5){
                    login1.RecordTransaction();
                }
                else if(_selected == 6){
                    login1.SearchInventory();
                }
                else if(_selected == 9){
                    LoginModule(login1, login2);
                    break;
                }
                else if(_selected == 0){
                    Console.WriteLine("Goodbye!");
                    break;
                }
            }
        }
        public static void MainMenuManager(Admin login1,Manager login2){
            int _selected;
            while(true){
                Console.WriteLine("Manager Page");
                Console.WriteLine("1.View List of Loyal Customer");
                Console.WriteLine("2.View Booking by Date");
                Console.WriteLine("3.View Transaction Daily or Monthly");
                Console.WriteLine("4.Filter Card");
                Console.WriteLine("9.Switch to Admin");
                Console.WriteLine("0.Quit the program");
                Console.Write("Select Option: ");
                _selected = Convert.ToInt16(Console.ReadLine());
                if(_selected == 1){
                    login2.ViewCustomers();
                }
                else if(_selected == 2){
                    login2.ViewBookingsbyDate();
                }
                else if(_selected == 3){
                    login2.ViewTransactionsDailyMonthly();
                }
                else if(_selected == 4){
                    login2.FilterInventory();
                }
                else if(_selected == 9){
                    LoginModule(login1, login2);
                    break;
                }
                else if(_selected == 0){
                    Console.WriteLine("Goodbye!");
                    break;
                }
            }
        }
        public static void LoginModule(Admin login1, Manager login2){
            string username;
            string password;
            while(true){
                Console.WriteLine("Admin/Manager Login Page");
                Console.Write("Username: ");
                username = Console.ReadLine();
                Console.Write("Password: ");
                password = Console.ReadLine();
                if(username == "admin" && password =="admin"){
                    Console.WriteLine("Hi Admin, Welcome!");
                    MainMenuAdmin(login1, login2);
                    break;
                }
                else if(username == "manager" && password =="manager"){
                    Console.WriteLine("Hi Manager, Welcome!");
                    MainMenuManager(login1, login2);
                    break;
                }else if(username == "0" && password =="0"){
                    Console.WriteLine("Exitted");
                    break;
                }
                Console.WriteLine("Wrong Information Entered! Try Again or Input 0 for username and password to exit");
            }
        }
        public static void Main()
        {  
            Admin login1 = new Admin();
            Manager login2 = new Manager(login1);
            LoginModule(login1, login2);
            
        }
    }
}
