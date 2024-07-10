using System;
using System.IO;

using Newtonsoft;
using Newtonsoft.Json;


using System.Net.Http;
using System.Net;
using System.Net.Sockets;

using System.Threading.Tasks;

namespace Primero_Help_XD_Server
{
    internal class Program
    {
        private static TcpListener myListener;
        private static int port = 6969;
        private static IPAddress localAddr = IPAddress.Parse("localhost");
        static void Main(string[] args)
        {
            myListener = new TcpListener(localAddr, port);
            myListener.Start();
            Console.WriteLine($"Web Server Running on {localAddr.ToString()} on port {port}... Press ^C to Stop...");
            Thread th = new Thread(new ThreadStart(PrimeroServer));
            th.Start();
        }
        public static void PrimeroServer() {
            while (true)
            {
                TcpClient client = myListener.AcceptTcpClient();
                NetworkStream stream = client.GetStream();

                client.Close();
            }
        }

    }
    
}
