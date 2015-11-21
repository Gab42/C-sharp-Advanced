using System;
using System.Collections.Generic;

namespace _06.Count_Symbols
{
    class Program
    {
        static void Main()
        {
            var dict = new SortedDictionary<char, int>();
            string input = Console.ReadLine();

            foreach (char item in input)
            {
                if (dict.ContainsKey(item))
                {
                    dict[item] += 1;
                }
                else
                {
                    dict.Add(item, 1);
                }
            }           

            foreach (var item in dict)
            {
                Console.WriteLine("{0}: {1} time/s", item.Key, item.Value);
            }
        }
    }
}
