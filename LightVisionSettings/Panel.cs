using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LightVisionSettings
{
    public class Panel
    {
        public string name;     //Name des Panels
        public List<int> colors;        //Liste mit 192 Farbwerten
        public double showtime;     //Anzeigezeit eines Panel
        public int wiederholungen;

        public Panel(string name)       //Konstruktor der ein leeres Panel nur mit Namen erstellt
        {
            this.name = name;
            List<int> defaultColors = new List<int>();      //es wird eine Liste von Pixel erstellt, diese Pixel sind aber weiß
            for (int i = 0; i < 192; i++)
            {
                defaultColors.Add(Color.White.ToArgb());
            }
            this.colors = defaultColors;
            this.showtime = 5;
            this.wiederholungen = 1;
        }

        public Panel(string name, double showtime)      //Konstruktor der ein leeres Panel nur mit Namen und Anzeigezeit erstellt
        {
            this.name = name;
            List<int> defaultColors = new List<int>();     //es wird eine Liste von Pixel erstellt, diese Pixel sind aber weiß
            for (int i = 0; i < 192; i++)
            {
                defaultColors.Add(Color.White.ToArgb());
            }
            this.colors = defaultColors;
            this.showtime = showtime;
            this.wiederholungen = 1;
        }

        public Panel(string name, List<int> colors, double showtime)        //Konstruktor der ein Panel mit Namen, Anzeigezeit und einer gegebenen Liste von Farben erstellt
        {
            this.colors = colors;
            this.name = name;
            this.showtime = showtime;
            this.wiederholungen = 1;
        }

        public Panel(string name, List<int> colors, double showtime, int wiederholungen)        //Konstruktor der ein Panel mit Namen, Anzeigezeit und einer gegebenen Liste von Farben erstellt
        {
            this.colors = colors;
            this.name = name;
            this.showtime = showtime;
            this.wiederholungen = wiederholungen;
        }
    }
}
