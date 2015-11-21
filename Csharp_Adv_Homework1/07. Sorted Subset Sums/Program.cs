using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Sorted_Subset_Sums
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).Distinct().ToArray();

            // Find how many combination are possible.
            double combins = Math.Pow(2, input.Length);

            // Check if there are any valid combinations (sum == n).
            bool check = false;

            // Current combination that we are looking at.
            List<int> combination = new List<int>();

            // All sums that equal num.
            List<List<int>> allSums = new List<List<int>>();

            for (int i = 1; i < combins; i++)
            {
                int sum = 0;
                for (int elementPos = 0; elementPos < input.Length; elementPos++)
                {
                    // Use bitmask to make the combinations
                    int mask = i & (1 << elementPos);
                    if (mask != 0)
                    {
                        sum += input[elementPos];
                        combination.Add(input[elementPos]);
                    }
                }

                // If the sum equals the input number, add combination to list.
                if (sum == num)
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
                // Sort all lists by lenght. // list => list.Count // list => list[0]
                List<List<int>> sortSums = new List<List<int>>(allSums.OrderBy(x => x.Count).ThenBy(y => y.First()));

                // Selective sort sortSums by the first number in all lists in ascending order.
                for (int i = 0; i < sortSums.Count - 1; i++)
                {
                    int first = sortSums[i].First();
                    for (int j = i + 1; j < sortSums.Count; j++)
                    {
                        int second = sortSums[j].First();
                        if (sortSums[i].Count == sortSums[j].Count && first > second)
                        {
                            List<int> temp = sortSums[i];
                            sortSums[i] = sortSums[j];
                            sortSums[i] = temp;
                        }
                    }
                }

                    foreach (var list in sortSums)
                    {
                        foreach (var item in list)
                        {
                            Console.Write(item + " + ");
                        }
                        Console.WriteLine("\b\b\b = " + num);
                    }                
            }
        }
    }
}
