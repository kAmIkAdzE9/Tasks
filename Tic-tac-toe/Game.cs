using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_tac_toe
{
    class Game
    {
        int size;
        string emptyCell;
        string zero;
        string cross;
        string[,] grid;
        int progress;

        public string[,] getGrid()
        {
            return grid;
        }

        public Game(int size, string emptyCell, string zero, string cross)
        {
            this.size = size;
            this.emptyCell = emptyCell;
            this.zero = zero;
            this.cross = cross;
            progress = 0;
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

            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    if(grid[i, j] == cross) {
                        counter_1++;
                    }

                    if(grid[i, j] == zero) {
                        counter_2++;
                    }
                
                    if(grid[j, i] == cross) {
                        counter_3++;
                    }

                    if(grid[j, i] == zero) {
                        counter_4++;
                    }
                }

                if(grid[i, i] == cross) {
                    counter_5++;
                }

                if(grid[i, i] == zero) {
                    counter_6++;
                }

                if(grid[i, size - i - 1] == cross) {
                    counter_7++;
                }

                if(grid[i, size - i - 1] == zero) {
                    counter_8++;
                }

                if(counter_1 == size || counter_3 == size) {
                    st = "Cross Win!";
                    return st;
                }

                if (counter_2 == size || counter_4 == size) {
                    st = "Zero Win!";
                    return st;
                }

                counter_1 = 0;
                counter_2 = 0;
                counter_3 = 0;
                counter_4 = 0;
            }

            if(counter_5 == size || counter_7 == size) {
                st = "Cross Win!";
                return st;
            }

            if(counter_6 == size || counter_8 == size) {
                st = "Zero Win!";
                return st;
            }

            if(progress == size * size)
            {
                st = "This is draw!";
                return st;
            }

            return st;
        }

        public string makeMove(int rowIndex, int columnIndex)
        {
            string status = "in progress";
            if(checkStatus() != "") {
                status = checkStatus();
                return status;
            }

            if (rowIndex > size || columnIndex > size)
            {
                status = "Some index is out of bounds.";
                return status;
            }

            if(grid[rowIndex, columnIndex] != emptyCell) {
                status = "The cell [" + rowIndex + ", " + columnIndex + "] is used. It is " + grid[rowIndex, columnIndex];
            }

            if(progress % 2 != 0)
            {
                if (grid[rowIndex, columnIndex] == emptyCell)
                {
                    grid[rowIndex, columnIndex] = zero;
                    progress++;
                    status = "Zero was set in [" + rowIndex + ", " + columnIndex + "] cell.";
                }
            }
            else
            {
                if(grid[rowIndex, columnIndex] == emptyCell)
                {
                    grid[rowIndex, columnIndex] = cross;
                    progress++;
                    status = "Cross was set in [" + rowIndex + ", " + columnIndex + "] cell.";
                }      
            }
            status = status + "\n" + checkStatus();
            return status;        
        }
    }
}