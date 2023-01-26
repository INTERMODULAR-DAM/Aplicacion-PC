using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Aplicacion_PC_Intermodular.Utils
{
    class ImageAndBase64
    {
        public static BitmapImage convertToImage(String pfp)
        {
            byte[] binaryData = Convert.FromBase64String(pfp);

            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = new MemoryStream(binaryData);
            bi.EndInit();

            return bi;
        }

        public static string convertToBase64(String fileName)
        {
            BitmapImage bmImg = new BitmapImage(new Uri(fileName));
            MemoryStream memoryStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmImg));
            encoder.Save(memoryStream);
            return Convert.ToBase64String(memoryStream.ToArray());
        }
    }
}
