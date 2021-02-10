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
    public partial class frmDSP : Form
    {
        public frmDSP(string connectionString, string manv)
        {
            InitializeComponent();
            this.connectionString = connectionString;
            this.manv = manv;
        }
        private string connectionString;
        private string tinhtrang = "A";
        private string maphong="";
        private string manv;
        private void frmDSP_Load(object sender, EventArgs e)
        {
            loadDSP();
        }
        private void loadDSP()
        {
            List<Parameters> para = new List<Parameters>();
            para.Add(new Parameters()
            {
                key = "@tinhtrang",
                value = this.tinhtrang.Trim()
            });

            dgvDSP.DataSource = null;
            dgvDSP.DataSource = new Database(connectionString).SelectData("sp_loadDSP", para);
        }
        private void rbtatca_Click(object sender, EventArgs e)
        {
            this.tinhtrang = "A";
            loadDSP();
        }
        private void rbtrong_Click(object sender, EventArgs e)
        {
            this.tinhtrang = "Y";
            loadDSP();
        }
        private void rbDaThue_Click(object sender, EventArgs e)
        {
            this.tinhtrang = "N";
            loadDSP();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            frmP frm = new frmP(maphong,false, connectionString);
            frm.ShowDialog();
            loadDSP();
        }
        private void dgvDSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == this.dgvDSP.Rows.Count - 1)
            {
                return;
            }
            this.maphong = this.dgvDSP.CurrentRow.Cells[1].Value.ToString().Trim();           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (this.maphong == "")
            {
                MessageBox.Show("Chọn dòng cần xóa");
                return;
            }
            DialogResult hoi = MessageBox.Show("Có chắc xóa không", "Cảnh báo", MessageBoxButtons.YesNo);
            if (hoi == DialogResult.Yes)
            {
                List<Parameters> para = new List<Parameters>()
                {
                    new Parameters()
                    {
                        key = "@maphong",
                        value = this.maphong
                    }
                };
                var excute = new Database(connectionString).ExCute("sp_xoaphong", para);
                if (excute == -1)
                {
                    MessageBox.Show("Lỗi");
                }
                else if (excute == 1)
                {
                    MessageBox.Show("Xòa thành công");
                }
            }
            else
                return;
            loadDSP();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (this.maphong == "")
            {
                MessageBox.Show("Chọn dòng cần sửa");
                return;
            }
            frmP frm = new frmP(maphong,true, connectionString);
            frm.ShowDialog();
            loadDSP();
        }

        private void btnDat_Click(object sender, EventArgs e)
        {
            if (this.maphong == "")
            {
                MessageBox.Show("Chọn dòng cần đặt");
                return;
            }
            else
            {
                var check = new Database(connectionString).Function("Select dbo.f_kiemtratrangthai('"+maphong+"')");
                if (check == 1)
                {
                    MessageBox.Show("Phòng đã có người đặt");
                }
                else if (check == 0)
                {
                    frmDatP frm = new frmDatP(maphong, connectionString, manv);
                    frm.ShowDialog();
                    loadDSP();
                }
                else { MessageBox.Show("Lỗi"); }             
            }
            
        }
    }
}
