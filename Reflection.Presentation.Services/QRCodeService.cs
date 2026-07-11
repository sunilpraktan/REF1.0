using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Runtime.InteropServices;

namespace Reflection.Presentation.Services
{
    public class QRCodeService
    {
        private void RenderQrCode()
        {
            string level = ECC_LEVEL.L.ToString();
            QRCodeGenerator.ECCLevel eccLevel = (QRCodeGenerator.ECCLevel)(level == "L" ? 0 : level == "M" ? 1 : level == "Q" ? 2 : 3);
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                //using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(txtQRCodeData.Text, eccLevel))
                //{
                //    using (QRCode qrCode = new QRCode(qrCodeData))
                //    {
                //        System.Windows.Controls.Image finalImage = new System.Windows.Controls.Image();
                //        BitmapImage finalImage2 = new BitmapImage();
                //        Bitmap bitmapImage = qrCode.GetGraphic(20, System.Drawing.Color.Black, System.Drawing.Color.White, GetIconBitmap(), Convert.ToInt32(iconSize.Text));
                //        finalImage = ConvertDrawingImageToWPFImage(bitmapImage);
                //        //imgQRCode.Source = finalImage.Source;
                //        //finalImage = ConvertDrawingImageToWPFImage(qrCode.GetGraphic(20, System.Drawing.Color.Black, System.Drawing.Color.White, GetIconBitmap(), Convert.ToInt32(iconSize.Text)));
                //        //this.imgQRCode.RenderSize = new System.Drawing.Size(Convert.ToInt32(imgQRCode.Width), Convert.ToInt32(imgQRCode.Height));
                //        //Set the SizeMode to center the image.
                //        //this.imgQRCode.SizeMode = PictureBoxSizeMode.CenterImage;

                //        //imgQRCode.SizeMode = PictureBoxSizeMode.StretchImage;


                //        //imgQRCode.Source = qrCode.GetGraphic(20, System.Drawing.Color.Black, System.Drawing.Color.White,
                //        //    GetIconBitmap(), Convert.ToInt32(iconSize.Text));

                //        //this.imgQRCode.RenderSize = new System.Drawing.Size(Convert.ToInt32(imgQRCode.Width), Convert.ToInt32(imgQRCode.Height));
                //        ////Set the SizeMode to center the image.
                //        //this.imgQRCode.SizeMode = PictureBoxSizeMode.CenterImage;

                //        //imgQRCode.SizeMode = PictureBoxSizeMode.StretchImage;
                //    }
                //}
            }
        }
        public byte[] RenderQrCodeForLabel(string QRData, int IconSize, string IconPath)
        {
            byte[] bytImage = null;
            string level = ECC_LEVEL.L.ToString();
            QRCodeGenerator.ECCLevel eccLevel = (QRCodeGenerator.ECCLevel)(level == "L" ? 0 : level == "M" ? 1 : level == "Q" ? 2 : 3);
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(QRData, eccLevel))
                {
                    using (QRCode qrCode = new QRCode(qrCodeData))
                    {
                        System.Windows.Controls.Image finalImage = new System.Windows.Controls.Image();
                        BitmapImage finalImage2 = new BitmapImage();
                        Bitmap bitmapImage = qrCode.GetGraphic(20, System.Drawing.Color.Black, System.Drawing.Color.White, GetIconBitmap(IconPath), IconSize);
                        bytImage = ImageToByte(bitmapImage);
                    }
                }
            }
            return bytImage;
        }
        private Bitmap GetIconBitmap(string iconPath)
        {
            Bitmap img = null;
            if (iconPath.Length > 0)
            {
                try
                {
                    img = new Bitmap(iconPath);
                }
                catch (Exception)
                {
                }
            }
            return img;
        }
        public void ExportToBmp(string path)
        {

        }
        private System.Windows.Controls.Image ConvertDrawingImageToWPFImage(System.Drawing.Image gdiImg)
        {


            System.Windows.Controls.Image img = new System.Windows.Controls.Image();

            //convert System.Drawing.Image to WPF image
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(gdiImg);
            IntPtr hBitmap = bmp.GetHbitmap();
            System.Windows.Media.ImageSource WpfBitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            img.Source = WpfBitmap;
            img.Width = 500;
            img.Height = 600;
            img.Stretch = System.Windows.Media.Stretch.Fill;
            return img;
        }
        public static byte[] ImageToByte(Image img)
        {
           System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        public static byte[] ImageToByte2(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
        public static byte[] BitmapToByteArray(Bitmap bitmap)
        {

            BitmapData bmpdata = null;

            try
            {
                bmpdata = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, bitmap.PixelFormat);
                int numbytes = bmpdata.Stride * bitmap.Height;
                byte[] bytedata = new byte[numbytes];
                IntPtr ptr = bmpdata.Scan0;

                Marshal.Copy(ptr, bytedata, 0, numbytes);

                return bytedata;
            }
            finally
            {
                if (bmpdata != null)
                    bitmap.UnlockBits(bmpdata);
            }

        }
        public static byte[] ImageToByte3(Bitmap img)
        {
            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Close();

                byteArray = stream.ToArray();
            }
            return byteArray;
        }
    }


    enum ECC_LEVEL
    {
        L, M, Q, H
    }
}
