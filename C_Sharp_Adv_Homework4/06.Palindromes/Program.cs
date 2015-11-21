using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Palindromes
{
    class Program
    {
        static void Main()
        {
            char[] delimiters = { ',', ' ', '!', '?', ';', '.' };
            string[] input = Console.ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int rightIndex = 0, leftIndex = 0;
            List<string> paliList = new List<string>();
            bool check;

            foreach (var str in input)
            {
                check = true;
                leftIndex = 0;
                rightIndex = str.Length - 1;

                while (leftIndex < rightIndex  && rightIndex > leftIndex)
                {
                    if (str[leftIndex] != str[rightIndex])
                    {
                        check = false;
                        break;
                    }
                    else
                    {
                        leftIndex++;
                        rightIndex--;
                    }
                }
                if (check)
                {
                    paliList.Add(str);
                }             
            }
            paliList.Sort();
            List<string> printList = paliList.Distinct().ToList();
            Console.WriteLine(string.Join(", ", printList));
        }
    }
}
