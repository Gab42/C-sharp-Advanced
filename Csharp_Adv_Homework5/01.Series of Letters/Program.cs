using System;
using System.Text.RegularExpressions;

namespace _01.Series_of_Letters
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Console.WriteLine(Regex.Replace(input, @"(.)(\1)+", "$1"));
        }
    }
}
