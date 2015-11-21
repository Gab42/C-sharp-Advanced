using System;
using System.Collections.Generic;
using System.Linq;


namespace _04.Sequences_of_Equal_Strings
{
    class Program
    {
        static void Main()
        {
            List<string> list = Console.ReadLine().Split(' ').ToList();
            int j;

            for (j = 0; j < list.Count - 1; j++)
            {
                Console.Write(list[j]);
                if (list[j].Equals(list[j+1], StringComparison.Ordinal))
                {
                    Console.Write(" ");
                   
                }
                else
                {
                    Console.WriteLine("");
                }
            }
            Console.WriteLine(list[j]);
        }
        
    }
}
