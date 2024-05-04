using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace AppQuanLyQuanCafe
{
    public partial class frmCategory : Form
    {
        BUS_Category bus_Category = new BUS_Category();
        public frmCategory(string role)
        {
            InitializeComponent();
            if (role=="Member")
            {
                btnAdd.Visible = false;
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                txtName.ReadOnly = true;
                txtDescription.ReadOnly = true;
            }    
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            dgvCategory.DataSource = bus_Category.getCategoryTable();
            clearAllCategoryInfo();
        }
        public void clearAllCategoryInfo()
        {
            txtID.Clear();
            txtName.Clear();
            txtCreatedDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtDescription.Clear();
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtCreatedDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (txtName.Text!="" && Regex.IsMatch(txtName.Text, "[a-zA-Z]"))
            {
                if (bus_Category.existCategoryName(-1,txtName.Text))
                {
                    MessageBox.Show("Tên danh mục như trên đã tồn tại, không thể thêm");
                    return;
              }    
                try
                {
                    DateTime dateTimeValue = DateTime.ParseExact(txtCreatedDate.Text, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    DTO_Category dto_category = new DTO_Category(0,txtName.Text, txtDescription.Text, dateTimeValue);
                    if (bus_Category.addCategory(dto_category))
                    {
                        MessageBox.Show("Thêm mới danh mục thành công !");
                        clearAllCategoryInfo();
                        dgvCategory.DataSource = bus_Category.getCategoryTable();

                    }
                    else
                    {
                        MessageBox.Show("Thêm mới danh mục không thành công !");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: "+ ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ / hợp lệ thông tin");
                   
            }
        }

        private void frmCategory_Click(object sender, EventArgs e)
        {
            dgvCategory.ClearSelection();
        }

        private void dgvCategory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvCategory.ClearSelection();

        }

        private void dgvCategory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count > 0)
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                DataGridViewRow selectedRow = dgvCategory.SelectedRows[0];
                try
                {
                    txtID.Text = selectedRow.Cells[0].Value.ToString();
                    txtName.Text = selectedRow.Cells[1].Value.ToString();
                    txtDescription.Text = selectedRow.Cells[2].Value.ToString();
                    txtCreatedDate.Text = selectedRow.Cells[3].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            else
            {
                clearAllCategoryInfo();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult  dlg = MessageBox.Show("Toàn bộ thức uống/đồ ăn thuộc danh mục này sẽ bị xoá, bạn có chắc chắn không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dlg == DialogResult.Yes)
            {
                if (bus_Category.deleteCategory(int.Parse(txtID.Text)))
                {
                    MessageBox.Show("Xoá danh mục thành công");
                    clearAllCategoryInfo() ;
                    dgvCategory.DataSource = bus_Category.getCategoryTable();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text!="" && Regex.IsMatch(txtName.Text, "[a-zA-Z]"))
            {
                try
                {
                    if (bus_Category.existCategoryName(int.Parse(txtID.Text), txtName.Text))
                    {
                        MessageBox.Show("Tên danh mục đã tồn tại trong hệ thống, không thể cập nhật.");
                        return;
                    }
                    DateTime dateTimeValue = DateTime.ParseExact(txtCreatedDate.Text, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    DTO_Category dto_category = new DTO_Category(int.Parse(txtID.Text), txtName.Text, txtDescription.Text, dateTimeValue);
                    if (bus_Category.updateCategory(dto_category))
                    {
                        MessageBox.Show("Cập nhật danh mục thành công");
                        dgvCategory.DataSource = bus_Category.getCategoryTable();
                        clearAllCategoryInfo();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra, cập nhật không thành công");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                
            }
            else
            {
                MessageBox.Show("Thông tin không hợp lệ / đầy đủ, không thể cập nhật");
            }
        }
    }
}
