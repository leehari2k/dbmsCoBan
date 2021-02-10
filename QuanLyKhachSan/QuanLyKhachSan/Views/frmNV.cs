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
    public partial class frmNV : Form
    {
        public frmNV(bool t, int manv, string connectionString)
        {
            InitializeComponent();
            this.t = t;
            this.manv = manv;
            this.connectionString = connectionString;
            this.check = new Database(connectionString).ExcuteTran("Select * from Nhanvien");
        }
        private int check;
        private bool t;
        private int manv;
        private string connectionString;
        private void txtLuu_Click(object sender, EventArgs e)
        {
            if (t)
                suanv();
            else
                themnv();          
        }
        private void suanv()
        {
            List<Parameters> para = new List<Parameters>()
            {
                new Parameters()
                {
                    key = "@manv",
                    value = manv.ToString()
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
                    key = "@ten",
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
                    key = "@chucvu",
                    value = this.cbbLoaiNV.Text.Trim()
                }
            };
            var excute = new Database(connectionString).ExCute("sp_suanv", para);
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
        private void themnv()
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
                    key = "@ten",
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
                    key = "@chucvu",
                    value = this.cbbLoaiNV.Text.Trim()
                }
            };
            var excute = new Database(connectionString).ExCute("sp_themnv", para);
            var count = new Database(connectionString).ExcuteTran("Select * from Nhanvien");
            if (count == check)
            {
                MessageBox.Show("Lỗi");
            }
            else
            {
                MessageBox.Show("Thêm thành công");
                this.Close();
            }
        }
        
        private void frmNV_Load(object sender, EventArgs e)
        {           
            this.cbbLoaiNV.DataSource = null;
            List<Parameters> para = new List<Parameters>()
            {
            };
            var loainv = new Database(connectionString).SelectData("sp_loainv", para);
            this.cbbLoaiNV.DataSource = loainv;
            this.cbbLoaiNV.DisplayMember = "chucvu";
            this.cbbLoaiNV.Text = null;

            if (t)
            {
                var select = new Database(connectionString).Select("sp_chonnv '" + manv + "'");
                this.txtHo.Text = select["ho"].ToString();
                this.txtTenlot.Text = select["tenlot"].ToString();
                this.txtTen.Text = select["tennv"].ToString();
                this.txtSdt.Text = select["sdt"].ToString();
                this.dtbNgaySinh.Value = DateTime.Parse(select["ngaysinh"].ToString());
                this.cbbLoaiNV.Text = select["chucvu"].ToString();
            }
            else
            {
                string date = "1/1/2000";
                this.dtbNgaySinh.Value = DateTime.Parse(date);
            }
        }
    }
}
