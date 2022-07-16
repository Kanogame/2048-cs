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
            else if (value == 64)
            {
                return Color.FromArgb(246, 94, 59);
            }
            else if (value == 128)
            {
                return Color.FromArgb(237, 207, 114);
            }
            else if (value == 256)
            {
                return Color.FromArgb(237, 204, 97);
            }
            else if (value == 512)
            {
                return Color.FromArgb(237, 200, 80);
            }
            else if (value == 1024)
            {
                return Color.FromArgb(237, 197, 63);
            }
            else if (value == 2048)
            {
                return Color.FromArgb(237, 194, 46);
            }
            return Color.White;
        }
    }
}
