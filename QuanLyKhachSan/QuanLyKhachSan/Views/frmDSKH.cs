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
    public partial class frmDSKH : Form
    {
        public frmDSKH(string loaitk, string tentk, string connectionString)
        {
            InitializeComponent();
            this.loaitk = loaitk;
            this.tentk = tentk;
            this.connectionString = connectionString;
        }
        private string loaitk;
        private string tentk;
        private string tukhoa = "";
        private int makh = 0;
        private string connectionString;
        private void frmDSKH_Load(object sender, EventArgs e)
        {
            loadDSKH(tukhoa);
        }
        public void loadDSKH(string tukhoa)
        {
            List<Parameters> para = new List<Parameters>()
            {
                new Parameters()
                {
                     key = "@tukhoa",
                     value = tukhoa
                },
                new Parameters()
                {
                    key= "@loaitk",
                    value = loaitk
                }
            };
            
            dgvDSKH.DataSource = null;
            dgvDSKH.DataSource = new Database(connectionString).SelectData("sp_loadDSKH", para);     
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            this.tukhoa = this.txtTimkiem.Text.Trim();
            loadDSKH(tukhoa);
        }
        private void txtTimkiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.tukhoa = this.txtTimkiem.Text.Trim();
            if (e.KeyChar == 13) loadDSKH(tukhoa);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            frmKH frm = new frmKH(makh, false, tentk, connectionString);
            frm.ShowDialog();
            this.txtTimkiem.Text = "";
            loadDSKH(tukhoa);
        }
        private void dgvDSKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == this.dgvDSKH.Rows.Count - 1)
            {
                return;
            }
            this.makh = int.Parse(this.dgvDSKH.CurrentRow.Cells[0].Value.ToString());
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (this.makh == 0)
            {
                MessageBox.Show("Chọn dòng cần sửa");
                return;
            }
            frmKH frm = new frmKH(makh, true, tentk, connectionString);
            frm.ShowDialog();
            loadDSKH(tukhoa);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (this.makh == 0)
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
                        key = "@makh",
                        value = makh.ToString()
                    }
                };
                var excute = new Database(connectionString).ExCute("sp_xoakh", para);
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
            loadDSKH(tukhoa);
        }
    }
}
