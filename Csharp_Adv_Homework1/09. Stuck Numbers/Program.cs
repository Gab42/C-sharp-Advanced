using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Stuck_Numbers
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            // All combinations with count of elements == 4.
            var allcombin = Combinations(input);

            // All permutations of those combinations.
            var allPerms = new List<List<string>>();
            
            for (int i = 0; i < allcombin.Count; i++)
            {
                foreach (var list in Permutations(allcombin[i]))
                {
                    List<string> strList = list.ConvertAll<string>(delegate (int m){return m.ToString();});
                    allPerms.Add(strList);
                }
            }
            Console.WriteLine(string.Join("123", "254"));
            // To check if there are any stuck numbers at all.
            bool check = false;

            foreach (var item in allPerms)
            {
                
                
                // Check if any of the permutations are stuck numbers.
                if ((string.Join(item[0], item[1])).Equals(string.Join(item[2], item[3])))
                {
                    check = true;
                    Console.WriteLine("{0}|{1}=={2}|{3}", item[0], item[1], item[2], item[3]);
                }

             }
            if (check == false)
            {
                Console.WriteLine("No");
            }
        }

        // Methods.

        // Find all combinations.
        public static List<List<int>> Combinations(int[] array)
        {
            // Find how many combination are possible.
            double combins = Math.Pow(2, array.Length);

            // List for current combination.
            List<int> combination = new List<int>();

            // List for all N-length combinations
            List<List<int>> allCombin = new List<List<int>>();

            for (int i = 1; i < combins; i++)
            {
                for (int elementPos = 0; elementPos < array.Length; elementPos++)
                {
                    // Use bitmask to make the combinations
                    int mask = i & (1 << elementPos);
                    if (mask != 0)
                    {
                        combination.Add(array[elementPos]);
                    }
                }
                if (combination.Count == 4)
                {
                    allCombin.Add(combination);
                }
                combination = new List<int>();
            }
            return allCombin;
        }

        // Find all permutations.
        private static List<List<int>> Permutations(List<int> list)
        {
            var perms = new List<List<int>>();

            int factorial = 1;

            // Find number of permutations.
            for (int i = 2; i <= list.Count; i++)
            {
                factorial *= i;
            }
            for (int v = 0; v < factorial; v++)
            {
                List<int> s = new List<int>(list);
                int k = v;

                for (int j = 2; j <= list.Count; j++)
                {
                    int other = (k % j);
                    var temp = s[j - 1];
                    s[j - 1] = s[other];
                    s[other] = temp;
                    k = k / j;
                }
                perms.Add(s);
            }
            return perms;
        }
    }
}
