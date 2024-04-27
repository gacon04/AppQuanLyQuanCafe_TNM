using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppQuanLyQuanCafe
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "admin" && txtPass.Text =="1")
            {
                MessageBox.Show("Bạn sẽ đăng nhập App với vai trò Quản trị viên !");
                frmMain frmMain = new frmMain();
                frmMain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Thông tin đăng nhập không hợp lệ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }    
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            
                if (checkBox1.Checked)
                {
                txtPass.UseSystemPasswordChar = false;
                }
                else
                {
                    txtPass.UseSystemPasswordChar= true;
                
                 }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
       

        }

        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ với Quản trị viên để cấp lại mật khẩu ");
        }
    }
}
