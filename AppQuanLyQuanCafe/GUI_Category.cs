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
    public partial class frmCategory : Form
    {
        BUS_Category bUS_Category = new BUS_Category();
        public frmCategory(string role)
        {
            InitializeComponent();
            if (role=="Member")
            {
                btnAdd.Visible = false;
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
            }    
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            dgvCategory.DataSource = bUS_Category.getCategoryTable();
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }
    }
}
