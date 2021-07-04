using System;
using System.Collections.Generic;
namespace PT13{
    public abstract class User{
        protected List<Card> _card;
        protected List<Customer> _cust;
        protected List<Booking> _booking;
        public User(){
            _card = new List<Card>();
            _cust = new List<Customer>();
            _booking = new List<Booking>();
        }   
        public abstract int ViewCustomers();
        public abstract void Selected();
        /// <summary>
        /// get; set; for all three lists so Manager and Admin does not need to declare lists anymore.
        /// </summary>
        
        public List<Card> Card
		{
			get { return _card; }
			set { _card = value; }
		}
        public List<Customer> Cust
		{
			get { return _cust; }
			set { _cust = value; }
		}
        public List<Booking> Booking
		{
			get { return _booking; }
			set { _booking = value; }
		}
        /// <value>All lists</value>
    }
}