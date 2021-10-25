using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Tic_tac_toe
{
    public class ServerConnection
    {
        private static TcpClient GetTcpClient(TcpListener server)
        {
            return server.AcceptTcpClient();
        }
        public static void ConnectToServer(string[] args)
        {
            TcpListener server = null;
            string emptyCell = "-";
            string zero = "0";
            string cross = "x";
            int size = 3;
            bool flag = true;
            Game game = new Game(size, emptyCell, zero, cross);
            try
            {
                IPAddress localAddr = IPAddress.Parse(args[0]);
                Int32 port = Int32.Parse(args[1]);

                server = new TcpListener(localAddr, port);

                server.Start();

                String data = null;
                while (true)
                {
                    Console.Write("Waiting for a connection... ");

                    TcpClient client1 = GetTcpClient(server);
                    NetworkStream stream1 = client1.GetStream();
                    StreamReader reader1 = new StreamReader(stream1);
                    StreamWriter writer1 = new StreamWriter(stream1);
                    Console.WriteLine("Connected");
                    TcpClient client2 = GetTcpClient(server);
                    NetworkStream stream2 = client2.GetStream();
                    StreamReader reader2 = new StreamReader(stream2);
                    StreamWriter writer2 = new StreamWriter(stream2);
                    Console.WriteLine("Connected");

                    StreamReader reader = reader1;

                    data = null;
                    Console.WriteLine(reader1.Equals(reader2));
                    while (true)
                    {
                        data = reader.ReadLine();
                        if (!flag)
                        {
                            reader = reader1;
                        }
                        else
                        {
                            reader = reader2;
                        }
                        flag = !flag;
                        Console.WriteLine("Received: {0}", data);
                        string response = Game.PlayGame(data, game);
                        writer1.WriteLine(response);
                        writer1.Flush();
                        Console.WriteLine("Sent: {0}", response);

                        writer2.WriteLine(response);
                        writer2.Flush();
                        Console.WriteLine("Sent: {0}", response);
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                server.Stop();
            }

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }
    }
}