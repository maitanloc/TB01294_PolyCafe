using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_PolyCafe;
using DTO_PolyCafe;

namespace BLL_PolyCafe
{
    public class BUSSanPham
    {
        DALSanPham dalSanPham = new DALSanPham();

        public List<SanPham> GetSanPhamList(int trangThai = -1)
        {
            return dalSanPham.selectAll(trangThai);
        }
        public string InsertSanPham(SanPham sp)
        {
            try
            {
                sp.MaSanPham = dalSanPham.generateMaSanPham();
                if (string.IsNullOrEmpty(sp.MaSanPham))
                {
                    return "Mã sản phẩm không hợp lệ.";
                }

                dalSanPham.insertSanPham(sp);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Thêm mới không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }
        public string UpdateSanPham(SanPham sp)
        {
            try
            {
                if (string.IsNullOrEmpty(sp.MaSanPham))
                {
                    return "Mã sản phẩm không hợp lệ.";
                }

                if (sp.HinhAnh == null)
                {
                    sp.HinhAnh = "";
                }

                dalSanPham.updateSanPham(sp);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Cập nhật không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }
        public string DeleteSanPham(string maSP)
        {
            try
            {
                if (string.IsNullOrEmpty(maSP))
                {
                    return "Mã sản phẩm không hợp lệ.";
                }

                dalSanPham.deleteSanPham(maSP);
                return string.Empty;
            }
            catch (Exception ex)
            {
                //return "Xóa không thành công.";
                return "Lỗi: " + ex.Message;
            }
        }
        public List<SanPham> SearchSanPham(string searchValue, int trangThai = -1)
        {
            try
            {
                // Lấy danh sách sản phẩm từ DAL
                List<SanPham> list = dalSanPham.selectAll(trangThai);

                // Nếu searchValue rỗng hoặc null, trả về toàn bộ danh sách
                if (string.IsNullOrEmpty(searchValue))
                {
                    return list;
                }

                // Tìm kiếm trên MaSanPham và TenSanPham, không phân biệt hoa thường
                searchValue = searchValue.ToLower();
                return list.Where(sp =>
                    (sp.MaSanPham?.ToLower().Contains(searchValue) ?? false) ||
                    (sp.TenSanPham?.ToLower().Contains(searchValue) ?? false)
                ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm sản phẩm: " + ex.Message);
            }
        }
    }
}
