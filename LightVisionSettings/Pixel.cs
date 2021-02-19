using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightVisionSettings
{
    public class Pixel
    {
        private int size;
        private Color color;
        private int x, y;
        public Pixel(int x, int y, int size)
        {
            this.Size = size;
            this.x = x;
            this.y = y;
            this.Color = Color.White;
        }

        public int Size { get => size; set => size = value; }
        public Color Color { get => color; set => color = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public void Render(Graphics g)
        {
            g.FillRectangle(new SolidBrush(this.color), x + 10, Y + 10, size, size);
        }
    }
}
