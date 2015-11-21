using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;


namespace _06.ZippingSlicedFiles
{
    class ZippingSlicedFiles
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
            Assemble(sliceList, destination, Path.GetExtension(source));

            string exactPath = Path.GetFullPath(destination);
            Console.WriteLine("Output files are in: " + exactPath);
        }


        static List<string> Slice(string source, string destination, int parts)
        {
            var resultsList = new List<string>();
            int counter = 1;
            string destinationFile;
            FileInfo f = new FileInfo(source);
            long partSize = f.Length / parts;
            string extension = Path.GetExtension(source);
            string sourceFileName = Path.GetFileNameWithoutExtension(source);

            //using (GZipStream stream = new GZipStream(File.Open(source, FileMode.Open), CompressionMode.Decompress))
            using (BinaryReader stream = new BinaryReader(File.Open(source, FileMode.Open)))
            {

                while (counter <= parts)
                {
                    destinationFile = destination + sourceFileName + counter + ".gz";
                    File.Create(destinationFile).Close();
                    resultsList.Add(destinationFile);

                    using (GZipStream writeStream = new GZipStream(File.Open(destinationFile, FileMode.Open), CompressionMode.Compress))

                    //using (BinaryWriter writeStream = new BinaryWriter(File.Open(destinationFile, FileMode.Open)))
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
                            while ((totalRead += bytesRead) <= partSize && (bytesRead = stream.Read(buffer, 0, 1024)) > 0)
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



        static void Assemble(List<string> files, string destinationDirectory, string extension)
        {
            string destinationFile = destinationDirectory + Path.GetFileNameWithoutExtension(files[0]) + "_new" + extension;
            File.Create(destinationFile).Close();
            //using (GZipStream writeStream = new GZipStream(File.Open(destinationFile, FileMode.Open), CompressionMode.Compress))
            using (BinaryWriter writeStream = new BinaryWriter(File.Open(destinationFile, FileMode.Open)))
            {
                foreach (var item in files)
                {
                    using (GZipStream stream = new GZipStream(File.Open(item, FileMode.Open), CompressionMode.Decompress))
                    //using (BinaryReader stream = new BinaryReader(File.Open(item, FileMode.Open)))
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
