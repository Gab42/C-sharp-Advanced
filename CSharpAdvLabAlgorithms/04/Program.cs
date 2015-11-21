using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04
{
    class Program
    {
        static void Main()
        {
            List<int> list = Console.ReadLine().Split(' ').Select(Int32.Parse).ToList();
            int number = int.Parse(Console.ReadLine());
            //Console.WriteLine(LinearSearch(list, number));
            Console.WriteLine(BinarySearch(list, number));

        }

        static int LinearSearch(List<int> array, int item)
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] == item)
                {
                    return i;
                }
            }

            return -1;

        }

        static int BinarySearch(List<int> array, int item)
        {
            var array2 = new List<int>(array);
            array.Sort();

            int min = 0;
            int max = array.Count - 1;
            int mid;

            while (Math.Abs(max - min) >= 1)
            {
                mid = (max + min) / 2;
                if (array[mid] == item)
                {
                    for (int i = 0; i < array2.Count; i++)
                    {
                        if (array2[i] == item)
                        {
                            return i;
                        }
                    }
                    
                }
                else if (array[mid] < item)
                {
                    min = mid;
                }
                else if (array[mid] > item)
                {
                    max = mid;
                }
            }

            return -1;

        }
    }
}
