using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class DAO_Account : DBConnect // ke thua
    {
        //tra ve table 
        public DataTable getAccountTable(string status)
        {
            try
            {

                if (conn.State == ConnectionState.Closed) conn.Open();
                string query="";
                if (status == "Full")
                {
                    query =   "SELECT ID,Account,Password,Role,Status FROM Account";
                } 
                else if (status=="Active")
                {
                     query ="SELECT ID,Account,Password,Role,Status FROM Account WHERE Status = N'Hoạt động'";
                }
                else if (status == "Off")
                {
                    query ="SELECT ID,Account,Password,Role,Status FROM Account WHERE Status = N'Nghỉ'";
                }
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
        public bool addAccount(DTO_Account account)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // Query string với tham số hóa
                string SQL = "INSERT INTO Account(Name,CCCD_Num,PhoneNumber,Sex,Address,Role,Account,Password,Status) VALUES (@Name,@CCCD_Num,@PhoneNumber,@Sex,@Address,@Role,@Account,@Password,@Status)";

                // Tạo đối tượng SqlCommand với câu lệnh SQL và kết nối
                using (SqlCommand command = new SqlCommand(SQL, conn))
                {

                    // Thêm tham số và giá trị tương ứng
                    command.Parameters.AddWithValue("@Name", account.Name);
                    command.Parameters.AddWithValue("@CCCD_Num", account.CCCD_Num);
                    command.Parameters.AddWithValue("@PhoneNumber", account.PhoneNumber);
                    command.Parameters.AddWithValue("@Sex", account.Sex);
                    command.Parameters.AddWithValue("@Address", account.Address);
                    command.Parameters.AddWithValue("@Role", account.Role);
                    command.Parameters.AddWithValue("@Account", account.Account);
                    command.Parameters.AddWithValue("@Password", account.Password);
                    command.Parameters.AddWithValue("@Status", account.Status);

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

        public bool deleteAccount(int account_ID, string role)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                int countAdminAccount = 1; 
                string query = "SELECT COUNT(*) FROM Account WHERE Role='Admin'";
                SqlCommand command = new SqlCommand(query, conn);                 
                countAdminAccount = (int)command.ExecuteScalar();

                // Nếu xoá member thì ko care, nếu là admin thì phải >=2 tài khoản admin trong hệ thống
                if ((countAdminAccount >=2 && role=="Admin") || (role=="Member")  ) {
                    string SQL = string.Format("DELETE FROM Account WHERE ID ={0}", account_ID);
                    SqlCommand cmd = new SqlCommand(SQL, conn);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                }
                

            }
            catch (Exception ex){
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public DTO_Account getAccountByID(int account_ID)
        {
            DTO_Account account=null;
            try
            {
                if (conn.State == ConnectionState.Closed  ) conn.Open();
                string query = "SELECT * FROM Account WHERE ID = @account_ID";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@account_ID", account_ID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            account = new DTO_Account();
                            account.ID = Convert.ToInt32(reader["ID"]);
                            account.Name = reader["Name"].ToString();
                            account.CCCD_Num = reader["CCCD_Num"].ToString();
                            account.PhoneNumber = reader["PhoneNumber"].ToString();
                            account.Address = reader["Address"].ToString();
                            account.Sex = reader["Sex"].ToString();
                            account.Role = reader["Role"].ToString();
                            account.Account = reader["Account"].ToString();
                            account.Password = reader["Password"].ToString();
                            account.Status = reader["Status"].ToString();
                        }
                    }
                }
                
                return account;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
            return account;

        }
        public bool updateAccount(DTO_Account account)
        {
            try
            {
                
                if (conn.State == ConnectionState.Closed) conn.Open();
                // Query string với tham số hóa
                string SQL = "UPDATE Account SET Name=@Name,CCCD_Num=@CCCD_Num,PhoneNumber=@PhoneNumber,Sex=@Sex,Address=@Address,Role=@Role,Account=@Account,Password=@Password,Status=@Status WHERE ID =@ID";

                // Tạo đối tượng SqlCommand với câu lệnh SQL và kết nối
                using (SqlCommand command = new SqlCommand(SQL, conn))
                {
                    command.Parameters.AddWithValue("@ID", account.ID);
                    // Thêm tham số và giá trị tương ứng
                    command.Parameters.AddWithValue("@Name", account.Name);
                    command.Parameters.AddWithValue("@CCCD_Num", account.CCCD_Num);
                    command.Parameters.AddWithValue("@PhoneNumber", account.PhoneNumber);
                    command.Parameters.AddWithValue("@Sex", account.Sex);
                    command.Parameters.AddWithValue("@Address", account.Address);
                    command.Parameters.AddWithValue("@Role", account.Role);
                    command.Parameters.AddWithValue("@Account", account.Account);
                    command.Parameters.AddWithValue("@Password", account.Password);
                    command.Parameters.AddWithValue("@Status", account.Status);

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
