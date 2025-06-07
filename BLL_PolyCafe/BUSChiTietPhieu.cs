using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_PolyCafe;
using DTO_PolyCafe;

namespace BLL_PolyCafe
{
    public class BUSChiTietPhieu
    {
        DALChiTietPhieu dalChiTietPhieu = new DALChiTietPhieu();
        

        public List<ChiTietPhieu> GetChiTietPhieuList(string maPhieu)
        {
            return dalChiTietPhieu.selectChiTietByMaPhieu(maPhieu);
        }

        public string InsertChiTietPhieu(ChiTietPhieu ct)
        {
            try
            {
                ct.MaChiTiet = dalChiTietPhieu.generateChiTietID();
                if (string.IsNullOrEmpty(ct.MaChiTiet))
                {
                    return "Mã chi tiết phiếu không hợp lệ.";
                }

                dalChiTietPhieu.insertChiTiet(ct);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        public string UpdateSoLuong(ChiTietPhieu pbh)
        {
            try
            {
                if (string.IsNullOrEmpty(pbh.MaChiTiet))
                {
                    return "Mã chi tiết phiếu không hợp lệ.";
                }

                dalChiTietPhieu.updateSoluong(pbh);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        public string DeleteChiTiet(string maPhieu)
        {
            try
            {
                if (string.IsNullOrEmpty(maPhieu))
                {
                    return "Mã phiếu bán hàng không hợp lệ.";
                }

                dalChiTietPhieu.deleteChiTietPhieu(maPhieu);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        // Hàm mới: Tính tổng tiền của một phiếu bán hàng
        public string CalculateTongTien(string maPhieu)
        {
            try
            {
                if (string.IsNullOrEmpty(maPhieu))
                {
                    return "Mã phiếu không hợp lệ.";
                }

                decimal tongTien = dalChiTietPhieu.CalculateTongTien(maPhieu);
                return tongTien.ToString(); // Trả về tổng tiền dưới dạng chuỗi
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
        public List<ChiTietPhieu> SearchChiTietBySanPham(string maPhieu, string keyword)
        {
            return dalChiTietPhieu.SearchChiTietBySanPham(maPhieu, keyword);
        }

        public List<SanPham> SearchSanPham(string keyword)
        {
            return dalChiTietPhieu.SearchSanPham(keyword);
        }
    }
}