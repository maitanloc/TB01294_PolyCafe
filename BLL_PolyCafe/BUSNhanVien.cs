using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO_PolyCafe;
using DAL_POLYCAFE;

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
    }
    
}
