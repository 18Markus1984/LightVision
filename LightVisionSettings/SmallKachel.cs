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
        public Image[] images;
        public PictureBox pb;

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
            InitializeComponent();
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
            InitializeComponent();
            this.mw = mw;
            height = heigh;
            length = lengt;
            this.panels = panels;
            pixel = new Pixel[length, height];
            this.size = size;
            thisISAnAnimation = true;
            animations = mw.settings.animationValue;
 
            CreateBitmapes(panels);

            pb = new PictureBox();
            pb.Size = new Size(1000,1000);
            pb.Enabled = false;
            this.Controls.Add(pb);


            thread = new Thread(Animation);
            thread.Start();
        }


        public void Animation()
        {
            while (thisISAnAnimation)
            {
                if (animations)
                {
                    pb.Image = images[shownPanel];

                    System.Threading.Thread.Sleep((int)panels[shownPanel].showtime * 1000);
                    shownPanel++;
                    if (shownPanel == panels.Length)
                    {
                        shownPanel = 0;
                    }
                }
                else
                {
                    shownPanel = 0;
                    pb.Image = images[shownPanel];
                }
            }
        }

        private void CreateBitmapes(Panel[] panels)
        {
            images = new Image[panels.Length];
            for (int i = 0; i < panels.Length; i++)
            {
                Bitmap b = new Bitmap(24*10, 8*10);
                Graphics g = Graphics.FromImage(b);
                int d = 0;


                for (int k = 0; k < 8; k++)
                {
                    for (int t = 0; t < 24; t++)
                    {

                        Render(g, t * 10, k * 10, 10, Color.FromArgb(panels[i].colors[d]));
                        d++;
                    }
                }
                Image image = (Image)b;
                images[i] = image;
                g.Dispose();
            }
        }

        public void Render(Graphics g,int x,int y,int size, Color color)
        {
            g.FillRectangle(new SolidBrush(color), x , y , size, size);
        }

        protected override void OnPaint(PaintEventArgs e)       //überschreibt die OnPaint Funktion, damit wir die Refresh funktion benutzen können
        {
            if (!thisISAnAnimation)
            {
                base.OnPaint(e);
                foreach (Pixel p in this.pixel)                     //Es werden alle Pixel durchgegangen und diese malen sich dann selber
                    p.Render(e.Graphics);
            }
        }
    }
}
