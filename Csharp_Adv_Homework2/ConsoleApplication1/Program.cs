/*using System;
using System.Linq;

class Pairs
{
    static void Main()
    {
        string[] strNumbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] inputNumbers = Array.ConvertAll<string, int>(strNumbers, int.Parse);
        int[] sums = new int[inputNumbers.Length / 2];
        int maxdiff = 0;
        int prev = inputNumbers[0] + inputNumbers[1];

        for (int i = 0; i < inputNumbers.Length - 1; i+=2)
        {
            int tempSum = inputNumbers[i] + inputNumbers[i+ 1];
            int diff = Math.Abs(tempSum - prev);
            maxdiff = Math.Max(diff, maxdiff);
            prev = tempSum;
            sums[(i / 2)] = tempSum;
        }


        if (sums.Max() == sums.Min())
        {
            Console.WriteLine("Yes, value={0}", sums[0]);
        }
        else
        {
            Console.WriteLine("No, maxdiff={0}", maxdiff);
        }
    }
}*/
using System;
using System.Linq;

class Pairs
{
    static void Main()
    {
        string[] strNumbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] inputNumbers = Array.ConvertAll<string, int>(strNumbers, int.Parse);
        int[] sums = new int[inputNumbers.Length / 2];
        int maxdiff = 0;
        int prev = inputNumbers[0] + inputNumbers[1];

        for (int i = 0, j = 0; i < inputNumbers.Length / 2; i++, j += 2)
        {
            sums[i] = inputNumbers[j] + inputNumbers[j + 1];
            int tempSum = inputNumbers[j] + inputNumbers[j + 1];
            
            int diff = Math.Abs(tempSum - prev);

            maxdiff = Math.Max(diff, maxdiff);

            prev = tempSum;
        }
        //sums.Max() == sums.Min()
        if (sums.Max() == sums.Min())
        {
            Console.WriteLine("Yes, value={0}", sums[0]);
        }
        else
        {
            Console.WriteLine("No, maxdiff={0}", Math.Abs(sums.Max() - sums.Min()));
        }
    }
}
/*
using System;

class Pairs
{
    static void Main()
    {
        string inputLine = Console.ReadLine();
        string[] elements = inputLine.Split(' ');

        int firstElement = int.Parse(elements[0]);
        int secondElement = int.Parse(elements[1]);
        int prevValue = firstElement + secondElement;

        int maxdiff = 0;
        for (int i = 2; i < elements.Length - 1; i += 2)
        {
            firstElement = int.Parse(elements[i]);
            secondElement = int.Parse(elements[i + 1]);
            int lastValue = firstElement + secondElement;
            int diff = Math.Abs(lastValue - prevValue);
            maxdiff = Math.Max(diff, maxdiff);
            prevValue = lastValue;
        }

        if (maxdiff == 0)
        {
            Console.WriteLine("Yes, value=" + prevValue);
        }
        else
        {
            Console.WriteLine("No, maxdiff=" + maxdiff);
        }
    }
}
*/