namespace QuanLyKhachSan.Views
{
    partial class frmDatP
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
            this.txtLuu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbLoaiKh = new System.Windows.Forms.Label();
            this.cbbMakh = new System.Windows.Forms.ComboBox();
            this.lbMaP = new System.Windows.Forms.Label();
            this.lbNgayDat = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtLuu
            // 
            this.txtLuu.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLuu.Location = new System.Drawing.Point(163, 195);
            this.txtLuu.Name = "txtLuu";
            this.txtLuu.Size = new System.Drawing.Size(81, 34);
            this.txtLuu.TabIndex = 24;
            this.txtLuu.Text = "Lưu";
            this.txtLuu.UseVisualStyleBackColor = true;
            this.txtLuu.Click += new System.EventHandler(this.txtLuu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Mã khách hàng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Mã phòng:";
            // 
            // lbLoaiKh
            // 
            this.lbLoaiKh.AutoSize = true;
            this.lbLoaiKh.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoaiKh.Location = new System.Drawing.Point(45, 128);
            this.lbLoaiKh.Name = "lbLoaiKh";
            this.lbLoaiKh.Size = new System.Drawing.Size(66, 17);
            this.lbLoaiKh.TabIndex = 25;
            this.lbLoaiKh.Text = "Ngày đặt:";
            // 
            // cbbMakh
            // 
            this.cbbMakh.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbMakh.FormattingEnabled = true;
            this.cbbMakh.Location = new System.Drawing.Point(163, 50);
            this.cbbMakh.Name = "cbbMakh";
            this.cbbMakh.Size = new System.Drawing.Size(200, 25);
            this.cbbMakh.TabIndex = 26;
            // 
            // lbMaP
            // 
            this.lbMaP.AutoSize = true;
            this.lbMaP.Location = new System.Drawing.Point(160, 97);
            this.lbMaP.Name = "lbMaP";
            this.lbMaP.Size = new System.Drawing.Size(35, 13);
            this.lbMaP.TabIndex = 27;
            this.lbMaP.Text = "label3";
            // 
            // lbNgayDat
            // 
            this.lbNgayDat.AutoSize = true;
            this.lbNgayDat.Location = new System.Drawing.Point(160, 128);
            this.lbNgayDat.Name = "lbNgayDat";
            this.lbNgayDat.Size = new System.Drawing.Size(35, 13);
            this.lbNgayDat.TabIndex = 28;
            this.lbNgayDat.Text = "label4";
            // 
            // frmDatP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 261);
            this.Controls.Add(this.lbNgayDat);
            this.Controls.Add(this.lbMaP);
            this.Controls.Add(this.cbbMakh);
            this.Controls.Add(this.lbLoaiKh);
            this.Controls.Add(this.txtLuu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDatP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đặt phòng";
            this.Load += new System.EventHandler(this.frmDatP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button txtLuu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbLoaiKh;
        private System.Windows.Forms.ComboBox cbbMakh;
        private System.Windows.Forms.Label lbMaP;
        private System.Windows.Forms.Label lbNgayDat;
    }
}