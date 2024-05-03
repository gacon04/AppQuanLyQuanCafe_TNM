using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_Food:DBConnect
    {
        public DataTable getFoodTable()
        {
            try
            {

                if (conn.State == ConnectionState.Closed) conn.Open();

                string query = "SELECT Food.ID as 'ID',  Category.Name AS 'Danh mục', Food.Name as 'Tên món', Food.Status as 'Tình trạng', Food.Price as 'Giá' FROM Food INNER JOIN Category ON Food.CategoryID = Category.ID;";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);

                DataTable dt_Food = new DataTable();
                sqlDataAdapter.Fill(dt_Food);
                return dt_Food;
            }
            catch (Exception ex)
            {
                return null;
            }


        }
    }
}
