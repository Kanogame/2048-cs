using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class Config
    {
        public Color GetColorFromInt(int value)
        {
            if (value <= 0)
            {
                return Color.White;
            }
            else if (value == 2)
            {
                return Color.FromArgb(238, 228, 218);
            }
            else if (value == 4)
            {
                return Color.FromArgb(237, 224, 200);
            }
            else if (value == 8)
            {
                return Color.FromArgb(237, 224, 200);
            }
            else if (value == 16)
            {
                return Color.FromArgb(245, 149, 99);
            }
            else if (value == 32)
            {
                return Color.FromArgb(246, 124, 95);
            }
            return Color.White;
/*
            private static final Color COLOR_64 = Color.rgb(246, 94, 59);
            private static final Color COLOR_128 = Color.rgb(237, 207, 114);
            private static final Color COLOR_256 = Color.rgb(237, 204, 97);
            private static final Color COLOR_512 = Color.rgb(237, 200, 80);
            private static final Color COLOR_1024 = Color.rgb(237, 197, 63);
            private static final Color COLOR_2048 = Color.rgb(237, 194, 46);
*/
        }
    }
}
