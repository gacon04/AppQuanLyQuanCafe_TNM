using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_BillInfoDetail
    {
        private string foodName;
        private int quantity;
        private decimal price;
        private decimal totalPrice;
        public string FoodName
        {
            get { return foodName; }
            set { foodName = value; }   
        }
        public int Quantity
        {
            get { return quantity; }
            set {  quantity = value; }
        }
        public decimal Price
        {
            get { return price; }
            set {  price = value; }
        }
        public decimal TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }
        public DTO_BillInfoDetail() { }

        public DTO_BillInfoDetail(string foodName, int quantity, decimal price, decimal totalPrice=0)
        {
            this.foodName = foodName;
            this.quantity = quantity;
            this.price = price;
            this.totalPrice = totalPrice;
        }
        public DTO_BillInfoDetail(DataRow row)
        {
            this.foodName = (string)row["Name"];
            this.quantity = (int)row["Quantity"];
            this.price = Decimal.Parse(row["Price"].ToString());
            this.totalPrice =(decimal)row["TotalPrice"];
        }
    }
}
