using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Subset_Sums
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).Distinct().ToArray();

            // How many combination are possible.
            double combins = Math.Pow(2, input.Length);

            // Check if there are any combinations for which (sum == n).
            bool check = false;

            // Current combination that we are looking at.
            List<int> combination = new List<int>();

            // All sums that equal n.
            List<List<int>> allSums = new List<List<int>>();
            
            for (int i = 1; i < combins; i++) 
            {
                int sum = 0;

                for (int elementPos = 0; elementPos < input.Length; elementPos++)
                {
                    // Make the combinations.
                    int mask = i & (1 << elementPos);
                    if (mask != 0)
                    {
                        sum += input[elementPos];
                        combination.Add(input[elementPos]);
                    }
                }

                // If the sum equals the input number, add combination to list.
                if (sum == n)
                {
                    allSums.Add(combination);
                    check = true;
                }
                combination = new List<int>();
            }

            // Check if there are any valid combinations at all.
            if (!check)
            {
                Console.WriteLine("No matching subsets.");
            }
            else
            {
                foreach (var list in allSums)
                {
                    foreach (var item in list)
                    {
                        Console.Write(item + " + ");
                    }
                    Console.WriteLine("\b\b\b = " + n);
                }
            }
        }
    }
}
