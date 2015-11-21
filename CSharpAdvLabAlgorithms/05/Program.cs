using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05
{
    class Program
    {
        static void Main()
        {
            var list = new List<List<string>>();
            string input; 
            var sublist = new List<string>();
            char[] charSeparators = new char[] { ',' };
            int count = 0;
            int max = 0;


            input = Console.ReadLine();
            sublist = input.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries).ToList();
            list.Add(sublist);

            while (input != "END")
            {
                input = Console.ReadLine();
                sublist = input.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries).ToList();
                list.Add(sublist);
            }
            string item = list[0][0];

            for (int row = 0; row < list.Count; row++)
            {
                for (int col = 0; col < list[0].Count; col++)
                {
                    if (list[row][col+1] == item)
                    {
                        for (int m = row + 1; m < list.Count; m++)
                        {
                                       
                        }
                                            
                    }
                }
            }

        }        
    }
}
