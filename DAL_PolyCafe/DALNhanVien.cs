using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_PolyCafe;


namespace DAL_POLYCAFE
{
    public class DAL_NHANVIEN
    {
        public NhanVien GetNHANVIEN(string email, string password)
        {
            string sql = "SELECT * FROM NHANVIEN WHERE Email = @0 AND MatKhau = @1";
            List<object> thamso = new List<object>();
            thamso.Add(email);
            thamso.Add(password);
            NhanVien nv = DBUtil.Value<NhanVien>(sql, thamso);
            return nv;

        }
        public void UpdateMatKhau(string email, string password)
        {
            try
            {
                string sql = "UPDATE NhanVien SET MatKhau = @0 WHERE Email = @1";
                List<object> thamso = new List<object>();
                thamso.Add(password);
                thamso.Add(email);
                DBUtil.Update(sql, thamso);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
