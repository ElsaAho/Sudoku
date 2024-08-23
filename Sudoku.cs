using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Sudoku
    {
        public static int[,] GenerateSudoku()
        {
            int[,] grid = new int[9,9];
            
            SolveSudoku(grid);

            return grid;
        }

        public static bool IsSafe(int[,] grid, int row, int col, int num)
        {
            for (int i = 0; i < 9; i++)
            {
                if (grid[row, i] == num)
                {
                    return false;
                }
            }

            for (int i = 0;i < 9; i++)
            {
                if (grid[i, col] == num)
                {
                    return false;
                }
            }

            int startRow = (row / 3) * 3;
            int startCol = (col / 3) * 3;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[startRow + i, startCol + j] == num)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        static bool SolveSudoku(int[,] grid)
        {
            Random random = new Random();

            for (int row = 0; row <9; row++)
            {
                for (int col = 0; col <9; col++)
                {
                    if (grid[row, col] == 0)
                    {
                        for (int num = 1; num <= 9; num++)
                        {
                            int luku = random.Next(1, 10);

                            if (IsSafe(grid, row, col, luku))
                            {
                                grid[row, col] = luku;
                                if (SolveSudoku(grid))
                                {
                                    return true;
                                }
                                grid[row, col] = 0;
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }
        public static void RemoveDigits(int[,] array)
        {
            Random random = new Random();
            int numToRemove = random.Next(35, 67);
            for (int i = 0; i < numToRemove; i++)
            {
                int row = random.Next(0, 9);
                int col = random.Next(0, 9);
                array[row, col] = 0;
            }
        }

    }
}
