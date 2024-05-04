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
        public bool deleteCategory(int cateID)
        {
            return DAOCategory.deleteCategory(cateID);
        }
        public bool existCategoryName(int id, string cateName)
        {
            return DAOCategory.existCategory(id,cateName);
        }
        public bool updateCategory(DTO_Category cate) {
            return DAOCategory.updateCategory(cate);
        }

    }
}
