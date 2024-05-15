using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_BillInfoDetails
    {
        DAO_BillInfoDetail dao_menu = new DAO_BillInfoDetail();
        public BUS_BillInfoDetails() { }
        public List<DTO_BillInfoDetail> GetListMenuByTableID(int id)
        {
            return dao_menu.GetListMenuByTableID(id);
        }
        public bool addBillInfo(DTO_BillInfo dto)
        {
            return dao_menu.AddBillInfo(dto);
        }
    }
}
