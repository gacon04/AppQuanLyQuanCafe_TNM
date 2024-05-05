using BUS;
using DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace AppQuanLyQuanCafe
{
    public partial class frmOrder : Form
    {
        BUS_Order bus_Order = new BUS_Order();
        public frmOrder()
        {
            InitializeComponent();
            LoadTable();
        }
        public void LoadTable()
        {
            List<DTO_Table> tableList = bus_Order.LoadTableList();
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
                if (table.Status=="Có người")
                {
                    btnTable.BackColor = Color.FromArgb(225, 183, 137);
                }    
                flpTableList.Controls.Add(btnTable);

            }
        }

        private void cbxFoodSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmOrder_Leave(object sender, EventArgs e)
        {

        }
        private void refresh2ComboBox()
        {
            cbxCateSelect.DataSource = bus_Order.getCateIdAndCateName();
            cbxCateSelect.DisplayMember = "Name";
            cbxCateSelect.ValueMember = "ID";
            cbxCateSelect.SelectedIndex = -1;
            cbxFoodSelect.DataSource = bus_Order.getFoodIDandFoodName(-1);
            cbxFoodSelect.DisplayMember = "Name";
            cbxFoodSelect.ValueMember = "ID";
            cbxFoodSelect.SelectedIndex = -1;
            cbxTableSwap.DataSource = bus_Order.getTableList();
            cbxTableSwap.DisplayMember = "Name";
            cbxTableSwap.ValueMember = "ID";    
        }
        private void frmOrder_Load(object sender, EventArgs e)
        {
            refresh2ComboBox();
        }

        private void cbxCateSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCateSelect.SelectedIndex != -1)
            {
                int cateID;
                if (int.TryParse(cbxCateSelect.SelectedValue.ToString(), out cateID))
                {
                    cbxFoodSelect.DataSource = bus_Order.getFoodIDandFoodName(cateID);
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
    }
}
