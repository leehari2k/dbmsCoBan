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
    public partial class frmKH : Form
    {
        public frmKH(int makh, bool t, string manv, string connectionString)
        {
            InitializeComponent();
            this.makh = makh;
            this.t = t;
            this.manv = manv;
            this.connectionString = connectionString;
        }
        private string connectionString;
        private int makh;
        private bool t;
        private string manv;
        private void frmKH_Load(object sender, EventArgs e)
        {            
            if (t)
            {
                this.cbbLoaiKH.Enabled = true;
                this.cbbLoaiKH.DataSource = null;
                List<Parameters> para = new List<Parameters>()
                {
                };
                var loaikh = new Database(connectionString).SelectData("sp_selectLoaikh", para);
                this.cbbLoaiKH.DataSource = loaikh;
                this.cbbLoaiKH.DisplayMember = "loaiKh";

                var select = new Database(connectionString).Select("sp_chonKh '" + makh + "'");
                this.txtHo.Text = select["ho"].ToString();
                this.txtTenlot.Text = select["tenlot"].ToString();
                this.txtTen.Text = select["tenKh"].ToString();
                this.txtSdt.Text = select["sdt"].ToString();
                this.dtbNgaySinh.Value = DateTime.Parse(select["ngaysinh"].ToString());
                this.cbbLoaiKH.Text = select["loaiKh"].ToString();                
            }
            else
            {
                this.cbbLoaiKH.Enabled = false;
                string date = "1/1/2000";
                this.dtbNgaySinh.Value = DateTime.Parse(date);
            }
        }
        private void themKh()
        {
            List<Parameters> para = new List<Parameters>()
            {
                new Parameters()
                {
                    key = "@ho",
                    value= this.txtHo.Text.Trim()
                },
                new Parameters()
                {
                    key = "@tenlot",
                    value = this.txtTenlot.Text.Trim()
                },
                new Parameters()
                {
                    key = "@tenkh",
                    value = this.txtTen.Text.Trim()
                },
                new Parameters()
                {
                    key=  "@sdt",
                    value = this.txtSdt.Text.Trim()
                },
                new Parameters()
                {
                    key = "@ngaysinh",
                    value = this.dtbNgaySinh.Value.ToString("MM/dd/yyyy")
                },
                new Parameters()
                {
                    key = "@mancn",
                    value = manv
                }
            };
            var excute = new Database(connectionString).ExCute("sp_themkh", para);
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
                    key = "@makh",
                    value = makh.ToString()
                },
                new Parameters()
                {
                    key = "@ho",
                    value= this.txtHo.Text.Trim()
                },
                new Parameters()
                {
                    key = "@tenlot",
                    value = this.txtTenlot.Text.Trim()
                },
                new Parameters()
                {
                    key = "@tenkh",
                    value = this.txtTen.Text.Trim()
                },
                new Parameters()
                {
                    key=  "@sdt",
                    value = this.txtSdt.Text.Trim()
                },
                new Parameters()
                {
                    key = "@ngaysinh",
                    value = this.dtbNgaySinh.Value.ToString("MM/dd/yyyy")
                },
                new Parameters()
                {
                    key = "@loaikh",
                    value = this.cbbLoaiKH.Text.Trim()
                },
                new Parameters()
                {
                    key = "@mancn",
                    value = manv
                }
                
            };
            var excute = new Database(connectionString).ExCute("sp_suakh", para);
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
