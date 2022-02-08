using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace SignalRHost.Utilities
{
    public class ImageUtitlity
    {
        public static Bitmap CreateBitmap(byte[] bytes, int width, int height)
        {
            byte[] rgbBytes = new byte[bytes.Length * 3];

            for (int i = 0; i <= bytes.Length - 1; i++)
            {
                rgbBytes[(i * 3)] = bytes[i];
                rgbBytes[(i * 3) + 1] = bytes[i];
                rgbBytes[(i * 3) + 2] = bytes[i];
            }

            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            for (int i = 0; i <= bmp.Height - 1; i++)
            {
                IntPtr p = new IntPtr(data.Scan0.ToInt64() + data.Stride * i);
                System.Runtime.InteropServices.Marshal.Copy(rgbBytes, i * bmp.Width * 3, p, bmp.Width * 3);
            }

            bmp.UnlockBits(data);

            return bmp;
        }

        public static byte[] ConvertBitmapToArray(Bitmap bitmap)
        {
            using (var ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public static string SaveImageToDisk(byte[] image)
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var imagesDir = Path.Combine(baseDir, "images");
            Directory.CreateDirectory(imagesDir);
            var filePath = Path.Combine(imagesDir, DateTime.Now.ToString("yyyyMMddHHmm") + ".png");
                       

            using (var ms = new MemoryStream(image))
            {
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    ms.WriteTo(fs);
                }
            }
            return filePath;
        }

        public static string ReadImageFromDisk(string filePath)
        {
            Image img = Image.FromFile(filePath);
            byte[] bytes;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                bytes = ms.ToArray();
            }

            return ConvertImageToBase64String(bytes);
        }

        public static void DeleteImageFromDisk(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        public static string ConvertImageToBase64String(byte[] image)
        {
            return Convert.ToBase64String(image, 0, image.Length);
        }

        public static byte[] ConvertBase64StringToBytes(string base64String)
        {
            return Convert.FromBase64String(base64String);
        }

        public static Bitmap GetScaledImage(Bitmap srcBitmap, int width, int height)
        {
            int w, h;
            float lvbRatio, lvRatio;

            lvbRatio = width / (float)height;
            lvRatio = srcBitmap.Width / (float)srcBitmap.Height;
            if (lvbRatio < lvRatio)
            {
                w = width;
                h = (int)(width / lvRatio);
            }
            else
            {
                w = (int)(height * lvRatio);
                h = height;
            }

            Bitmap resizedImage = new Bitmap(w, h, PixelFormat.Format24bppRgb);
            resizedImage.SetResolution(srcBitmap.HorizontalResolution, srcBitmap.VerticalResolution);

            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                g.DrawImage(srcBitmap,
                    new Rectangle(0, 0, w, h),
                    new Rectangle(0, 0, srcBitmap.Width, srcBitmap.Height),
                    GraphicsUnit.Pixel);
            }

            for (int c = 0; c < resizedImage.Palette.Entries.Length; c++)
                resizedImage.Palette.Entries[c] = Color.FromArgb(c, c, c);
            return resizedImage;
        }
    
    }
}
