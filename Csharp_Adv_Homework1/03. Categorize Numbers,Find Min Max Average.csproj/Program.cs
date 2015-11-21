using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _03.Problem_4.Categorize_Numbers_Find_Min_Max_Average
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter numbers, use \".\" for decimal.");
            /*Homework description requires the output float numbers to be represented with a "." point, instead of ",". 
            User local culture is unknown, so I'm forcing en-US. */
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            String[] input = Console.ReadLine().Split(' ').ToArray();
            List<float> ParsedList = new List<float>();

            foreach (string s in input)
            {
                ParsedList.Add(float.Parse(s, Thread.CurrentThread.CurrentUICulture)); 
            } 

            List<float> FloatList = new List<float>();
            List<float> IntList = new List<float>();

            // Separate numbers, depending if int or float .
            foreach (float i in ParsedList)
            {
                if (i % 1 < Double.Epsilon)
                {
                    IntList.Add(i);
                }
                else
                {
                    FloatList.Add(i);
                }
            }
            PrintResults(FloatList);
            PrintResults(IntList);
        }

        // Method for printing the results.
        public static void PrintResults(List<float> List)
        {
            // Min.
            float min = List[0];
            foreach (float i in List)
            {
                if(min > i)
                {
                    min = i;
                }
            }

            // Max.
            float max = List[0];
            foreach (float i in List)
            {
                if (max < i)
                {
                    max = i;
                }
            }

            // Sum.
            float sum = 0;
            foreach (float i in List)
            {
                sum += i;
            }

            // Average.
            float avg = sum / List.Count;

            // Print result.
            Console.Write('[');

            for (int i = 0; i < List.Count; i++)
            {
                Console.Write(List[i]);
                if (i < List.Count - 1)
                {
                    Console.Write(", ");
                }
            }

            Console.Write("]");
            Console.WriteLine(" -> min: {0}, max: {1}, sum: {2}, avg:{3}", min,max,sum,avg);

        }
    }
}
