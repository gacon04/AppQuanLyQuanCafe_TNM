using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
namespace AppQuanLyQuanCafe
{
    public partial class frmAccount : Form
    {
        BUS_Account busAcc = new BUS_Account();
        private int accountIDNow=0;
        public frmAccount()
        {
            InitializeComponent();
        }

       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            dgvAccount.DataSource = busAcc.getAccountTable();
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;  
        }

        private void grpAccInfo_Click(object sender, EventArgs e)
        {

        }

        public bool checkInfoBeforeAdd()
        {
            if (txtName.Text=="") return false;
            if (txtCCCDNum.Text.Length < 12 || txtCCCDNum.Text.Any(char.IsLetter))
            {
                return false;
            }    
            if (txtPhoneNumber.Text.Any(char.IsLetter)) return false;
            if (txtAddress.Text == "") return false;
            if (cbxRole.SelectedIndex == -1) return false;
            if (rdnFemale.Checked==false && rdnMale.Checked==false) return false;
            if (txtAccount.Text == "") return false;
            if (txtPassword.Text == "") return false;
            return true;
        }
        public void clearInfoGroupBoxAccount()
        {
            txtName.Clear();
            txtCCCDNum.Clear();
            txtPhoneNumber.Clear();
            txtAddress.Clear();
            txtPassword.Clear();
            txtAccount.Clear();
            chkActive.Checked = false;
            rdnFemale.Checked = false;
            rdnMale.Checked = false;
            cbxRole.SelectedIndex = -1;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkInfoBeforeAdd())
            {
                string sex = "Nam";
                if (rdnFemale.Checked)
                {
                    sex = "Nữ";
                }
                string role = "Admin";
                if (cbxRole.SelectedIndex == 1)
                {
                    role = "Member";
                }
                string activeStatus = "Nghỉ";
                if (chkActive.Checked)
                {
                    activeStatus = "Hoạt động";
                }    
                DTO_Account account = new DTO_Account(0,txtName.Text,txtCCCDNum.Text,txtPhoneNumber.Text, sex, txtAddress.Text,role,txtAccount.Text,txtPassword.Text,activeStatus);
                if (busAcc.addAccount(account))
                {
                    MessageBox.Show("Thêm mới tài khoản thành công");
                    dgvAccount.DataSource = busAcc.getAccountTable();
                    clearInfoGroupBoxAccount();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra, thêm mới không thành công");
                }
            }
            else
            {
                MessageBox.Show("Vui long nhap day du va hop le moi thong tin");
            }    
        }

        private void frmAccount_Click(object sender, EventArgs e)
        {
            dgvAccount.ClearSelection();
        }

        private void dgvAccount_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvAccount.ClearSelection();

        }
        public void xuLyGroupBoxAccount(string name, string CCCDNum, string phoneNum, string sex, string address,string role, string account, string password, string status)
        {
            txtName.Text = name;
            txtCCCDNum.Text = CCCDNum;
            txtPhoneNumber.Text = phoneNum;
            if (sex == "Nam")
            {
                rdnMale.Checked = true;
                rdnFemale.Checked = false;
            }
            else
            {
                rdnFemale.Checked = true;
                rdnMale.Checked = false;
            }
            txtAddress.Text = address;
            if (role == "Admin")
            {
                cbxRole.SelectedIndex = 0;

            }
            else
            {
                cbxRole.SelectedIndex = 1;
            }
            txtAccount.Text = account;
            txtPassword.Text = password;
            if (status =="Hoạt động")
            {
                chkActive.Checked = true;
            }
            else { chkActive.Checked = false; }
        }
        private void dgvAccount_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAccount.SelectedRows.Count > 0)
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                DataGridViewRow selectedRow = dgvAccount.SelectedRows[0];
                accountIDNow = (int)selectedRow.Cells[0].Value;
                if (busAcc.canGetAccountByID(accountIDNow))
                {
                    DTO_Account account = busAcc.getAccountByID(accountIDNow);
            
                    xuLyGroupBoxAccount(account.Name, account.CCCD_Num, account.PhoneNumber, account.Sex, account.Address, account.Role, account.Account, account.Password, account.Status);

                }
            }
            else
            {
                clearInfoGroupBoxAccount();
                btnAdd.Enabled = true;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }

        }
    }
}
