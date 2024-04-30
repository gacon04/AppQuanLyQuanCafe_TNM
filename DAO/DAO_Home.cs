using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_Home:DBConnect
    {
        public int countAdminAccount()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string query = "SELECT COUNT(*) FROM Account WHERE Role='Admin' and Status = N'Hoạt động' ";
                SqlCommand command = new SqlCommand(query, conn);
                return (int)command.ExecuteScalar();
               
               

            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }
        public int countMemberAccount()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                string query = "SELECT COUNT(*) FROM Account WHERE Role='Member' and Status = N'Hoạt động'";
                SqlCommand command = new SqlCommand(query, conn);
                return (int)command.ExecuteScalar();


            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
