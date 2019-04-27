using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Directory_Traversal
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string reportFile = "..\\..\\..\\..\\Files\\report.txt";
            string directoryPath = "..\\..\\..\\..\\Files";

            string[] filesPaths = Directory.GetFiles(directoryPath);

            var directory = new Dictionary<string, Dictionary<string, double>>();

            FillDirectory(directory, filesPaths);

            Write(directory, reportFile);
        }

        private static void Write(Dictionary<string, Dictionary<string, double>> directory, string reportFile)
        {
            using (StreamWriter writer = new StreamWriter(reportFile))
            {
                var sortedDirectory = directory
                    .OrderByDescending(x => x.Value.Count)
                    .ThenBy(y => y.Key)
                    .ToDictionary(y => y.Key, x => x.Value);

                foreach (var directoryKvp in sortedDirectory)
                {
                    writer.WriteLine(directoryKvp.Key);

                    foreach (var fileKvp in directoryKvp.Value)
                    {
                        writer.WriteLine($"--{fileKvp.Key} - {fileKvp.Value:F3}kb");
                    }
                }
            }
        }

        private static void FillDirectory(Dictionary<string, Dictionary<string, double>> directory, string[] filesPaths)
        {
            foreach (var filePath in filesPaths)
            {
                string file = GetFile(filePath);

                int indexOfExtension = file.LastIndexOf(".");
                string fileExtension = file.Substring(indexOfExtension);

                double fileLength = (double)File.ReadAllBytes(filePath).LongLength / 1000;

                if (!directory.ContainsKey(fileExtension))
                {
                    directory[fileExtension] = new Dictionary<string, double>();
                }

                directory[fileExtension][file] = fileLength;
            }
        }

        private static string GetFile(string filePath)
        {
            int nameIndex = filePath.LastIndexOf("\\") + 1;
            string file = filePath.Substring(nameIndex);

            return file;
        }
    }
}
