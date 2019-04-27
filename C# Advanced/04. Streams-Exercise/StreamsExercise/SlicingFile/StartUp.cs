using System;
using System.Collections.Generic;
using System.IO;

namespace SlicingFile
{
    public class StartUp
    {
        private static List<string> files;

        static void Main(string[] args)
        {
            files = new List<string>();
            string sourceFile = @"..\..\..\..\Files\sliceMe.mp4";
            string destinationDirectory = @"..\..\..\..\Files\NewFiles";
            int parts = 5;

            Slice(sourceFile, destinationDirectory, parts);

            Assemble(files, destinationDirectory);
        }

        private static void Assemble(List<string> files, string destinationDirectory)
        {
            string assembledFile = $@"{destinationDirectory}\Assembled{files[0].Substring(files[0].LastIndexOf("."))}";
            using (FileStream writer = new FileStream(assembledFile, FileMode.Create))
            {
                byte[] buffer = new byte[4096];

                foreach (var slice in files)
                {
                    using (FileStream reader = new FileStream(slice, FileMode.Open))
                    {
                        while (true)
                        {
                            int read = reader.Read(buffer, 0, buffer.Length);

                            if (read == 0)
                            {
                                break;
                            }

                            writer.Write(buffer, 0, read);
                        }
                    }
                }
            }
        }

        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                int partLength = (int)Math.Ceiling(reader.Length / (double)parts);
                byte[] buffer = new byte[4096];

                for (int i = 1; i <= parts; i++)
                {
                    string slice = $@"{destinationDirectory}\Part{i}{sourceFile.Substring(sourceFile.LastIndexOf("."))}";
                    files.Add(slice);

                    using (FileStream writer = new FileStream(slice, FileMode.Create))
                    {
                        while (true)
                        {
                            int count = Math.Min(partLength, buffer.Length);
                            int read = reader.Read(buffer, 0, count);

                            writer.Write(buffer, 0, read);

                            if (writer.Length >= partLength || read == 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
