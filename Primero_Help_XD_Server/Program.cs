using System;
using System.IO;

using Newtonsoft;
using Newtonsoft.Json;


using System.Net.Http;
using System.Net;
using System.Net.Sockets;

using System.Threading.Tasks;
using System.Text.Json.Nodes;

namespace Primero_Help_XD_Server
{
    internal class Program
    {
        private static TcpListener myListener;
        private static int port = 6969;
        private static IPAddress localAddr = IPAddress.Parse("0.0.0.0");

        static void Main(string[] args)
        {
            myListener = new TcpListener(localAddr,port);
            myListener.Start();
            Console.WriteLine($"Web Server Running on {localAddr.ToString()} on port {port}... Press ^C to Stop...");
            Thread th = new Thread(new ThreadStart(PrimeroServer));
            th.Start();
        }
        public static void PrimeroServer() {
            while (true)
            {
                using (TcpClient client = myListener.AcceptTcpClient())
                using (NetworkStream stream = client.GetStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    string json = sr.ReadToEnd();
                    Console.WriteLine(json);
                    var Response = JsonConvert.DeserializeObject<string>(json);



                    // Process the request (e.g., handle JSON deserialization)
                    string response = $"Received: {Response}";

                    // Send the response back to the client
                    byte[] responseData = System.Text.Encoding.ASCII.GetBytes(response);
                    stream.Write(responseData, 0, responseData.Length);
                    Console.WriteLine($"Sent response: {response}");

                    client.Close();
                }
            }
        }

    }
    
}
