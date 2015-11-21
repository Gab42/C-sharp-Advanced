using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string[] inputArr = { "" };
            int temp;
            string temp2;
            int max;
            int index;
            string result;
            var list = new List<int>();

            while (inputArr[0] != "end")
            {
                inputArr = Console.ReadLine().Split(' ').ToArray();

                switch (inputArr[0])
                {
                    case "exchange":
                        temp = int.Parse(inputArr[1]);
                        if (temp >= array.Length)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            var firstArray = array.Take(temp+1).ToArray();
                            var secondArray = array.Skip(temp+1).ToArray();
                            array = secondArray.Concat(firstArray).ToArray();
                        }
                        break;
                    case "max":
                        if (inputArr[1] == "even")
                        {
                           temp = 0;
                           max = -1;
                           index = 0;
                           for (int i = 0; i < array.Length; i++)
                            {
                                temp = array[i];
                                if (temp % 2 == 0 && temp >= max)
                                {
                                    max = temp;
                                    index = i;
                                }
                            }
                            if (max != -1)
                            {
                                Console.WriteLine(index);
                            }
                            else
                            {
                                Console.WriteLine("No matches");
                            }
                        }
                        else if (inputArr[1] == "odd")
                        {
                            temp = 0;
                            max = -1;
                            index = 0;
                            for (int i = 0; i < array.Length; i++)
                            {
                                temp = array[i];
                                if (temp % 2 != 0 && temp >= max)
                                {
                                    max = temp;
                                    index = i;
                                }
                            }
                            if (max != -1)
                            {
                                Console.WriteLine(index);
                            }
                            else
                            {
                                Console.WriteLine("No matches");
                            }
                        }
                        break;
                    case "min":
                        if (inputArr[1] == "even")
                        {
                            temp = 0;
                            max = 1001;
                            index = -1;
                            for (int i = 0; i < array.Length; i++)
                            {
                                temp = array[i];
                                if (temp % 2 == 0 && temp <= max)
                                {
                                    max = temp;
                                    index = i;
                                }
                            }
                            if (index != -1)
                            {
                                Console.WriteLine(index);
                            }
                            else
                            {
                                Console.WriteLine("No matches");
                            }
                        }
                        else if (inputArr[1] == "odd")
                        {
                            temp = 0;
                            max = 1001;
                            index = -1;
                            for (int i = 0; i < array.Length; i++)
                            {
                                temp = array[i];
                                if (temp % 2 != 0 && temp <= max)
                                {
                                    max = temp;
                                    index = i;
                                }
                            }
                            if (index != -1)
                            {
                                Console.WriteLine(index);
                            }
                            else
                            {
                                Console.WriteLine("No matches");
                            }
                        }
                        break;

                    case "first":
                        if (inputArr[1] == "even")
                        {
                            temp2 = "";
                            temp2 = (from m in array where m % 2 == 0 select m).First().ToString();
                            if (temp2 == "")
                            {
                                Console.WriteLine("No matches");
                            }
                            else
                            {
                                Console.WriteLine(temp2);
                            }
                        }
                        else if (inputArr[1] == "odd")
                        {
                            temp2 = "";
                            temp2 = (from m in array where m % 2 != 0 select m).First().ToString();
                            if (temp2 == "")
                            {
                                Console.WriteLine("No matches");
                            }
                            else
                            {
                                Console.WriteLine(temp2);
                            }
                        }
                        else
                        {
                            if (int.Parse(inputArr[1]) > array.Length)
                            {
                                Console.WriteLine("Invalid count");
                            }
                            else
                            {
                                temp = int.Parse(inputArr[1]);
                                list = new List<int>();

                                if (inputArr[2] == "even")
                                {
                                    list = new List<int>();

                                    list = (from m in array where m % 2 == 0 select m).ToList();
                                    int blah = list.Count - temp;
                                    if (list.Count > temp)
                                    {
                                        for (int i = 1; i <= blah; i++)
                                        {
                                            list.RemoveAt(temp);
                                        }
                                    }

                                    result = String.Join(", ", list);
                                    Console.Write("[");
                                    Console.Write(result);
                                    Console.WriteLine("]");
                                }
                                else
                                {
                                    list = new List<int>();
                                    list = (from m in array where m % 2 != 0 select m).ToList();
                                    int blah = list.Count - temp;
                                    if (list.Count > temp)
                                    {
                                        for (int i = 1; i <= blah; i++)
                                        {
                                            list.RemoveAt(temp);
                                        }
                                    }

                                    result = String.Join(", ", list);
                                    Console.Write("[");
                                    Console.Write(result);
                                    Console.WriteLine("]");
                                }
                            }
                        }
                        break;

                    case "last":
                        if (inputArr[1] == "even")
                        {
                            temp2 = "";
                            temp2 = (from m in array where m % 2 == 0 select m).Last().ToString();
                            if (temp2 == "")
                            {
                                Console.WriteLine("No matches");
                            }
                            else
                            {
                                Console.WriteLine(temp2);
                            }
                        }
                        else if (inputArr[1] == "odd")
                        {
                            temp2 = "";
                            temp2 = (from m in array where m % 2 != 0 select m).Last().ToString();
                            if (temp2 == "")
                            {
                                Console.WriteLine("No matches");
                            }
                            else
                            {
                                Console.WriteLine(temp2);
                            }
                        }
                        else
                        {
                            if (int.Parse(inputArr[1]) > array.Length)
                            {
                                Console.WriteLine("Invalid count");
                            }
                            else
                            {
                                list = new List<int>();
                                temp = int.Parse(inputArr[1]);
                                if (inputArr[2] == "even")
                                {

                                    list = (from m in array where m % 2 == 0 select m).ToList();
                                    int blah = list.Count - temp;
                                    for (int i = 1; i <= blah; i++)
                                    {
                                        if (list.Any())
                                        {
                                            list.RemoveAt(0);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }


                                    result = String.Join(", ", list);
                                    Console.Write("[");
                                    Console.Write(result);
                                    Console.WriteLine("]");
                                }
                                else
                                {
                                    list = (from m in array where m % 2 != 0 select m).ToList();
                                    int blah = list.Count - temp;
                                    for (int i = 1; i <= blah; i++)
                                    {
                                        if (list.Any())
                                        {
                                            list.RemoveAt(0);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }

                               
                                    result = String.Join(", ", list);
                                    Console.Write("[");
                                    Console.Write(result);
                                    Console.WriteLine("]");
                                }
                            }
                        }
                        break;
                    case "end":
                        break;
                }
                
            }

            result = string.Join(", ", array);
            Console.Write("[");
            Console.Write(result);
            Console.WriteLine("]");
        }
    }
}
