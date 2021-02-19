using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace LightVisionSettings
{
    public class Client
    {
        private Socket socket;
        private NetworkStream ns;
        private StreamWriter sw;
        private StreamReader sr;

        public Client(string ip, int port)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ip, port);
            ns = new NetworkStream(socket);
            sw = new StreamWriter(ns);
            sr = new StreamReader(ns);
        }

        public string Write(string msg)
        {
            sw.WriteLine(msg);
            sw.Flush();

            return sr.ReadLine();
        }

        public string Read()
        {
            return sr.ReadLine();
        }

    }
}
