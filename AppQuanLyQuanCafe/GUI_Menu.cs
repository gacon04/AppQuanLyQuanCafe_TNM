using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppQuanLyQuanCafe
{
    public partial class frmMenu : Form
    {
        BUS_Food bus_Food = new BUS_Food();
        public frmMenu(string role)
        {
            InitializeComponent();
            if (role == "Member")
            {
                btnAdd.Visible = false;
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                txtName.ReadOnly = true;
                txtPrice.ReadOnly = true;
                txtDescription.ReadOnly = true;
                cbxCateName.Enabled = false;
                cbxStatus.Enabled = false;
            }
        }
        public void clearAllFoodInfo()
        {
            txtID.Clear();
            cbxCateName.SelectedIndex = -1;
            txtName.Clear();
            txtCreatedDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtPrice.Clear();
            cbxStatus.SelectedIndex = -1;
            txtDescription.Clear();
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            cbxCateName.SelectedIndex = -1;

        }
        private void frmMenu_Load(object sender, EventArgs e)
        {
            dgvFood.DataSource = bus_Food.getFoodTable();
            dgvFood.ClearSelection();
            cbxCateName.DataSource = bus_Food.getCateIdAndCateName();
            cbxCateName.DisplayMember ="Name";
            cbxCateName.ValueMember = "ID";
            clearAllFoodInfo();

        }
        public bool checkValidInfo()
        {
            if (cbxCateName.SelectedIndex == -1) return false;
            if (txtName.Text == "") return false;
            if (cbxStatus.SelectedIndex == -1) return false;
            if (txtPrice.Text == "" || Regex.IsMatch(txtPrice.Text, "[a-zA-Z]")) return false;
            if (cbxStatus.SelectedIndex==-1) return false;
            return true;

        }

        private void frmMenu_Click(object sender, EventArgs e)
        {
            dgvFood.ClearSelection();
        }

        private void dgvFood_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvFood.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkValidInfo())
            {
                if (bus_Food.exitFoodNameInSameCategory(-1,int.Parse(cbxCateName.SelectedValue.ToString()),txtName.Text))
                {
                    MessageBox.Show("Tên thức ăn/đồ uống trên đã tồn tại trong cùng danh mục, không thể thêm");
                    return;
                }    
                try
                {
                    DateTime dateTimeValue = DateTime.ParseExact(txtCreatedDate.Text, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    int cateID = int.Parse(cbxCateName.SelectedValue.ToString());
                    DTO_Food dTO_Food = new DTO_Food(0, txtName.Text, txtDescription.Text, cbxStatus.Text, decimal.Parse(txtPrice.Text), cateID, dateTimeValue);
                    if (bus_Food.addFood(dTO_Food))
                    {
                        MessageBox.Show("Thêm món mới thành công !");
                        clearAllFoodInfo();
                        dgvFood.DataSource = bus_Food.getFoodTable();

                    }
                    else
                    {
                        MessageBox.Show("Thêm mới danh mục không thành công !");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            } 
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ/hợp lệ thông tin");
            }    
        }
        private void xuLyGroupBoxFood(int id,string name,decimal price, string description, DateTime dateTime, string status)
        {
            txtID.Text = id.ToString();
            txtName.Text = name;
            txtPrice.Text = price.ToString();
            txtDescription.Text = description;
            txtCreatedDate.Text = dateTime.ToString();
            cbxStatus.SelectedIndex = 1;
            if (status=="Còn")
            {
                cbxStatus.SelectedIndex=0;
            }    
            

        }
        private void dgvFood_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFood.SelectedRows.Count > 0)
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                try
                {
                   
                    DataGridViewRow selectedRow = dgvFood.SelectedRows[0];
                    int foodID = (int)selectedRow.Cells[0].Value;
                    DTO_Food food = bus_Food.GetFoodByID(foodID);
                    xuLyGroupBoxFood(foodID, food.Name, food.Price, food.Description, food.CreatedDate,food.Status);
                    cbxCateName.Text = selectedRow.Cells[1].Value.ToString() ;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            else
            {
                clearAllFoodInfo();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (checkValidInfo())
            {
                try
                {
                    if (bus_Food.exitFoodNameInSameCategory(int.Parse(txtID.Text),int.Parse(cbxCateName.SelectedValue.ToString()),txtName.Text))
                    {
                        MessageBox.Show("Tên món ăn/thức uống đã tồn tại trong danh mục, không thể cập nhật.");
                        return;
                    }
                    DateTime dateTimeValue = DateTime.ParseExact(txtCreatedDate.Text, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    int cateID = int.Parse(cbxCateName.SelectedValue.ToString());
                    DTO_Food _Food = new DTO_Food(int.Parse(txtID.Text),txtName.Text,txtDescription.Text,cbxStatus.Text,decimal.Parse(txtPrice.Text),cateID,dateTimeValue);
                    if (bus_Food.updateFood(_Food))
                    {
                        MessageBox.Show("Cập nhật món thành công");
                        dgvFood.DataSource = bus_Food.getFoodTable();
                        clearAllFoodInfo();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (bus_Food.deleteFood(int.Parse(txtID.Text)))
            {
                MessageBox.Show("Xoá món thành công");
                dgvFood.DataSource = bus_Food.getFoodTable();
                dgvFood.ClearSelection();
                clearAllFoodInfo();
                
            }
        }
    }
}
