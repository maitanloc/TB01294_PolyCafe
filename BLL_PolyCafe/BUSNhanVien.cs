using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO_PolyCafe;
using DAL_POLYCAFE;
using System.Runtime.InteropServices.WindowsRuntime;

namespace BLL_PolyCafe
{


    public class BUSNhanVien
    {
        DAL_NHANVIEN dalNhanVien = new DAL_NHANVIEN();
        public NhanVien DangNhap(string email, string password)
        {
            NhanVien nv = dalNhanVien.GetNHANVIEN(email, password);
            if (nv == null)
            {
                return null;
            }
            return dalNhanVien.GetNHANVIEN(email, password);
        }
        public bool updateMatKhau(string email, string mk)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(mk))
                {
                    return false;
                }
                dalNhanVien.UpdateMatKhau(email, mk);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<NhanVien> GetNhanVien()
        {

            return dalNhanVien.selectAll();
        }

        public List<NhanVien> GetNhanVienlist()
        {
            return dalNhanVien.selectAll();

        }
        public string InsertNhanVien(NhanVien nv)
        {
            try
            {
                nv.MaNhanVien = dalNhanVien.generateMaNhanVien();
                if (string.IsNullOrEmpty(nv.MaNhanVien))
                {
                    return " Mã Nhân Viên Không hợp lệ";
                }
                if (dalNhanVien.checkEmailExits(nv.Email))
                {
                    return "Email đã tồn tại trong hệ thống";
                }

                dalNhanVien.insert(nv);
                return "Thêm Nhân Viên thành công";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }



        public void UpdateVaiTro(string maNhanVien, bool vaiTro)
        {
            dalNhanVien.updateVaiTro(maNhanVien, vaiTro);
        }

        public void UpdateTrangThai(string maNhanVien, bool trangThai)
        {
            dalNhanVien.updateTrangThai(maNhanVien, trangThai);
        }
        // delete
        public void DeleteNhanVien(string maNhanVien)
        {
            dalNhanVien.delete(maNhanVien);
        }
        public void UpdateNhanVien(NhanVien nv)
        {
            dalNhanVien.update(nv);
        }
    }
}









