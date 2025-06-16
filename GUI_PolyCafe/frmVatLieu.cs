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
    public partial class frmVatLieu : Form
    {
        private BUSVatLieu busVatLieu = new BUSVatLieu();
        private BUSLoaiVatLieu busLoaiVatLieu = new BUSLoaiVatLieu();

        public frmVatLieu()
        {
            InitializeComponent();
        }

        private void frmVatLieu_Load(object sender, EventArgs e)
        {
            LoadDanhSachVatLieu();
            loadMaLoai();
            LoadTrangThai();
            ClearForm();
        }

        private void ClearForm()
        {
            btnNutThem.Enabled = true;
            btnNutSua.Enabled = false;
            btnNutXoa.Enabled = false;
            txtMaVatLieu.Clear();
            txtTenVatLieu.Clear();
            txtSoLuong.Clear();
            txtGhiChu.Clear();
            cboTrangThai.SelectedIndex = 0;
            cboMaLoai.SelectedIndex = -1;
            txtTimKiem.Clear();
        }

        private void LoadDanhSachVatLieu()
        {
            dgvVatLieu.DataSource = null;
            List<VatLieu> lstVL = busVatLieu.GetVatLieuList();
            dgvVatLieu.DataSource = lstVL;
        }

        private void LoadTrangThai()
        {
            cboTrangThai.Items.AddRange(new string[] { "Sử dụng được", "Hư hỏng", "Đang sửa chữa" });
            cboTrangThai.SelectedIndex = 0;
        }

        private void loadMaLoai()
        {
            try
            {
                List<LoaiVatLieu> dsLoai = busLoaiVatLieu.GetLoaiVatLieuList();
                dsLoai.Insert(0, new LoaiVatLieu { MaLoai = string.Empty, TenLoai = "--Vui lòng chọn loại vật liệu--" });
                cboMaLoai.DataSource = dsLoai;
                cboMaLoai.ValueMember = "MaLoai";
                cboMaLoai.DisplayMember = "TenLoai";
                cboMaLoai.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách loại vật liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNutThem_Click(object sender, EventArgs e)
        {
            try
            {
                string tenVL = txtTenVatLieu.Text.Trim();
                string soLuongText = txtSoLuong.Text.Trim();
                string maLoai = cboMaLoai.SelectedValue?.ToString();
                string trangThai = cboTrangThai.SelectedItem?.ToString();
                string ghiChu = txtGhiChu.Text.Trim();

                // Kiểm tra dữ liệu nhập vào
                if (string.IsNullOrEmpty(tenVL) || string.IsNullOrEmpty(soLuongText) || string.IsNullOrEmpty(maLoai))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin (Tên, Số lượng, Loại vật liệu)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi số lượng
                if (!int.TryParse(soLuongText, out int soLuong) || soLuong < 0)
                {
                    MessageBox.Show("Số lượng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo đối tượng vật liệu
                VatLieu vl = new VatLieu
                {
                    TenVatLieu = tenVL,
                    SoLuong = soLuong,
                    TrangThai = trangThai,
                    GhiChu = ghiChu,
                    MaLoai = maLoai == string.Empty ? null : maLoai
                };

                // Thêm vật liệu vào cơ sở dữ liệu
                string result = busVatLieu.InsertVatLieu(vl);
                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Thêm vật liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadDanhSachVatLieu();
                }
                else
                {
                    MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNutSua_Click(object sender, EventArgs e)
        {
            try
            {
                string maVL = txtMaVatLieu.Text.Trim();
                string tenVL = txtTenVatLieu.Text.Trim();
                string soLuongText = txtSoLuong.Text.Trim();
                string maLoai = cboMaLoai.SelectedValue?.ToString();
                string trangThai = cboTrangThai.SelectedItem?.ToString();
                string ghiChu = txtGhiChu.Text.Trim();

                // Kiểm tra dữ liệu nhập vào
                if (string.IsNullOrEmpty(maVL) || string.IsNullOrEmpty(tenVL) || string.IsNullOrEmpty(soLuongText) || string.IsNullOrEmpty(maLoai))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin (Mã, Tên, Số lượng, Loại vật liệu)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi số lượng
                if (!int.TryParse(soLuongText, out int soLuong) || soLuong < 0)
                {
                    MessageBox.Show("Số lượng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo đối tượng vật liệu
                VatLieu vl = new VatLieu
                {
                    MaVatLieu = maVL,
                    TenVatLieu = tenVL,
                    SoLuong = soLuong,
                    TrangThai = trangThai,
                    GhiChu = ghiChu,
                    MaLoai = maLoai == string.Empty ? null : maLoai
                };

                // Cập nhật vật liệu
                string result = busVatLieu.UpdateVatLieu(vl);
                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Cập nhật vật liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadDanhSachVatLieu();
                }
                else
                {
                    MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNutXoa_Click(object sender, EventArgs e)
        {
            string maVL = txtMaVatLieu.Text.Trim();
            string tenVL = string.Empty;

            // Nếu maVL rỗng, lấy từ dòng được chọn trong DataGridView
            if (string.IsNullOrEmpty(maVL))
            {
                if (dgvVatLieu.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dgvVatLieu.SelectedRows[0];
                    maVL = selectedRow.Cells["MaVatLieu"].Value?.ToString();
                    tenVL = selectedRow.Cells["TenVatLieu"].Value?.ToString();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mã vật liệu hoặc chọn một vật liệu để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                tenVL = txtTenVatLieu.Text.Trim();
            }

            // Đảm bảo maVL không rỗng
            if (string.IsNullOrEmpty(maVL))
            {
                MessageBox.Show("Mã vật liệu không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xác nhận xóa
            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa vật liệu {maVL} - {tenVL}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                string result = busVatLieu.DeleteVatLieu(maVL);
                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show($"Xóa vật liệu {maVL} - {tenVL} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadDanhSachVatLieu();
                }
                else
                {
                    MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNutLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            loadMaLoai();
            LoadDanhSachVatLieu();
        }

        private void TimKiem()
        {
            try
            {
                string searchValue = txtTimKiem.Text.Trim();
                string trangThai = cboTrangThai.SelectedItem?.ToString();
                List<VatLieu> result = busVatLieu.SearchVatLieu(searchValue, trangThai);

                dgvVatLieu.DataSource = null;
                dgvVatLieu.DataSource = result;

                if (result.Count == 0 && !string.IsNullOrEmpty(searchValue))
                {
                    MessageBox.Show("Không tìm thấy vật liệu nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiemNhanVien_Click(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void dgvVatLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvVatLieu.Rows[e.RowIndex];
                txtMaVatLieu.Text = row.Cells["MaVatLieu"].Value.ToString();
                txtTenVatLieu.Text = row.Cells["TenVatLieu"].Value.ToString();
                txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
                cboTrangThai.SelectedItem = row.Cells["TrangThai"].Value.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();
                cboMaLoai.SelectedValue = row.Cells["MaLoai"].Value?.ToString() ?? string.Empty;
                btnNutThem.Enabled = false;
                btnNutSua.Enabled = true;
                btnNutXoa.Enabled = true;
            }
        }
    }
}