using System;
using System.Text.RegularExpressions;

namespace _03.Extract_Emails
{
    class Program
    {
        static void Main()
        {
            MatchCollection matches;
            var input = Console.ReadLine();
            string temp = @"(((\w|\d)+)\.*-*_*)*((\w|\d)+)\@\w+(\.+\w+)+";
            Regex pattern = new Regex(temp);
            matches = pattern.Matches(input);

            foreach (var item in matches)
            {
                Console.WriteLine(item);
            }
            
        }
    }
}
