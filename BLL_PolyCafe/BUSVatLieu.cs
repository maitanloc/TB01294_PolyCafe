using System;
using System.Collections.Generic;
using System.Linq;
using DAL_PolyCafe;
using DTO_PolyCafe;

namespace BLL_PolyCafe
{
    public class BUSVatLieu
    {
        DALVatLieu dalVatLieu = new DALVatLieu();

        public List<VatLieu> GetVatLieuList(string trangThai = null)
        {
            return dalVatLieu.selectAll(trangThai);
        }

        public string InsertVatLieu(VatLieu vl)
        {
            try
            {
                vl.MaVatLieu = dalVatLieu.generateMaVatLieu();
                if (string.IsNullOrEmpty(vl.MaVatLieu))
                {
                    return "Mã vật liệu không hợp lệ.";
                }

                if (string.IsNullOrEmpty(vl.TenVatLieu))
                {
                    return "Tên vật liệu không được để trống.";
                }

                if (vl.SoLuong < 0)
                {
                    return "Số lượng không được âm.";
                }

                dalVatLieu.insertVatLieu(vl);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        public string UpdateVatLieu(VatLieu vl)
        {
            try
            {
                if (string.IsNullOrEmpty(vl.MaVatLieu))
                {
                    return "Mã vật liệu không hợp lệ.";
                }

                if (string.IsNullOrEmpty(vl.TenVatLieu))
                {
                    return "Tên vật liệu không được để trống.";
                }

                if (vl.SoLuong < 0)
                {
                    return "Số lượng không được âm.";
                }

                if (vl.GhiChu == null)
                {
                    vl.GhiChu = "";
                }

                dalVatLieu.updateVatLieu(vl);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        public string DeleteVatLieu(string maVL)
        {
            try
            {
                if (string.IsNullOrEmpty(maVL))
                {
                    return "Mã vật liệu không hợp lệ.";
                }

                dalVatLieu.deleteVatLieu(maVL);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        public List<VatLieu> SearchVatLieu(string searchValue, string trangThai = null)
        {
            try
            {
                // Lấy danh sách vật liệu từ DAL
                List<VatLieu> list = dalVatLieu.selectAll(trangThai);

                // Nếu searchValue rỗng hoặc null, trả về toàn bộ danh sách
                if (string.IsNullOrEmpty(searchValue))
                {
                    return list;
                }

                // Tìm kiếm trên MaVatLieu và TenVatLieu, không phân biệt hoa thường
                searchValue = searchValue.ToLower();
                return list.Where(vl =>
                    (vl.MaVatLieu?.ToLower().Contains(searchValue) ?? false) ||
                    (vl.TenVatLieu?.ToLower().Contains(searchValue) ?? false)
                ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm vật liệu: " + ex.Message);
            }
        }
    }
}