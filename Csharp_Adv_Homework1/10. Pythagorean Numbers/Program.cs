using System;

namespace _10.Pythagorean_Numbers
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(array);
            
            // Check if there are any pythagorean tuples at all.
            bool check = false;

            for (int i = 0; i < n; i++)
            {
                int a = array[i] * array[i];
                for (int j = i; j < n; j++)
                {
                    int b = array[j] * array[j];

                    // Check if any of the tuples match the formula with array[i] and array[j]
                    for (int k = 0; k < n; k++)
                    {
                        if (a + b == array[k]*array[k])
                        {
                            Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}",array[i],array[j],array[k]);
                            check = true;
                        }
                    }
                }
            }
            if (!check)
            {
                Console.WriteLine("No");
            }
        }
    }
}
