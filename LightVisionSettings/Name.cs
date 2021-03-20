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
        List<Panel> panels;


        public Name(LightVision_Base mw,List<int> puffer)
        {
            InitializeComponent();
            this.mw = mw;
            this.puffer = puffer;
        }

        public Name(LightVision_Base mw, List<Panel> panels)
        {
            InitializeComponent();
            this.mw = mw;
            this.panels = panels;
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
                if (puffer != null)
                {
                    Panel p = new Panel(textBox1.Text, puffer, 5);
                    mw.kacheln.ImportPanel(p);
                }
                else
                {
                    Animation a = new Animation(textBox1.Text, panels.Count, 5, panels, 1);
                    for (int i = 0; i < a.numberOfPanels; i++)
                    {
                        a.animation[i].name = textBox1.Text + i;
                    }
                    mw.animator.ImportAnimation(a);
                }
               
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
