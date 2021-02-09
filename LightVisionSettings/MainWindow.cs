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
    public partial class LightVision_Base : Form
    {
        public LightVision_Base()
        {
            InitializeComponent();
        }

        private void bt_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_Wecker_Click(object sender, EventArgs e)
        {
            p_Slider.Location = new Point(0, 126);
        }

        private void bt_Kacheln_Click(object sender, EventArgs e)
        {
            p_Slider.Location = new Point(0, 166);
        }

        private void bt_Einstellungen_Click(object sender, EventArgs e)
        {
            p_Slider.Location = new Point(0, 206);
        }
    }
}
