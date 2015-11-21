using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace _03.WordCount
{
    class WordCount
    {
        static void Main(string[] args)
        {
            Assembly assemb = Assembly.GetExecutingAssembly();
            string path = System.IO.Path.GetDirectoryName(assemb.Location);
            var words = path + "..\\..\\..\\words.txt";
            var text = path + "..\\..\\..\\text.txt";
            var results = path + "..\\..\\..\\results.txt";
            string wordsLine;
            var dictionary = new Dictionary<string, int>();

            FileStream fileStream = File.Open(results, FileMode.Open);
            fileStream.SetLength(0);
            fileStream.Close();

            using (var wordsReader = new StreamReader(words))
            {
                using (var textReader = new StreamReader(text))
                {

                    string contents = textReader.ReadToEnd();
                    while ((wordsLine = wordsReader.ReadLine()) != null)
                    {
                        string word = "\\b" + wordsLine + "\\b";
                        MatchCollection matches = Regex.Matches(contents, word, RegexOptions.IgnoreCase);
                        dictionary.Add(wordsLine, matches.Count);
                    }
                }
            }

            var sortedDict = from pair in dictionary orderby pair.Value descending select pair;

            using (var resultsWriter = new StreamWriter(results, true))
            {
                foreach (KeyValuePair<string, int> entry in sortedDict)
                {
                    // do something with entry.Value or entry.Key
                    resultsWriter.WriteLine(entry.Key + " - " + entry.Value);
                }
            }

            string exactPath = Path.GetFullPath(path + "..\\..\\..\\results.txt");
            Console.WriteLine("Output file is: " + exactPath);
        }
    }
}
