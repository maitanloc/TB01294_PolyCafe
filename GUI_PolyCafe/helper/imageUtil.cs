using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using DTO_PolyCafe;

namespace GUI_PolyCafe
{
    public class ImageUtil
    {
        // Chuyển đổi hình ảnh sang mảng byte[]
        public static byte[] ImageToByteArray(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                return ms.ToArray();
            }
        }

        // Chuyển đổi mảng byte[] sang hình ảnh
        public static Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        // Lưu hình ảnh vào thư mục
        public static string SaveImage(Image img, string folderPath)
        {
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, Guid.NewGuid().ToString() + ".jpg");
            img.Save(filePath, ImageFormat.Jpeg);

            return filePath;
        }

        // Xóa hình ảnh trong thư mục
        public static void DeleteImage(string imagePath)
        {
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
        }

        // Tải hình ảnh từ đường dẫn
        public static Image LoadImage(string imagePath)
        {
            if (File.Exists(imagePath))
            {
                return Image.FromFile(imagePath);
            }

            return Properties.Resources.Placeholder_view_vector_svg;
        }
    }
}
