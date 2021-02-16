using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LightVisionSettings
{
    public class Panel
    {
        Color[,] panel;

        public Panel()
        {
            panel = new Color[10, 28];
        }

        public void fill(Color color, int row, int colume)
        {
            panel[row, colume] = color;
        }

        public void fill(int alpha,int red,int green,int blue, int row, int colume)
        {
            panel[row, colume] = Color.FromArgb(alpha,red, green, blue);
        }
    }
}
