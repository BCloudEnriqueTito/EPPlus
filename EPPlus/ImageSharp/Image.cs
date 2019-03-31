#if Core
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EPPlus.ImageSharp
{
    public class Image
    {
        IImageFormat _format;
        Image<Rgba32> _image;
        public Image(Image<Rgba32> img,IImageFormat fmt)
        {
            _image = img;
            _format = fmt;
        }
        public Byte[] GetImageAsByteArray()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                _image.Save(stream, _format);
                
                return stream.ToArray();
            }
                
        }
        public int Width
        {
            get
            {
                return _image.Width;
            }
        }
        public int Height
        {
            get
            {
                
                return _image.Height;
            }
        }

        public double HorizontalResolution { get
            {
                return _image.MetaData.HorizontalResolution;
            }
        }
        public double VerticalResolution { get
            {
                return _image.MetaData.VerticalResolution;
            }
        }

        internal static Image FromStream(Stream stream)
        {            
            var img= SixLabors.ImageSharp.Image.Load(stream, out IImageFormat format);
            return new Image(img, format);
        }
        internal static Image FromFile(string fileName)
        {
            var img = SixLabors.ImageSharp.Image.Load(fileName, out IImageFormat format);
            return new Image(img, format);
        }

        internal void Dispose()
        {
            _image.Dispose();
        }

        internal void Save(Stream stream)
        {
            _image.Save(stream, _format);
        }
    }
}
#endif
