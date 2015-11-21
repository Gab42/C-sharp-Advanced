using System;

namespace _02.Last_Digit_of_Number
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(GetLastDigitAsWord(439));
        }

        static string GetLastDigitAsWord(int number)
        {
            string s = number.ToString();
            char word = s[(s.Length - 1)];

            switch(word)
            {
                case '0':
                    return "zero";
                case '1':
                    return "one";
                case '2':
                    return "two";
                case '3':
                    return "three";
                case '4':
                    return "four";
                case '5':
                    return "five";
                case '6':
                    return "six";
                case '7':
                    return "seven";
                case '8':
                    return "eight";
                case '9':
                    return "nine";
                default:
                    return "Invalid input.";
            }
        }
    }
}
