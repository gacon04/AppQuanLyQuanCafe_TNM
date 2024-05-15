using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_BillInfo
    {
        private int _id;
        private int _billId;
        private int _foodId;
        private int _quantity;
        public DTO_BillInfo() { }
        public DTO_BillInfo(DataRow row)
        {
            _id =(int) row["ID"];
            _billId = (int) row["BillID"];
            _foodId = (int) row["FoodID"];
            _quantity = (int) row["Quantity"];
        }
        public DTO_BillInfo(int id, int billId, int foodId, int quantity)
        {
            _id = id;
            _billId = billId;
            _foodId = foodId;
            _quantity = quantity;
        }
        public int Id { 
            get { return _id; } 
            set { _id = value; }
        }
        
        public int BillID
        {
            get { return _billId; }
            set { _billId = value; }
        }
        public int FoodID
        {
            get { return _foodId; }
            set { _foodId = value; }    
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
    }
}
