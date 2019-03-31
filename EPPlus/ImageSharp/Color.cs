#if Core
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace EPPlus.ImageSharp
{
    public struct Color
    {
        private Rgba32 rgba32;

        public Color(Rgba32 black) : this()
        {
            this.rgba32 = black;
        }

        public static Color Black {
            get { 
                return new Color(Rgba32.Black);
            }
        }
        public static Color White
        {
            get
            {
                return new Color(Rgba32.White);
            }
        }

        internal static Color FromArgb(int alpha, Color c)
        {
            c.rgba32.A = (byte)alpha;
            return c;
        }

        internal static Color FromArgb(int v)
        {
            var red = v & 0x00FF0000;
            var green = v & 0x0000FF00;
            var blue = v & 0x000000FF;
            var alpha = v & 0xFF000000;
            Rgba32  rgba32 = new Rgba32(red, green, blue, alpha);
            return new Color(rgba32);
        }

        internal static Color FromArgb(int red, int green, int blue)
        {
            Rgba32 rgba32 = new Rgba32(red, green, blue, 255);
            return new Color(rgba32);
        }
        internal static Color FromArgb(int alpha,int red, int green, int blue)
        {
            Rgba32 rgba32 = new Rgba32(red, green, blue, alpha);
            return new Color(rgba32);
        }
        internal int ToArgb()
        {
            return ((int)rgba32.A) << 24 | (int)rgba32.R << 16 | (int)rgba32.G << 8 | rgba32.B;
        }
        internal byte A { get { return rgba32.A; } }

        public bool IsEmpty
        {
            get
            {
                return rgba32 == Empty.rgba32;
            }
        }

       

        public static Color Empty;
    }
}
#endif