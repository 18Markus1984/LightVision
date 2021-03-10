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
    public partial class Animator : UserControl
    {
        private LightVision_Base mw;
        public Animator(LightVision_Base mw)
        {
            InitializeComponent();
            this.mw = mw;
        }
    }
}
