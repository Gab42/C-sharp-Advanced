using System;

namespace _02.String_Length
{
    class StringLength
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int length = input.Length;

            if (length < 20)
            {             
                Console.Write(input); 
                while(length < 20)
                {
                    Console.Write('*');
                    length++;
                }
            }
            else
            {
                length = 0;
                while (length < 20)
                {
                    Console.Write(input[length]);
                    length++;
                }
            }
        }
    }
}
