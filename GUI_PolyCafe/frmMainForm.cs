using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_PolyCafe
{
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();
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
            // Nếu muốn modal (phải đóng mới thao tác tiếp được): dùng ShowDialog() thay vì Show()
        }

        private void pnMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}