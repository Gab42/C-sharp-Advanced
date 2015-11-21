using System;
using System.Collections.Generic;

namespace _06.Number_Calculations
{
    class Program
    {
        static void Main()
        {
            var arrayDouble = new double[5] { 1, 2, 4.5, 6.9, 7 };
            var arrayDecimal = new decimal[5] { 1m, 2m, 4.5m, 6.9m, 7m };
            var listDouble = new List<double>();
            var listDecimal = new List<decimal>();

            listDouble = NumberCalculations(arrayDouble);       
            Console.WriteLine("min: {0}, max: {1}, sum: {2}, avg:{3}, prod:{4}",listDouble[0], listDouble[1], listDouble[2], listDouble[3], listDouble[4]);

            listDecimal = NumberCalculations(arrayDecimal);
            Console.WriteLine("min: {0}, max: {1}, sum: {2}, avg:{3}, prod:{4}", listDecimal[0], listDecimal[1], listDecimal[2], listDecimal[3], listDecimal[4]);
        }

        public static List<double> NumberCalculations(double[] array)
        {
            var resultList = new List<double>();
            // Min.
            double min = array[0];
            foreach (double i in array)
            {
                if (min > i)
                {
                    min = i;
                }
            }

            // Max.
            double max = array[0];
            foreach (double i in array)
            {
                if (max < i)
                {
                    max = i;
                }
            }

            // Sum.
            double sum = 0;
            foreach (double i in array)
            {
                sum += i;
            }

            // Average.
            double avg = sum / array.Length;

            // Product.
            double prod = 1;
            foreach (double i in array)
            {
                prod *= i;
            }

            resultList.Add(min);
            resultList.Add(max);
            resultList.Add(sum);
            resultList.Add(avg);
            resultList.Add(prod);

            return resultList;
        }

        public static List<decimal> NumberCalculations(decimal[] array)
        {
            var resultList = new List<decimal>();

            // Min.
            decimal min = array[0];
            foreach (decimal i in array)
            {
                if (min > i)
                {
                    min = i;
                }
            }

            // Max.
            decimal max = array[0];
            foreach (decimal i in array)
            {
                if (max < i)
                {
                    max = i;
                }
            }

            // Sum.
            decimal sum = 0m;
            foreach (decimal i in array)
            {
                sum += i;
            }

            // Average.
            decimal avg = sum / array.Length;

            // Product.
            decimal prod = 1m;
            foreach (decimal i in array)
            {
                prod *= i;
            }

            resultList.Add(min);
            resultList.Add(max);
            resultList.Add(sum);
            resultList.Add(avg);
            resultList.Add(prod);

            return resultList;
        }
    }
}
