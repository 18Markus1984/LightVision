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
    public partial class Name : Form
    {
        LightVision_Base mw ;
        List<int> puffer;
        public Name(LightVision_Base mw,List<int> puffer)
        {
            InitializeComponent();
            this.mw = mw;
            this.puffer = puffer;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> nameOfPanels = new List<string>();
            foreach (Panel p in mw.savedPanels)     //Eine Liste mit bis jetzt allen exsistierenden Panel und Animations Namen wird erstellt
            {
                nameOfPanels.Add(p.name);
            }
            foreach (Animation a in mw.savedAnimations)
            {
                nameOfPanels.Add(a.name);
            }
            if (!nameOfPanels.Contains(textBox1.Text) && textBox1.Text.Trim() != "" && textBox1.Text.Any(char.IsDigit) == false)
            {
                Panel p = new Panel(textBox1.Text, puffer, 5);
                mw.kacheln.ImportPanel(p);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
