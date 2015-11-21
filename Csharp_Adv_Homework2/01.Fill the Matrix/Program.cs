using System;
using System.Linq;

namespace _01.Fill_the_Matrix
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter number of rows/columns:");
            int n = int.Parse(Console.ReadLine());
            int m = n;

            PrintArray(PatternA(n, m));
            PrintArray(PatternB(n, m));
        }

        static int[,] PatternA(int n, int m)
        {
            int[,] matrix = new int[n, m];
            int val = 1;
            // check - protection for iterating the same [row,col] more than once at end of row.
            bool check = true;
            int row = 0;
            int col = 0;

            for (int i = 0; i < n * m; i++)
            {
                matrix[row, col] = val;
                val++;

                // If at last element of the row, go to next row and reverse direction.
                if (((col > 0 && (row == 0 || row == n - 1)) || (col == 0 && (row == n - 1))) && check)
                {
                    col++;
                    row = 0;
                    check = false;
                }
                else
                {
                    check = true;
                    row++;
                }
            }
            return matrix;
        }

        static int[,] PatternB(int n, int m)
        {
            int[,] matrix = new int[n, m];
            int val = 1;
            // rev == false (top to bottom); rev == true (bottom to top).
            bool rev = false;
            // check - protection for iterating the same [row,col] more than once at end of row.
            bool check = true;
            int row = 0;
            int col = 0;

            for (int i = 0; i < n * m; i++)
            {
                matrix[row, col] = val;
                val++;

                // If at last element of the row, go to next row and reverse direction.
                if (((col > 0 && (row == 0 || row == n - 1)) || (col == 0 && (row == n - 1))) && check)
                {
                    col++;
                    rev = !rev;
                    check = false;
                }
                else
                {
                    check = true;

                    // Top to bottom.
                    if (!rev)
                    {
                        row++;
                    }
                    // Bottom to top.
                    else
                    {
                        row--;
                    }
                }
            }
            return matrix;
        }

        static void PrintArray(int[,] array)
        { 
            int row = array.GetLength(0);
            int col = array.GetLength(1);
            double max = Math.Floor(Math.Log10(array.Cast<int>().Max())) + 1;

            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    for (int ws = 1; ws <= ( max - Math.Floor( Math.Log10(array[r, c] ))); ws++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(array[r, c]);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }
    }
}
    