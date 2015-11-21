using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03
{
    class Program
    {
        static void Main()
        {
            var list = new List<int>();
            list = Console.ReadLine().Split(' ').Select(Int32.Parse).ToList();
            int temp;

            for (int i = 1; i < list.Count; i++)
            {
                    for (int k = i; k >0; k--)
                    {
                        if (list[k-1] > list[k])
                        {
                        temp = list[k];
                        list[k] = list[k - 1];
                        list[k - 1] = temp;
                        }                   
                    }
            }

            for(int n = 0; n < list.Count-1; n++)
            {
                Console.Write(list[n] + " ");
            }
            Console.Write(list[list.Count-1]);

        }
    }
}
