using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Bill
    {
        private int _id;
        private int _tableID;
        private decimal _totalPrice;
        private decimal _Discount;
        private DateTime _dateCheckIn;
        private DateTime _dateCheckOut;
        private int _accountID;
        private string _status;
        DTO_Bill() { }
        DTO_Bill(int id, int tableID, decimal totalPrice, decimal discount, DateTime dateCheckIn, DateTime dateCheckOut, int accountID, string status)
        {
            _id = id;
            _tableID = tableID;
            _totalPrice = totalPrice;
            _Discount = discount;
            _dateCheckIn = dateCheckIn;
            _dateCheckOut = dateCheckOut;
            _accountID = accountID;
            _status = status;
        }
        public int ID 
        { 
            get { return _id;} 
            set { _id = value; }
        }
        public int TableID
        {
            get { return _tableID;}
            set { _tableID = value; }
        }
        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }
        public DateTime DateCheckIn
        {
            get { return _dateCheckIn; }
            set { _dateCheckIn = value; }
        }
        public DateTime DateCheckOut
        {
            get { return _dateCheckOut; }
            set { _dateCheckOut = value; }
        }
        public int AccountID
        {
            get { return _accountID; }
            set { _accountID = value; }
        }
        public string Status
        {
            get { return _status; }
            set { _status = value; }  
        }
    }
}
