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
    public partial class frmDatP : Form
    {
        public frmDatP(string maphong, string connnectionString, string manv)
        {
            InitializeComponent();
            this.maphong = maphong;
            this.connectionString = connnectionString;
            this.manv = manv;
        }
        private string maphong;
        private string manv;
        private string connectionString;
        private void txtLuu_Click(object sender, EventArgs e)
        {
            List<Parameters> para = new List<Parameters>()
            {
                new Parameters()
                {
                    key = "@maphong",
                    value = this.maphong
                },
                new Parameters()
                {
                    key = "@makh",
                    value = this.cbbMakh.Text.Trim()                   
                },
                new Parameters()
                {
                    key = "@mancc",
                    value = this.manv
                }
            };
            var datphong = new Database(connectionString).ExCute("sp_datphong", para);
            if (datphong == -1)
            {
                MessageBox.Show("Lỗi");
            }
            else if (datphong == 2)
            {
                MessageBox.Show("Đã đặt phòng");
                this.Close();
            }
        }

        private void frmDatP_Load(object sender, EventArgs e)
        {
            var cbb = new Database(connectionString).Query("Select distinct maKh from Khachhang");
            this.cbbMakh.DataSource = null;
            this.cbbMakh.DataSource = cbb;
            this.cbbMakh.DisplayMember = "maKh";
            this.cbbMakh.Text = null;

            this.lbMaP.Text = this.maphong;
            this.lbNgayDat.Text = DateTime.Now.ToString();
        }
    }
}
