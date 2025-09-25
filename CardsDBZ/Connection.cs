using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static CardsDBZ.Functions;

namespace CardsDBZ
{
    class Connection
    {
        public List<TcpClient> clients;
        public List<StreamReader> readers;
        public List<StreamWriter> writers;

        public Connection()
        {
            clients = new List<TcpClient>();
            readers = new List<StreamReader>();
            writers = new List<StreamWriter>();
        }
        public static string MyLocalIp()
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    return address.ToString();
                }
            }
            return null;
        }
        public void Host(int port)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            TcpClient client = listener.AcceptTcpClient();
            StreamReader Str = new StreamReader(client.GetStream());
            StreamWriter Stw = new StreamWriter(client.GetStream());
            Stw.AutoFlush = true;

            clients.Add(client);
            readers.Add(Str);
            writers.Add(Stw);

            listener.Stop();
        }
        public void Join(int port, string ip)
        {
            TcpClient client = new TcpClient();
            IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse(ip), port);

            try
            {
                client.Connect(IpEnd);
                StreamWriter Stw = new StreamWriter(client.GetStream());
                StreamReader Str = new StreamReader(client.GetStream());
                Stw.AutoFlush = true;

                clients.Add(client);
                readers.Add(Str);
                writers.Add(Stw);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Message Receive(int clientId)
        {
            try
            {
                string receive = readers[clientId].ReadLine();
                Message msj = StringToObject<Message>(receive);
                if (msj == null)
                {
                    throw new Exception("Messaje not received");
                }
                return msj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Send(Message msj, int clientId)
        {
            //Sending message to a client
            if (clients[clientId].Connected)
            {
                writers[clientId].WriteLine(ObjectToString(msj));
            }
        }
        public void Send(Message msj)
        {
            //Sending message to the server
            if (clients[0].Connected)
            {
                writers[0].WriteLine(ObjectToString(msj));
            }
        }
    }
}
