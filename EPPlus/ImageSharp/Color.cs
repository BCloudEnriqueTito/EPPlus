#if Core
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace EPPlus.ImageSharp
{
    /// <summary>
    /// 适配模式包装Rgba32
    /// </summary>
    public struct Color
    {
        private Rgba32 _rgba32;
        /// <summary>
        /// 从Rgba32构建
        /// </summary>
        /// <param name="rgba32"></param>
        public Color(Rgba32 rgba32) : this()
        {
            _rgba32 = rgba32;
        }
        /// <summary>
        /// 黑色
        /// </summary>
        public static Color Black {
            get { 
                return new Color(Rgba32.Black);
            }
        }
        /// <summary>
        /// 白色
        /// </summary>
        public static Color White
        {
            get
            {
                return new Color(Rgba32.White);
            }
        }
        /// <summary>
        /// 灰色
        /// </summary>
        public static Color Gray
        {
            get
            {
                return new Color(Rgba32.Gray);
            }
        }
        /// <summary>
        /// 浅灰色
        /// </summary>
        public static Color LightGray
        {
            get
            {
                return new Color(Rgba32.LightGray);
            }
        }
        /// <summary>
        /// 烟白色
        /// </summary>
        public static Color WhiteSmoke
        {
            get
            {
                return new Color(Rgba32.WhiteSmoke);
            }
        }
        /// <summary>
        /// 红色
        /// </summary>
        public static Color Red
        {
            get
            {
                return new Color(Rgba32.Red);
            }
        }
        /// <summary>
        /// 黄色
        /// </summary>
        public static Color Yellow
        {
            get
            {
                return new Color(Rgba32.Yellow);
            }
        }
        /// <summary>
        /// 蓝色
        /// </summary>
        public static Color Blue
        {
            get
            {
                return new Color(Rgba32.Blue);
            }
        }
        /// <summary>
        /// 天蓝色
        /// </summary>
        public static Color SkyBlue
        {
            get
            {
                return new Color(Rgba32.SkyBlue);
            }
        }


        /// <summary>
        /// 使用给定的alpha值修改颜色
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        internal static Color FromArgb(int alpha, Color c)
        {
            c._rgba32.A = (byte)alpha;
            return c;
        }
        /// <summary>
        /// 从32位整数构建颜色
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        internal static Color FromArgb(int v)
        {
            var red = v & 0x00FF0000;
            var green = v & 0x0000FF00;
            var blue = v & 0x000000FF;
            var alpha = v & 0xFF000000;
            Rgba32  rgba32 = new Rgba32(red, green, blue, alpha);
            return new Color(rgba32);
        }
        /// <summary>
        /// 按红，绿，蓝三原色构建颜色
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <returns></returns>
        internal static Color FromArgb(int red, int green, int blue)
        {
            Rgba32 rgba32 = new Rgba32(red, green, blue, 255);
            return new Color(rgba32);
        }
        /// <summary>
        /// 按alpha和红，绿，蓝三原色构建颜色
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <returns></returns>
        internal static Color FromArgb(int alpha,int red, int green, int blue)
        {
            Rgba32 rgba32 = new Rgba32(red, green, blue, alpha);
            return new Color(rgba32);
        }
        /// <summary>
        /// 从颜色返回Argb对应的32位整数
        /// </summary>
        /// <returns></returns>
        internal int ToArgb()
        {
            return ((int)_rgba32.A) << 24 | (int)_rgba32.R << 16 | (int)_rgba32.G << 8 | _rgba32.B;
        }
        /// <summary>
        ///获取 alpha部分
        /// </summary>
        internal byte A { get { return _rgba32.A; } }
        /// <summary>
        /// 是否位空
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return _rgba32 == Empty._rgba32;
            }
        }

       
        /// <summary>
        /// 空
        /// </summary>
        public static Color Empty;
    }
}
#endif