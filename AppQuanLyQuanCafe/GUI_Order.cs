using BUS;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AppQuanLyQuanCafe
{
    public partial class frmOrder : Form
    {
      
        BUS_TableList bus_Table = new BUS_TableList();
        BUS_Food bus_Food = new BUS_Food();
        BUS_Category bus_Category = new BUS_Category();
        BUS_Bill bus_Bill = new BUS_Bill();
        BUS_BillInfoDetails bus_BillInfoDetails  = new BUS_BillInfoDetails();
        public int accountID = 0;
        public frmOrder(int accID)
        {
            InitializeComponent();
            LoadTable();
            accountID = accID;
            lblSum.Text = "0";
        }
        public void LoadTable()
        {
            List<DTO_Table> tableList = bus_Table.LoadTableList();
            foreach (DTO_Table table in tableList)
            {
                Guna2Button btnTable = new Guna2Button()
                {
                    Width = 120,
                    Height = 120,
                    Text = table.Name+"\n"+table.Status,
                    BackColor = Color.FromArgb(252, 234, 218),
                    FillColor = Color.Transparent,
                    Margin = new Padding(13, 14, 13, 14),
                    ForeColor = Color.Black,
                    Font = new Font("Montserrat Medium", 14.25f)

                };
                btnTable.Click += btn_Click; // gán cho các button tạo ra bàn từ bảng sự kiện trên
                btnTable.Tag = table; // gán tag (có kiểu dữ liệu object) bằng 1 DTO_Table
                if (table.Status=="Có người")
                {
                    btnTable.BackColor = Color.FromArgb(225, 183, 137);
                }    
                flpTableList.Controls.Add(btnTable);

            }
        }
        
        public void ShowBill(int ID)
        {
            lsvBill.Items.Clear();
            decimal tongTien = 0;
            List<DTO_BillInfoDetail> listBillDetails = bus_BillInfoDetails.GetListMenuByTableID(ID);
            foreach (DTO_BillInfoDetail item in listBillDetails)
            {
                //bản chất listview là 1 item ở cột bàn đầu vào các cột còn lại là subitem
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.Quantity.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                tongTien += item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN"); //định dạng nhận diện vùng miền
            lblSum.Text = Math.Round(tongTien).ToString("c",culture); //currency
            if (lblSum.Text != "0")
            {
                txtDiscount.Enabled = true;
            }
            else
            {
                txtDiscount.Enabled = false;
            }
        }
        public void btn_Click(object sender, EventArgs e)
        {
            isAnyButtonClicked = true;
            int tableID = ((sender as Guna2Button).Tag as DTO_Table).ID;
            lsvBill.Tag = (sender as Guna2Button).Tag;  //gán tag của listview bằng chính button mà ta bấm vào
            ShowBill(tableID);
        }
        private void cbxFoodSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmOrder_Leave(object sender, EventArgs e)
        {

        }
        private void refresh2ComboBox()
        {
            cbxCateSelect.DataSource = bus_Category.getCategoryTable();
            cbxCateSelect.DisplayMember = "Tên";
            cbxCateSelect.ValueMember = "ID";
            cbxCateSelect.SelectedIndex = -1;
            cbxFoodSelect.DataSource = bus_Food.getFoodIDandFoodName(-1);
            cbxFoodSelect.DisplayMember = "Name";
            cbxFoodSelect.ValueMember = "ID";
            cbxFoodSelect.SelectedIndex = -1;
            cbxTableSwap.DataSource = bus_Table.getTableList();
            cbxTableSwap.DisplayMember = "Name";
            cbxTableSwap.ValueMember = "ID";    
        }
        private void frmOrder_Load(object sender, EventArgs e)
        {
            refresh2ComboBox();
            txtDiscount.Enabled = false;
        }

        private void cbxCateSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCateSelect.SelectedIndex != -1)
            {
                int cateID;
                if (int.TryParse(cbxCateSelect.SelectedValue.ToString(), out cateID))
                {
                    cbxFoodSelect.DataSource = bus_Food.getFoodIDandFoodName(cateID);
                    cbxFoodSelect.DisplayMember = "Name";
                    cbxFoodSelect.ValueMember = "ID";
                    cbxFoodSelect.SelectedIndex = -1;
                }
                else
                {
                    // Xử lý khi không thể chuyển đổi giá trị sang số nguyên
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Bạn có muốn in ra hoá đơn mới thanh toán gần nhất","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
        }

        private void lblSum_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void lblSum_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!isAnyButtonClicked)
            {
                MessageBox.Show("Chưa có bàn nào được chọn,hãy chọn bàn muốn thêm món");
                return;
            }    
           DTO_Table table = lsvBill.Tag as DTO_Table;
            if (cbxFoodSelect.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn món thêm");
                return;
            }
            
            int idFoodSelected =(int)cbxFoodSelect.SelectedValue;
            int idBill = bus_Bill.GetUncheckedBillIDByTableID(table.ID);
            if (idBill==-1) //trường hợp bàn đó chưa có billID nào chưa thanh toán -->tạo mới
            {
                DTO_Bill dTO_Bill = new DTO_Bill(0, table.ID, 0, 0,DateTime.Now,DateTime.Now, accountID, 0);
                if (!bus_Bill.AddBill(dTO_Bill))
                {
                    MessageBox.Show("Thêm hoá đơn mới không thành công");
                    return;
                } 
                DTO_BillInfo dTO_BillInfo = new DTO_BillInfo(0, bus_Bill.GetMaxBillID(), idFoodSelected, (int)nudFoodCount.Value);
                if (!bus_BillInfoDetails.addBillInfo(dTO_BillInfo))
                {
                    MessageBox.Show("Thêm món vào hoá đơn không thành công");
                }
            }    
            else
            {
                DTO_BillInfo dTO_BillInfo = new DTO_BillInfo(0,idBill,idFoodSelected, (int)nudFoodCount.Value);
                bus_BillInfoDetails.addBillInfo(dTO_BillInfo);
            }
            ShowBill(table.ID);
        }

        private bool isAnyButtonClicked = false;

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (!isAnyButtonClicked)
            {
                MessageBox.Show("Chưa có bàn nào được chọn để thanh toán", "Nhắc nhở");
                return;
            }
            DTO_Table tableNow = lsvBill.Tag as DTO_Table; //lấy bàn hiện tại đang gắn tag trong listview
            int idBill = bus_Bill.GetUncheckedBillIDByTableID(tableNow.ID);
            if (idBill == -1) {
                MessageBox.Show("Bàn này hiện tại không có hoá đơn nào");
                return;
            }
            else
            {
                string mess = "Bạn có chắc chắn muốn thanh toán hoá đơn của " + tableNow.Name + " ?";
                DialogResult dlg = MessageBox.Show(mess, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dlg == DialogResult.Yes)
                {
                    if (bus_Bill.CheckOutBill(idBill,DateTime.Now))
                    {
                        MessageBox.Show("Thanh toán thành công");
                        ShowBill(tableNow.ID);
                    }    
                }

            }


        }
    }
}
