using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_PolyCafe;
using DAL_PolyCafe;
using DTO_PolyCafe;

namespace GUI_PolyCafe
{
    public partial class frmChiTietPhieu : Form
    {
        private TheLuuDong theLuuDong;
        private PhieuBanHang phieuBanHang;
        private NhanVien nhanVien;
        private List<ChiTietPhieu> lstChiTiet;
        private List<SanPham> lstSanPham;
        bool isActive = true;
        public frmChiTietPhieu(TheLuuDong the, PhieuBanHang phieu, NhanVien nv)
        {
            InitializeComponent();
            theLuuDong = the;
            phieuBanHang = phieu;
            nhanVien = nv;
            lstChiTiet = new List<ChiTietPhieu>();
            lstSanPham = new List<SanPham>();
            isActive = phieu.TrangThai;
        }
        private void activeTranfer()
        {
            if (!isActive)    // đảo điều kiện
            {
                btnThemChiTiet.Enabled = true;
                btnXoaChiTiet.Enabled = true;
                txtPhanTram.Enabled = true;
            }
            else
            {
                txtPhanTram.Enabled = false;
                btnThemChiTiet.Enabled = false;
                btnXoaChiTiet.Enabled = false;
            }
        }

        private void LoadInfo()
        {
            lblTenChuSoHuu.Text = $"{theLuuDong.MaThe} - {theLuuDong.ChuSoHuu}";
            lblSoMaPhieu.Text = phieuBanHang.MaPhieu;
            lblVaoNgayLap.Text = phieuBanHang.NgayTao.ToString("dd/MM/yyyy");
        }


        private void dgvPhieuBanHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmChiTietPhieu_Load(object sender, EventArgs e)
        {
            loadThanhToan();
            LoadInfo();
            loadSanPham();
            loadChiTietPhieu(phieuBanHang.MaPhieu);
            activeTranfer();
            txtPhanTram.TextChanged += RecalculateDiscountAndTotal;
            txtDichVu.TextChanged += RecalculateDiscountAndTotal;
        }
        // 2. Hàm tính lại
        private void RecalculateDiscountAndTotal(object sender, EventArgs e)
        {
            // Lấy tổng tiền đã có (giả sử đã lưu vào biến hoặc txtTong)
            if (!decimal.TryParse(txtTong.Text, out decimal total))
                return;

            // Đọc giá trị dịch vụ
            decimal dichVu = 0;
            decimal.TryParse(txtDichVu.Text, out dichVu);

            // Đọc phần trăm giảm giá
            decimal phanTram = 0;
            decimal.TryParse(txtPhanTram.Text, out phanTram);

            // Tính tiền giảm
            decimal giamGia = total * phanTram / 100;
            txtGiamGia.Text = giamGia.ToString("N0");

            // Tính thành tiền: tổng + dịch vụ – giảm giá
            decimal thanhTien = total + dichVu - giamGia;
            txtThanhTien.Text = thanhTien.ToString("N0");
        }
        private void loadSanPham()
        {
            BUSSanPham sp = new BUSSanPham();
            lstSanPham = sp.GetSanPhamList(1);
            dgvSanPham.DataSource = lstSanPham;
            dgvSanPham.Columns["MaSanPham"].HeaderText = "Mã Sản Phẩm";
            dgvSanPham.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
            dgvSanPham.Columns["DonGia"].HeaderText = "Đơn Gía";
            dgvSanPham.Columns["TenLoai"].HeaderText = "Loại Sản Phẩm";
            dgvSanPham.Columns["HinhAnh"].HeaderText = "Hình Ảnh";


            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void loadChiTietPhieu(string maPhieu)
        {
            BUSChiTietPhieu bus = new BUSChiTietPhieu();
            lstChiTiet = bus.GetChiTietPhieuList(maPhieu);
            dgvPhieuBanHang.DataSource = lstChiTiet;
            dgvPhieuBanHang.Columns["MaChiTiet"].Visible = false;
            dgvPhieuBanHang.Columns["MaPhieu"].Visible = false;
            dgvPhieuBanHang.Columns["MaSanPham"].Visible = false;
            dgvPhieuBanHang.Columns["TenSanPham"].HeaderText = "Sản Phẩm";
            dgvPhieuBanHang.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgvPhieuBanHang.Columns["DonGia"].HeaderText = "Đơn Giá";
            dgvPhieuBanHang.Columns["ThanhTien"].HeaderText = "Thành Tiền";
            dgvPhieuBanHang.Columns["SoLuong"].ReadOnly = false;

            dgvPhieuBanHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn col in dgvPhieuBanHang.Columns)
            {
                col.ReadOnly = true;
            }
            dgvPhieuBanHang.Columns["SoLuong"].ReadOnly = false;
        }

        private void dgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isActive)
            {
                return;
            }
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];

                // Tạo đối tượng từ dữ liệu hàng
                SanPham sanPham = new SanPham
                {
                    MaSanPham = row.Cells["MaSanPham"].Value.ToString(),
                    TenSanPham = row.Cells["TenSanPham"].Value.ToString(),
                    DonGia = Convert.ToInt32(row.Cells["DonGia"].Value)
                };

                transfer(sanPham);
            }
        }
        private void transfer(SanPham sp, int soLuong = 1)
        {
            // Kiểm tra trạng thái hoạt động của phiếu
            if (isActive)
            {
                return;
            }
            if (sp != null)
            {
                BUSChiTietPhieu bus = new BUSChiTietPhieu();
                ChiTietPhieu existingItem = lstChiTiet.FirstOrDefault(item => item.MaSanPham == sp.MaSanPham);
                if (existingItem != null)
                {
                    existingItem.SoLuong += soLuong;
                    string result = bus.UpdateSoLuong(existingItem);
                    if (!string.IsNullOrEmpty(result))
                    {
                        MessageBox.Show("Thêm sản phẩm không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    ChiTietPhieu ct = new ChiTietPhieu()
                    {
                        MaPhieu = phieuBanHang.MaPhieu,
                        MaSanPham = sp.MaSanPham,
                        SoLuong = soLuong,
                        DonGia = sp.DonGia,
                    };
                    string result = bus.InsertChiTietPhieu(ct);
                    if (!string.IsNullOrEmpty(result))
                    {
                        MessageBox.Show("Thêm sản phẩm không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                loadChiTietPhieu(phieuBanHang.MaPhieu);

            }

        }

        private void btnXoaChiTiet_Click(object sender, EventArgs e)
        {
            if (isActive)
            {
                return;
            }
            deleteChiTiet();

        }
        private void deleteChiTiet()
        {
            if (dgvPhieuBanHang.CurrentRow != null)
            {
                string id = Convert.ToString(dgvPhieuBanHang.CurrentRow.Cells["MaChiTiet"].Value);
                string name = Convert.ToString(dgvPhieuBanHang.CurrentRow.Cells["TenSanPham"].Value);
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phầm {name}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    BUSChiTietPhieu bus = new BUSChiTietPhieu();
                    string kq = bus.DeleteChiTiet(id); ;
                    if (string.IsNullOrEmpty(kq))
                    {
                        loadChiTietPhieu(phieuBanHang.MaPhieu);
                    }
                }
            }
        }


        private void dgvPhieuBanHang_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (isActive)
            {
                return;
            }

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                BUSChiTietPhieu bus = new BUSChiTietPhieu();
                ChiTietPhieu ct = lstChiTiet[e.RowIndex];
                int newQuantity;
                if (int.TryParse(dgvPhieuBanHang.Rows[e.RowIndex].Cells["SoLuong"].Value.ToString(), out newQuantity))
                {
                    ct.SoLuong = newQuantity;
                    string result = bus.UpdateSoLuong(ct);
                    if (!string.IsNullOrEmpty(result))
                    {
                        MessageBox.Show("Thêm sản phẩm không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //Đảm bảo ko lỗi khi đang edit mà chuyển ô
                    this.BeginInvoke((Action)(() =>
                    {
                        loadChiTietPhieu(phieuBanHang.MaPhieu);
                    }));
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            if (isActive)
            {
                return;
            }
            if (dgvSanPham.CurrentRow != null)
            {
                string id = Convert.ToString(dgvSanPham.CurrentRow.Cells["MaSanPham"].Value);
                string ten = Convert.ToString(dgvSanPham.CurrentRow.Cells["TenSanPham"].Value);
                decimal dongia = Convert.ToDecimal(dgvSanPham.CurrentRow.Cells["DonGia"].Value);
                SanPham sanPham = new SanPham
                {
                    MaSanPham = id,
                    TenSanPham = ten,
                    DonGia = dongia
                };

                transfer(sanPham);
            }
        }
        private void loadThanhToan()
        {
            txtTong.Text = "0";
            txtGiamGia.Text = "0";
            txtPhanTram.Text = "0";
            txtThanhTien.Text = "0";
            txtDichVu.Text = "0";
        }

        // 1) Khai báo biến BUSChiTietPhieu ở cấp class của Form
        BUSChiTietPhieu busChiTiet = new BUSChiTietPhieu();

        private void dgvPhieuBanHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvPhieuBanHang.Rows[e.RowIndex];

            // 2) Lấy mã phiếu từ DataGridView
            //    Giả sử cột MaPhieu có Name = "MaPhieu"
            string maPhieu = row.Cells["MaPhieu"].Value?.ToString() ?? "";
            if (string.IsNullOrEmpty(maPhieu))
            {
                MessageBox.Show("Mã phiếu không hợp lệ.");
                return;
            }

            // 3) Gọi BLL để lấy tổng tiền
            string tongTienStr = busChiTiet.CalculateTongTien(maPhieu);
            // Nếu BUS trả về chuỗi lỗi, sẽ có chữ "Lỗi:" ở đầu
            if (tongTienStr.StartsWith("Lỗi:"))
            {
                MessageBox.Show(tongTienStr);
                return;
            }

            // 4) Chuyển về decimal và hiển thị
            if (!decimal.TryParse(tongTienStr, out decimal total))
            {
                MessageBox.Show("Dữ liệu tổng tiền không hợp lệ.");
                return;
            }
            txtTong.Text = total.ToString("N0");

            // 5) Tính các phần còn lại như trước
            decimal dichVu = 0, phanTram = 0;
            decimal.TryParse(txtDichVu.Text, out dichVu);
            decimal.TryParse(txtPhanTram.Text, out phanTram);

            decimal giamGia = total * phanTram / 100;
            decimal thanhTien = total + dichVu - giamGia;

            txtGiamGia.Text = giamGia.ToString("N0");
            txtThanhTien.Text = thanhTien.ToString("N0");
        }

        private void btnTimKiemChiTietPhieu_Click(object sender, EventArgs e)
        {
            string kw = txtTimKiemChiTietPhieu.Text.Trim();
            // Nếu trống, load lại toàn bộ
            if (string.IsNullOrEmpty(kw))
                loadChiTietPhieu(phieuBanHang.MaPhieu);
            else
            {
                var ketQua = busChiTiet.SearchChiTietBySanPham(
                    phieuBanHang.MaPhieu, kw);
                dgvPhieuBanHang.DataSource = ketQua;
            }
        }

        private void btnTimKiemSanPham_Click(object sender, EventArgs e)
        {
            string kw = txtTimKiemSanPham.Text.Trim();
            // Nếu trống, load lại toàn bộ
            if (string.IsNullOrEmpty(kw))
                loadSanPham();
            else
            {
                var ketQua = busChiTiet.SearchSanPham(kw);
                dgvSanPham.DataSource = ketQua;
            }
        }


        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // 1. Xóa các ô tìm kiếm
            txtTimKiemChiTietPhieu.Text = string.Empty;
            txtTimKiemSanPham.Text = string.Empty;

            // 2. Load lại dữ liệu gốc
            loadChiTietPhieu(phieuBanHang.MaPhieu);
            loadSanPham();

            // 3. Reset phần thanh toán về 0
            loadThanhToan();

            // 4. (Tuỳ chọn) Bỏ chọn dòng hiện tại trong DataGridView
            if (dgvPhieuBanHang.CurrentRow != null)
                dgvPhieuBanHang.ClearSelection();
            if (dgvSanPham.CurrentRow != null)
                dgvSanPham.ClearSelection();

        }
    }
}
