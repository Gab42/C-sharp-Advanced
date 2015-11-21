using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace _05.SlicingFile
{
    class SlicingFile
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many parts do you want the file to be split into?");
            int parts = int.Parse(Console.ReadLine());
            Assembly assemb = Assembly.GetExecutingAssembly();
            string path = System.IO.Path.GetDirectoryName(assemb.Location);
            var source = path + "..\\..\\..\\cat.jpg";
            var destination = path + "..\\..\\..\\";
            var sliceList = Slice(source, destination, parts);
            Assemble(sliceList,destination);

            string exactPath = Path.GetFullPath(destination);
            Console.WriteLine("Output files are in: " + exactPath);
        }


        static List<string> Slice(string source, string destination, int parts)
        {
            var resultsList = new List<string>();
            int counter = 1;
            string destinationFile;
            FileInfo f = new FileInfo(source);
            long partSize = f.Length/parts;
            string extension = Path.GetExtension(source);
            string sourceFileName = Path.GetFileNameWithoutExtension(source);

            using (BinaryReader stream = new BinaryReader(File.Open(source, FileMode.Open)))
            {

                while (counter <= parts)
                {
                    destinationFile = destination + sourceFileName + counter + extension;
                    File.Create(destinationFile).Close();
                    resultsList.Add(destinationFile);

                    using (BinaryWriter writeStream = new BinaryWriter(File.Open(destinationFile, FileMode.Open)))
                    {
                        byte[] buffer = new Byte[1024];
                        int bytesRead = 0;
                        int totalRead = 0;
                        if (counter == parts)
                        {
                            while ((bytesRead = stream.Read(buffer, 0, 1024)) > 0)
                            {
                                writeStream.Write(buffer, 0, bytesRead);
                            }
                        }
                        else
                        {
                            while ((totalRead += bytesRead) <= partSize && (bytesRead = stream.Read(buffer, 0, 1024)) > 0 )
                            {
                                writeStream.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                    counter++;
                }
            }
            return resultsList;
        }



        static void Assemble(List<string> files, string destinationDirectory)
        {
            string destinationFile = destinationDirectory + Path.GetFileNameWithoutExtension(files[0]) + "_new" + Path.GetExtension(files[0]);
            File.Create(destinationFile).Close();
            using (BinaryWriter writeStream = new BinaryWriter(File.Open(destinationFile, FileMode.Open)))
            {
                foreach (var item in files)
                {
                    using (BinaryReader stream = new BinaryReader(File.Open(item, FileMode.Open)))
                    {
                        byte[] buffer = new Byte[1024];
                        int bytesRead;

                        while ((bytesRead = stream.Read(buffer, 0, 1024)) > 0)
                        {
                            writeStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
        }

        
    }
}
