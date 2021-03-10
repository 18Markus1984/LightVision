using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LightVisionSettings
{
    public partial class Animator : UserControl
    {
        private LightVision_Base mw;
        private int height;
        private int length;
        private int size;
        private Pixel[,] pixel;
        private CircleAnimator[] circles;

        private int numberOfPanels = 5;


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        public Animator(LightVision_Base mw, int size, int height, int length)
        {
            InitializeComponent();
            
            this.mw = mw;
            this.size = size;
            this.height = height;
            this.length = length;
            AddButtonCircles();

        }

        public void AddButtonCircles()
        {
            pixel = new Pixel[length, height];
            int d = 0;
            for (int i = 0; i < height; i++)
            {
                for (int m = 0; m < length; m++)
                {
                    pixel[m, i] = new Pixel(m * size + ((747-25*25)/2), i * size + 30, size, Color.White);

                }
            }

            circles = new CircleAnimator[numberOfPanels];
            for (int i = 0; i < numberOfPanels; i++)
            {
                circles[i] = new CircleAnimator(10, Color.White, ((747 - 24 * 25) / 2+55)+i*(24*25/numberOfPanels), 20);
                
            }circles[2].Color = mw.contentColor;

            this.Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)       //überschreibt die OnPaint Funktion, damit wir die Refresh funktion benutzen können
        {
            base.OnPaint(e);
            foreach (Pixel p in this.pixel)                     //Es werden alle Pixel durchgegangen und diese malen sich dann selber
            {
                p.Render(e.Graphics);
            }
            foreach (CircleAnimator c in circles)
            {
                c.Render(e.Graphics);
            }


        }

        
    }
}
