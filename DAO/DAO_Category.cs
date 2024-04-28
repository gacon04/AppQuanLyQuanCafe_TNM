using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_Category: DBConnect
    {
        public DataTable getCategoryTable()
        {
            try
            {

                if (conn.State == ConnectionState.Closed) conn.Open();
                
                string query = "SELECT ID,Name,Description,CreatedDate FROM Category";
               
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
    }
}
