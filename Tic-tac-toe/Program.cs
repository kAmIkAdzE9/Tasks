using System;

namespace Tic_tac_toe
{
    class Program
    {
        static void PrintGrid(string[,] grid, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void PlayGame(int size, string emptyCell, string zero, string cross, int[,] scenario)
        {
            Game game = new Game(size, emptyCell, zero, cross);

            for (int i = 0; i < scenario.GetLength(0); i++)
            {
                Console.WriteLine(game.makeMove(scenario[i, 0], scenario[i, 1]));
            }

            string[,] grid = game.getGrid();
            PrintGrid(grid, size);
        }

        static void PlayGame_2(int size, string emptyCell, string zero, string cross)
        {
            Game game = new Game(size, emptyCell, zero, cross);
            while (!game.getStatus())
            {           
                try {
                    Console.WriteLine("Enter the coordinates. X: ");               
                    int x = int.Parse(Console.ReadLine());

                    Console.WriteLine("Y: ");
                    int y = int.Parse(Console.ReadLine());

                    Console.WriteLine(game.makeMove(x, y));
                    PrintGrid(game.getGrid(), size);
                }
                catch {
                    Console.WriteLine("Input error");
                }                
            }
        }

        static void Main(string[] args)
        {
            string emptyCell = "0";
            string zero = "1";
            string cross = "2";
            int size = 3;

            //int[,] scenario = { { 1, 1 }, { 0, 1 }, { 0, 0 }, { 2, 2 }, { 2, 0 }, { 1, 0 }, { 0, 2 } };          
            //int[,] scenario_2 = { { 0, 0 }, { 1, 1 }, { 0, 1 }, { 1, 2 }, { 0, 2 } };
            //int[,] scenario_3 = { { 0, 0 }, { 0, 1 }, { 1, 1 }, { 0, 2 }, { 2, 2 }, { 1, 2 } };
            //int[,] scenario_4 = { { 0, 2 }, { 0, 1 }, { 1, 1 }, { 0, 0 }, { 2, 0 } };
            //int[,] scenario_5 = { { 0, 1 }, { 0, 2 }, { 1, 1 }, { 1, 2 }, { 2, 1 } };
            //int[,] scenario_6 = { { 10, 0 }, { 0, 10 }, { 1, 1 } };
            //int[,] scenario_7 = { { 0, 1 }, { 0, 0 }, { 0, 2 }, { 1, 1 }, { 1, 2 }, { 2, 2 } };
            //int[,] scenario_8 = { { 1, 1 }, { 0, 0 }, { 0, 2 }, { 2, 0 }, { 1, 0 }, { 1, 2 }, { 0, 1 }, { 2, 1 }, { 2, 2 } };
            //PlayGame(size, emptyCell, zero, cross, scenario_4);

            PlayGame_2(size, emptyCell, zero, cross);
        }
    }
}
