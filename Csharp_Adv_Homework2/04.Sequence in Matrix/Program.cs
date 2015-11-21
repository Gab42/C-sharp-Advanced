using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Sequence_in_Matrix
{
    class Program
    {
        static void Main()
        {
            var list = new List<List<string>>();

            Console.WriteLine("Enter number of rows and columns:");
            string s = Console.ReadLine();
            int row, col;

            if (s.Split(' ').Length < 2)
            {
                row = int.Parse(s.Split(' ')[0]);
                Console.WriteLine("Enter number of columns:");
                col = int.Parse(Console.ReadLine());
            }
            else
            {
                row = int.Parse(s.Split(' ')[0]);
                col = int.Parse(s.Split(' ')[1]);
            }

            var array = new string[row][];
            Console.WriteLine("Enter matrix:");
            for (int i = 0; i<row; i++)
            {
                array[i] = new string[col];
                array[i] = Console.ReadLine().Split(' ').ToArray();
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                   list.Add(Diag(array, ref row, ref col, i, j));
                   list.Add(DiagRev(array, ref row, ref col, i, j));
                   list.Add(Vertical(array, ref row, ref col, i, j));
                   list.Add(Horizontal(array, ref row, ref col, i, j));
                }
            }

            var max = list[0].Count;
            int pos = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Count > max)
                {
                    max = list[i].Count;
                    pos = i;
                }
            }

            Console.WriteLine();
            int counter = 0;

            foreach (string item in list[pos])
            {
                if (counter < list[pos].Count - 1)
                {
                    Console.Write(item + ", ");
                }
                else
                {
                    Console.Write(item);
                }
                counter++;
            }
        }

        static List<string> Diag(string[][] array, ref int row, ref int col, int startRow, int startCol)
        {
            var tmpList = new List<string>();
            tmpList.Add(array[startRow][startCol]);
            int j = startCol+1;
            int listElem = 0;

            for (int i = startRow+1; i < row; i++)
            {
                if (j < col)
                {
                    if (tmpList[listElem].Equals(array[i][j]))
                    {
                        tmpList.Add(array[i][j]);
                    }
                    else
                    {
                        break;
                    }
                    j++;
                }
            }
            return tmpList;
        }

        static List<string> DiagRev(string[][] array, ref int row, ref int col, int startRow, int startCol)
        {
            var tmpList = new List<string>();
            tmpList.Add(array[startRow][startCol]);
            int j = startCol-1;
            int listElem = 0;

            if (startRow + 1 > row)
            {
                return tmpList;
            }

            for (int i = startRow+1; i < row; i++)
            {
                if (j >= 0)
                {
                    if (tmpList[listElem].Equals(array[i][j]))
                    {
                        tmpList.Add(array[i][j]);
                    }
                    else
                    {
                        break;
                    }
                    j--;
                }
            }
            return tmpList;
        }

        static List<string> Vertical(string[][] array, ref int row, ref int col, int startRow, int startCol)
        {
            var tmpList = new List<string>();
            tmpList.Add(array[startRow][startCol]);
            int listElem = 0;
            if (startRow+1 >= row)
            {
                return tmpList;
            }
            for (int i = startRow+1; i < row; i++)
            {
                if (tmpList[listElem].Equals(array[i][startCol]))
                {
                    tmpList.Add(array[i][startCol]);
                }  
                else
                {
                    break;
                }            
            }
            return tmpList;
        }

        static List<string> Horizontal(string[][] array, ref int row, ref int col, int startRow, int startCol)
        {
            var tmpList = new List<string>();
            tmpList.Add(array[startRow][startCol]);
            int listElem = 0;
            if (startCol + 1 >= col)
            {
                return tmpList;
            }

            for (int j = startCol + 1; j < col; j++)
            {
                if (tmpList[listElem].Equals(array[startRow][j]))
                {
                    tmpList.Add(array[startRow][j]);
                }
                else
                {
                    break;
                }
                // array[startRow][i];
            }
            return tmpList;
        }

    }
}
