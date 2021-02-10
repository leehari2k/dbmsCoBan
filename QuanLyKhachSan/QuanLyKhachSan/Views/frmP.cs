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
    public partial class frmP : Form
    {
        public frmP(string maphong, bool t, string connectionString)
        {
            InitializeComponent();
            this.maphong = maphong;
            this.t = t;
            this.connectionString = connectionString;
        }
        private string connectionString;
        private string maphong;
        private bool t;
        private void frmP_Load(object sender, EventArgs e)
        {
            var loaiphong = new Database(connectionString).Query("Select distinct loaiphong from Phong");
            this.cbbLoaiPhong.DataSource = loaiphong;
            this.cbbLoaiPhong.DisplayMember = "loaiphong";

            var capdo = new Database(connectionString).Query("Select distinct capdo from Phong");
            this.cbbCapdo.DataSource = capdo;
            this.cbbCapdo.DisplayMember = "capdo";

            var tinhtrang = new Database(connectionString).Query("Select distinct tinhtrang from Phong");
            this.cbbTinhtrang.DataSource = tinhtrang;
            this.cbbTinhtrang.DisplayMember = "tinhtrang";

            if (t)
            {
                this.txtMaP.Enabled = false;
                var select = new Database(connectionString).Select("sp_chonphong '" + maphong + "'");
                this.txtMaP.Text = select["maphong"].ToString();
                this.cbbLoaiPhong.Text = select["loaiphong"].ToString();
                this.cbbCapdo.Text = select["capdo"].ToString();
                this.txtGiaPhong.Text = select["giaphong"].ToString();
                this.cbbTinhtrang.Text = select["tinhtrang"].ToString();
            }
            else
            {
                this.txtMaP.Enabled = true;
                this.txtMaP.Text = null;
                this.cbbLoaiPhong.Text = null;
                this.cbbCapdo.Text = null;
                this.txtGiaPhong.Text = null;
                this.cbbTinhtrang.Text = null;
            }
        }
        private void themKh()
        {
            List<Parameters> para = new List<Parameters>()
            {
                 new Parameters()
                {
                    key = "@maphong",
                    value = this.txtMaP.Text.Trim()
                },
                new Parameters()
                {
                    key = "@loaiphong",
                    value= this.cbbLoaiPhong.Text.Trim()
                },
                new Parameters()
                {
                    key = "@capdo",
                    value = this.cbbCapdo.Text.Trim()
                },
                new Parameters()
                {
                    key = "@giaphong",
                    value = this.txtGiaPhong.Text.Trim()
                },
                new Parameters()
                {
                    key=  "@tinhtrang",
                    value = this.cbbTinhtrang.Text.Trim()
                },
            };
            var excute = new Database(connectionString).ExCute("sp_themphong", para);
            if (excute == -1)
            {
                MessageBox.Show("Lỗi");
            }
            else if (excute == 1)
            {
                MessageBox.Show("Thêm thành công");
                this.Close();
            }
        }
        private void suaKh()
        {
            List<Parameters> para = new List<Parameters>()
            {
                new Parameters()
                {
                    key = "@maphong",
                    value = this.txtMaP.Text.Trim()
                },
                new Parameters()
                {
                    key = "@loaiphong",
                    value= this.cbbLoaiPhong.Text.Trim()
                },
                new Parameters()
                {
                    key = "@capdo",
                    value = this.cbbCapdo.Text.Trim()
                },
                new Parameters()
                {
                    key = "@giaphong",
                    value = this.txtGiaPhong.Text.Trim()
                },
                new Parameters()
                {
                    key=  "@tinhtrang",
                    value = this.cbbTinhtrang.Text.Trim()
                },
            };
            var excute = new Database(connectionString).ExCute("sp_suaphong", para);
            if (excute == -1)
            {
                MessageBox.Show("Lỗi");
            }
            else if (excute == 1)
            {
                MessageBox.Show("Sửa thành công");
                this.Close();
            }
        }
        private void txtLuu_Click(object sender, EventArgs e)
        {
            if (t)
                suaKh();
            else
                themKh();
            
        }       
    }
}
