using BUS;
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
    public partial class frmBill : Form
    {
        BUS_Bill bus_Bill = new BUS_Bill();
        public frmBill()
        {
            InitializeComponent();
            LoadDateTimePicker();
        }
        public void LoadDateTimePicker()
        {
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = dtpStart.Value.AddMonths(1).AddDays(-1);
            dgvBill.DataSource = bus_Bill.getBill(dtpStart.Value, dtpEnd.Value);
            dgvBill.ClearSelection();
        }


        private void btnWatchBill_Click_1(object sender, EventArgs e)
        {
            if (dtpStart.Value > dtpEnd.Value)
            {
                MessageBox.Show("Chọn lại ngày xem hoá đơn hợp lệ");
                dtpStart.Value = dtpEnd.Value;
            }
            else
            {
                dgvBill.DataSource = bus_Bill.getBill(dtpStart.Value, dtpEnd.Value);
                dgvBill.ClearSelection();
            }
        }
        BUS_BillInfoDetails bUS_BillInfoDetails = new BUS_BillInfoDetails();
        private void dgvBill_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBill.SelectedRows.Count > 0)
            {
                dgvBillInfo.DataSource = bUS_BillInfoDetails.GetBillInfoByBillID((int)dgvBill.CurrentRow.Cells[0].Value);
            }
            else
            {
                dgvBillInfo.DataSource = null;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (dgvBill.SelectedRows.Count > 0)
            {

            }
            else
            {
                MessageBox.Show("Không có hoá đơn nào đang được chọn");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (dgvBill.SelectedRows.Count > 0)
            {
                
            }
            else
            {
                MessageBox.Show("Không có hoá đơn nào đang được chọn");
            }
        }
       
    }
}
