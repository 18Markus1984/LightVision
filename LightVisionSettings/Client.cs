using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace LightVisionSettings
{
    public class Client
    {
        private Socket socket;
        private NetworkStream ns;
        private StreamReader sr;
        //private Stream s;

        public Client(string ip, int port)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ip, port);
            ns = new NetworkStream(socket);
            sr = new StreamReader(ns);
        }

        public List<Panel> GetPanel()
        {
            string data = "";
            using (sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                sw.Write("getPanel\n");
                sw.Flush();
                data = sr.ReadLine();
            }
            List<string> seperateStrings = ExtensionMethods.getStringInBetween(data, '{', '}');
            List<Panel> panels = new List<Panel>();
            foreach (string s in seperateStrings)
            {
                panels.Add(ExtensionMethods.getPanelFromString(s));
            }
            return panels;
        }

        public void SendPanel(List<Panel> listOfPanel)
         {
            using (StreamWriter sw = new StreamWriter(ns))
            {
                var json = JsonConvert.SerializeObject(listOfPanel);
                sw.WriteLine(json);
                //sw.Flush();
            }
        }
    }
}
