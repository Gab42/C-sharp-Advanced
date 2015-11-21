using System;

namespace _05.Unicode_Characters
{
    class Program
    {
        static void Main()
        {
            //"\\u" + ((int)c).ToString("X4");
            var input = Console.ReadLine().ToCharArray();

            foreach (var item in input)
            {
                Console.Write("\\u" + ((int)item).ToString("X4"));
            }

        }
    }
}
