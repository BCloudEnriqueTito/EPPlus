#if Core
using System;
using System.Collections.Generic;
using System.Text;
using SixLabors.Fonts;
using SixLabors.Primitives;

namespace EPPlus.ImageSharp
{
    public class Font
    {
        SixLabors.Fonts.Font _font;
        //private string name;
        //private float size;
        //private FontStyle fs;

        public Font(string name, float size, FontStyle fs)
        {
            _font = SixLabors.Fonts.SystemFonts.CreateFont(name, size, fs);
        }

        public string Name { get
            {
                return _font.Name;
            }
        }
        public float Size { get
            {
                return _font.Size;
            }
        }
        public bool Strikeout { get
            {
                return false;
            }
        }
        public bool Bold { get {
                return _font.Bold;
            }
        }
        public bool Underline { get
            {
                return false;
            }
        }
        public bool Italic { get
            {
                return _font.Italic;
            }
        }
        public SizeF MeasureSize(string text)
        {
            SizeF size = TextMeasurer.Measure(text, new RendererOptions(this._font));
            return size;

        }
    }
}
#endif