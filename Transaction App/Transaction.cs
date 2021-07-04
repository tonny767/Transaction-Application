using System;

namespace PT13{
    public class Transaction{
        //Integer for Transaction ID/Number        
        private int _transNo;
        //String for Date
        private DateTime _transdate;
        //Integer for amount of transaction
        private double _amounts;
        //Integer for points 
        private int _points;
        public Transaction(int TransNo, DateTime TransDate, double Amounts){
            _transNo = TransNo;
            _transdate = TransDate;
            _amounts = Amounts;
        }
        public int UpdatePoints(){
            if(_amounts > 0){
                _points = 10 * Convert.ToInt32(_amounts)/20;
            }
            return _points;
        }
        /// <summary>
        /// Print Transaction after information input
        /// </summary>
        public void PrintInfo(){
            Console.WriteLine(
                "Transaction No: {0}\nTransaction Date: {1}\nTransaction Amount: {2}\nPoints: {3}\n",TransNo, TransDate.ToString("dd/MM/yyyy"), Amounts, UpdatePoints()
            );
        }
        /// <summary>
        /// returning all properties
        /// </summary>
        
        public int TransNo{
            get{ return _transNo; }
            set{ _transNo = value; }
        }
        public DateTime TransDate{
            get{ return _transdate; }
            set{ _transdate = value; }
        }
        public double Amounts{
            get{ return _amounts; }
            set{ _amounts = value; }
        }
        /// <value>int, DateTime, double, int</value>
    }
}