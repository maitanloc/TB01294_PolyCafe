using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_PolyCafe;
using UTIL_PolyCafe;

namespace GUI_PolyCafe
{
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();
            CheckPermisson();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frmDoiMatKhau = new frmDoiMatKhau();
            frmDoiMatKhau.ShowDialog();
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            // Nếu muốn khi mở chương trình sẽ load form Nhân viên vào panel
            // openChildForm(new frmNhanVien());
            // Hoặc để trống nếu không cần
        }

        private Form CurrentFormChild;

        private void openChildForm(Form childForm)
        {
            if (CurrentFormChild != null)
            {
                CurrentFormChild.Close();
            }
            CurrentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnMain.Controls.Add(childForm);
            pnMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // Sự kiện menu "Nhân viên" - Mở ra 1 cửa sổ mới
        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frmNhanVien());


            frmNhanVien frmNhanVien = new frmNhanVien();
        }

        private void pnMain_Paint(object sender, PaintEventArgs e)
        {

        }
        private void VaiTroNhanVien()
        {
            danhmucToolStripMenuItem.Enabled = false;
            nhanvienToolStripMenuItem.Enabled = false;
            doanhthuToolStripMenuItem.Enabled = false;
        }
        private void CheckPermisson()
        {
            if (AuthUtil.isLogin())
            {

                danhmucToolStripMenuItem.Visible = true;
                banhangToolStripMenuItem.Visible = true;
                nhanvienToolStripMenuItem.Visible = true;
                doanhthuToolStripMenuItem.Visible = true;
                if (AuthUtil.user.VaiTro == false)
                {
                    VaiTroNhanVien();
                }
            }
            else
            {
                hethongToolStripMenuItem.Visible = true; // Xác định xem điều khiển có hiển thị trên giao diện hay không.
                dangxuatToolStripMenuItem.Enabled = false; // Xác định xem điều khiển có thể tương tác hay không.
                thongtintaikhoanToolStripMenuItem.Enabled = false;
                danhmucToolStripMenuItem.Visible = false;
                banhangToolStripMenuItem.Visible = false;
                nhanvienToolStripMenuItem.Visible = false;
                doanhthuToolStripMenuItem.Visible = false;
            }



        }

        private void banhangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTheLuuDong());
            frmTheLuuDong frmTheLuuDong = new frmTheLuuDong();

        }

        private void btnHeThong_Click(object sender, EventArgs e)
        {
            pnHeThong.Visible = !pnHeThong.Visible;

        }

        private void pnHeThong_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            pnDanhMuc.Visible = !pnDanhMuc.Visible;
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {

            pnPhieuBanHang.Visible = !pnPhieuBanHang.Visible;
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            openChildForm(new frmNhanVien());


            frmNhanVien frmNhanVien = new frmNhanVien();

        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frmDoiMatKhau = new frmDoiMatKhau();
            frmDoiMatKhau.ShowDialog();
        }

        private void lblQuanLySanPham_Click(object sender, EventArgs e)
        {

        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            openChildForm(new frmQuanLySanPham());
            frmQuanLySanPham frmquanlysanpham = new frmQuanLySanPham();
        }

        private void btnLoaiSanPham_Click(object sender, EventArgs e)
        {
            openChildForm(new frmQuanLyLoaiSanPham());
            frmQuanLyLoaiSanPham frmquanlyloaisanpham = new frmQuanLyLoaiSanPham();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            openChildForm(new frmPhieuBanHang());
            frmPhieuBanHang frmPhieuBanHang = new frmPhieuBanHang();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Replace these with actual objects or variables from your form
            TheLuuDong the = new TheLuuDong(); // You need to get the correct TheLuuDong object
            PhieuBanHang phieu = new PhieuBanHang(); // You need to get the correct PhieuBanHang object
            NhanVien nv = new NhanVien(); // You need to get the correct NhanVien object

            // Pass the required parameters to frmChiTietPhieu
            openChildForm(new frmChiTietPhieu(the, phieu, nv));
        }

        private void pnPhieuBanHang_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTheLuuDong_Click(object sender, EventArgs e)
        {
            openChildForm(new frmTheLuuDong());
            frmTheLuuDong frmTheLuuDong = new frmTheLuuDong();

        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            pnThongKe.Visible = !pnThongKe.Visible;
        }

        private void btnThongKeNhanVien_Click(object sender, EventArgs e)
        {
            openChildForm(new frmThongKeNhanVien());
            frmThongKeNhanVien frmThongKeNhanVien = new frmThongKeNhanVien();

        }

        private void btnThongKeSP_Click(object sender, EventArgs e)
        {
            openChildForm(new frmThongKeLoaiSP());
            frmThongKeLoaiSP frmThongKeLoaiSP = new frmThongKeLoaiSP();
        }
    }
}