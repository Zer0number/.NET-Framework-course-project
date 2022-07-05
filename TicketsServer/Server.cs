using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketsServer
{
    class Server
    {
        TcpListener listener;
        int port = 25555;
        string ip = "127.0.0.1";

        public Server()
        {
            listener = new TcpListener(new IPEndPoint(IPAddress.Parse(ip), port));
        }

        public void Start(ListBox listBox)
        {
            listener.Start();
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                listBox.Items.Add($"Client {client.Client.RemoteEndPoint} connected at {DateTime.Now.ToShortTimeString()}");
                Task.Run(() => HandleClient(client));
            }
        }

        private void HandleClient(TcpClient client)
        {
            string endPoint = client.Client.RemoteEndPoint.ToString();
            NetworkStream ns = client.GetStream();
            StreamReader reader = new StreamReader(ns);
            using(StreamWriter writer = new StreamWriter(ns))
            {
                while (true)
                {
                    string message = reader.ReadLine();
                    if (message.Contains("get"))
                    {

                    }
                }
            }
        }
    }
}
