using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_PolyCafe;

namespace UTIL_PolyCafe
{

    public class AuthUtil
    {
        public static NhanVien user = null;
        public static bool isLogin()
        {
            if (user == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(user.MaNhanVien))
            {
                return false;
            }
            return true;
        }
        // log out
        public static void Logout()
        {
            user = null;
        }
    }
}
