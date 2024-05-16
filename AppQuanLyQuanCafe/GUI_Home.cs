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
using BUS;
using System.Security.Cryptography;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
namespace AppQuanLyQuanCafe
{
    public partial class frmHome : Form
    {
        BUS_Bill bUS_Bill = new BUS_Bill();
        //  private frmMain formMainInstance;
        BUS_Home bus_Home = new BUS_Home();
        Func<ChartPoint, string> labelPoint = chartpoint => string.Format("{0} {1:P}", chartpoint.Y, chartpoint.Participation);

        public frmHome()
        {
            InitializeComponent();
            //      formMainInstance = new frmMain();
            dgvRevueneHome.DataSource = bUS_Bill.GetRevueneByCategory();
            SeriesCollection series = new SeriesCollection();
            foreach (DataRow row in ((DataTable)dgvRevueneHome.DataSource).Rows)
            {
                series.Add(new PieSeries { Title = row["Danh mục"].ToString(), Values = new ChartValues<decimal> { Convert.ToDecimal(row["Doanh thu"]) }, DataLabels = true, LabelPoint = labelPoint });
            }
            pieChart1.Series = series;
            pieChart1.LegendLocation = LegendLocation.Bottom;
        }
        
        private void frmHome_Load(object sender, EventArgs e)
        {
            xuLySoLieuCucBo();
        }
        public void xuLySoLieuCucBo()
        {
            DateTime dateTime = DateTime.Now;
            lblTieude.Text += "tháng "+dateTime.Month.ToString()+ "/"+dateTime.Year.ToString();
            lblCountAdmin.Text = bus_Home.processLblCountAdmin()+"";
            lblCountMem.Text = bus_Home.processLblCountMember()+"";
        }
        private void btnDetails_Click(object sender, EventArgs e)
        {
            
        }
    }
}
