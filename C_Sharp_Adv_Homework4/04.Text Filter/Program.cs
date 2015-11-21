using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Text_Filter
{
    class Program
    {
        static void Main()
        {
            char[] chars = { ',',' ' };
            string[] banned = Console.ReadLine().Split(chars,StringSplitOptions.RemoveEmptyEntries).ToArray();
            string input = Console.ReadLine();
            var sbInput = new StringBuilder(input);
            int startingIndex;

            foreach (var val in banned)
            {
                startingIndex = 0;
                while ((startingIndex = input.IndexOf(val, startingIndex)) >= 0)
                {
                    sbInput.Remove(startingIndex, val.Length);
                    string insertString = String.Join("", Enumerable.Repeat('*', val.Length));
                    sbInput.Insert(startingIndex, insertString);
                    ++startingIndex;
                }
            }

            input = sbInput.ToString();
            Console.WriteLine(input);
        }
    }
}
