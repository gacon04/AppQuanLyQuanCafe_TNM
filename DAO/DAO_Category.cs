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
        public bool deleteCategory(int categoryID)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string SQL1 = string.Format("DELETE FROM Category WHERE ID ={0}", categoryID);
                string SQL2 = string.Format("DELETE FROM Food WHERE CategoryID ={0}", categoryID);
                SqlCommand cmd = new SqlCommand(SQL1, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    cmd.CommandText = SQL2;
                    cmd.ExecuteNonQuery();
                    return true;
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public bool existCategory(int id, string cateName)
        {
            try
            {

                if (conn.State == ConnectionState.Closed) conn.Open();

                string SQL = "SELECT COUNT(*) FROM Category WHERE  Name= @Name AND  ID<>@ID";
                if (id == -1)
                //trường hợp id=-1 là thêm mới, chỉ cần kiểm tra coi có tên ấy chưa không
                // còn nếu cập nhật thì phải ktra những dòng khác id coi có dòng nào trùng account không
                {
                    SQL = "SELECT COUNT(*) FROM Category WHERE  Name= @Name";
                }
                using (SqlCommand command = new SqlCommand(SQL, conn))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Name", cateName);
                    return (int)command.ExecuteScalar() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }


            finally
            {
                conn.Close();
            }
            return false;
        }
        public bool updateCategory(DTO_Category dTO_Category)
        {
            try
            {

                if (conn.State == ConnectionState.Closed) conn.Open();

                string SQL = "UPDATE Category SET Name=@Name, Description=@Description WHERE ID =@ID";

                // Tạo đối tượng SqlCommand với câu lệnh SQL và kết nối
                using (SqlCommand command = new SqlCommand(SQL, conn))
                {
                    command.Parameters.AddWithValue("@ID", dTO_Category.ID);

                    command.Parameters.AddWithValue("@Description", dTO_Category.Description);
                    command.Parameters.AddWithValue("@Name", dTO_Category.Name);

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
