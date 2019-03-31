using System;
using System.Collections.Generic;
#if Core
using EPPlus.ImageSharp;
#else
using System.Drawing;
using System.Drawing.Imaging;
#endif
using System.IO;
using System.Linq;
using System.Text;

namespace OfficeOpenXml.Compatibility
{
    internal class ImageCompat
    {
        internal static byte[] GetImageAsByteArray(Image image)
        {
        #if Core
            return image.GetImageAsByteArray();
        #else
            var ms = new MemoryStream();
            if (image.RawFormat.Guid == ImageFormat.Gif.Guid)
            {
                image.Save(ms, ImageFormat.Gif);
            }
            else if (image.RawFormat.Guid == ImageFormat.Bmp.Guid)
            {
                image.Save(ms, ImageFormat.Bmp);
            }
            else if (image.RawFormat.Guid == ImageFormat.Png.Guid)
            {
                image.Save(ms, ImageFormat.Png);
            }
            else if (image.RawFormat.Guid == ImageFormat.Tiff.Guid)
            {
                image.Save(ms, ImageFormat.Tiff);
            }
            else
            {
                image.Save(ms, ImageFormat.Jpeg);
            }

            return ms.ToArray();
            #endif
        }
    }
}
