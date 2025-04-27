namespace BTL_GK.Views
{
    partial class ThongKe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThongKe));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvThongKeSanPham = new System.Windows.Forms.DataGridView();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongSoLuongBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnChucNang2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnConIt = new System.Windows.Forms.RadioButton();
            this.rbtnTonNhieuNhat = new System.Windows.Forms.RadioButton();
            this.rbtnBanChayNhat = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.pnChucNang = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpNgay2 = new System.Windows.Forms.DateTimePicker();
            this.lblDoanhThu = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTuyChonTK = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXemKetQua = new System.Windows.Forms.Button();
            this.btnLoc = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeSanPham)).BeginInit();
            this.pnChucNang2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnChucNang.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvThongKeSanPham);
            this.panel1.Controls.Add(this.pnChucNang2);
            this.panel1.Controls.Add(this.pnChucNang);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 405);
            this.panel1.TabIndex = 0;
            // 
            // dgvThongKeSanPham
            // 
            this.dgvThongKeSanPham.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvThongKeSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKeSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSP,
            this.TenSP,
            this.SoLuong,
            this.TongSoLuongBan});
            this.dgvThongKeSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThongKeSanPham.GridColor = System.Drawing.Color.Gray;
            this.dgvThongKeSanPham.Location = new System.Drawing.Point(0, 244);
            this.dgvThongKeSanPham.Name = "dgvThongKeSanPham";
            this.dgvThongKeSanPham.RowHeadersWidth = 62;
            this.dgvThongKeSanPham.Size = new System.Drawing.Size(584, 161);
            this.dgvThongKeSanPham.TabIndex = 5;
            // 
            // MaSP
            // 
            this.MaSP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaSP.DataPropertyName = "MaSP";
            this.MaSP.HeaderText = "Mã sản phẩm";
            this.MaSP.MinimumWidth = 8;
            this.MaSP.Name = "MaSP";
            this.MaSP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // TenSP
            // 
            this.TenSP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenSP.DataPropertyName = "TenSP";
            this.TenSP.HeaderText = "Tên sản phẩm";
            this.TenSP.MinimumWidth = 8;
            this.TenSP.Name = "TenSP";
            // 
            // SoLuong
            // 
            this.SoLuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.MinimumWidth = 8;
            this.SoLuong.Name = "SoLuong";
            // 
            // TongSoLuongBan
            // 
            this.TongSoLuongBan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TongSoLuongBan.DataPropertyName = "TongSoLuongBan";
            this.TongSoLuongBan.HeaderText = "Tổng lượng bán ";
            this.TongSoLuongBan.MinimumWidth = 8;
            this.TongSoLuongBan.Name = "TongSoLuongBan";
            // 
            // pnChucNang2
            // 
            this.pnChucNang2.Controls.Add(this.groupBox2);
            this.pnChucNang2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnChucNang2.Location = new System.Drawing.Point(0, 134);
            this.pnChucNang2.Name = "pnChucNang2";
            this.pnChucNang2.Size = new System.Drawing.Size(584, 110);
            this.pnChucNang2.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnConIt);
            this.groupBox2.Controls.Add(this.rbtnTonNhieuNhat);
            this.groupBox2.Controls.Add(this.rbtnBanChayNhat);
            this.groupBox2.Controls.Add(this.btnXemKetQua);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(584, 110);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lọc sản phẩm";
            // 
            // rbtnConIt
            // 
            this.rbtnConIt.AutoSize = true;
            this.rbtnConIt.Location = new System.Drawing.Point(104, 82);
            this.rbtnConIt.Name = "rbtnConIt";
            this.rbtnConIt.Size = new System.Drawing.Size(192, 21);
            this.rbtnConIt.TabIndex = 7;
            this.rbtnConIt.TabStop = true;
            this.rbtnConIt.Text = "Sản phẩm còn ít trong kho";
            this.rbtnConIt.UseVisualStyleBackColor = true;
            // 
            // rbtnTonNhieuNhat
            // 
            this.rbtnTonNhieuNhat.AutoSize = true;
            this.rbtnTonNhieuNhat.Location = new System.Drawing.Point(104, 52);
            this.rbtnTonNhieuNhat.Name = "rbtnTonNhieuNhat";
            this.rbtnTonNhieuNhat.Size = new System.Drawing.Size(212, 21);
            this.rbtnTonNhieuNhat.TabIndex = 6;
            this.rbtnTonNhieuNhat.TabStop = true;
            this.rbtnTonNhieuNhat.Text = "Sản phẩm còn tồn nhiều nhất";
            this.rbtnTonNhieuNhat.UseVisualStyleBackColor = true;
            // 
            // rbtnBanChayNhat
            // 
            this.rbtnBanChayNhat.AutoSize = true;
            this.rbtnBanChayNhat.Location = new System.Drawing.Point(104, 19);
            this.rbtnBanChayNhat.Name = "rbtnBanChayNhat";
            this.rbtnBanChayNhat.Size = new System.Drawing.Size(181, 21);
            this.rbtnBanChayNhat.TabIndex = 5;
            this.rbtnBanChayNhat.TabStop = true;
            this.rbtnBanChayNhat.Text = "Số lượng bán nhiều nhất";
            this.rbtnBanChayNhat.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Xem theo:";
            // 
            // pnChucNang
            // 
            this.pnChucNang.Controls.Add(this.groupBox1);
            this.pnChucNang.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnChucNang.Location = new System.Drawing.Point(0, 35);
            this.pnChucNang.Name = "pnChucNang";
            this.pnChucNang.Size = new System.Drawing.Size(584, 99);
            this.pnChucNang.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpNgay2);
            this.groupBox1.Controls.Add(this.lblDoanhThu);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnLoc);
            this.groupBox1.Controls.Add(this.cboTuyChonTK);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpNgay);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 99);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống kê doanh thu";
            // 
            // dtpNgay2
            // 
            this.dtpNgay2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgay2.Location = new System.Drawing.Point(249, 63);
            this.dtpNgay2.Name = "dtpNgay2";
            this.dtpNgay2.Size = new System.Drawing.Size(119, 23);
            this.dtpNgay2.TabIndex = 6;
            // 
            // lblDoanhThu
            // 
            this.lblDoanhThu.Location = new System.Drawing.Point(449, 68);
            this.lblDoanhThu.Name = "lblDoanhThu";
            this.lblDoanhThu.Size = new System.Drawing.Size(135, 17);
            this.lblDoanhThu.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(374, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Doanh thu:";
            // 
            // cboTuyChonTK
            // 
            this.cboTuyChonTK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTuyChonTK.FormattingEnabled = true;
            this.cboTuyChonTK.Items.AddRange(new object[] {
            "Theo ngày",
            "Theo tháng",
            "Theo năm",
            "Nhiều ngày"});
            this.cboTuyChonTK.Location = new System.Drawing.Point(113, 26);
            this.cboTuyChonTK.Name = "cboTuyChonTK";
            this.cboTuyChonTK.Size = new System.Drawing.Size(121, 24);
            this.cboTuyChonTK.TabIndex = 0;
            this.cboTuyChonTK.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Thống kê theo:";
            // 
            // dtpNgay
            // 
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgay.Location = new System.Drawing.Point(113, 63);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(119, 23);
            this.dtpNgay.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(584, 35);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(183, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thống kê doanh thu";
            // 
            // btnXemKetQua
            // 
            this.btnXemKetQua.Image = ((System.Drawing.Image)(resources.GetObject("btnXemKetQua.Image")));
            this.btnXemKetQua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemKetQua.Location = new System.Drawing.Point(367, 52);
            this.btnXemKetQua.Name = "btnXemKetQua";
            this.btnXemKetQua.Size = new System.Drawing.Size(129, 41);
            this.btnXemKetQua.TabIndex = 4;
            this.btnXemKetQua.Text = "Xem kết quả";
            this.btnXemKetQua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXemKetQua.UseVisualStyleBackColor = true;
            this.btnXemKetQua.Click += new System.EventHandler(this.btnXemKetQua_Click);
            // 
            // btnLoc
            // 
            this.btnLoc.Image = ((System.Drawing.Image)(resources.GetObject("btnLoc.Image")));
            this.btnLoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoc.Location = new System.Drawing.Point(259, 22);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(75, 33);
            this.btnLoc.TabIndex = 3;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 405);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ThongKe";
            this.Text = "ThongKe";
            this.Load += new System.EventHandler(this.ThongKe_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeSanPham)).EndInit();
            this.pnChucNang2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnChucNang.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboTuyChonTK;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnChucNang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Panel pnChucNang2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnXemKetQua;
        private System.Windows.Forms.Label lblDoanhThu;
        private System.Windows.Forms.RadioButton rbtnTonNhieuNhat;
        private System.Windows.Forms.RadioButton rbtnBanChayNhat;
        private System.Windows.Forms.DataGridView dgvThongKeSanPham;
        private System.Windows.Forms.RadioButton rbtnConIt;
        private System.Windows.Forms.DateTimePicker dtpNgay2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongSoLuongBan;
    }
}