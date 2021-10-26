using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_tac_toe
{
    class Game
    {
        int size = 3;
        string emptyCell = "-";
        string zero = "0";
        string cross = "x";
        string[,] grid;
        bool status = false;
        bool activePlayer = true;
        int progress = 0;

        public string[,] getGrid()
        {
            return grid;
        }

        public bool IsGameEnd()
        {
            return status;
        }

        public bool IsFirstPlayer()
        {
            return activePlayer;
        }

        public int getSize()
        {
            return size;
        }

        public Game()
        {
            generateGrid();
        }

        public Game(int size)
        {
            if (size > 3)
            {
                this.size = size;
            }
            generateGrid();
        }
        public Game(int size, string emptyCell, string zero, string cross)
        {
            if (size > 3)
            {
                this.size = size;
            }

            this.emptyCell = emptyCell;
            this.zero = zero;
            this.cross = cross; ;
            generateGrid();
        }


        private void generateGrid()
        {
            grid = new string[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[i, j] = emptyCell;
                }
            }
        }

        public string getStringOfGrid(string[,] grid, int size)
        {
            string output = "";
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    output += grid[i, j] + " ";
                }
                output += "\n";
            }
            return output;
        }

        private string checkStatus()
        {
            string st = "";
            int counter_1 = 0;
            int counter_2 = 0;
            int counter_3 = 0;
            int counter_4 = 0;
            int counter_5 = 0;
            int counter_6 = 0;
            int counter_7 = 0;
            int counter_8 = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (grid[i, j] == cross)
                    {
                        counter_1++;
                    }

                    if (grid[i, j] == zero)
                    {
                        counter_2++;
                    }

                    if (grid[j, i] == cross)
                    {
                        counter_3++;
                    }

                    if (grid[j, i] == zero)
                    {
                        counter_4++;
                    }
                }

                if (grid[i, i] == cross)
                {
                    counter_5++;
                }

                if (grid[i, i] == zero)
                {
                    counter_6++;
                }

                if (grid[i, size - i - 1] == cross)
                {
                    counter_7++;
                }

                if (grid[i, size - i - 1] == zero)
                {
                    counter_8++;
                }

                if (counter_1 == size || counter_3 == size)
                {
                    st = "Cross Win!";
                    status = true;
                    return st;
                }

                if (counter_2 == size || counter_4 == size)
                {
                    st = "Zero Win!";
                    status = true;
                    return st;
                }

                counter_1 = 0;
                counter_2 = 0;
                counter_3 = 0;
                counter_4 = 0;
            }

            if (counter_5 == size || counter_7 == size)
            {
                st = "Cross Win!";
                status = true;
                return st;
            }

            if (counter_6 == size || counter_8 == size)
            {
                st = "Zero Win!";
                status = true;
                return st;
            }

            if (progress == size * size)
            {
                st = "This is draw!";
                status = true;
                return st;
            }

            return st;
        }

        public string makeMove(int rowIndex, int columnIndex)
        {
            string output = "";
            if (checkStatus() != "")
            {
                output = checkStatus();
                return output;
            }

            if (rowIndex > size || columnIndex > size)
            {
                output = "Some index is out of bounds.";
                return output;
            }

            if (grid[rowIndex, columnIndex] != emptyCell)
            {
                output = "The cell [" + rowIndex + ", " + columnIndex + "] is used. It is " + grid[rowIndex, columnIndex];
                return output;
            }

            if (progress % 2 != 0)
            {
                if (grid[rowIndex, columnIndex] == emptyCell)
                {
                    grid[rowIndex, columnIndex] = zero;
                    progress++;
                    output = "Zero was set in [" + rowIndex + ", " + columnIndex + "] cell.";
                    activePlayer = !activePlayer;
                }
            }
            else
            {
                if (grid[rowIndex, columnIndex] == emptyCell)
                {
                    grid[rowIndex, columnIndex] = cross;
                    progress++;
                    output = "Cross was set in [" + rowIndex + ", " + columnIndex + "] cell.";
                    activePlayer = !activePlayer;
                }
            }

            output = output + "\n" + checkStatus();
            return output;
        }
    }
}