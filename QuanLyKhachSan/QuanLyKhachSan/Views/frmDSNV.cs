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
    public partial class frmDSNV : Form
    {
        public frmDSNV(string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
        }
        private string connectionString;
        private int manv = 0;
        private void frmDSNV_Load(object sender, EventArgs e)
        {
            loadds();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (this.manv == 0)
            {
                MessageBox.Show("Chọn dòng cần sửa");
                return;
            }
            frmNV frm = new frmNV(true, manv, connectionString);
            frm.ShowDialog();
            loadds();
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            loadds();
        }
        private void loadds()
        {
            List<Parameters> para = new List<Parameters>()
            {
                new Parameters()
                {
                    key = "@tukhoa",
                    value = this.txtTimkiem.Text.Trim()
                }
            };
            var load = new Database(connectionString).SelectData("sp_loadnv", para);
            this.dgvDSNV.DataSource = null;
            this.dgvDSNV.DataSource = load;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            frmNV frm = new frmNV(false, manv, connectionString);
            frm.ShowDialog();
            this.txtTimkiem.Text = "";
            loadds();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (this.manv == 0)
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
                        key = "@manv",
                        value = manv.ToString()
                    }
                };
                var excute = new Database(connectionString).ExCute("sp_xoanv", para);
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
            loadds();
        }
        private void dgvDSNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == this.dgvDSNV.Rows.Count - 1)
            {
                return;
            }
            this.manv = int.Parse(this.dgvDSNV.CurrentRow.Cells[0].Value.ToString());
        }
        private void txtTimkiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) loadds();
        }
    }
}
