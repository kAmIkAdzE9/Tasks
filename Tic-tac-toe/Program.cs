using System;

namespace Tic_tac_toe
{
    class Program
    {
        static void PrintGrid(string[,] grid, int size) {
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void PlayGame(int size, string emptyCell, string zero, string cross, int[,] scenario, int n) {
            Game game = new Game(size, emptyCell, zero, cross);

            for(int i = 0; i < n; i++) {
                Console.WriteLine(game.makeMove(scenario[i, 0], scenario[i, 1]));
            }
           
            string[,] grid = game.getGrid();
            PrintGrid(grid, size);
        }
        static void Main(string[] args)
        {
            string emptyCell = "0";
            string zero = "1";
            string cross = "2";
            int size = 3;

            int[,] scenario = {{1,1}, {0, 1}, {0, 0}, {2, 2}, {2, 0}, {1, 0}, {0, 2}};
            int[,] scenario_2 = {{0, 0}, {1, 1}, {0, 1}, {1, 2}, {0, 2}};
            int[,] scenario_3 = {{0, 0}, {0, 1}, {1, 1}, {0, 2}, {1, 1}, {1, 2}};

            PlayGame(size, emptyCell, zero, cross, scenario_3, 6);
        }
    }
}
