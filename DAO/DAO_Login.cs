using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_Login:DBConnect //kế thừa conn
    {
        public string roleOfInput(string account, string password)
        {
            string role = "";
            string status = "";
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string query = "SELECT Role,Status FROM Account WHERE Account=@account AND Password=@password";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@account", account);
                    command.Parameters.AddWithValue("@password", password);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        { 
                            role = reader["Role"].ToString();
                            status = reader["Status"].ToString() ;
                        }
                    }
                }

                if ((role=="Admin"||role=="Member") && status=="Hoạt động") return role;
            }
            catch (Exception ex)
            {
                return "";
            }
            finally
            {
                conn.Close();
            }
            return "";

        }
    }
}
