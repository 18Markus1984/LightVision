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
        private int size;           //größe des Pixel und da der Pixel ein Quadrat ist brauchen wir nur eine Länge
        private Color color;        //die Farbe des Pixels
        private int x, y;           //Position
        public Pixel(int x, int y, int size)
        {
            this.Size = size;
            this.x = x;
            this.y = y;
            this.Color = Color.White;       //Startfarbe ist weiß
        }

        public int Size { get => size; set => size = value; }
        public Color Color { get => color; set => color = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public void Render(Graphics g)
        {
            g.FillRectangle(new SolidBrush(this.color), x + 10, Y + 10, size, size); //malt ein Quadrat an der Position, um 10 versetzt an x und y Position in der Farbe die im Pixel gespeichert ist
        }
    }
}
