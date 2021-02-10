using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhachSan.Models;

namespace QuanLyKhachSan.Views
{
    public partial class frmDSTK : Form
    {
        public frmDSTK(string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
        }
        private string connectionString;
        private void frmDSTK_Load(object sender, EventArgs e)
        {
            var load = new Database(connectionString).Query("Select * from Taikhoan_view");
            this.dgvDSTK.DataSource = null;
            this.dgvDSTK.DataSource = load;
        }
    }
}
