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
        public Settings()
        {
            InitializeComponent();
        }

        private void cB_RGB_CheckedChanged(object sender, EventArgs e)
        {
            rgb = !rgb;
        }
    }
}
