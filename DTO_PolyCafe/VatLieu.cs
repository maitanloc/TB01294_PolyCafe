using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_PolyCafe
{
    public class VatLieu
    {
        public string MaVatLieu { get; set; }
        public string TenVatLieu { get; set; }
        public int SoLuong { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
        public string MaLoai { get; set; }
        public DateTime NgayCapNhat { get; set; }
    }
}
