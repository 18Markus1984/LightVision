using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            name = source.Remove(0, 9);
            name = name.Substring(0, name.IndexOf('\"'));
            colors = getStringInBetween(source, '[', ']')[0];
            colors = colors.Remove(0,1);
            colors = colors.Remove(colors.Length - 1, 1);
            return new Panel(name, colors.Split(',').Select(Int32.Parse).ToList());
        }
    }
}
