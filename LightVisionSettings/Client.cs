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

        public string Write(List<int> msg)
        {
            var json = JsonConvert.SerializeObject(msg);
            using (StreamWriter sw = new StreamWriter(ns))
            {
                sw.Write(json);
                sw.Flush();
            }
            return sr.ReadLine();
        }

        public List<Panel> GetPanel()
        {
            using (sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                sw.Write("getPanel");
                sw.Flush();
                //var data = sr.ReadToEndAsync();
                byte[] data = new byte[2048];
                int bytesRead = ns.Read(data, 0, data.Length);
            }
            //JsonConvert.DeserializeObject(sr.ReadLine());
            return null;
        }

        public void SendPanel(List<Panel> listOfPanel)
        {
            using (StreamWriter sw = new StreamWriter(ns))
            {
                var json = JsonConvert.SerializeObject(listOfPanel);
                sw.Write(json);
                sw.Flush();
            }
        }
    }
}
