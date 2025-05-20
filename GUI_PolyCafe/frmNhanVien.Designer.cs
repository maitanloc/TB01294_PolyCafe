namespace GUI_PolyCafe
{
    partial class frmNhanVien
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
            lblNhanVien = new Label();
            dataGridView1 = new DataGridView();
            txtTimKemNhanVien = new TextBox();
            btnTimKiemNhanVien = new Button();
            groupBox1 = new GroupBox();
            cboTinhTrang = new ComboBox();
            cboVaiTro = new ComboBox();
            txtDiaChi = new TextBox();
            txtMatKhau = new TextBox();
            txtEmail = new TextBox();
            txtHoTen = new TextBox();
            txtMaNV = new TextBox();
            lblTinhTrang = new Label();
            lblVaiTro = new Label();
            lblDiaChi = new Label();
            lblMatKhau = new Label();
            lblEmail = new Label();
            lblHoTen = new Label();
            lblMaNV = new Label();
            lblThongTinNhanVien = new Label();
            btnThemNhanVien = new Button();
            btnSuaNhanVien = new Button();
            btnDanhSachNhanVien = new Button();
            btnXoaNhanVien = new Button();
            btnLamMoiNhanVien = new Button();
            btnThoatNhanVien = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblNhanVien
            // 
            lblNhanVien.AutoSize = true;
            lblNhanVien.Font = new Font("Script MT Bold", 20F);
            lblNhanVien.Location = new Point(12, 9);
            lblNhanVien.Name = "lblNhanVien";
            lblNhanVien.Size = new Size(166, 41);
            lblNhanVien.TabIndex = 0;
            lblNhanVien.Text = "Nhân Viên";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(15, 58);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1108, 253);
            dataGridView1.TabIndex = 1;
            // 
            // txtTimKemNhanVien
            // 
            txtTimKemNhanVien.Location = new Point(769, 25);
            txtTimKemNhanVien.Name = "txtTimKemNhanVien";
            txtTimKemNhanVien.Size = new Size(256, 27);
            txtTimKemNhanVien.TabIndex = 2;
            // 
            // btnTimKiemNhanVien
            // 
            btnTimKiemNhanVien.Location = new Point(1031, 23);
            btnTimKiemNhanVien.Name = "btnTimKiemNhanVien";
            btnTimKiemNhanVien.Size = new Size(92, 27);
            btnTimKiemNhanVien.TabIndex = 3;
            btnTimKiemNhanVien.Text = "Tìm Kiếm";
            btnTimKiemNhanVien.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cboTinhTrang);
            groupBox1.Controls.Add(cboVaiTro);
            groupBox1.Controls.Add(txtDiaChi);
            groupBox1.Controls.Add(txtMatKhau);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtHoTen);
            groupBox1.Controls.Add(txtMaNV);
            groupBox1.Controls.Add(lblTinhTrang);
            groupBox1.Controls.Add(lblVaiTro);
            groupBox1.Controls.Add(lblDiaChi);
            groupBox1.Controls.Add(lblMatKhau);
            groupBox1.Controls.Add(lblEmail);
            groupBox1.Controls.Add(lblHoTen);
            groupBox1.Controls.Add(lblMaNV);
            groupBox1.Location = new Point(21, 369);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1102, 202);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // cboTinhTrang
            // 
            cboTinhTrang.FormattingEnabled = true;
            cboTinhTrang.Location = new Point(667, 135);
            cboTinhTrang.Name = "cboTinhTrang";
            cboTinhTrang.Size = new Size(411, 28);
            cboTinhTrang.TabIndex = 13;
            // 
            // cboVaiTro
            // 
            cboVaiTro.FormattingEnabled = true;
            cboVaiTro.Location = new Point(667, 88);
            cboVaiTro.Name = "cboVaiTro";
            cboVaiTro.Size = new Size(411, 28);
            cboVaiTro.TabIndex = 12;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(667, 31);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(413, 27);
            txtDiaChi.TabIndex = 11;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(98, 157);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(413, 27);
            txtMatKhau.TabIndex = 10;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(98, 114);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(413, 27);
            txtEmail.TabIndex = 9;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(98, 70);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(413, 27);
            txtHoTen.TabIndex = 8;
            // 
            // txtMaNV
            // 
            txtMaNV.Location = new Point(98, 28);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(413, 27);
            txtMaNV.TabIndex = 7;
            // 
            // lblTinhTrang
            // 
            lblTinhTrang.AutoSize = true;
            lblTinhTrang.Location = new Point(583, 143);
            lblTinhTrang.Name = "lblTinhTrang";
            lblTinhTrang.Size = new Size(78, 20);
            lblTinhTrang.TabIndex = 6;
            lblTinhTrang.Text = "Tình Trạng";
            // 
            // lblVaiTro
            // 
            lblVaiTro.AutoSize = true;
            lblVaiTro.Location = new Point(583, 91);
            lblVaiTro.Name = "lblVaiTro";
            lblVaiTro.Size = new Size(54, 20);
            lblVaiTro.TabIndex = 5;
            lblVaiTro.Text = "Vai Trò";
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Location = new Point(583, 31);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(57, 20);
            lblDiaChi.TabIndex = 4;
            lblDiaChi.Text = "Địa Chỉ";
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new Point(28, 160);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(72, 20);
            lblMatKhau.TabIndex = 3;
            lblMatKhau.Text = "Mật Khẩu";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(28, 114);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email";
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(28, 70);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(56, 20);
            lblHoTen.TabIndex = 1;
            lblHoTen.Text = "Họ Tên";
            // 
            // lblMaNV
            // 
            lblMaNV.AutoSize = true;
            lblMaNV.Location = new Point(28, 31);
            lblMaNV.Name = "lblMaNV";
            lblMaNV.Size = new Size(54, 20);
            lblMaNV.TabIndex = 0;
            lblMaNV.Text = "Mã NV";
            // 
            // lblThongTinNhanVien
            // 
            lblThongTinNhanVien.AutoSize = true;
            lblThongTinNhanVien.Font = new Font("Script MT Bold", 20F);
            lblThongTinNhanVien.Location = new Point(21, 325);
            lblThongTinNhanVien.Name = "lblThongTinNhanVien";
            lblThongTinNhanVien.Size = new Size(253, 41);
            lblThongTinNhanVien.TabIndex = 5;
            lblThongTinNhanVien.Text = "Nhập Thông Tin";
            // 
            // btnThemNhanVien
            // 
            btnThemNhanVien.Location = new Point(21, 577);
            btnThemNhanVien.Name = "btnThemNhanVien";
            btnThemNhanVien.Size = new Size(157, 72);
            btnThemNhanVien.TabIndex = 6;
            btnThemNhanVien.Text = "Thêm";
            btnThemNhanVien.UseVisualStyleBackColor = true;
            // 
            // btnSuaNhanVien
            // 
            btnSuaNhanVien.Location = new Point(207, 577);
            btnSuaNhanVien.Name = "btnSuaNhanVien";
            btnSuaNhanVien.Size = new Size(142, 72);
            btnSuaNhanVien.TabIndex = 7;
            btnSuaNhanVien.Text = "Sửa";
            btnSuaNhanVien.UseVisualStyleBackColor = true;
            // 
            // btnDanhSachNhanVien
            // 
            btnDanhSachNhanVien.Location = new Point(388, 577);
            btnDanhSachNhanVien.Name = "btnDanhSachNhanVien";
            btnDanhSachNhanVien.Size = new Size(144, 72);
            btnDanhSachNhanVien.TabIndex = 8;
            btnDanhSachNhanVien.Text = "Danh Sách";
            btnDanhSachNhanVien.UseVisualStyleBackColor = true;
            // 
            // btnXoaNhanVien
            // 
            btnXoaNhanVien.Location = new Point(594, 577);
            btnXoaNhanVien.Name = "btnXoaNhanVien";
            btnXoaNhanVien.Size = new Size(150, 72);
            btnXoaNhanVien.TabIndex = 9;
            btnXoaNhanVien.Text = "Xóa";
            btnXoaNhanVien.UseVisualStyleBackColor = true;
            // 
            // btnLamMoiNhanVien
            // 
            btnLamMoiNhanVien.Location = new Point(785, 577);
            btnLamMoiNhanVien.Name = "btnLamMoiNhanVien";
            btnLamMoiNhanVien.Size = new Size(144, 72);
            btnLamMoiNhanVien.TabIndex = 10;
            btnLamMoiNhanVien.Text = "Làm Mới";
            btnLamMoiNhanVien.UseVisualStyleBackColor = true;
            // 
            // btnThoatNhanVien
            // 
            btnThoatNhanVien.Location = new Point(975, 577);
            btnThoatNhanVien.Name = "btnThoatNhanVien";
            btnThoatNhanVien.Size = new Size(148, 72);
            btnThoatNhanVien.TabIndex = 11;
            btnThoatNhanVien.Text = "Thoát";
            btnThoatNhanVien.UseVisualStyleBackColor = true;
            // 
            // frmNhanVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1145, 691);
            Controls.Add(btnThoatNhanVien);
            Controls.Add(btnLamMoiNhanVien);
            Controls.Add(btnXoaNhanVien);
            Controls.Add(btnDanhSachNhanVien);
            Controls.Add(btnSuaNhanVien);
            Controls.Add(btnThemNhanVien);
            Controls.Add(lblThongTinNhanVien);
            Controls.Add(groupBox1);
            Controls.Add(btnTimKiemNhanVien);
            Controls.Add(txtTimKemNhanVien);
            Controls.Add(dataGridView1);
            Controls.Add(lblNhanVien);
            DoubleBuffered = true;
            Name = "frmNhanVien";
            Text = "frmNhanVien";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNhanVien;
        private DataGridView dataGridView1;
        private TextBox txtTimKemNhanVien;
        private Button btnTimKiemNhanVien;
        private GroupBox groupBox1;
        private Label lblThongTinNhanVien;
        private ComboBox cboTinhTrang;
        private ComboBox cboVaiTro;
        private TextBox txtDiaChi;
        private TextBox txtMatKhau;
        private TextBox txtEmail;
        private TextBox txtHoTen;
        private TextBox txtMaNV;
        private Label lblTinhTrang;
        private Label lblVaiTro;
        private Label lblDiaChi;
        private Label lblMatKhau;
        private Label lblEmail;
        private Label lblHoTen;
        private Label lblMaNV;
        private Button btnThemNhanVien;
        private Button btnSuaNhanVien;
        private Button btnDanhSachNhanVien;
        private Button btnXoaNhanVien;
        private Button btnLamMoiNhanVien;
        private Button btnThoatNhanVien;
    }
}