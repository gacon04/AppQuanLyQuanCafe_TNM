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
    }
}
