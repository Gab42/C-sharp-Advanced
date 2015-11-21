using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            var doubles = new Dictionary<int,List<string>>();
            var ints = new Dictionary<int, List<string>>();
            var list = new List<string>();
            int scopeNum = 0;
            int leftbracket = 0;
            int rightbracket = 0;
            bool repeatFlag = false;
            var resultList = new List<string>();

            while (input != "//END_OF_CODE")
            {
                input = Console.ReadLine();
                list = input.Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
                if (list.Count > 0)
                {
                    if (list[0] == "private" || list[0] == "public"|| list[0] == "static" || list[0] == "class" || list[0] == "void" || list[0] == "if"|| list[0] == "else if" || list[0] == "else")
                    {
                        leftbracket = 0;
                        rightbracket = 0;
                    }
                    else if (list[0] == "{")
                    {
                        leftbracket++;
                    }
                    else if (list[0] == "}")
                    {
                        rightbracket++;
                    }

                    if (leftbracket != 0 && rightbracket == leftbracket)
                    {
                        scopeNum++;
                    }

                    //doubles
                    Regex regex = new Regex(@"(?<=double\s)\b.+?\b");
                    Match match = regex.Match(input);

                    if (doubles.ContainsKey(scopeNum))
                    {
                        foreach (var item in doubles[scopeNum])
                        {
                            if (match.Success && item == match.Value)
                            {
                                repeatFlag = true;
                                break;
                            }
                        }

                        if (!repeatFlag)
                        {
                            doubles[scopeNum].Add(match.Value);
                        }
                    }
                    else
                    {
                        list = new List<string>();
                        doubles.Add(scopeNum, list);
                        doubles[scopeNum].Add(match.Value);
                    }

                    //ints
                    regex = new Regex(@"(?<=int\s)\b.+?\b");
                    match = regex.Match(input);

                    if (ints.ContainsKey(scopeNum))
                    {
                        foreach (var item in ints[scopeNum])
                        {
                            if (match.Success && item == match.Value)
                            {
                                repeatFlag = true;
                                break;
                            }
                        }

                        if (!repeatFlag)
                        {
                            ints[scopeNum].Add(match.Value);
                        }
                    }
                    else
                    {
                        list = new List<string>();
                        ints.Add(scopeNum, list);
                        ints[scopeNum].Add(match.Value);
                    }
                }
            }

            // doubles
            Console.Write("Doubles: ");
            foreach (var item in doubles)
            {
                foreach (var item2 in item.Value)
                {
                    resultList.Add(item2);
                }
            }
            resultList = resultList.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
            resultList.Sort();


            if (!resultList.Any())
            {
                Console.WriteLine("None");
            }
            else
            {
                string result = String.Join(", ", resultList);
                Console.WriteLine(result);
            }
            // Ints
            resultList = new List<string>();
            Console.Write("Ints: ");
            foreach (var item in ints)
            {
                foreach (var item2 in item.Value)
                {
                    resultList.Add(item2);
                }
            }
            resultList = resultList.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
            resultList.Sort();



            if (!resultList.Any())
            {
                Console.WriteLine("None");
            }
            else
            {
                string result = String.Join(", ", resultList);
                Console.WriteLine(result);
            }

        }
    }
}
