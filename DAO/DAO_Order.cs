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
    public class DAO_Order:DBConnect
    {
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
            finally { conn.Close(); }   

        }
        public DataTable getFoodIDandFoodName(int cateID)
        {
            try
            {
                
                if (conn.State == ConnectionState.Closed) conn.Open();

                string SQL = string.Format("SELECT ID, Name FROM Food WHERE Status=N'Còn' AND CategoryID={0}", cateID);
                if (cateID==-1)
                {
                    SQL = "SELECT ID, Name FROM Food WHERE Status=N'Còn'";
                }    
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
        //Các datatable chỉ sử dụng import vào các combobox, dgv dc thôi. Muốn sử dụng cho các control khác phải xài kiểu khác
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
                    DTO_Table table = new DTO_Table(row);
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
    }
}
