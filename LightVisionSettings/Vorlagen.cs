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
            List<string> namen = new List<string>();
            foreach (Panel item in mw.savedPanels)
            {
                namen.Add(item.name);
            }
            if (namen.Contains("clock"))
            {
                checkBox1.Checked = true;
            }

            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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
    }
}
