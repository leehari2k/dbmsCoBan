using QuanLyKhachSan.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.Views
{
    public partial class frmTTCN : Form
    {
        public frmTTCN(string tentk, string connectionString)
        {
            InitializeComponent();
            this.tentk = tentk;
            this.connectionString = connectionString;
        }
        private string tentk;
        private string connectionString;
        private void frmTTCN_Load(object sender, EventArgs e)
        {
            var result = new Database(connectionString).Select("sp_thongtincn '" +tentk+"'");

            this.lbTen.Text = result["hovaten"].ToString();
            this.lbNgaySinh.Text = result["ngaysinh"].ToString();
            this.lbsdt.Text = result["sdt"].ToString();
            this.lbChucVu.Text = result["chucvu"].ToString();
        }
    }
}
