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
    public partial class frmThongKeNhanVien : Form
    {
        public frmThongKeNhanVien()
        {
            InitializeComponent();
        }

        private void frmThongKeNhanVien_Load(object sender, EventArgs e)
        {
            // Lấy ngày đầu tháng hiện tại
            DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            // Gán giá trị cho DateTimePicker
            dtpTuNgay.Value = firstDayOfMonth;
            LoadNhanVien();

            btnThongKe_Click(sender, e);

        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            string maNV = cboNhanVien.SelectedValue.ToString();
            DateTime bd = dtpTuNgay.Value.Date;
            DateTime kt = dtpDenNgay.Value.Date;

            BUSThongKe busThongKe = new BUSThongKe();
            List<TKDoanhThuTheoNhanVien> result = busThongKe.getThongKeNhanVien(maNV, bd, kt);
            dgvThongKeNhanVien.DataSource = result;
        }
        private void LoadNhanVien()
        {
            try
            {
                BUSNhanVien busNhanVien = new BUSNhanVien();
                List<NhanVien> dsNhanVien = busNhanVien.GetNhanVienlist();
                dsNhanVien.Insert(0, new NhanVien() { MaNhanVien = string.Empty, HoTen = string.Format("--Tất Cả--") });
                cboNhanVien.DataSource = dsNhanVien;
                cboNhanVien.ValueMember = "MaNhanVien";
                cboNhanVien.DisplayMember = "HoTen";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
