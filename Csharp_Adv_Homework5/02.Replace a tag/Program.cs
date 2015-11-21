using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.Replace_a_tag
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();         
            string pattern1 = "<a href=(\"|\')(.*)\\1>(.*)</a>";
            input = Regex.Replace(input,pattern1 , "[URL href=$2]$3[/URL]");

            Console.WriteLine(input);
        }
    }
}
