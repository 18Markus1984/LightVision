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
        private bool addedBefore = false;
        public Vorlagen(LightVision_Base mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            List<int> puffer = new List<int>();

            Bitmap b = new Bitmap(Properties.Resources.uhrV2);
            for (int i = 0; i < 8; i++)
            {
                for (int m = 0; m < 24; m++)
                {
                    puffer.Add(b.GetPixel(m, i).ToArgb());
                }
            }
            Panel p = new Panel("clock", puffer, 10);

            if (!mw.savedPanels.Contains(p))
            {
                mw.savedPanels.Add(p);
            }
            else
            {
                mw.savedPanels.Remove(p);
            }

            addedBefore = !addedBefore;
        }
    }
}
