using System;

namespace _01.Reverse_String
{
    class Program
    {
        static void Main()
        {
            char[] input = Console.ReadLine().ToCharArray();
            var len = input.Length - 1;
            double halflen = Math.Floor((double)input.Length / 2);
            char temp;

            for (int i = 0; i < halflen; i++)
            {
                temp = input[i];
                input[i] = input[len - i];
                input[len - i] = temp;
            }
            Console.WriteLine(input);
        }
    }
}
