using System;
using System.Collections.Generic;
using System.Linq;


namespace _05._Longest_Increasing_Sequence
{
    class Program
    {
        static void Main()
        {
            List<int> list = Console.ReadLine().Split(' ').Select(Int32.Parse).ToList();

            // Current sequence list.
            List<int> counterList = new List<int>();
            // Biggest sequence list.
            List<int> maxList = new List<int>();

            int i = 0;
            while (i < list.Count - 1)
            {
                counterList.Add(list[i]);
                Console.Write(list[i] + " ");

                if (list[i] < list[i + 1])
                {
                    // Out of bounds protection (because of i+1); 
                    if (i == list.Count - 2)
                    {
                        Console.Write(list[i + 1]);
                        counterList.Add(list[i + 1]);
                        CompareSeq(counterList, maxList);
                        break;
                    }
                    i++;
                }

                // If at end of a sequence, startover with next element.
                else
                {
                    CompareSeq(counterList, maxList);
                    i++;
                    Console.WriteLine("");
                }
            }


            Console.WriteLine("");
            Console.Write("Longest: ");
            foreach (int element in maxList)
            {
                Console.Write(element);
                Console.Write(" ");
            }
        }

        // Compare sequences by size and copy the bigger sequence to MaxList.
        public static void CompareSeq(List<int> Counter, List<int> Max)
        {
            if (Counter.Count > Max.Count)
            {
                Max.Clear();
                Counter.ForEach(val => { Max.Add(val); });
            }
            Counter.Clear();
        }
    }
}
  

