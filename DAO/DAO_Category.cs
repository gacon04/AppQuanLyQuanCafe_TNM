using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class DAO_Category: DBConnect
    {
        public DataTable getCategoryTable()
        {
            try
            {

                if (conn.State == ConnectionState.Closed) conn.Open();
                
                string query = "SELECT ID,Name as 'Tên',Description as 'Miêu tả',CreatedDate as 'Ngày tạo' FROM Category";
               
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);

                DataTable dt_Account = new DataTable();
                sqlDataAdapter.Fill(dt_Account);
                return dt_Account;
            }
            catch (Exception ex)
            {
                return null;
            }


        }
        public bool addCategory(DTO_Category category)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // Query string với tham số hóa
                string SQL = "INSERT INTO Category(Name,Description,CreatedDate) VALUES (@Name,@Description,@CreatedDate)";

                // Tạo đối tượng SqlCommand với câu lệnh SQL và kết nối
                using (SqlCommand command = new SqlCommand(SQL, conn))
                {

                    // Thêm tham số và giá trị tương ứng
                    command.Parameters.AddWithValue("@Name", category.Name);
                    command.Parameters.AddWithValue("@Description", category.Description);
                    command.Parameters.AddWithValue("@CreatedDate", category.CreatedDate);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }


            finally
            {
                conn.Close();
            }
        }
        
    }
}
