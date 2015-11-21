using System;
using System.Linq;

namespace _01.Sort_Array_of_Numbers
{
    class Program
    {
        static void Main()
        {
            int[] intArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Array.Sort(intArray);
            foreach (int item in intArray)
            {
                Console.Write(item + " ");
            }
        }
    }
}
