using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppQuanLyQuanCafe
{
    public partial class frmTableList : Form
    {
        BUS_TableList  BUS_TableList = new BUS_TableList();
        
        public frmTableList(string role)
        {
            InitializeComponent();
            if (role =="Member" ) {
                btnAdd.Visible = false;
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
            }
        }

        public void refreshForm()
        {
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
            txtID.Clear();
            txtName.Clear();
            cbxStatus.SelectedIndex = 0;
        }
        private void frmTableList_Load(object sender, EventArgs e)
        {
            dgvTableList.DataSource = BUS_TableList.getTableList(cbxStatusFillter.Text);
            refreshForm();
            dgvTableList.ClearSelection();
        }
        
        private void cbxStatusFillter_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvTableList.DataSource = BUS_TableList.getTableList(cbxStatusFillter.Text);

        }

        private void frmTableList_Click(object sender, EventArgs e)
        {
            dgvTableList.ClearSelection();
        }
        public bool checkValidInfo()
        {
            return (txtName.Text != "" && cbxStatus.SelectedIndex != -1);
        }

        private void dgvTableList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTableList.SelectedRows.Count > 0)
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                DataGridViewRow selectedRow = dgvTableList.SelectedRows[0];
                try
                {
                    txtID.Text = selectedRow.Cells[0].Value.ToString();
                    txtName.Text = selectedRow.Cells[1].Value.ToString();
                    if (selectedRow.Cells[2].Value.ToString()=="Trống")
                    {
                        cbxStatus.SelectedIndex = 0;
                    }    
                    else cbxStatus.SelectedIndex = 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            else
            {
                refreshForm();
            }
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTableList.SelectedRows.Count > 0)
            {
                
                
                if (BUS_TableList.deleteTable(int.Parse(txtID.Text)))
                {
                    MessageBox.Show("Xóa bàn thành công");

                    dgvTableList.DataSource = BUS_TableList.getTableList(cbxStatusFillter.Text);
                    refreshForm();
                }
                else
                {
                    MessageBox.Show("Xóa bàn không thành công, trong hoá đơn đang có bàn này");
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn bàn muốn xoá");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkValidInfo())
            {
                if (BUS_TableList.existTableName(-1,txtName.Text))
                {
                    MessageBox.Show("Tên bàn đã tồn tại trong hệ thống, không thể thêm vào.");
                    return;
                }    
                DTO_Table table = new DTO_Table(0, txtName.Text,cbxStatus.Text.Trim());
                if (BUS_TableList.addTable(table))
                {
                    MessageBox.Show("Thêm bàn mới thành công");
                    refreshForm();
                    dgvTableList.DataSource = BUS_TableList.getTableList(cbxStatusFillter.Text);
                    dgvTableList.ClearSelection();
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

        private void dgvTableList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvTableList.ClearSelection();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (checkValidInfo())
            {
               if (BUS_TableList.existTableName(int.Parse(txtID.Text),txtName.Text))
                {
                    MessageBox.Show("Tên bàn đã tồn tại trong hệ thống, không thể cập nhật.");
                    return;
                }    
                DTO_Table table = new DTO_Table(int.Parse(txtID.Text),txtName.Text,cbxStatus.Text);
                if (BUS_TableList.updateTable(table))
                {
                    MessageBox.Show("Cập nhật bàn thành công");
                    dgvTableList.DataSource = BUS_TableList.getTableList(cbxStatusFillter.Text);
                    refreshForm() ;
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
    }
}
