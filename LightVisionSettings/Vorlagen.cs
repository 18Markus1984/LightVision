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
    public partial class Vorlagen : UserControl
    {
        private LightVision_Base mw;
        private Panel clock;
        private Animation stonks;
        public Vorlagen(LightVision_Base mw)
        {
            InitializeComponent();
            this.mw = mw;
            List<int> puffer = new List<int>();

            Bitmap b = new Bitmap(Properties.Resources.uhrV2);
            for (int i = 0; i < 8; i++)
            {
                for (int m = 0; m < 24; m++)
                {
                    puffer.Add(b.GetPixel(m, i).ToArgb());
                }
            }
            clock = new Panel("clock", puffer, 10);


            List<Panel> panels = new List<Panel>();
            Bitmap p = Properties.Resources.ezgif_7_424c1e747021;
            int k = 0;
            foreach (Image image in mw.animator.GetFramesFromAnimatedGIF(p))
            {
                puffer = new List<int>();
                Bitmap bitmap = (Bitmap)image;
                if (bitmap.Width != 24 || bitmap.Height != 8)
                {
                    bitmap = new Bitmap(bitmap, new Size(24, 8));
                }
                for (int i = 0; i < 8; i++)
                {
                    for (int m = 0; m < 24; m++)
                    {
                        puffer.Add((bitmap.GetPixel(m, i).ToArgb()));
                    }
                }
                panels.Add(new Panel("stonks"+k, puffer, Convert.ToDouble(5)));
                k++;
            }
            stonks = new Animation("stonks", 2, 5, panels, 1);

            List<string> namen = new List<string>();
            foreach (Panel item in mw.savedPanels)
            {
                namen.Add(item.name);
            }
            foreach (Animation item in mw.savedAnimations)
            {
                namen.Add(item.name);
            }
            if (namen.Contains("clock"))
            {
                cB_clock.Checked = true;
            }
            if (namen.Contains("stonks"))
            {
                cB_GME.Checked = true;
            }

            cB_clock.CheckedChanged += clock_CheckedChanged;
            cB_GME.CheckedChanged += GME_CheckedChanged;
        }

        private void clock_CheckedChanged(object sender, EventArgs e)
        {
            List<string> namen = new List<string>();
            Panel panel = new Panel("");
            foreach (Panel item in mw.savedPanels)
            {
                namen.Add(item.name);
                if (item.name == "clock")
                {
                    panel = item;
                }
            }
            if (namen.Contains("clock"))
            {
                mw.savedPanels.Remove(panel);
            }
            else
            {
                mw.savedPanels.Add(clock);
            }
        }

        private void GME_CheckedChanged(object sender, EventArgs e)
        {
            List<string> namen = new List<string>();
            Animation panel = new Animation("",1,1);
            foreach (Animation item in mw.savedAnimations)
            {
                namen.Add(item.name);
                if (item.name == "stonks")
                {
                    panel = item;
                }
            }
            if (namen.Contains("stonks"))
            {
                mw.savedAnimations.Remove(panel);
            }
            else
            {
                mw.savedAnimations.Add(stonks);
            }
        }
    }
}
