using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_Bill
    {
        DAO_Bill DAO_Bill = new DAO_Bill();
        public DataTable getBill(DateTime time1,DateTime time2)
        {
            return DAO_Bill.getBillByDate(time1,time2);
        }
        public bool deleteBill(int id)
        {
            return DAO_Bill.deleteBill(id); 
        }
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
        public bool CheckOutBill(int id, decimal sumBill, decimal discount)
        {
            return DAO_Bill.CheckoutBill(id, sumBill, discount);
        }
        public DataTable GetRevueneByCategory()
        {
            return DAO_Bill.GetRevueneByCategory();
        }

        public int CountBillsInCurrentMonth()
        {
            return DAO_Bill.CountBillCurrentMonth();
        }
        public int CountAllBill()
        {
            return DAO_Bill.CountAllBill();
        }
        public string SumBillCurrentMonth()
        {
            return ConvertToCurrencyString(DAO_Bill.SumBillCurrentMonth());
        }
        public string SumAllBills()
        {
            return ConvertToCurrencyString(DAO_Bill.SummAllBills());
        }

        public string ConvertToCurrencyString(decimal number)
        {
            // Kiểm tra nếu số tiền là 0, trả về "0 đồng"
            if (number == 0)
            {
                return "0 đồng";
            }
            // Kiểm tra nếu số tiền nhỏ hơn 1 triệu, hiển thị số tiền dưới dạng số nguyên kèm đơn vị "đồng"
            else if (number < 1000000)
            {
                return number.ToString("#,##0") + " đồng";
            }
            else
            {
                // Chia số tiền cho 1 triệu để lấy phần nguyên và phần thập phân
                decimal millions = number / 1000000;
                decimal remainder = number % 1000000;

                // Nếu phần thập phân bằng 0, chỉ hiển thị phần nguyên
                if (remainder == 0)
                {
                    return millions.ToString("#,##0.##") + " triệu đồng";
                }
                // Nếu có phần thập phân, hiển thị số tiền dưới dạng phần nguyên và phần thập phân với 1 chữ số, kèm đơn vị "triệu đồng"
                else
                {
                    return millions.ToString("#,##0.0") + " triệu đồng";
                }
            }
        }
    }
}
