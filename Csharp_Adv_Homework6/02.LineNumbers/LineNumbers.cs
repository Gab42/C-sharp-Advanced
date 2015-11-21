using System;
using System.IO;
using System.Reflection;

namespace _02.LineNumbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            
            Assembly assemb = Assembly.GetExecutingAssembly();
            string path = System.IO.Path.GetDirectoryName(assemb.Location);           
            var inputFile = path + "..\\..\\..\\input.txt";
            string outputFile = path + "..\\..\\..\\output.txt";

            string exactPath = Path.GetFullPath(path + "..\\..\\..\\input.txt");
            Console.WriteLine("Input file is: " + exactPath);
            Console.WriteLine();
            if (File.Exists(outputFile))
            {

                FileStream fileStream = File.Open(outputFile, FileMode.Open);
                fileStream.SetLength(0);
                fileStream.Close();

            }
            else
            {
                File.Create(outputFile).Close();
            }

            string line;
            int lineCounter = 0;

             using (var reader = new StreamReader(inputFile))
             {
                 using (var writer = new StreamWriter(outputFile, true))
                 {
                     while ((line = reader.ReadLine()) != null)
                     {
                         writer.WriteLine(lineCounter + " " + line);
                         lineCounter++;
                     }
                 }
             }

            exactPath = Path.GetFullPath(path + "..\\..\\..\\output.txt");
            Console.WriteLine("Output file is: " + exactPath);
        }
    }
}
