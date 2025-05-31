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
using DTO_PolyCafe;

namespace GUI_PolyCafe
{
    public partial class frmQuanLySanPham : Form
    {
        public frmQuanLySanPham()
        {
            InitializeComponent();

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }
        private void ClearForm()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = true;
            txtMaSanPham.Clear();
            txtTenSanPham.Clear();
            txtDonGia.Clear();
            rdbActive.Checked = true;
            pbHinhAnh.Image = null;
        }
        private void LoadDanhSachSanPham()
        {
            BUSSanPham bUSSanPham = new BUSSanPham();
            dgvSanPham.DataSource = null;
            List<SanPham> lstSP = bUSSanPham.GetSanPhamList();
            dgvSanPham.DataSource = lstSP;
        }


        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadLoaiSanPham();
            LoadDanhSachSanPham();

        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
            txtMaSanPham.Text = row.Cells["MaSanPham"].Value.ToString();
            txtTenSanPham.Text = row.Cells["TenSanPham"].Value.ToString();
            txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
            cboMaLoai.SelectedValue = row.Cells["MaLoai"].Value.ToString();
            bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
            if (trangThai)
            {
                rdbActive.Checked = true;
            }
            else
            {
                rdbActive.Checked = true;
            }
            // Bật nút "Sửa"
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        private void LoadLoaiSanPham()
        {
            try
            {
                BUSLoaiSanPham bUSLoaiSanPham = new BUSLoaiSanPham();
                List<LoaiSanPham> dsLoai = bUSLoaiSanPham.GetLoaiSanPhamList();
                cboMaLoai.DataSource = dsLoai;
                cboMaLoai.ValueMember = "MaLoai";
                cboMaLoai.DisplayMember = "TenLoai";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách loại sản phẩm" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmQuanLySanPham_Load(object sender, EventArgs e)
        {
            BUSSanPham bUSSanPham = new BUSSanPham();
            dgvSanPham.DataSource = null;
            List<SanPham> lstSP = bUSSanPham.GetSanPhamList();
            dgvSanPham.DataSource = lstSP;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string tenSP = txtTenSanPham.Text.Trim();
                string donGiaText = txtDonGia.Text.Trim();
                string maLoai = cboMaLoai.SelectedValue?.ToString();
                bool trangThai = rdbActive.Checked;


                // Kiểm tra dữ liệu nhập vào
                if (string.IsNullOrEmpty(tenSP) || string.IsNullOrEmpty(donGiaText) || string.IsNullOrEmpty(maLoai))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi đơn giá
                if (!decimal.TryParse(donGiaText, out decimal donGia))
                {
                    MessageBox.Show("Đơn giá không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo đối tượng sản phẩm
                SanPham sp = new SanPham
                {
                    TenSanPham = tenSP,
                    DonGia = donGia,
                    MaLoai = maLoai,
                    TrangThai = trangThai,
                    HinhAnh = ""
                };

                // Thêm sản phẩm vào cơ sở dữ liệu
                BUSSanPham bUSSanPham = new BUSSanPham();
                bUSSanPham.InsertSanPham(sp);

                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Làm mới form sau khi thêm
                ClearForm();
                LoadDanhSachSanPham();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string tenSP = txtTenSanPham.Text.Trim();
                string donGiaText = txtDonGia.Text.Trim();
                string maLoai = cboMaLoai.SelectedValue?.ToString();
                bool trangThai = rdbActive.Checked;
                string maSP = txtMaSanPham.Text.Trim();

                // Kiểm tra dữ liệu nhập vào
                if (string.IsNullOrEmpty(tenSP) || string.IsNullOrEmpty(donGiaText) || string.IsNullOrEmpty(maLoai))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi đơn giá
                if (!decimal.TryParse(donGiaText, out decimal donGia))
                {
                    MessageBox.Show("Đơn giá không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo đối tượng sản phẩm
                SanPham sp = new SanPham
                {
                    MaSanPham = maSP,
                    TenSanPham = tenSP,
                    DonGia = donGia,
                    MaLoai = maLoai,
                    TrangThai = trangThai,
                };

                // Thêm sản phẩm vào cơ sở dữ liệu
                BUSSanPham bUSSanPham = new BUSSanPham();
                string result = bUSSanPham.UpdateSanPham(sp);

                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Cập nhật thông tin thành công");
                    ClearForm();
                    LoadDanhSachSanPham();
                }
                else
                {
                    MessageBox.Show(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSanPham.Text.Trim();
            string tenSP = string.Empty;
            string hinhAnh = string.Empty;

            // If maSP is empty, try to get it from the selected DataGridView row
            if (string.IsNullOrEmpty(maSP))
            {
                if (dgvSanPham.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvSanPham.SelectedRows[0];
                    maSP = selectedRow.Cells["MaSanPham"].Value?.ToString();
                    tenSP = selectedRow.Cells["TenSanPham"].Value?.ToString();
                    hinhAnh = selectedRow.Cells["HinhAnh"].Value?.ToString();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mã sản phẩm hoặc chọn một sản phẩm để xóa!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                tenSP = txtTenSanPham.Text.Trim();
            }

            // Ensure maSP is not empty before proceeding
            if (string.IsNullOrEmpty(maSP))
            {
                MessageBox.Show("Mã sản phẩm không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirm deletion with user
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm {maSP} - {tenSP}?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                BUSSanPham bus = new BUSSanPham();
                string kq = bus.DeleteSanPham(maSP);

                if (string.IsNullOrEmpty(kq))
                {
                    MessageBox.Show($"Xóa thông tin sản phẩm {maSP} - {tenSP} thành công!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadDanhSachSanPham();
                }
                else
                {
                    MessageBox.Show(kq, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {

            try
            {
                // Tạo một đối tượng OpenFileDialog
                OpenFileDialog openFileDialog = new OpenFileDialog();

                // Thiết lập bộ lọc để chỉ cho phép các file ảnh
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";
                openFileDialog.Title = "Chọn hình ảnh sản phẩm";

                // Hiển thị hộp thoại và kiểm tra nếu người dùng chọn file
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn file ảnh
                    string imagePath = openFileDialog.FileName;

                    // Hiển thị ảnh lên PictureBox
                    pbHinhAnh.Image = Image.FromFile(imagePath);

                    // (Tùy chọn) Lưu đường dẫn ảnh vào một biến hoặc đối tượng SanPham
                    // Ví dụ: sp.HinhAnh = imagePath; (sử dụng trong btnThem hoặc btnSua)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TimKiem()
        {
            try
            {
                string searchValue = txtTimKiem.Text.Trim(); // Sử dụng TextBox riêng cho tìm kiếm
                BUSSanPham busSanPham = new BUSSanPham();

                // Gọi phương thức SearchSanPham từ BUSSanPham
                List<SanPham> result = busSanPham.SearchSanPham(searchValue);

                // Cập nhật DataGridView
                dgvSanPham.DataSource = null;
                dgvSanPham.DataSource = result;

                // Thông báo nếu không tìm thấy kết quả
                if (result.Count == 0 && !string.IsNullOrEmpty(searchValue))
                {
                    MessageBox.Show("Không tìm thấy sản phẩm nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiem();
        }
    }
}

