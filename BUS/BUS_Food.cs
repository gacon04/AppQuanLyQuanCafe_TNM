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
        public DataTable getCateIdAndCateName()
        {
            return DAOFood.getCateIDandCateName();
        }
        public bool exitFoodNameInSameCategory(int id,int cateID,string name)
        {
            return DAOFood.existFoodNameInSameCategory(id,cateID,name);
        }
        public bool addFood(DTO_Food food)
        {
            return DAOFood.addFood(food);
        }
        public DTO_Food GetFoodByID(int id)
        {
            return DAOFood.getFoodByID(id);
        }
        public string getCateNameByID(int id)
        {
            return DAOFood.getCateNameById(id);
        }
        public bool deleteFood(int foodID)
        {
            return DAOFood.deleteFood(foodID);
        }
        public bool updateFood(DTO_Food food)
        {
            return DAOFood.updateFood(food);
        }
        public DataTable getFoodIDandFoodName(int cateID)
        {
            return DAOFood.getFoodIDandFoodName(cateID);
        }
    }
}
