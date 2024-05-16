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
    public class DAO_BillInfoDetail:DBConnect
    {
        public DAO_BillInfoDetail() { }
        public bool AddBillInfo(DTO_BillInfo dto)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // Query string với tham số hóa
                string SQL = "USP_InsertBillInfo @BillID, @FoodID, @Quantity";

                // Tạo đối tượng SqlCommand với câu lệnh SQL và kết nối
                using (SqlCommand command = new SqlCommand(SQL, conn))
                {
                    command.Parameters.AddWithValue("@BillID", dto.BillID);
                    command.Parameters.AddWithValue("@FoodID", dto.FoodID);
                    command.Parameters.AddWithValue("@Quantity", dto.Quantity);
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
        public DataTable getBillInfoByBillID(int id)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string proc = "GetBillDetailsByBillID";
                using (SqlCommand command = new SqlCommand(proc, conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@BillID", id);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    sqlDataAdapter.Fill(dt);

                    return dt;
                }
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
        public List<DTO_BillInfoDetail> GetListMenuByTableID(int id)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                List<DTO_BillInfoDetail> billInfoList = new List<DTO_BillInfoDetail>();
                DataTable dt = new DataTable();
               
                string SQL = string.Format("SELECT f.Name , f.Price , bi.Quantity , f.Price*bi.Quantity as TotalPrice FROM dbo.BillInfo as bi ,dbo.Bill as b,dbo.Food as f WHERE bi.BillID = b.ID AND bi.FoodID=f.ID AND b.Status=0 and b.TableID={0}", id);
                using (SqlCommand command = new SqlCommand(SQL, conn))
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dt);
                    }
                }
                foreach (DataRow row in dt.Rows)
                {
                    DTO_BillInfoDetail billInfo = new DTO_BillInfoDetail(row);
                    billInfoList.Add(billInfo);
                }
                return billInfoList;
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
