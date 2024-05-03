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
        private int accountIDNow=-1;
        private string statusFillterNow = "Full";
        public frmAccount()
        {
            InitializeComponent();
        }


        private void frmAccount_Load(object sender, EventArgs e)
        {
            dgvAccount.DataSource = busAcc.getAccountTable(statusFillterNow);
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;  
        }

        private void grpAccInfo_Click(object sender, EventArgs e)
        {

        }

        public bool checkValidInfo()
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
            if (checkValidInfo())
            {
                if (busAcc.existAccount(-1,txtAccount.Text))
                {
                    MessageBox.Show("Tài khoản đăng nhập như trên đã tồn tại trong hệ thống, không thể thêm mới tài khoản");
                    return;
                }    
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
                    dgvAccount.DataSource = busAcc.getAccountTable(statusFillterNow);
                    clearInfoGroupBoxAccount();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra, thêm mới không thành công");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ / hợp lệ mọi thông tin !");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAccount.SelectedRows.Count > 0)
            {
                string thisRole = "Admin";
                if (cbxRole.SelectedIndex == 1)
                {
                    thisRole = "Member";
                }    
                if (busAcc.deleteAccount(accountIDNow,thisRole))
                {
                    MessageBox.Show("Xóa tài khoản thành công");

                    dgvAccount.DataSource = busAcc.getAccountTable(statusFillterNow);// refresh datagridview
                    clearInfoGroupBoxAccount();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công, tài khoản không thể xoá");
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn tài khoản muốn xoá");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (checkValidInfo())
            {
                int IDAccountNow = int.Parse(dgvAccount.CurrentRow.Cells[0].Value.ToString());
                if (busAcc.existAccount(IDAccountNow,txtAccount.Text))
                {
                    MessageBox.Show("Tài khoản đăng nhập như trên đã tồn tại, không thể cập nhật");
                    return;
                }    
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
                DTO_Account account = new DTO_Account(accountIDNow, txtName.Text, txtCCCDNum.Text, txtPhoneNumber.Text, sex, txtAddress.Text, role, txtAccount.Text, txtPassword.Text, activeStatus);
                if (busAcc.updateAccount(account))
                {
                    MessageBox.Show("Cập nhật tài khoản thành công");
                    dgvAccount.DataSource = busAcc.getAccountTable(statusFillterNow);
                    clearInfoGroupBoxAccount();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra, cập nhật không thành công");
                }
            }   
            else
            {
                MessageBox.Show("Thông tin không hợp lệ / đầy đủ, không thể cập nhật");
            }
        }

        private void cbxAccountStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxAccountStatus.SelectedIndex == 0)
            {
                statusFillterNow = "Full";
            }
            else if (cbxAccountStatus.SelectedIndex == 1)
            {
                statusFillterNow = "Active";
            }
            else if (cbxAccountStatus.SelectedIndex == 2)
            {
                statusFillterNow = "Off";
            }
            dgvAccount.DataSource = busAcc.getAccountTable(statusFillterNow);
        }
    }
}
