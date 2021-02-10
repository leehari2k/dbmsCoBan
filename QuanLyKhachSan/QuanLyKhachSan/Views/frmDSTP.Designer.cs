namespace QuanLyKhachSan.Views
{
    partial class frmDSTP
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
            this.rdtatca = new System.Windows.Forms.RadioButton();
            this.rdDatra = new System.Windows.Forms.RadioButton();
            this.rdChuaTra = new System.Windows.Forms.RadioButton();
            this.btnTra = new System.Windows.Forms.Button();
            this.txtTimkiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvDSTP = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSTP)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.rdtatca);
            this.splitContainer1.Panel1.Controls.Add(this.rdDatra);
            this.splitContainer1.Panel1.Controls.Add(this.rdChuaTra);
            this.splitContainer1.Panel1.Controls.Add(this.btnTra);
            this.splitContainer1.Panel1.Controls.Add(this.txtTimkiem);
            this.splitContainer1.Panel1.Controls.Add(this.btnTimKiem);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDSTP);
            this.splitContainer1.Size = new System.Drawing.Size(714, 478);
            this.splitContainer1.SplitterDistance = 53;
            this.splitContainer1.TabIndex = 1;
            // 
            // rdtatca
            // 
            this.rdtatca.AutoSize = true;
            this.rdtatca.Checked = true;
            this.rdtatca.Location = new System.Drawing.Point(262, 19);
            this.rdtatca.Name = "rdtatca";
            this.rdtatca.Size = new System.Drawing.Size(56, 17);
            this.rdtatca.TabIndex = 12;
            this.rdtatca.TabStop = true;
            this.rdtatca.Text = "Tất cả";
            this.rdtatca.UseVisualStyleBackColor = true;
            this.rdtatca.Click += new System.EventHandler(this.rdtatca_Click);
            // 
            // rdDatra
            // 
            this.rdDatra.AutoSize = true;
            this.rdDatra.Location = new System.Drawing.Point(424, 18);
            this.rdDatra.Name = "rdDatra";
            this.rdDatra.Size = new System.Drawing.Size(54, 17);
            this.rdDatra.TabIndex = 11;
            this.rdDatra.Text = "Đã trả";
            this.rdDatra.UseVisualStyleBackColor = true;
            this.rdDatra.Click += new System.EventHandler(this.rdDatra_Click);
            // 
            // rdChuaTra
            // 
            this.rdChuaTra.AutoSize = true;
            this.rdChuaTra.Location = new System.Drawing.Point(333, 19);
            this.rdChuaTra.Name = "rdChuaTra";
            this.rdChuaTra.Size = new System.Drawing.Size(75, 17);
            this.rdChuaTra.TabIndex = 10;
            this.rdChuaTra.Text = "Đang thuê";
            this.rdChuaTra.UseVisualStyleBackColor = true;
            this.rdChuaTra.Click += new System.EventHandler(this.rdChuaTra_Click);
            // 
            // btnTra
            // 
            this.btnTra.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTra.Location = new System.Drawing.Point(10, 11);
            this.btnTra.Name = "btnTra";
            this.btnTra.Size = new System.Drawing.Size(75, 23);
            this.btnTra.TabIndex = 9;
            this.btnTra.Text = "Trả phòng";
            this.btnTra.UseVisualStyleBackColor = true;
            this.btnTra.Click += new System.EventHandler(this.btnTra_Click);
            // 
            // txtTimkiem
            // 
            this.txtTimkiem.Location = new System.Drawing.Point(519, 18);
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.Size = new System.Drawing.Size(100, 20);
            this.txtTimkiem.TabIndex = 6;
            this.txtTimkiem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimkiem_KeyPress);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(625, 16);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 5;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dgvDSTP
            // 
            this.dgvDSTP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSTP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDSTP.Location = new System.Drawing.Point(0, 0);
            this.dgvDSTP.Name = "dgvDSTP";
            this.dgvDSTP.Size = new System.Drawing.Size(710, 417);
            this.dgvDSTP.TabIndex = 0;
            this.dgvDSTP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSTP_CellClick);
            // 
            // frmDSTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 478);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDSTP";
            this.Text = "frmDSTP";
            this.Load += new System.EventHandler(this.frmDSTP_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSTP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnTra;
        private System.Windows.Forms.TextBox txtTimkiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvDSTP;
        private System.Windows.Forms.RadioButton rdtatca;
        private System.Windows.Forms.RadioButton rdDatra;
        private System.Windows.Forms.RadioButton rdChuaTra;
    }
}