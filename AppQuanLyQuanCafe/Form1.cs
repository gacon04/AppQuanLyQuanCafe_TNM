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
    public partial class frmMain : Form
    {
        Timer timer;
        public frmMain()
        {
            InitializeComponent();
            this.Size = new Size(1536, 863);
            DateTime currentTime = DateTime.Now;
            timer = new Timer();
            timer.Interval = 1000;

            // Gắn sự kiện Tick của Timer với phương thức xử lý sự kiện Timer_Tick
            timer.Tick += Timer_Tick;

            // Bắt đầu Timer
            timer.Start();

           
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Lấy thời gian đồng hồ hiện tại
            DateTime currentTime = DateTime.Now;

            // Gán thời gian vào một Label có tên là labelClock
            lblHi.Text = " Hế nhô, hiện tại là: " + currentTime.ToString("HH:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }
    }
}
