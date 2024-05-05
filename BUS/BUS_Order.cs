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
    public class BUS_Order
    {
        DAO_Order dao_Order = new DAO_Order();
        public DataTable getCateIdAndCateName()
        {
            return  dao_Order.getCateIDandCateName();
        }
        public DataTable getFoodIDandFoodName(int cateID)
        {
            return dao_Order.getFoodIDandFoodName(cateID);
        }
        public DataTable getTableList()
        {
            return dao_Order.getTableList();
        }
        public List<DTO_Table> LoadTableList()
        {
            return dao_Order.LoadTableList();
        }
    }
}
