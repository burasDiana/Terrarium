using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UDPReceiver.TempWebserviceCloud;

namespace UDPReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 7000;
            //IPAddress ip = IPAddress.Parse(IPAddress.Any);

            UdpClient udpClient = new UdpClient(port);
            IPEndPoint remoteIpEndpoint = new IPEndPoint(IPAddress.Any, port);
            //udpClient.Connect(remoteIpEndpoint);

            //init the Webservice
            TempWebserviceCloud.Service1Client ts = new Service1Client("BasicHttpBinding_IService1");
            while (true)
            {
                { Console.ForegroundColor = ConsoleColor.Green; }
                Console.WriteLine("Waiting for broadcast on port: {0}", port);
                Byte[] recievedBytes = udpClient.Receive(ref remoteIpEndpoint);
                string recievedData = Encoding.ASCII.GetString(recievedBytes);

                int temp;
                string time;

                TextReader tr = new StringReader(recievedData);

                var str1 = tr.ReadLine();
                temp = Convert.ToInt32(str1.Split('|')[0]);
                time = str1.Split('|')[1];

                //Upload data to WS
                var potato = new TemperatureLog();
                potato.Timestamp = time;
                potato.Temperature = temp;
                ts.AddData(potato);
                Console.WriteLine($"Your data: (Temp:{temp} & Time:{time}) have been uploaded to the database, via SOAP webservice");

                { Console.ForegroundColor = ConsoleColor.Cyan; }
                Console.WriteLine(temp + " | " + time + "\n");
                
            }
            ts.Close();
        }
    }
}
