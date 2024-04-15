using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppQuanLyQuanCafe
{
    public partial class frmTableList : Form
    {
        String connectString = "Data Source=DESKTOP-664DDD6;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";
        SqlConnection SqlConnection;
        SqlCommand SqlCommand;
        SqlDataAdapter SqlDataAdapter;
        DataTable dt = new DataTable();
        public frmTableList()
        {
            InitializeComponent();
        }

        private void frmTableList_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection = new SqlConnection(connectString);
                SqlConnection.Open();
                SqlCommand = new SqlCommand("Select * from TableList", SqlConnection);
                SqlDataAdapter = new SqlDataAdapter(SqlCommand);
                SqlDataAdapter.Fill(dt);
                dataGridView1.DataSource = dt;
                SqlConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
