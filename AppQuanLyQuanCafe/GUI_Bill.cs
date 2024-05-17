using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;
using System.Windows.Media.Media3D;
namespace AppQuanLyQuanCafe
{
    public partial class frmBill : Form
    {
        BUS_Bill bus_Bill = new BUS_Bill();
        public frmBill(string role)
        {
            InitializeComponent();
            LoadDateTimePicker();
            if (role == "Member")
            {
                btnDeleteBill.Enabled = false;
            }    
            btnPrint.Enabled = false;
            btnExcelExport.Enabled = false;
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
                btnExcelExport.Enabled = true;
                btnPrint.Enabled = true;
            }
            else
            {
                dgvBillInfo.DataSource = null;
                btnExcelExport.Enabled = false;
                btnPrint.Enabled = false;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (dgvBill.SelectedRows.Count > 0)
            {
                if (!bus_Bill.deleteBill((int)dgvBill.CurrentRow.Cells[0].Value))
                        {
                    MessageBox.Show("Xoá hoá đơn không thành công");
                }
                else
                {
                    MessageBox.Show("Xoá thành công");
                }
                dgvBill.DataSource = bus_Bill.getBill(dtpStart.Value,dtpEnd.Value);
                dgvBill.ClearSelection();
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
                
                Form1 form1 = new Form1((int)dgvBill.CurrentRow.Cells[0].Value);
                form1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không có hoá đơn nào đang được chọn");
            }
        }
        public void ExportExcel(DataGridView g,string duongDan,string tenFile)
        {
            try
            {
                app obj = new app();
                obj.Application.Workbooks.Add(Type.Missing);
                obj.Columns.ColumnWidth = 40;
                for (int i=1;i<=g.Columns.Count;i++)
                {
                    obj.Cells[1, i] = g.Columns[i - 1].HeaderText;
                }    
                for (int i=0;i<g.Rows.Count;i++)
                {
                    for (int j=0;j<g.Columns.Count;j++)
                    {
                        if (g.Rows[i].Cells[j].Value!=null)
                        {
                            obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString();
                        }    
                    }    
                }
                obj.ActiveWorkbook.SaveCopyAs(duongDan + tenFile + ".xlsx");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xuất excel không thành công");
            }
        }
        public static int  c=0;
        private void btnExportExcel_Click_1(object sender, EventArgs e)
        {
            if (dgvBill.SelectedRows.Count > 0)
            {
                ExportExcel(dgvBillInfo, @"D:\", "hoadonchitiet" + c.ToString());
                c++;
                MessageBox.Show("Xuất excel thành công");
            }
            
        }
    }
}
