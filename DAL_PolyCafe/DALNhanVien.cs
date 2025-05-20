using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_PolyCafe;
using System.Net.Http.Headers;


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
        public  void insert(NhanVien nv)
        {
            string sql = "INSERT INTO NhanVien (MaNhanVien, HoTen, Email, MatKhau, VaiTro, TrangThai) " +
                         "VALUES (@0, @1, @2, @3, @4, @5)";

            List<object> thamSo = new List<object>();
            thamSo.Add(nv.MaNhanVien);
            thamSo.Add(nv.HoTen);
            thamSo.Add(nv.Email);
            thamSo.Add(nv.MatKhau);
            thamSo.Add(nv.VaiTro);
            thamSo.Add(nv.TrangThai);

            DBUtil.Update(sql, thamSo);
        }
        public  void update(NhanVien nv)
        {
            string sql = "UPDATE NhanVien SET HoTen=@0, MatKhau=@1, Email=@2, VaiTro=@3, TrangThai=@4 WHERE MaNhanVien=@5";

            List<object> thamSo = new List<object>();
            thamSo.Add(nv.HoTen);
            thamSo.Add(nv.MatKhau);
            thamSo.Add(nv.Email);
            thamSo.Add(nv.VaiTro);
            thamSo.Add(nv.TrangThai);
            thamSo.Add(nv.MaNhanVien);

            DBUtil.Update(sql, thamSo);
        }
        public  List<NhanVien> selectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<NhanVien> list = new List<NhanVien>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    NhanVien entity = new NhanVien();
                    //entity.MaNhanVien = reader["MaNhanVien"].ToString();
                    //entity.HoTen = reader["HoTen"].ToString();
                    //entity.Email = reader["Email"].ToString();
                    //entity.MatKhau = reader["MatKhau"].ToString();
                    //// sài bool.parse hoặc convert
                    //entity.VaiTro = bool.Parse(reader["VaiTro"].ToString());
                    //entity.TrangThai = bool.Parse(reader["TrangThai"].ToString());


                    entity.MaNhanVien = reader.GetString(0);
                    entity.HoTen = reader.GetString(1);
                    entity.Email = reader.GetString(2);
                    entity.MatKhau = reader.GetString(3);
                    entity.VaiTro = reader.GetBoolean(4);
                    entity.TrangThai = reader.GetBoolean(5);
                   
                    list.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
        public  List<NhanVien> selectAll()
        {
            String sql = "SELECT * FROM NhanVien";
            return selectBySql(sql, new List<Object>());
        }

        public  NhanVien selectById(String id)
        {
            String sql = "SELECT * FROM NhanVien WHERE MaNhanVien=01";
            List<Object> thamSo = new List<Object>();
            thamSo.Add(id);
            List<NhanVien> list = selectBySql(sql, thamSo);
            return list.Count > 0 ? list[0] : null;
        }
        // tìm kiếm theo tên
        public List<NhanVien> searchByName(string name)
        {
            string sql = "SELECT * FROM NhanVien WHERE HoTen LIKE @0";
            List<object> thamSo = new List<object>();
            thamSo.Add("%" + name + "%");
            return selectBySql(sql, thamSo);
        }
        public string generateMaNhanVien()
        {
            string prefix = "NV";
            string sql = "SELECT MAX(MaNhanVien) FROM NhanVien";
            List<object> thamSo = new List<object>();
            object result = DBUtil.ScalarQuery(sql, thamSo);
            if (result != null && result.ToString().StartsWith(prefix))
            {
                string maxCode = result.ToString().Substring(2);
                int newNumber = int.Parse(maxCode) + 1;
                return $"{prefix}{newNumber:D3}";
            }

            return $"{prefix}001";
        }
        public bool checkEmailExits(string email)
        {
            string sql = "SELECT COUNT(*) FROM NhanVien WHERE Email = @0";
            List<object> thamSo = new List<object>();
            thamSo.Add(email);
            object result = DBUtil.ScalarQuery(sql, thamSo);
            return Convert.ToInt32(result) > 0;

        }
    }





}

