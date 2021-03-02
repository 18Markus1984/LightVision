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
        public string name;
        public List<int> colors;

        public Panel(string name)
        {
            this.name = name;
            List<int> defaultColors = new List<int>();
            for (int i = 0; i < 192; i++)
            {
                defaultColors.Add(Color.Green.ToArgb());
            }
            colors = defaultColors;
        }
        
        public Panel(string name, List<int> colors)
        {
            this.colors = colors;
        }

        //public void fill(Color color, int row, int colume)
        //{
        //    panel[row, colume] = color;
        //}

        //public void fill(int alpha,int red,int green,int blue, int row, int colume)
        //{
        //    panel[row, colume] = Color.FromArgb(alpha,red, green, blue);
        //}
    }
}
