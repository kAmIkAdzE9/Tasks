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

        static void PlayGameWithScenario(int size, string emptyCell, string zero, string cross, int[,] scenario)
        {
            Game game = new Game(size, emptyCell, zero, cross);

            for (int i = 0; i < scenario.GetLength(0); i++)
            {
                Console.WriteLine(game.makeMove(scenario[i, 0], scenario[i, 1]));
            }

            string[,] grid = game.getGrid();
            PrintGrid(grid, size);
        }

        static void Main(string[] args)
        {
            string emptyCell = "-";
            string zero = "0";
            string cross = "x";
            int size = 3;
            Game game = new Game(size, emptyCell, zero, cross);

            //int[,] scenario = { { 1, 1 }, { 0, 1 }, { 0, 0 }, { 2, 2 }, { 2, 0 }, { 1, 0 }, { 0, 2 } };          
            //int[,] scenario_2 = { { 0, 0 }, { 1, 1 }, { 0, 1 }, { 1, 2 }, { 0, 2 } };
            //int[,] scenario_3 = { { 0, 0 }, { 0, 1 }, { 1, 1 }, { 0, 2 }, { 2, 2 }, { 1, 2 } };
            //int[,] scenario_4 = { { 0, 2 }, { 0, 1 }, { 1, 1 }, { 0, 0 }, { 2, 0 } };
            //int[,] scenario_5 = { { 0, 1 }, { 0, 2 }, { 1, 1 }, { 1, 2 }, { 2, 1 } };
            //int[,] scenario_6 = { { 10, 0 }, { 0, 10 }, { 1, 1 } };
            //int[,] scenario_7 = { { 0, 1 }, { 0, 0 }, { 0, 2 }, { 1, 1 }, { 1, 2 }, { 2, 2 } };
            //int[,] scenario_8 = { { 1, 1 }, { 0, 0 }, { 0, 2 }, { 2, 0 }, { 1, 0 }, { 1, 2 }, { 0, 1 }, { 2, 1 }, { 2, 2 } };
            //PlayGameWithScenario(size, emptyCell, zero, cross, scenario_3);


            String[] input = { "127.0.0.1", "12345" };
            TicTacToeServerGame.PlayGame(input); 
            Console.WriteLine();
        }
    }
}
