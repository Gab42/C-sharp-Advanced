using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Matrix_shuffling
{
    class Program
    {
        static void Main()
        {
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

            var list = new List<int>();
            var tempList = new List<string>();
            Console.WriteLine("Enter matrix:");

            while (list.Count < row*col)
            {
                tempList = Console.ReadLine().Split(' ').ToList();
                foreach (string item in tempList)
                {
                    list.Add(int.Parse(item));
                }
                tempList = new List<string>();
            }

            string input = "";
            while (input != "END")
            {                
                input = Console.ReadLine();
                List<string> listInput = input.Split(' ').ToList();
                if (listInput[0].Equals("swap") && listInput.Count == 5)
                {
                    //do stuff
                    int elem1Pos = int.Parse(listInput[1]) * col + int.Parse(listInput[2]);
                    int elem2Pos = int.Parse(listInput[3]) * col + int.Parse(listInput[4]);

                    int tempSwap = list[elem2Pos];
                    list[elem2Pos] = list[elem1Pos];
                    list[elem1Pos] = tempSwap;
                    int rowCounter = 0;
                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.Write(list[i]);
                        
                        if (i % ((col-1) + rowCounter*col) == 0 && i != 0)
                        {
                            Console.WriteLine();
                            rowCounter++;
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }

                }
                else if (input == "END")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                }
            }
        }
    }
}
