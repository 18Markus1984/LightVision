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
        public bool rgb = false;        //Wert für die RGB animation           
        public bool animationValue = true;      //Wert für die Animationen im Dashboard
        public Color menuColor;     //Die Farbe für das Menü
        public Color contentColor;      //Die Farbe für den Content
        private LightVision_Base mw;        //Die Main Form

        public Settings(LightVision_Base mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void cB_RGB_CheckedChanged(object sender, EventArgs e)      //Die RGB Einstellung wird gewechselt
        {
            rgb = !rgb;
        }

        private void animation_CheckedChanged(object sender, EventArgs e)      //Die Animations Einstellung wird gewechselt 
        {
            animationValue = !animationValue;
        }

        private void contentColor_Click(object sender, EventArgs e)         //Die Farbe für die Content Color wird gesetzt
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK && colorDialog1.Color != menuColor)
            {
                bt_ContentColor.BackColor = colorDialog1.Color;
                contentColor = colorDialog1.Color;
            }
        }

        private void MenuColor_Click(object sender, EventArgs e)        //Die Farbe für die Menu Color wird gesetzt
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK && colorDialog1.Color != contentColor)
            {
                bt_MenuColor.BackColor = colorDialog1.Color;
                menuColor = colorDialog1.Color;
            }
        }
    }
}
