using System;
using System.IO;
using System.Reflection;

namespace _01.OddLines
{
    class OddLines
    {
        static void Main(string[] args)
        {
            
            string line;
            int lineCounter = 0;

            Assembly assemb = Assembly.GetExecutingAssembly();
            string path = System.IO.Path.GetDirectoryName(assemb.Location);
            string inputFile = path + "..\\..\\..\\input.txt";
            string exactPath = Path.GetFullPath(path + "..\\..\\..\\input.txt");

            Console.WriteLine("Input file location: " + exactPath);
            Console.WriteLine();

            using (var reader = new StreamReader(inputFile))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (lineCounter % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    lineCounter++;
                }
            }          
        }
    }
}
