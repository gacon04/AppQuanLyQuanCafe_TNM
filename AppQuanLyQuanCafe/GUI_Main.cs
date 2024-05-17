using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

namespace AppQuanLyQuanCafe
{
    public partial class frmMain : Form
    {
        string thisRole = "";
        Timer timer;
        int accountID = -1;
        public frmMain(string role,int accID)
        {
            InitializeComponent();
           
            DateTime currentTime = DateTime.Now;
            thisRole = role;
            if (role == "Member")
            {
                btnAccount.Visible = false; 
            }
            timer = new Timer();
            timer.Interval = 100;

            // Gắn sự kiện Tick của Timer với phương thức xử lý sự kiện Timer_Tick
            timer.Tick += Timer_Tick;
            
            // Bắt đầu Timer
            timer.Start();
            lblDate.Text = currentTime.ToString("dd/MM/yyyy"); 
            OpenChildForm(new frmHome());
            accountID = accID;

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Lấy thời gian đồng hồ hiện tại
            DateTime currentTime = DateTime.Now;

            // Gán thời gian vào một Label có tên là labelClock
            lblHi.Text = currentTime.ToString("HH:mm:ss");
        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
             OpenChildForm(new frmHome());
            lblTenmuc.Text = "TỔNG QUAN";

        }
        private Form currentFormChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null) { 
            currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle=FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelBody.Controls.Add(childForm);
            panelBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btnTableList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTableList(thisRole));
            lblTenmuc.Text = "DANH SÁCH BÀN";
        }
        private void btnBill_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmOrder(accountID));
            lblTenmuc.Text = "BÁN HÀNG";

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMenu(thisRole));
            lblTenmuc.Text = "THỰC ĐƠN";

        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCategory(thisRole));
            lblTenmuc.Text = "DANH MỤC";

        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
         

        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmAccount());
            lblTenmuc.Text = "TÀI KHOẢN";

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thoát phiên đăng nhập này", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {
                frmLogin frm = new frmLogin();
                frm.Show();
                this.Hide();
            }    
            
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void lblPage_Click(object sender, EventArgs e)
        {

        }

        private void panelLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_Top_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit ();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panelBody_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new frmBill(thisRole));
            lblTenmuc.Text = "HOÁ ĐƠN";
        }
    }
}
