#if Core
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SixLabors.Fonts;
using SixLabors.Primitives;

namespace EPPlus.ImageSharp
{
    /// <summary>
    /// 适配模式包装ImageSharp Font 
    /// </summary>
    public class Font
    {
        SixLabors.Fonts.Font _font;
        private static readonly FontCollection _Fonts= new FontCollection();
        /// <summary>
        /// 从ImageSharp Font构建
        /// </summary>
        /// <param name="font"></param>
        public Font(SixLabors.Fonts.Font font)
        {
            _font = font;
        }
        /// <summary>
        /// 若系统中有安装要求字体，从系统字体中创建返回，
        /// 否则从配件清单资源中安装字体，若无要求的字体返回默认字体"Lato"
        /// </summary>
        /// <param name="familyName"></param>
        /// <param name="size"></param>
        /// <param name="fs"></param>
        /// <returns></returns>
        public static Font CreateFont(string familyName, float size, FontStyle fs)
        {
            if (SixLabors.Fonts.SystemFonts.TryFind(familyName, out FontFamily family))
            {
                var font = SixLabors.Fonts.SystemFonts.CreateFont(familyName, size, fs);
                return new Font(font);

            }
            else
            {
                //FontFamily family;
                if (!_Fonts.Families.Any())
                {
                    Assembly assembly = typeof(Font).Assembly;
                    var rs = assembly.GetManifestResourceNames();

                    foreach (var file in rs.Where(f => f.EndsWith(".ttf")))
                    {
                        using (var stream = assembly.GetManifestResourceStream(file))
                        {
                            _Fonts.Install(stream, out FontDescription fd);
                        }
                    }
                }

                if (!_Fonts.TryFind(familyName, out family))
                {
                    family = _Fonts.Find("Lato");
                }

                SixLabors.Fonts.Font font = new SixLabors.Fonts.Font(family, size, fs);
                return new Font(font);
            }
        }

        /// <summary>
        /// 字体名称
        /// </summary>
        public string Name { get
            {
                return _font.Name;
            }
        }
        /// <summary>
        /// 字体尺码
        /// </summary>
        public float Size { get
            {
                return _font.Size;
            }
        }
        /// <summary>
        /// 是否加删除线
        /// </summary>
        public bool Strikeout { get
            {
                return false;
            }
        }
        /// <summary>
        /// 是否粗体
        /// </summary>
        public bool Bold { get {
                return _font.Bold;
            }
        }
        /// <summary>
        /// 是否有下画线，
        /// </summary>
        public bool Underline { get
            {
                return false;
            }
        }
        /// <summary>
        /// 是否斜体
        /// </summary>
        public bool Italic { get
            {
                return _font.Italic;
            }
        }
        /// <summary>
        /// 度量文本尺寸
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public SizeF MeasureSize(string text)
        {
            SizeF size = TextMeasurer.Measure(text, new RendererOptions(this._font));
            return size;

        }
    }
}
#endif