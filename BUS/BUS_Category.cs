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
    public class BUS_Category
    {
        DAO_Category DAOCategory = new DAO_Category();
        public DataTable getCategoryTable()
        {
            return DAOCategory.getCategoryTable();
        }
        public bool addCategory(DTO_Category category)
        {
            return DAOCategory.addCategory(category);
        }
       
    }
}
