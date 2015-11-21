using System;

namespace _03.Count_Substring_Occurrences
{
    class CountSubstrings
    {
        static void Main()
        {
            string input = Console.ReadLine().ToLower();
            string val = Console.ReadLine();

            int occurrences = 0;
            int startingIndex = 0;

            while ((startingIndex = input.IndexOf(val, startingIndex)) >= 0)
            {
                ++occurrences;
                ++startingIndex;
            }
            Console.WriteLine(occurrences);
        }
    }
}
