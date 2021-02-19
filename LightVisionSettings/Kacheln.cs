using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightVisionSettings
{
    public partial class Kacheln : UserControl
    {
        public Kacheln()
        {
            InitializeComponent();
            AddButtons();
            Random r = new Random();
            colorDialog1.Color = Color.FromArgb(r.Next(0, 256),r.Next(0, 256), r.Next(0, 256));
            bt_Color.BackColor = colorDialog1.Color;
        }

        private Pixel[,] pixel;
        private bool onClick;
        private Color backColorButtons;
        private bool fill;


        private void AddButtons()
        {
            pixel = new Pixel[28, 10];
            onClick = false;
            for (int i = 0; i < 28; i++)
            {
                for (int k = 0; k < 10; k++)
                {
                    pixel[i, k] = new Pixel(i * 25, k * 25, 25);
                }
            }
            this.DoubleBuffered = true;
            this.MouseMove += kachel_MouseMove;
            this.fill = false;
        }

        private void buttonLED_Click(object sender, EventArgs e)
        {
            Control clickedButton = (Control)sender;
            clickedButton.BackColor = backColorButtons;
        }

        private void kachel_MouseMove(object sender, MouseEventArgs e)
        {
            if (onClick)
            {
                foreach (Pixel p in this.pixel)
                {
                    if (e.X > p.X  && e.X < p.X + p.Size && e.Y > p.Y && e.Y < p.Y + p.Size)
                    {
                        p.Color = colorDialog1.Color;
                        this.Refresh();
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (Pixel p in this.pixel)
                p.Render(e.Graphics);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (fill)
            {
                fillButtons(e.X, e.Y);
                return;
            }

            onClick = true;
            foreach (Pixel p in this.pixel)
            {
                if (e.X - 10> p.X && e.X - 10 < p.X + p.Size && e.Y -10 > p.Y && e.Y -10 < p.Y + p.Size)
                {
                    p.Color = colorDialog1.Color;
                    this.Refresh();
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            onClick = false;
        }

        private void bt_Color_Click_1(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                bt_Color.BackColor = colorDialog1.Color;
                backColorButtons = colorDialog1.Color;
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            foreach (var item in pixel)
            {
                item.Color = Color.White;
            }    
            this.Refresh();
        }

        private void bt_Speichern_Click(object sender, EventArgs e)
        {
            List<int> colors = new List<int>();
            foreach (var item in pixel)
            {
                colors.Add(item.Color.ToArgb());
            }
        }

        private void Fill_Click(object sender, EventArgs e)
        {
            
            if (fill)
            {
                bt_fill.BackColor = SystemColors.Control;
            }
            else
            {
                bt_fill.BackColor = Color.LightGray;
            }
            fill = !fill;
        }

        public void fillButtons(int x, int y)
        {
            int xPosition = (x / 25);
            int yPosition = (y / 25);

            Pixel p = pixel[xPosition, yPosition];
        }
    }
}
