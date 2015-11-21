using System;

namespace _03.Larger_Than_Neighbours
{
    class Program
    {
        static void Main()
        {
            int[] numbers = { 1, 3, 4, 5, 1, 0, 5};

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(IsLargerThanNeighbours(numbers, i));
            }
        }

        static string IsLargerThanNeighbours(int[] array, int num)
        {
            if (num > 0)
            {
                // Middle of array.
                if (num < array.Length-1)
                {
                    if (array[num] > array[num+1] && array[num] > array[num-1])
                        {
                            return "True";
                        }
                    else
                        {
                            return "False";
                        }
                }
                // Last element of array.
                else
                {
                    if (array[num] > array[num - 1])
                    {
                        return "True";
                    }
                    else
                    {
                        return "False";
                    }
                }
            }
            // First element of array.
            else
            {
                if (array[num] > array[num + 1])
                {
                    return "True";
                }
                else
                {
                    return "False";
                }
            }
        }
    }
}
