using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.First_Larger_Than_Neighbours
{
    class Program
    {
        static void Main()
        {
            int[] numbers = { 1, 3, 4, 5, 1, 0, 5 };
            Console.WriteLine(IsLargerThanNeighbours(numbers));

        }


        static int IsLargerThanNeighbours(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i > 0)
                {
                    if (i < array.Length - 1)
                    {
                        if (array[i] > array[i + 1] && array[i] > array[i - 1])
                        {
                            return i;
                        }
                    }
                    else
                    {
                        if (array[i] > array[i - 1])
                        {
                            return i;
                        }
                    }
                }
                else
                {
                    if (array[i] > array[i + 1])
                    {
                        return i;
                    }
                }
            }
                return -1;
        }
    }
}
