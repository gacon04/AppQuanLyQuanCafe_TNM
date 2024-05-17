using BUS;
using Microsoft.Reporting.WinForms;
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
    public partial class Form1 : Form
    {
        BUS_BillInfoDetails bus = new BUS_BillInfoDetails();
        int idBill=0;
        string tenban;
        string ten = "";
        decimal gia ;
        string giovao;
        string giora;
        decimal giamgia;

        public Form1(int idBill )
        {
            InitializeComponent();
            this.idBill = idBill;
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                
                ReportDataSource reportDataSource = new ReportDataSource("DataSet1", bus.GetBillInfoByBillID(idBill));

                // Thêm ReportDataSource vào ReportViewer
                this.reportViewer1.LocalReport.DataSources.Clear(); // Xóa các nguồn dữ liệu hiện có
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource); // Thêm ReportDataSource mới

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
               
            }

            this.reportViewer1.RefreshReport();
        }
    }
}
