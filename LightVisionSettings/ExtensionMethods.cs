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
            List<string> results = new List<string>();
            while (source.Contains(sep1) || source.Contains(sep2))
            {
                string buffer = "";
                int start = source.IndexOf(sep1);
                int end = source.IndexOf(sep2);
                buffer = source.Substring(start, end - start);
                results.Add(buffer);
                source = source.Remove(start, end - start + 1);
            }
            return results;
        }

        public static Panel getPanelFromString(string source)
        {
            string name;
            string colors;
            double showtime;
            name = source.Remove(0, 9);
            name = name.Substring(0, name.IndexOf('\"'));
            colors = getStringInBetween(source, '[', ']')[0];
            colors = colors.Remove(0,1);
            showtime = double.Parse(source.Remove(0, source.LastIndexOf(':') + 1), CultureInfo.InvariantCulture);
            //colors = colors.Remove(colors.Length - 1, 1);
            return new Panel(name, colors.Split(',').Select(Int32.Parse).ToList(), showtime);
        }
        public static string RemoveDigits(string source)
        {
            return Regex.Replace(source, @"\d", "");
        }
    }
}
