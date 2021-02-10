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
    public partial class frmDSTP : Form
    {
        public frmDSTP(string connectionString, string loaitk, string manv)
        {
            InitializeComponent();
            this.connectionString = connectionString;
            this.loaitk = loaitk;
            this.manv = manv;
        }
        private string connectionString;
        private string loaitk;
        private string manv;
        private string tinhtrang = "A";
        private string maphong = "";
        private string mathue = "";
        private void frmDSTP_Load(object sender, EventArgs e)
        {
            loadDS();
        }
        private void loadDS()
        {
            List<Parameters> para = new List<Parameters>()
            {
                new Parameters()
                {
                    key = "@tukhoa",
                    value = this.txtTimkiem.Text.Trim()
                },
                 new Parameters()
                {
                    key = "@loaitk",
                    value = this.loaitk
                },
                new Parameters()
                {
                    key = "@trangthai",
                    value = this.tinhtrang.Trim()
                }
               
            };
            var load = new Database(connectionString).SelectData("sp_loadDSTP", para);
            this.dgvDSTP.DataSource = null;
            this.dgvDSTP.DataSource = load;
        }

        private void rdtatca_Click(object sender, EventArgs e)
        {
            this.tinhtrang = "A";
            loadDS();           
        }

        private void rdChuaTra_Click(object sender, EventArgs e)
        {
            this.tinhtrang = "N";
            loadDS();
            
        }

        private void rdDatra_Click(object sender, EventArgs e)
        {
            
            this.tinhtrang = "Y";
            loadDS();
        }

        private void txtTimkiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) loadDS();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            loadDS();
        }

        private void btnTra_Click(object sender, EventArgs e)
        {
            if (mathue == "" || maphong == "")
            {
                MessageBox.Show("Chọn dòng");
            }
            else
            {
                List<Parameters> para = new List<Parameters>()
                {
                    new Parameters()
                    {
                        key = "@maphong",
                        value = maphong
                    },
                    new Parameters()
                    {
                        key = "@maThue",
                        value = mathue
                    },
                    new Parameters()
                    {
                        key = "@mancc",
                        value = manv
                    }
                };

                var traphong = new Database(connectionString).ExCute("sp_traphong", para);
                if (traphong == -1)
                {
                    MessageBox.Show("Lỗi");
                }
                else
                {
                    MessageBox.Show("Đã trả");
                    loadDS();
                }
            }
        }
        private void dgvDSTP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == this.dgvDSTP.Rows.Count - 1)
            {
                return;
            }
            this.maphong = this.dgvDSTP.CurrentRow.Cells[0].Value.ToString().Trim();
            this.mathue = this.dgvDSTP.CurrentRow.Cells[8].Value.ToString().Trim();
        }
    }
}
