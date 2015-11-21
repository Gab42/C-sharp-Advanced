using System;
using System.IO;
using System.Reflection;


namespace _04.CopyBinaryFile
{
    class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            Assembly assemb = Assembly.GetExecutingAssembly();
            string path = System.IO.Path.GetDirectoryName(assemb.Location);
            var source = path + "..\\..\\..\\cat.jpg";
            var destination = path + "..\\..\\..\\newcat.jpg";

            if (File.Exists(destination))
            {

                FileStream fileStream = File.Open(destination, FileMode.Open);
                fileStream.SetLength(0);
                fileStream.Close();

            }
            else
            {
                File.Create(destination).Close();
            }


            using (FileStream stream = File.OpenRead(source))
            using (FileStream writeStream = File.OpenWrite(destination))
            {

                byte[] buffer = new Byte[4096];
                int bytesRead;

                while ((bytesRead = stream.Read(buffer, 0, 4096)) > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                }
            }

            string exactPath = Path.GetFullPath(path + "..\\..\\..\\newcat.jpg");
            Console.WriteLine("Copied binary file is: " + exactPath);
        }
    }
}
