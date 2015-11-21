using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace _07.DirectoryTraversal
{
    class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            Assembly assemb = Assembly.GetExecutingAssembly();
            var directory = System.IO.Path.GetDirectoryName(assemb.Location) + "..\\..\\..\\";
            var tempFileList = Directory.GetFiles(directory).ToList();
            var fileList = new List<string>();
            var extDictionary = new Dictionary<string, List<string>>();

            foreach (var item in tempFileList)
            {
                fileList.Add(Path.GetFileName(Path.GetFullPath(item)));
            }


            string resultPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string outputFile = resultPath + "\\result.txt";

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

            foreach (var item in fileList)
            {
                if (extDictionary.ContainsKey(Path.GetExtension(item)))
                {
                    extDictionary[Path.GetExtension(item)].Add(item);
                }
                else
                {
                    var list = new List<string>();
                    list.Add(item);
                    extDictionary.Add(Path.GetExtension(item), list);
                }
            }

            var sortedDict = extDictionary.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key);

            using (var writer = new StreamWriter(outputFile))
            {
               foreach (var item in sortedDict)
                {
                    writer.WriteLine(item.Key);
                    foreach (var listItem in item.Value)
                    {
                        FileInfo fInf = new FileInfo(directory + listItem);
                        string sLen = fInf.Length.ToString();

                        if (fInf.Length >= (1 << 30))
                            sLen = string.Format("{0}Gb", fInf.Length >> 30);
                        else if (fInf.Length >= (1 << 20))
                            sLen = string.Format("{0}Mb", fInf.Length >> 20);
                        else if (fInf.Length >= (1 << 10))
                            sLen = string.Format("{0}Kb", fInf.Length >> 10);
                        else 
                            sLen = string.Format("{0}b", fInf.Length);

                        writer.WriteLine("--" + listItem + " - " + sLen);
                    }
                }
            }
            Console.WriteLine("Output file: " + resultPath + "\\result.txt");
        }
    }
}
