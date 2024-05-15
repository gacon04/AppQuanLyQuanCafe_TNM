using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Windows.Input;
using System.Security.Principal;

namespace DAO
{
    public class DAO_TableList:DBConnect
    {
        public DataTable getTableList(string status)
        {
            try
            {

                if (conn.State == ConnectionState.Closed) conn.Open();
                string query = "";
                if (status == "Tất cả")
                {
                    query = "SELECT ID as N'ID bàn' ,Name as N'Tên bàn',Status as N'Trạng thái' FROM TableList";
                }
                else if (status == "Trống")
                {
                    query = "SELECT ID as N'ID bàn' ,Name as N'Tên bàn',Status as N'Trạng thái' FROM TableList WHERE Status= N'Trống'";
                }
                else if (status == "Có người")
                {
                    query = "SELECT ID as N'ID bàn' ,Name as N'Tên bàn',Status as N'Trạng thái' FROM TableList WHERE Status= N'Có người'";
                }
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);

                DataTable dt_TableList = new DataTable();
                sqlDataAdapter.Fill(dt_TableList);
                return dt_TableList;
            }
            catch (Exception ex)
            {
                return null;
            }


        }
        
        public bool addTable(DTO_Table table)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

               
                string SQL = "INSERT INTO TableList(Name,Status) VALUES (@Name,@Status)";

                // Tạo đối tượng SqlCommand với câu lệnh SQL và kết nối
                using (SqlCommand command = new SqlCommand(SQL, conn))
                {

                    // Thêm tham số và giá trị tương ứng
                    command.Parameters.AddWithValue("@Name", table.Name);
                  
                    command.Parameters.AddWithValue("@Status", table.Status);

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
        public bool deleteTable(int table_id)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
              
               
                    string SQL = string.Format("DELETE FROM TableList WHERE ID ={0}", table_id);
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
        public bool existTableName(int tableID,string tableName)
        {
            try
            {

                if (conn.State == ConnectionState.Closed) conn.Open();

                string SQL = "SELECT COUNT(*) FROM TableList WHERE  Name= @Name AND  ID<>@ID";
                if (tableID == -1)
                //trường hợp id=-1 là thêm mới, chỉ cần kiểm tra coi có tên ấy chưa không
                // còn nếu cập nhật thì phải ktra những dòng mà khác id coi có dòng nào trùng tên bàn không
                {
                    SQL = "SELECT COUNT(*) FROM TableList WHERE  Name= @Name";
                }
                using (SqlCommand command = new SqlCommand(SQL, conn))
                {
                    command.Parameters.AddWithValue("@ID", tableID);
                    command.Parameters.AddWithValue("@Name", tableName);
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
        public bool updateTable(DTO_Table table)
        {
            try
            {

                if (conn.State == ConnectionState.Closed) conn.Open();
               
                string SQL = "UPDATE TableList SET Name=@Name,Status=@Status WHERE ID =@ID";

                // Tạo đối tượng SqlCommand với câu lệnh SQL và kết nối
                using (SqlCommand command = new SqlCommand(SQL, conn))
                {
                    command.Parameters.AddWithValue("@ID", table.ID);

                    command.Parameters.AddWithValue("@Name", table.Name);
                    command.Parameters.AddWithValue("@Status", table.Status);

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
        public List<DTO_Table> LoadTableList()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                List<DTO_Table> tablelist = new List<DTO_Table>();
                DataTable dt = new DataTable();
                using (SqlCommand command = new SqlCommand("SP_GetTableList", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dt);
                    }
                }
                foreach (DataRow row in dt.Rows)
                {
                    DTO_Table table = new DTO_Table(row); // đã có hàm chuyển đổi 1 datarow thành 1 DTO_Table trong DTO_Table
                    tablelist.Add(table);
                }
                return tablelist;
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
        public DataTable getTableList()
        {
            try
            {

                if (conn.State == ConnectionState.Closed) conn.Open();

                string SQL = "SELECT ID, Name FROM TableList";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(SQL, conn);

                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally { conn.Close(); }
        }
    }
}
