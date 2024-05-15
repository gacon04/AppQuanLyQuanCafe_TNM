using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_Bill
    {
        DAO_Bill DAO_Bill = new DAO_Bill();
        public bool AddBill(DTO_Bill dto)
        {
            return DAO_Bill.AddBill(dto);
        }
        public int GetUncheckedBillIDByTableID(int tableID)
        {
            return DAO_Bill.GetUncheckedBillIDByTableID(tableID);
        }
        public int GetMaxBillID()
        {
            return DAO_Bill.GetMaxBillID();
        }
        public bool CheckOutBill(int id,DateTime date)
        {
            return DAO_Bill.CheckoutBill(id,date);
        }
    }
}
