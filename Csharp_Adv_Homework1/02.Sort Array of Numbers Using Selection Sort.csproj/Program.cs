using System;
using System.Linq;


namespace _02.Sort_Array_of_Numbers_Using_Selection_Sort
{
    class Program
    {
        static void Main()
        {
            
            string[] s = Console.ReadLine().Split(' ').ToArray();
            int[] intArray = new int[s.Length];
            
            for (int i = 0; i < s.Length; i++)
            {
                 intArray[i] = int.Parse(s[i]);
            }
            int Min;

            for (int i = 0; i < intArray.Length; i++)
            {
                Min = i;

                // Find if there are smaller numbers than [i] element.
                for (int j = i; j < intArray.Length; j++)
                {
                    if (intArray[Min] >= intArray[j])
                    {
                        Min = j;
                    }
                }

                // If there is a smaller (smallest) number, switch places with [i] element.
                if (Min != i)
                {
                    int Temp = intArray[i];
                    intArray[i] = intArray[Min];
                    intArray[Min] = Temp;
                }
            }

            for (int i = 0; i < intArray.Length; i++)
            {
                Console.Write(intArray[i] + " ");
            }
        }
    }
}
