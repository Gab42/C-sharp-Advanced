using System;

namespace _02.Maximal_Sum
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter number of rows and columns:");
            string input = Console.ReadLine();
            int row = int.Parse(input.Split(' ')[0]);
            int col = int.Parse(input.Split(' ')[1]);
            int[][] array = new int[row][];

            Console.WriteLine("Enter array:");
            for (int i = 0; i < row; i++)
            {
                array[i] = new int[col];
                array[i] = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
            }

            var sumArray = new int[3];
            int prevSum = 0;

            for (int i = 0; i <= row - 3; i++)
            {
                for (int j = 0; j <= col - 3; j++)
                {
                   int sum = array[i][j] + array[i][j+1] + array[i][j+2] 
                        + array[i+1][j] + array[i+1][j+1] + array[i+1][j+2]
                        + array[i+2][j] + array[i+2][j+1] + array[i+2][j+2];

                    if (sum >= prevSum)
                    {
                        sumArray[0] = i;
                        sumArray[1] = j;
                        sumArray[2] = sum;
                        prevSum = sum;
                    }
                }
            }

            Console.WriteLine("Sum = " + sumArray[2]);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(array[sumArray[0] + i][sumArray[1] + j] + " ");                    
                }
                Console.WriteLine("");
            }
        }
    }
}
