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
    public partial class frmMain : Form
    {
        public frmMain(string loaitk, string tentk, string connectionString)
        {
            InitializeComponent();
            this.loaitk = loaitk;
            this.tentk = tentk;
            this.connectionString = connectionString;
        }
        private string connectionString;
        private string loaitk;
        private string tentk;
        private void frmMain_Load(object sender, EventArgs e)
        {
            //if (loaitk == "admin")
            //{
            //    this.btnDSThue.Visible = false;
            //    this.btnDSTK.Visible = true;
            //    this.btnDSTK.BringToFront();
            //}
            //else if (loaitk == "TN")
            //{
            //    this.btnDSThue.Visible = true;
            //    this.btnDSTK.Visible = false;
            //    this.btnDSThue.BringToFront();
            //}
        }
        private void addForm(Form f)
        {
            f.TopLevel = false;
            f.AutoScroll = true;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(f);

            f.Show();
            f.BringToFront();
        }
        private void btnDSKH_Click(object sender, EventArgs e)
        {
            frmDSKH dskh = new frmDSKH(loaitk,tentk, connectionString);
            addForm(dskh);
        }
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            frmLogin formLogin = new frmLogin();
            formLogin.Show();
            this.Close();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnTTCN_Click(object sender, EventArgs e)
        {
            frmTTCN ttcn = new frmTTCN(tentk, connectionString);
            addForm(ttcn);
        }
        private void btnDSNV_Click(object sender, EventArgs e)
        {
            frmDSNV frm = new frmDSNV(connectionString);
            addForm(frm);
        }
        private void btnDSP_Click(object sender, EventArgs e)
        {
            frmDSP frm = new frmDSP(connectionString,tentk);
            addForm(frm);
        }

        private void btnDSTK_Click(object sender, EventArgs e)
        {
            frmDSTK frm = new frmDSTK(connectionString);
            addForm(frm);
        }

        private void btnDSThue_Click(object sender, EventArgs e)
        {
            frmDSTP frm = new frmDSTP(connectionString,loaitk,tentk);
            addForm(frm);
        }
    }
}
