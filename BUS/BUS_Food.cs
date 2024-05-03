using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class BUS_Food
    {
        DAO_Food DAOFood = new DAO_Food();
        public DataTable getFoodTable()
        {
            return DAOFood.getFoodTable();
        }

    }
}
