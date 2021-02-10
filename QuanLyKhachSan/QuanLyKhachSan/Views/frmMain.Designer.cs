namespace QuanLyKhachSan.Views
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnDSTK = new System.Windows.Forms.Button();
            this.btnTTCN = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnDSThue = new System.Windows.Forms.Button();
            this.btnDSP = new System.Windows.Forms.Button();
            this.btnDSNV = new System.Windows.Forms.Button();
            this.btnDSKH = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnDSTK);
            this.splitContainer1.Panel1.Controls.Add(this.btnTTCN);
            this.splitContainer1.Panel1.Controls.Add(this.btnThoat);
            this.splitContainer1.Panel1.Controls.Add(this.btnDangXuat);
            this.splitContainer1.Panel1.Controls.Add(this.btnDSThue);
            this.splitContainer1.Panel1.Controls.Add(this.btnDSP);
            this.splitContainer1.Panel1.Controls.Add(this.btnDSNV);
            this.splitContainer1.Panel1.Controls.Add(this.btnDSKH);
            this.splitContainer1.Size = new System.Drawing.Size(1014, 447);
            this.splitContainer1.SplitterDistance = 251;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnDSTK
            // 
            this.btnDSTK.Location = new System.Drawing.Point(54, 246);
            this.btnDSTK.Name = "btnDSTK";
            this.btnDSTK.Size = new System.Drawing.Size(144, 31);
            this.btnDSTK.TabIndex = 6;
            this.btnDSTK.Text = "Danh sách tài khoản";
            this.btnDSTK.UseVisualStyleBackColor = true;
            this.btnDSTK.Click += new System.EventHandler(this.btnDSTK_Click);
            // 
            // btnTTCN
            // 
            this.btnTTCN.Location = new System.Drawing.Point(54, 300);
            this.btnTTCN.Name = "btnTTCN";
            this.btnTTCN.Size = new System.Drawing.Size(144, 31);
            this.btnTTCN.TabIndex = 7;
            this.btnTTCN.Text = "Thông tin cá nhân";
            this.btnTTCN.UseVisualStyleBackColor = true;
            this.btnTTCN.Click += new System.EventHandler(this.btnTTCN_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(54, 402);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(144, 31);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Location = new System.Drawing.Point(54, 354);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(144, 31);
            this.btnDangXuat.TabIndex = 8;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnDSThue
            // 
            this.btnDSThue.Location = new System.Drawing.Point(54, 191);
            this.btnDSThue.Name = "btnDSThue";
            this.btnDSThue.Size = new System.Drawing.Size(144, 31);
            this.btnDSThue.TabIndex = 6;
            this.btnDSThue.Text = "Danh sách thuê phòng";
            this.btnDSThue.UseVisualStyleBackColor = true;
            this.btnDSThue.Click += new System.EventHandler(this.btnDSThue_Click);
            // 
            // btnDSP
            // 
            this.btnDSP.Location = new System.Drawing.Point(54, 83);
            this.btnDSP.Name = "btnDSP";
            this.btnDSP.Size = new System.Drawing.Size(144, 31);
            this.btnDSP.TabIndex = 3;
            this.btnDSP.Text = "Danh sách phòng";
            this.btnDSP.UseVisualStyleBackColor = true;
            this.btnDSP.Click += new System.EventHandler(this.btnDSP_Click);
            // 
            // btnDSNV
            // 
            this.btnDSNV.Location = new System.Drawing.Point(54, 137);
            this.btnDSNV.Name = "btnDSNV";
            this.btnDSNV.Size = new System.Drawing.Size(144, 31);
            this.btnDSNV.TabIndex = 4;
            this.btnDSNV.Text = "Danh sách nhân viên";
            this.btnDSNV.UseVisualStyleBackColor = true;
            this.btnDSNV.Click += new System.EventHandler(this.btnDSNV_Click);
            // 
            // btnDSKH
            // 
            this.btnDSKH.Location = new System.Drawing.Point(54, 30);
            this.btnDSKH.Name = "btnDSKH";
            this.btnDSKH.Size = new System.Drawing.Size(144, 31);
            this.btnDSKH.TabIndex = 2;
            this.btnDSKH.Text = "Danh sách khách hàng";
            this.btnDSKH.UseVisualStyleBackColor = true;
            this.btnDSKH.Click += new System.EventHandler(this.btnDSKH_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 447);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý khách sạn";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnDSP;
        private System.Windows.Forms.Button btnDSNV;
        private System.Windows.Forms.Button btnDSKH;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnDSThue;
        private System.Windows.Forms.Button btnDSTK;
        private System.Windows.Forms.Button btnTTCN;
        private System.Windows.Forms.Button btnThoat;
    }
}