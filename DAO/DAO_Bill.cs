using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using DTO;
namespace DAO
{
    public class DAO_Bill:DBConnect
    {
       public DAO_Bill() { }
       public DataTable GetRevueneByCategory()
        {
            try
            {

                if (conn.State == ConnectionState.Closed) conn.Open();
                string query = "EXEC CalculateCategoryRevenue"; // gọi đến store procedure trong sql
               
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);

                DataTable dt_Account = new DataTable();
                sqlDataAdapter.Fill(dt_Account);
                return dt_Account;
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
       public bool CheckoutBill(int billID, decimal sumBill, decimal discount)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // Query string với tham số hóa
                string SQL = "UPDATE Bill SET Status=1, DateCheckout=@Date, Discount=@Discount,TotalPrice=@TotalPrice WHERE ID=@BillID";

                // Tạo đối tượng SqlCommand với câu lệnh SQL và kết nối
                using (SqlCommand command = new SqlCommand(SQL, conn))
                {

                    
                    command.Parameters.AddWithValue("@BillID", billID);
                    command.Parameters.AddWithValue("@Discount", discount);
                    command.Parameters.AddWithValue("@TotalPrice", sumBill);
                    command.Parameters.AddWithValue("@Date", DateTime.Now);


                    return (int)command.ExecuteNonQuery()>0;
                    
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
       public int GetUncheckedBillIDByTableID(int tableID)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // Query string với tham số hóa
                string SQL = "SELECT ID FROM Bill WHERE TableID=@TableID AND Status=0";

                // Tạo đối tượng SqlCommand với câu lệnh SQL và kết nối
                using (SqlCommand command = new SqlCommand(SQL, conn))
                {

                    // Thêm tham số và giá trị tương ứng
                    command.Parameters.AddWithValue("@TableID", tableID);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return (int)result;
                    }
                    else
                    {
                        return -1; 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return -1;
            }


            finally
            {
                conn.Close();
            }
        }
        public int GetMaxBillID()
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // Query string với tham số hóa
                string SQL = "SELECT MAX(ID) FROM Bill";

                // Tạo đối tượng SqlCommand với câu lệnh SQL và kết nối
                using (SqlCommand command = new SqlCommand(SQL, conn))
                {
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return (int)result;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return -1;
            }


            finally
            {
                conn.Close();
            }
        } 
       public bool AddBill(DTO_Bill dto)
        {
            try
            {
                if (conn.State == ConnectionState.Closed) conn.Open();

                // Query string với tham số hóa
                string SQL = "INSERT INTO Bill(TableID,TotalPrice,Discount,DateCheckin,DateCheckout,AccountID,Status) VALUES (@TableID,@TotalPrice,@Discount,@DateCheckin,@DateCheckout,@AccountID,@Status)";

                // Tạo đối tượng SqlCommand với câu lệnh SQL và kết nối
                using (SqlCommand command = new SqlCommand(SQL, conn))
                {

                    // Thêm tham số và giá trị tương ứng
                    command.Parameters.AddWithValue("@TableID", dto.TableID);
                    command.Parameters.AddWithValue("@TotalPrice", dto.TotalPrice);
                    command.Parameters.AddWithValue("@Discount", dto.Discount);
                    command.Parameters.AddWithValue("@DateCheckin", dto.DateCheckIn);
                    command.Parameters.AddWithValue("@DateCheckout", dto.DateCheckOut);
                    command.Parameters.AddWithValue("@Status", dto.Status);
                    command.Parameters.AddWithValue("@AccountID", dto.AccountID);



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
