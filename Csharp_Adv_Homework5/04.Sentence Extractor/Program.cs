using System;
using System.Text.RegularExpressions;

namespace _04.Sentence_Extractor
{
    class Program
    {
        static void Main()
        {
            MatchCollection matches;
            string keyword = Console.ReadLine();
            string input = Console.ReadLine();
            string str = @"(?<=\s|^)[^.!?;]*( " + keyword + @" )[^.!?;]*[.!?;]";

            var pattern = new Regex(str);
            matches = pattern.Matches(input);

            foreach (var item in matches)
            {
                Console.WriteLine(item);
            }

        }
    }
}
