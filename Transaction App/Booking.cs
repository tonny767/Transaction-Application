using System;
using System.Collections.Generic;

namespace PT13{
    public class Booking{
       private string _name;
       private DateTime _date;
       private int _hours;
       private string _description;
       public Booking(string Name, DateTime Date, int Hours, string Description){
           _name = Name;
           _date = Date;
           _hours = Hours;
           _description = Description;
       }
       /// <summary>
       /// print booking details inputted
       /// </summary>
       public void ViewBookingDetails()
        {
            Console.WriteLine("Customer Name: {0}\nDate: {1}\nHow many hours: {2}\nBooking Description: {3}"
            , Name, Date.ToString("dd/MM/yyyy"), Hours, Description);
        }
       public string Name{
           get{ return _name; }
           set{ _name = value; }
       }
       public DateTime Date{
           get{ return _date; }
           set{ _date = value; }
       }
       public int Hours{
           get{ return _hours; }
           set{ _hours = value; }
       }
       public string Description{
           get{ return _description; }
           set{ _description = value; }
       }
    }
}