using QuanLyKhachSan.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.Views
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.ActiveControl = this.txtTaiKhoan;
        }
        #region connect
        private string loaitk;
        private string tentk;
        private string connectionString;
        private string connectionString1 = @"Persist Security Info=False;User ID=admin;Password=1234;Initial Catalog=CKDBMS;Data Source= DESKTOP-CBH7IMS;";
        private string connectionString2 = @"Persist Security Info=False;User ID=thungan;Password=1234;Initial Catalog=CKDBMS;Data Source= DESKTOP-CBH7IMS;";
        #endregion
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            dangNhap();
        }
        private void dangNhap()
        {
            if (this.radioButton1.Checked)
            {
                loaitk = "admin";
                connectionString = connectionString1;
            } 
            else if (this.radioButton2.Checked)
            {
                loaitk = "TN";
                connectionString = connectionString2;
            } 

            if (this.txtMatKhau.Text == "" || this.txtMatKhau.Text == null || this.txtTaiKhoan.Text == null || this.txtTaiKhoan.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            this.tentk = this.txtTaiKhoan.Text.Trim();

            var dangnhap = new Database(connectionString1).Function("Select dbo.f_dangnhap('" + tentk +"','" + this.txtMatKhau.Text.Trim() + "','" + loaitk + "')");
            if (dangnhap == 1)
            {
                this.Hide();
                frmMain frm = new frmMain(loaitk, tentk, connectionString);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác");
            }
        }
        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) dangNhap();
        }
        private void txtTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) dangNhap();
        }
        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            //conn = new SqlConnection(connectionString);
        }
    }
}
