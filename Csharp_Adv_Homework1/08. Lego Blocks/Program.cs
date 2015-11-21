using System;
using System.Linq;

namespace _08.Lego_Blocks
{
    class Program
    {
        static void Main()
        {
            int num; 
            num = int.Parse(Console.ReadLine());
            var array1 = new int[num][];
            var array2 = new int[num][];
           
            for (int n = 0; n < num * 2; n++)
            {
                var inputLine = Console.ReadLine().Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse).ToList();

                if (n < num)
                {
                    array1[n] = new int[inputLine.Count];
                    for (int j = 0; j < inputLine.Count; j++)
                    {
                        array1[n][j] = inputLine[j];
                    }
                }
                else
                {
                    array2[n - num] = new int[inputLine.Count];
                    for (int j = 0; j < inputLine.Count; j++)
                    {
                        array2[n - num][j] = inputLine[j];
                    }
                }
               
            }

            /* If the two arrays fit together, reverse the 2nd array, merge it with the 1st array and print the result. 
             * Else, print number of cells in both arrays. 
             */
            if (Fit(array1, array2, num))
            {
                array2 = ReverseJaggedArray(array2, num);
                int[][] arrayMerged = MergeArrays(array1, array2, num);
                PrintMatch(arrayMerged, num);
            }          
            else
            {
                PrintNumCells(array1, array2, num);
            }
        }

        // Methods.


        // Check if the two jagged arrays fit together.
        public static bool Fit( int[][] array1,  int[][] array2,  int num)
        {
            int elemNum = array1[0].Length + array2[0].Length;
            bool check = true;

            for (int i = 0; i < num; i++)
            {
                if (elemNum != array1[i].Length + array2[i].Length)
                {
                    check = false;
                    break;
                }
            }
            return check;
        }

        // Reverse jagged array.
        public static int[][] ReverseJaggedArray(int[][] array, int num)
        {
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < (array[i].Length / 2); j++)
                {
                    int temp = array[i][j];
                    array[i][j] =
                      array[i][array[i].Length - 1 - j];
                    array[i][array[i].Length - 1 - j] = temp;
                }
            }
            return array;
        }

        // Merge two jagged arrays.
        public static int[][] MergeArrays(int[][] array1, int[][] array2, int num)
        {

            int[][] arrayMerged = new int[num * 2][];

            for (int i = 0; i < num; i++)
            {
                int halfLen = array1[i].Length;
                arrayMerged[i] = new int[halfLen + array2[i].Length];
                for (int j = 0; j < halfLen; j++)
                {

                    arrayMerged[i][j] = array1[i][j];
                }
                for (int k = 0; k < array2[i].Length; k++)
                {
                    arrayMerged[i][(halfLen + k)] = array2[i][k];
                }
            }
            return arrayMerged;
        }

        // Print jagged array.
        public static void PrintMatch(int[][] array, int num)
        {
            for (int i = 0; i < num; i++)
            {
                Console.Write('[');

                for (int j = 0; j < array[i].Length; j++)
                {

                    Console.Write(array[i][j]);
                    if (j < (array[i].Length - 1))
                    {
                        Console.Write(", ");
                    }
                    else
                    {
                        Console.WriteLine("]");
                    }
                }
            }
        }

        // Print number of cells in a jagged array.
        public static void PrintNumCells(int[][] array1, int[][] array2, int num)
        {
            int cellCount = 0;
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < array1[i].Length; j++)
                {
                    cellCount += 1;
                }
                for (int k = 0; k < array2[i].Length; k++)
                {
                    cellCount += 1;
                }
            }
            Console.Write("The total number of cells is: " + cellCount);
        }
    }
}


