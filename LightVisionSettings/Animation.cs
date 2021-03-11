using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightVisionSettings
{
    class Animation
    {
        public Panel[] animation;
        public double showtime;
        public int numberOfPanels;
        public string name;

        public Animation(string name,int numberOfPanels)
        {
            this.numberOfPanels = numberOfPanels;
            this.name = name;
            animation = new Panel[numberOfPanels];
            showtime = 5;

            for (int i = 0; i < numberOfPanels; i++)
            {
                animation[i] = new Panel(name + i);
            }
        }

        public Animation(string name, int numberOfPanels, double showtime, Panel[] panels)
        {
            this.numberOfPanels = numberOfPanels;
            this.name = name;
            this.showtime = showtime;
            if (panels.Length == numberOfPanels)
            {
                animation = panels;
            }
            else
            {
                animation = new Panel[numberOfPanels];
                for (int i = 0; i < numberOfPanels; i++)
                {
                    animation[i] = panels[i];
                }
            }
        }

        public Animation(string name, int numberOfPanels, double showtime, List<Panel> panels)
        {
            this.numberOfPanels = numberOfPanels;
            this.name = name;
            this.showtime = showtime;
            if (panels.Count == numberOfPanels)
            {
                animation = panels.ToArray();
            }
            else
            {
                animation = new Panel[numberOfPanels];
                for (int i = 0; i < numberOfPanels; i++)
                {
                    animation[i] = panels[i];
                }
            }
        }
    }
}
