using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightVisionSettings
{
    public partial class SmallKachel : UserControl
    {
        private LightVision_Base mw;
        public Pixel[,] pixel;

        public int shownPanel = 0;
        public Panel[] panels;
        public bool animations = true;
        public int size;
        public int height;
        public int length;
        public Point mouseDown;
        public bool moved = false;
        public int matchingPanel;
        public bool thisISAnAnimation = false;
        public Thread thread;


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

        public SmallKachel(int size, Panel[] panels, int heigh, int lengt,LightVision_Base mw)
        {
            this.mw = mw;
            height = heigh;
            length = lengt;
            this.panels = panels;
            pixel = new Pixel[length, height];
            this.size = size;
            thisISAnAnimation = true;
            animations = mw.settings.animationValue;

            int d = 0;
            for (int i = 0; i < height; i++)
            {
                for (int m = 0; m < length; m++)
                {
                    pixel[m, i] = new Pixel(m * size - 10, i * size - 10, size);
                    d++;
                }
            }
            thread = new Thread(Animation);
            thread.Start();
        }


        public void Animation()
        {
            while (true && animations && thisISAnAnimation)
            {
                int d = 0;
                for (int i = 0; i < height; i++)
                {
                    for (int m = 0; m < length; m++)
                    {
                        pixel[m, i].Color = Color.FromArgb(panels[shownPanel].colors[d]);
                        d++;
                    }
                }
                System.Threading.Thread.Sleep((int)panels[shownPanel].showtime * 1000);
                shownPanel++;
                if (shownPanel == panels.Length)
                {
                    shownPanel = 0;
                }
                
            }
        }


        protected override void OnPaint(PaintEventArgs e)       //überschreibt die OnPaint Funktion, damit wir die Refresh funktion benutzen können
        {
            base.OnPaint(e);
            foreach (Pixel p in this.pixel)                     //Es werden alle Pixel durchgegangen und diese malen sich dann selber
                p.Render(e.Graphics);
        }

        //private void timer_Tick(object sender, EventArgs e)
        //{
        //    //Animation();
        //}
    }
}
