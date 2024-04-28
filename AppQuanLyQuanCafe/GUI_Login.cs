using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
namespace AppQuanLyQuanCafe
{
    public partial class frmLogin : Form
    {
        BUS_Login BUS_Login = new BUS_Login();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BUS_Login.haveRole(txtUserName.Text,txtPass.Text))
            {
                if (BUS_Login.isAdmin(txtUserName.Text,txtPass.Text))
                {
                    MessageBox.Show("Bạn sẽ đăng nhập với vai trò Quản trị viên");
                    frmMain frmMain = new frmMain("Admin");
                    this.Hide();
                    frmMain.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Bạn sẽ đăng nhập với vai trò Nhân viên, làm việc tốt nhé !");
                    frmMain frmMain = new frmMain("Member");
                    this.Hide();
                    frmMain.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công, kiểm tra lại thông tin và trạng thái tài khoản","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }    
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
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

        private void txtAccount_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }
    }
}
