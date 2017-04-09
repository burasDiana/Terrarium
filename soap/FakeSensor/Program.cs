using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FakeSensor
{
    class Program
    {
        public static void Main(string[] args)
        {


            //Init UDP
            int port = 7000;
            UdpClient UdpServer = new UdpClient() {EnableBroadcast = true};
            IPEndPoint remoteIpEndpoint = new IPEndPoint(IPAddress.Broadcast, port);

            try
            {
                //Init RNG
                Random rand = new Random();

                //Define seed
                int seed = 25;
                int initSeed = seed;

                while (true)
                {
                    //What are we sending
                    var toBeSent = seed + "|" + DateTime.Now.ToString();
                    { Console.ForegroundColor = ConsoleColor.Gray; }
                    Console.WriteLine(seed + "°  | " + DateTime.Now.ToString());

                    //Send the pre-defined data
                    Byte[] sendData = Encoding.ASCII.GetBytes(toBeSent);
                    UdpServer.Send(sendData, sendData.Length, remoteIpEndpoint);
                    { Console.ForegroundColor = ConsoleColor.Green; }
                    Console.WriteLine($"Data Have been broadcasted via UDP | on port:{port} \n"); 

                    int workNumber = rand.Next(10, 20);
                    if (workNumber <= 13)
                    {
                        seed--;
                        Thread.Sleep(10000); //sleep for 5m
                        if (seed <= (initSeed - 5))
                        {
                            { Console.ForegroundColor = ConsoleColor.Red; }
                            Console.WriteLine("Heat lamp turned on...");
                            for (int y = 0; y < 6; y++)
                            {
                                Console.WriteLine(seed);
                                seed++;
                                Thread.Sleep(3000);
                            }
                        }
                    }
                    else if (workNumber > 13 && workNumber <= 16)
                    {
                        Thread.Sleep(10000); //sleep for 5m
                    }
                    else if (workNumber > 16)
                    {
                        seed++;
                        Thread.Sleep(10000); //sleep for 5m
                        if (seed >= (initSeed + 5))
                        {
                            { Console.ForegroundColor = ConsoleColor.Blue; }
                            Console.WriteLine("Terrarium too hot, cooling down...");
                            for (int y = 0; y < 6; y++)
                            {
                                Console.WriteLine(seed);
                                seed--;
                                Thread.Sleep(3000);
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                UdpServer.Close();
                
            }
            Console.ReadKey();
        }
    }
}