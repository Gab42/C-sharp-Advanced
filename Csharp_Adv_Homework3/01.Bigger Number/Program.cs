using System;

namespace _01.Bigger_Number
{
    class Program
    {
        static void Main()
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            int max = GetMax(firstNum, secondNum);
            Console.WriteLine(max);
        }

        static int GetMax(int first, int second)
        {
            if (first > second)
            {
                return first;
            }
            else
            {
                return second;
            }
        }


    }
}
