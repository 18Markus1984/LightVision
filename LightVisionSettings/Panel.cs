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
        public double showtime;
             
        public Panel(string name)
        {
            this.name = name;
            List<int> defaultColors = new List<int>();
            for (int i = 0; i < 192; i++)
            {
                defaultColors.Add(Color.White.ToArgb());
            }
            colors = defaultColors;
            showtime = 5;
        }
        
        public Panel(string name, List<int> colors, double showtime)
        {
            this.colors = colors;
            this.name = name;
            this.showtime = showtime;
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
