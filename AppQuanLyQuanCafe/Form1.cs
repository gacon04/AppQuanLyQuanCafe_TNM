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
using Microsoft.Reporting.WinForms;
namespace AppQuanLyQuanCafe
{
    public partial class Form1 : Form
    {
        BUS_BillInfoDetails bus = new BUS_BillInfoDetails();
        int getidBill;
        string id = "";
        string tenban;
        string ten = "";
        string gia ;
        string giovao;
        string giora;
        string giamgia;

        public Form1(int idBill, string[] s )
        {
            
            InitializeComponent();
            id = s[0];
            this.getidBill = idBill;
            tenban = s[1];
            giovao = s[2];
            giora= s[3];
            ten= s[4];
            giamgia = s[5];
            gia = s[6];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                
                ReportDataSource reportDataSource = new ReportDataSource("DataSet1", bus.GetBillInfoByBillID(getidBill));
                ReportParameterCollection reportParameters = new ReportParameterCollection();
                reportParameters.Add(new ReportParameter("RP1", id));
                reportParameters.Add(new ReportParameter("RP2", tenban));
                reportParameters.Add(new ReportParameter("RP3", giovao));
                reportParameters.Add(new ReportParameter("RP4", giora));
                reportParameters.Add(new ReportParameter("RP5", ten));
                reportParameters.Add(new ReportParameter("RP6", giamgia));
                reportParameters.Add(new ReportParameter("RP7", gia));
                reportViewer1.LocalReport.SetParameters(reportParameters);

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
