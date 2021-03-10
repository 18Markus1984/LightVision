using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightVisionSettings
{
    public partial class SmallKachel : UserControl
    {
        public Pixel[,] pixel;
        public int size;
        public int height;
        public int length;
        public Point mouseDown;
        public bool moved = false;
        public int matchingPanel;

        public SmallKachel()
        {
            InitializeComponent();
            this.Height = 100;
            this.Width = 300;
            mouseDown = new Point(0, 0);
        }

        public SmallKachel(int size, List<int> colors, int heigh, int lengt)
        {
            height = heigh;
            length = lengt;
            pixel = new Pixel[length, height];
            int d = 0;
            for (int i = 0; i < height; i++)
            {
                for (int m = 0; m < length; m++)
                {
                    pixel[m, i] = new Pixel(m * size-10, i * size-10, size, Color.FromArgb(colors[d]));
                    d++;
                }
            }
            this.size = size;
            this.Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)       //überschreibt die OnPaint Funktion, damit wir die Refresh funktion benutzen können
        {
            base.OnPaint(e);
            foreach (Pixel p in this.pixel)                     //Es werden alle Pixel durchgegangen und diese malen sich dann selber
                p.Render(e.Graphics);
        }

        

        
    }
}
