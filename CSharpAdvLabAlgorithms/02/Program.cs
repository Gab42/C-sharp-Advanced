using System;
using System.Collections.Generic;
using System.Linq;

namespace _02
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            var list = new List<int>();
            IEnumerable<int> list2 = Enumerable.Range(2, number-1);
            list = list2.ToList();
           
            int p=2;
            while (p<=number)
            {
                for (int i = 2*(p-1);i < list.Count;i=i+p )
                {
                        list[i] = -1;
                }
                p++;
            }

            list.RemoveAll(item => item == -1);


            for (int i = 0; i < list.Count - 1; i++)
            {
                Console.Write(list[i] + ", ");
            }
                Console.Write(list[list.Count - 1]);


        }
       
    }
}
