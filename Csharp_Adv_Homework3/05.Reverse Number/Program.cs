using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Reverse_Number
{
    class Program
    {
        static void Main()
        {
            double reversed = GetReversedNumber(123.45);
            Console.WriteLine(reversed);

            reversed = GetReversedNumber(-235);
            Console.WriteLine(reversed);
        }

        static double GetReversedNumber(double number)
        {
            bool negative = false;

            if (number < 0)
            {
                number = Math.Abs(number);
                negative = true;
            }

            string str = number.ToString();
            char[] array = str.ToCharArray();
            Array.Reverse(array);
            str = new string(array);
            number = Convert.ToDouble(str);

            if (negative)
            {
                return -number;
            }
            else
            {
                return number;
            }

        }
    }
}
