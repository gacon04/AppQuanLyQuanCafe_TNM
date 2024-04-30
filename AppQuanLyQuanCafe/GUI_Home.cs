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
namespace AppQuanLyQuanCafe
{
    public partial class frmHome : Form
    {
      //  private frmMain formMainInstance;
        BUS_Home bus_Home = new BUS_Home();
        public frmHome()
        {
            InitializeComponent();
      //      formMainInstance = new frmMain();
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
