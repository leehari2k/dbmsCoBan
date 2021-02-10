namespace QuanLyKhachSan.Views
{
    partial class frmDSP
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
            this.rbDaThue = new System.Windows.Forms.RadioButton();
            this.rbtrong = new System.Windows.Forms.RadioButton();
            this.rbtatca = new System.Windows.Forms.RadioButton();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.dgvDSP = new System.Windows.Forms.DataGridView();
            this.btnDat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSP)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnDat);
            this.splitContainer1.Panel1.Controls.Add(this.rbDaThue);
            this.splitContainer1.Panel1.Controls.Add(this.rbtrong);
            this.splitContainer1.Panel1.Controls.Add(this.rbtatca);
            this.splitContainer1.Panel1.Controls.Add(this.btnThem);
            this.splitContainer1.Panel1.Controls.Add(this.btnSua);
            this.splitContainer1.Panel1.Controls.Add(this.btnXoa);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDSP);
            this.splitContainer1.Size = new System.Drawing.Size(714, 478);
            this.splitContainer1.SplitterDistance = 43;
            this.splitContainer1.TabIndex = 2;
            // 
            // rbDaThue
            // 
            this.rbDaThue.AutoSize = true;
            this.rbDaThue.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDaThue.Location = new System.Drawing.Point(575, 11);
            this.rbDaThue.Name = "rbDaThue";
            this.rbDaThue.Size = new System.Drawing.Size(108, 21);
            this.rbDaThue.TabIndex = 7;
            this.rbDaThue.Text = "Đã được thuê";
            this.rbDaThue.UseVisualStyleBackColor = true;
            this.rbDaThue.Click += new System.EventHandler(this.rbDaThue_Click);
            // 
            // rbtrong
            // 
            this.rbtrong.AutoSize = true;
            this.rbtrong.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtrong.Location = new System.Drawing.Point(484, 11);
            this.rbtrong.Name = "rbtrong";
            this.rbtrong.Size = new System.Drawing.Size(60, 21);
            this.rbtrong.TabIndex = 6;
            this.rbtrong.Text = "Trống";
            this.rbtrong.UseVisualStyleBackColor = true;
            this.rbtrong.Click += new System.EventHandler(this.rbtrong_Click);
            // 
            // rbtatca
            // 
            this.rbtatca.AutoSize = true;
            this.rbtatca.Checked = true;
            this.rbtatca.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtatca.Location = new System.Drawing.Point(393, 11);
            this.rbtatca.Name = "rbtatca";
            this.rbtatca.Size = new System.Drawing.Size(64, 21);
            this.rbtatca.TabIndex = 5;
            this.rbtatca.TabStop = true;
            this.rbtatca.Text = "Tất cả";
            this.rbtatca.UseVisualStyleBackColor = true;
            this.rbtatca.Click += new System.EventHandler(this.rbtatca_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(22, 8);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(103, 8);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(184, 8);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // dgvDSP
            // 
            this.dgvDSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDSP.Location = new System.Drawing.Point(0, 0);
            this.dgvDSP.Name = "dgvDSP";
            this.dgvDSP.Size = new System.Drawing.Size(710, 427);
            this.dgvDSP.TabIndex = 0;
            this.dgvDSP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSP_CellClick);
            // 
            // btnDat
            // 
            this.btnDat.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDat.Location = new System.Drawing.Point(265, 8);
            this.btnDat.Name = "btnDat";
            this.btnDat.Size = new System.Drawing.Size(90, 23);
            this.btnDat.TabIndex = 8;
            this.btnDat.Text = "Đặt phòng";
            this.btnDat.UseVisualStyleBackColor = true;
            this.btnDat.Click += new System.EventHandler(this.btnDat_Click);
            // 
            // frmDSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 478);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDSP";
            this.Text = "frmDSP";
            this.Load += new System.EventHandler(this.frmDSP_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridView dgvDSP;
        private System.Windows.Forms.RadioButton rbDaThue;
        private System.Windows.Forms.RadioButton rbtrong;
        private System.Windows.Forms.RadioButton rbtatca;
        private System.Windows.Forms.Button btnDat;
    }
}