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
    /// <summary>
    /// 适配模式构建Image
    /// </summary>
    public class Image
    {
        IImageFormat _format;
        Image<Rgba32> _image;
        /// <summary>
        /// 从原图像和图像格式构建
        /// </summary>
        /// <param name="img"></param>
        /// <param name="fmt"></param>
        public Image(Image<Rgba32> img,IImageFormat fmt)
        {
            _image = img;
            _format = fmt;
        }
        /// <summary>
        /// 从图像对象返回Byte数组
        /// </summary>
        /// <returns></returns>
        public Byte[] GetImageAsByteArray()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                _image.Save(stream, _format);
                
                return stream.ToArray();
            }
                
        }
        /// <summary>
        /// 图像宽度
        /// </summary>
        public int Width
        {
            get
            {
                return _image.Width;
            }
        }
        /// <summary>
        /// 图像高度
        /// </summary>
        public int Height
        {
            get
            {
                
                return _image.Height;
            }
        }
        /// <summary>
        /// 横向解析度
        /// </summary>
        public double HorizontalResolution { get
            {
                return _image.MetaData.HorizontalResolution;
            }
        }
        /// <summary>
        /// 竖向解析度
        /// </summary>
        public double VerticalResolution { get
            {
                return _image.MetaData.VerticalResolution;
            }
        }
        /// <summary>
        /// 从流对象构建Image
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        internal static Image FromStream(Stream stream)
        {            
            var img= SixLabors.ImageSharp.Image.Load(stream, out IImageFormat format);
            return new Image(img, format);
        }
        /// <summary>
        /// 从文件路径构建Image
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        internal static Image FromFile(string fileName)
        {
            var img = SixLabors.ImageSharp.Image.Load(fileName, out IImageFormat format);
            return new Image(img, format);
        }
        /// <summary>
        /// 释放图像资源
        /// </summary>
        internal void Dispose()
        {
            _image.Dispose();
        }
        /// <summary>
        /// 将图像保存到流
        /// </summary>
        /// <param name="stream"></param>
        internal void Save(Stream stream)
        {
            _image.Save(stream, _format);
        }
    }
}
#endif
