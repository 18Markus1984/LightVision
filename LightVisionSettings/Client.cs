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
            //Connection zum Server wird hergestellt und der Network-Stream erstellt
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ip, port);
            ns = new NetworkStream(socket);
            sr = new StreamReader(ns);
        }

        public List<Panel> GetPanel()       //Die DAten werden vom Server abgerufen
        {
            //Die Methode sendet ein getPanel an den Server und erstellt aus dem empfangenen JSON die verschiedenen Panel Objekte um sie anzuzeigen und zu bearbeiten
            string data = "";
            using (sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                sw.Write("getPanel\n");
                sw.Flush();
                data = sr.ReadLine();
            }
            List<string> seperateStrings = ExtensionMethods.getStringInBetween(data, '{', '}'); //Die JSON Strings für jedes einzelne Panel werden getrennt
            List<Panel> panels = new List<Panel>();
            foreach (string s in seperateStrings)
            {
                panels.Add(ExtensionMethods.getPanelFromString(s)); //Die Panel Objekte werden aus den einzelnen Strings der Panel erstellt
            }
            socket.Close(); //Verbindung zum Server wird sauber getrennt
            return panels;  //Panels werden zurückgegeben
        }

        public void SendPanel(List<Panel> listOfPanel)      
        {
            //Die Methode konvertiert die übergebenen Panel zu JSON und sendet diese nachfolgend an den Server
            using (StreamWriter sw = new StreamWriter(ns))
            {
                var json = JsonConvert.SerializeObject(listOfPanel);
                sw.WriteLine(json);
                sw.Flush();
            }
            socket.Close(); //Verbindung zum Server wird sauber getrennt
        }
    }
}
