using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
    public class DBConnect
    {
        protected SqlConnection conn = new SqlConnection("Data Source=DESKTOP-664DDD6;Initial Catalog=QuanLyQuanCafe;Integrated Security=True");
   
    }
}
