using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
    }
}