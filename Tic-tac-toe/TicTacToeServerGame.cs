using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Tic_tac_toe
{
    public class TicTacToeServerGame
    {
        private static string MakeMove(string input, Game game)
        {
            string output = "";
            string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int x = 0;
            int y = 0;
            try {
                x = int.Parse(data[0]);
                y = int.Parse(data[1]);
            }
            catch {
                output = "Input error!";
                return output;
            }
            if (!game.IsGameEnd())
            {
                output = game.makeMove(x, y);
                output += "\n" + game.getStringOfGrid(game.getGrid(), game.getSize());
            }
            return output;
        }

        public static void PlayGame(string[] args)
        {
            TcpListener server = null;
            Game game = new Game();
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

                    TcpClient client1 = server.AcceptTcpClient();
                    NetworkStream stream1 = client1.GetStream();
                    StreamReader reader1 = new StreamReader(stream1);
                    StreamWriter writer1 = new StreamWriter(stream1);
                    Console.WriteLine("Connected");

                    TcpClient client2 = server.AcceptTcpClient();
                    NetworkStream stream2 = client2.GetStream();
                    StreamReader reader2 = new StreamReader(stream2);
                    StreamWriter writer2 = new StreamWriter(stream2);
                    Console.WriteLine("Connected");

                    StreamReader reader = reader1;

                    data = null;
                    while (true)
                    {
                        if(game.IsGameEnd()) {

                            server.Stop();
                            client1.Close();
                            client2.Close();
                            reader.Close();
                            reader1.Close();
                            reader2.Close();
                            writer1.Close();
                            writer2.Close();
                            return;
                        }
                  
                        reader = game.IsFirstPlayer() ? reader1 : reader2;
                        Console.WriteLine(game.IsFirstPlayer());

                        data = reader.ReadLine();
                        Console.WriteLine("Received: ", data);
                        string response = MakeMove(data, game);
                        Console.WriteLine(response);

                        writer1.WriteLine(response);
                        writer1.Flush();
                        
                        writer2.WriteLine(response);
                        writer2.Flush();
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