using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace LightVisionSettings
{
    public static class ExtensionMethods
    {
        public static List<string> getStringInBetween(string source, char sep1, char sep2)
        {
            //Die Methode zieht in dem angegebenen Source-String jeden Inhalt zwischen den zwei angegeben Chars heraus

            List<string> results = new List<string>();
            while (source.Contains(sep1) || source.Contains(sep2))  //Solange die Sep. Chars überhaupt noch vorhanden sind
            {
                string buffer = "";
                int start = source.IndexOf(sep1);
                int end = source.IndexOf(sep2);
                buffer = source.Substring(start, end - start);  //Substring zwischen dem ersten Vorkommen der beiden Chars wird extrahiert
                results.Add(buffer);    //Und zum Buffer hinzugefügt
                source = source.Remove(start, end - start + 1); //Vorher rausgezogenes wird entfernt um Dopplungen zu vermeiden
            }
            return results;
        }

        public static Panel getPanelFromString(string source)
        {
            //Die Methode erstellt ein neues Panel Objekt aus einem angegeben Source String im JSON Format
            string name;
            string colors;
            double showtime;
            int wiederholung;
            name = source.Remove(0, 9);
            name = name.Substring(0, name.IndexOf('\"'));   //Substring zum Namen des Panels wird gebildet
            colors = getStringInBetween(source, '[', ']')[0];   //Substring zu den Colors des Panels wird gebildet
            colors = colors.Remove(0,1);
            wiederholung = int.Parse(source.Remove(0, source.LastIndexOf(':') + 1));    //Substring zu den Wiederholungen wird gebildet
            source = source.Remove(source.LastIndexOf(','), source.Length - source.LastIndexOf(','));
            showtime = double.Parse(source.Remove(0, source.LastIndexOf(':') + 1), CultureInfo.InvariantCulture);   //Substring zur Showtime wird gebildet
            return new Panel(name, colors.Split(',').Select(Int32.Parse).ToList(), showtime, wiederholung); //Panel Objekt wird mit den extrahierten Informationen erstellt
        }

        public static string RemoveDigits(string source)
        {
            //Die Methode entfernt sämtliche Zahlen aus dem angegebenen String
            return Regex.Replace(source, @"\d", "");
        }
    }
}
