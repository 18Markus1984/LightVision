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
    public partial class Settings : UserControl
    {
        public bool rgb = false;
        public bool animationValue = true;
        public Color menuColor;
        public Color contentColor;
        private LightVision_Base mw;

        public Settings(LightVision_Base mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void cB_RGB_CheckedChanged(object sender, EventArgs e)
        {
            rgb = !rgb;
        }

        private void contentColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK && colorDialog1.Color != menuColor)
            {
                bt_ContentColor.BackColor = colorDialog1.Color;
                contentColor = colorDialog1.Color;
            }
        }

        private void MenuColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK && colorDialog1.Color != contentColor)
            {
                bt_MenuColor.BackColor = colorDialog1.Color;
                menuColor = colorDialog1.Color;
            }
        }

        private void animation_CheckedChanged(object sender, EventArgs e)
        {
            animationValue = !animationValue;
        }
    }
}
