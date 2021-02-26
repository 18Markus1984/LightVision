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
        private Stream s;

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

        public string GetPanel()
        {
            using (StreamWriter sw = new StreamWriter(ns))
            {
                sw.Write(Encoding.ASCII.GetBytes("getPanel"));
                sw.Flush();
            }
            return sr.ReadToEnd();
        }
        
        public string Read()
        {
            return sr.ReadLine();
        }

    }
}
