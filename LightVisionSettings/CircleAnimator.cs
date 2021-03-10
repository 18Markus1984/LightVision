using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LightVisionSettings
{
    public class CircleAnimator
    {
        private int radius;
        private Color color;
        private int x, y;

        public CircleAnimator(int radius, Color color, int x, int y)
        {
            this.radius = radius;
            this.color = color;
            this.x = x;
            this.y = y;
        }

        public int Radius { get => radius; set => radius = value; }
        public Color Color { get => color; set => color = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(color), x - radius, y - radius, radius + radius, radius + radius);
        }
    }
}
