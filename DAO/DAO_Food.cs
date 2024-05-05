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
    public class DAO_Food:DBConnect
    {
        public DataTable getFoodTable()
        {
            try
            {

                if (conn.State == ConnectionState.Closed) conn.Open();

                string query = "SELECT Food.ID as 'ID',  Category.Name AS 'Danh mục', Food.Name as 'Tên món', Food.Status as 'Tình trạng', Food.Price as 'Giá' FROM Food INNER JOIN Category ON Food.CategoryID = Category.ID";

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
        public DataTable getCateIDandCateName()
        {
            try
            {

                if (conn.State == ConnectionState.Closed) conn.Open();

                string query = "SELECT ID, Name FROM Category ";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);

                DataTable dt_IDandName = new DataTable();
                sqlDataAdapter.Fill(dt_IDandName);
                return dt_IDandName;
            }
            catch (Exception ex)
            {
                return null;
            }
           
        }
        public bool existFoodNameInSameCategory(int id,int cateID, string foodName)
        {
            try
            {

                if (conn.State == ConnectionState.Closed) conn.Open();
                string SQL = "SELECT COUNT(*) FROM Food WHERE  Name= @Name AND CategoryID = @CateID AND ID<>@ID";
                if (id == -1)
                //trường hợp id=-1 là thêm mới, chỉ cần kiểm tra coi có tên ấy chưa không
                // còn nếu cập nhật thì phải ktra những dòng khác xem có dòng nào cùng cateid mà trùng tên không
                {
                    SQL = "SELECT COUNT(*) FROM Food WHERE  Name= @Name AND CategoryID = @CateID";
                }
                using (SqlCommand command = new SqlCommand(SQL, conn))
                {
                    command.Parameters.AddWithValue("@Name", foodName);
                    command.Parameters.AddWithValue("@CateID", cateID);
                    command.Parameters.AddWithValue("@ID", id);
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
        public bool addFood(DTO_Food dTO_Food)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // Query string với tham số hóa
                string SQL = "INSERT INTO Food(Name,Description,Status,Price,CategoryID, CreatedDate) VALUES (@Name,@Description,@Status,@Price,@CategoryID, @CreatedDate)";

                // Tạo đối tượng SqlCommand với câu lệnh SQL và kết nối
                using (SqlCommand command = new SqlCommand(SQL, conn))
                {

                    // Thêm tham số và giá trị tương ứng
                    command.Parameters.AddWithValue("@Name", dTO_Food.Name);
                    command.Parameters.AddWithValue("@Description", dTO_Food.Description);
                    command.Parameters.AddWithValue("@Status", dTO_Food.Status);
                    command.Parameters.AddWithValue("@Price", dTO_Food.Price);
                    command.Parameters.AddWithValue("@CategoryID", dTO_Food.CategoryID);
                    command.Parameters.AddWithValue("@CreatedDate", dTO_Food.CreatedDate);
                    
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
        public DTO_Food getFoodByID(int id)
        {
            DTO_Food food = null;
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string query = "SELECT * FROM Food WHERE ID = @id";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int foodID = Convert.ToInt32(reader["ID"]);
                            string name = reader["Name"].ToString();
                            string description = reader["Description"].ToString();
                            string status = reader["Status"].ToString();
                            decimal price = Convert.ToDecimal(reader["Price"]);
                            int categoryID = Convert.ToInt32(reader["CategoryID"]);
                            DateTime createdDate = Convert.ToDateTime(reader["CreatedDate"]);

                            food = new DTO_Food(foodID, name, description, status, price, categoryID, createdDate);
                        }
                    }
                }

                return food;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public string getCateNameById(int id)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                string query = "SELECT Name FROM Category Where ID=@ID";

                using (SqlCommand command = new SqlCommand(query, conn))
                {

                    // Thêm tham số và giá trị tương ứng
                    command.Parameters.AddWithValue("@ID", id);


                    return command.ExecuteScalar().ToString();
                }
            }
            catch
            {
                
                return "";
            }
            finally { conn.Close(); }
        }

        public bool deleteFood(int id)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string SQL= string.Format("DELETE FROM Food WHERE ID ={0}", id);
                SqlCommand cmd = new SqlCommand(SQL, conn);
                return cmd.ExecuteNonQuery() > 0;  

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
        public bool updateFood(DTO_Food food)
        {
            try
            {

                if (conn.State == ConnectionState.Closed) conn.Open();

                string SQL = "UPDATE Food SET Name=@Name, Description=@Description,Status=@Status,Price=@Price,CategoryID=@CateID,CreatedDate=@CreatedDate  WHERE ID =@ID";

                // Tạo đối tượng SqlCommand với câu lệnh SQL và kết nối
                using (SqlCommand command = new SqlCommand(SQL, conn))
                {
                    command.Parameters.AddWithValue("@ID", food.ID);
                    command.Parameters.AddWithValue("@Name",food.Name);
                    command.Parameters.AddWithValue("@Description",food.Description);
                    command.Parameters.AddWithValue("@Status",food.Status);
                    command.Parameters.AddWithValue("@Price",food.Price);
                    command.Parameters.AddWithValue("@CateID",food.CategoryID);
                    command.Parameters.AddWithValue("@CreatedDate",food.CreatedDate);
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
