using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01
{
    class Program
    {
        static void Main()
        {
            int origNumber = int.Parse(Console.ReadLine());
            int number = origNumber;
            int prime = 2;

            Console.Write(origNumber + " = ");
            
            while (number != 1)
            {
                if (number % prime == 0)
                {
                        number = number / prime;
                        if (number != 1)
                        {
                            Console.Write(prime + " * ");
                        }
                        else
                        {
                            Console.Write(prime);
                        }           
                }
                else
                {
                    prime++;
                }            
            }
        }
    }
}
