using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BLL_PolyCafe;
using DTO_PolyCafe;

namespace GUI_PolyCafe
{
    public partial class frmNhaCungCap : Form
    {
        private BUSNhaCungCap busNhaCungCap = new BUSNhaCungCap();

        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadDanhSachNhaCungCap();
            ClearForm();
        }

        private void ClearForm()
        {
            txtMaNhaCungCap.Clear();
            txtTenNhaCungCap.Clear();
            txtDiaChi.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtGhiChu.Clear();
            txtTimKiem.Clear();
            txtMaNhaCungCap.ReadOnly = true;
            btnNutThem.Enabled = true;
            btnNutSua.Enabled = false;
            btnNutXoa.Enabled = false;
        }

        private void LoadDanhSachNhaCungCap()
        {
            dgvNhaCungCap.DataSource = null;
            List<NhaCungCap> lstNhaCungCap = busNhaCungCap.GetNhaCungCapList();
            dgvNhaCungCap.DataSource = lstNhaCungCap;
            dgvNhaCungCap.Columns["MaNhaCungCap"].HeaderText = "Mã Nhà Cung Cấp";
            dgvNhaCungCap.Columns["TenNhaCungCap"].HeaderText = "Tên Nhà Cung Cấp";
            dgvNhaCungCap.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dgvNhaCungCap.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
            dgvNhaCungCap.Columns["Email"].HeaderText = "Email";
            dgvNhaCungCap.Columns["GhiChu"].HeaderText = "Ghi Chú";
            dgvNhaCungCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnNutThem_Click(object sender, EventArgs e)
        {
            try
            {
                NhaCungCap ncc = new NhaCungCap
                {
                    TenNhaCungCap = txtTenNhaCungCap.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    GhiChu = txtGhiChu.Text.Trim()
                };

                string result = busNhaCungCap.InsertNhaCungCap(ncc);
                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadDanhSachNhaCungCap();
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
                if (string.IsNullOrEmpty(txtMaNhaCungCap.Text))
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                NhaCungCap ncc = new NhaCungCap
                {
                    MaNhaCungCap = txtMaNhaCungCap.Text.Trim(),
                    TenNhaCungCap = txtTenNhaCungCap.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    GhiChu = txtGhiChu.Text.Trim()
                };

                string result = busNhaCungCap.UpdateNhaCungCap(ncc);
                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Cập nhật nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadDanhSachNhaCungCap();
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
            try
            {
                string maNhaCungCap = txtMaNhaCungCap.Text.Trim();
                if (string.IsNullOrEmpty(maNhaCungCap))
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhà cung cấp {maNhaCungCap}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    string result = busNhaCungCap.DeleteNhaCungCap(maNhaCungCap);
                    if (string.IsNullOrEmpty(result))
                    {
                        MessageBox.Show($"Xóa nhà cung cấp {maNhaCungCap} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        LoadDanhSachNhaCungCap();
                    }
                    else
                    {
                        MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNutLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadDanhSachNhaCungCap();
        }

        private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhaCungCap.Rows[e.RowIndex];
                txtMaNhaCungCap.Text = row.Cells["MaNhaCungCap"].Value.ToString();
                txtTenNhaCungCap.Text = row.Cells["TenNhaCungCap"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString() ?? "";
                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString() ?? "";
                txtMaNhaCungCap.ReadOnly = true;
                btnNutThem.Enabled = false;
                btnNutSua.Enabled = true;
                btnNutXoa.Enabled = true;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiemNhaCungCap();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiemNhaCungCap();
        }

        private void TimKiemNhaCungCap()
        {
            try
            {
                string searchValue = txtTimKiem.Text.Trim();
                if (string.IsNullOrEmpty(searchValue))
                {
                    LoadDanhSachNhaCungCap();
                    return;
                }

                List<NhaCungCap> list = busNhaCungCap.GetNhaCungCapList();
                var result = list.Where(ncc =>
                    ncc.TenNhaCungCap.ToLower().Contains(searchValue.ToLower()) ||
                    ncc.SoDienThoai.Contains(searchValue)
                ).ToList();

                dgvNhaCungCap.DataSource = null;
                dgvNhaCungCap.DataSource = result;

                if (result.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy nhà cung cấp nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grpNhaCungCap_Click(object sender, EventArgs e)
        {
            // Không cần xử lý sự kiện Click cho GroupBox
        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            TimKiemNhaCungCap();
        }
    }
}