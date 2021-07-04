using System;
using System.Collections.Generic;

namespace PT13{
    /// <summary>
    /// Customer class is used by primary classes like manager and admin
    /// </summary>
    public class Customer{
        private int _id;
        private string _name;
        private string _contact;
        private DateTime _date;
        private List<Transaction> _trans;
        //private List<Booking> _booking;
        private Boolean _status;
        //Constructor for Customer Class
        public Customer(int ID, string Name, string Contact, DateTime Date){
            _id = ID;
            _name = Name;
            _contact = Contact;
            _date = Date;
            _status = Status;
            _trans = new List<Transaction>();
        }
        public List<Transaction> Trans{
            get { return _trans; }
            set { _trans = Trans; }
        }
        public string MemberDetails(){
            string message = "";
            if(_status == true){
                message = "Member status : Active";
            }else if(_status == false){
                message = "Member status : Not Active";
            }
            return message;
        }
        /// <summary>
        /// Sum of total amount spent for listing of loyal customer
        /// </summary>
        public int Total(){
            int total = 0;
            foreach(Transaction t in _trans){
                total = total + Convert.ToInt32(t.Amounts);
            }
            return total;
        }
        /// <returns>total that will be in ViewCustomerDetails after transaction is executed for the first time</returns>
        /// <summary>
        /// printing relevant details about inventory inputted in admin class
        /// </summary>
        public void ViewCustomerDetails(){
            Console.WriteLine("Customer ID: {0}\nCustomer Name: {1}\nContact Number: {2}\nDate Joined: {3}\n{4}",
            _id, _name, _contact, _date.ToString("mm/yy"), MemberDetails());
            if(Total() != 0){
                Console.WriteLine("Total Purchase: RM{0}", Total());
                Console.WriteLine("Total Points: {0}pts", UpdateTotalPoints());
            }
        }
        /// <summary>
        /// Update points after transactions are done
        /// </summary>
        public int UpdateTotalPoints(){
            int points = 0;
            points = 10 * Total()/20;
            return points;
        }
        /// <return>points</return>

        /// <summary>
        /// Ask for input before adding it to transaction list
        /// </summary>
        public void AddTransaction(){
            string pattern= "dd/MM/yyyy";
            Transaction transaction = new Transaction(0, DateTime.ParseExact("01/01/0001", pattern, null), 0);
            _trans.Add(transaction);
            Console.WriteLine("Input the Transaction No: ");
            transaction.TransNo =  Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input the Transaction Date(dd/MM/yyyy): ");
            transaction.TransDate = DateTime.ParseExact(Console.ReadLine(), pattern, null);
            Console.WriteLine("How much is the item: ");
            transaction.Amounts = Convert.ToDouble(Console.ReadLine());
            if(_status == true){
                Console.WriteLine("You have been entitled 20% discounts");
                transaction.Amounts = transaction.Amounts*0.8;
            }
            transaction.PrintInfo();
        }
        public void Add(Transaction trans){
            _trans.Add(trans);
        }
        //to get all properties
        public int ID{
            get{ return _id; }
            set{ _id = value; }
        }
        public DateTime Date{
            get{ return _date; }
            set{ _date = value; }
        }
        public string Name{
            get{ return _name; }
            set{ _name = value; }
        }
        public string Contact{
            get{ return _contact; }
            set{ _contact = value; }
        }
        public Boolean Status{
            get{ return _status; }
            set{ _status = value; }
        }
    }
}