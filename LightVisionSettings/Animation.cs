using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightVisionSettings
{
    public class Animation
    {
        public Panel[] animation;       //Liste von Panels
        public double showtime;         //Anzeigezeit für die Panels
        public int numberOfPanels;      //Anzahl der Panels bzw. animation.Length
        public string name;             //Name der Animation
        public int wiederholungen;      //Anzahl der Wiederholungen der Animation

        public Animation(string name,int numberOfPanels, double showtime)       //Konstruktor für das Erstellen eines Panels ohne eine Farbe zu wissen
        {
            this.numberOfPanels = numberOfPanels;
            this.name = name;
            animation = new Panel[numberOfPanels];
            this.showtime = showtime;
            this.wiederholungen = 1;
            for (int i = 0; i < numberOfPanels; i++)
            {
                animation[i] = new Panel(name + i, showtime);
            }
        }

        public Animation(string name, int numberOfPanels, double showtime, Panel[] panels)      //Konstruktor für das Erstellen eines Panels mit einem Array von Panels
        {
            this.numberOfPanels = numberOfPanels;
            this.name = name;
            this.showtime = showtime;
            this.wiederholungen = 1;
            if (panels.Length == numberOfPanels)        //Hier wird überprüft, ob die Anzahl der eingegebenen Liste mit dem Array übereinstimmt
            {
                animation = panels;
            }
            else        //Ansonstens werden nur die anfänglichen Panels der Liste verwendet
            {
                animation = new Panel[numberOfPanels];
                for (int i = 0; i < numberOfPanels; i++)
                {
                    animation[i] = panels[i];
                }
            }
        }

        public Animation(string name, int numberOfPanels, double showtime, List<Panel> panels, int wiederholungen)      //Konstruktor für das Erstellen eines Panels mit einer Liste von Panels
        {
            this.numberOfPanels = numberOfPanels;
            this.name = name;
            this.showtime = showtime;
            this.wiederholungen = wiederholungen;
            if (panels.Count == numberOfPanels)     //Hier wird überprüft, ob die Anzahl der eingegebenen Liste mit dem Array übereinstimmt
            {
                animation = panels.ToArray();
            }
            else        //Ansonstens werden nur die anfänglichen Panels der Liste verwendet
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
