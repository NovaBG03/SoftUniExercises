using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Directory_Traversal
{
    public class StartUp
    {
        private static Dictionary<string, Dictionary<string, double>> FilesInfo;
        private static bool append = false;

        public static void Main(string[] args)
        {
            string reportFile = "..\\..\\..\\..\\Files\\report.txt";
            string directoryPath = "..\\..\\..\\..\\Files";

            ProcessDirectoryInfo(directoryPath, reportFile);

            foreach (var subDirectoryPath in Directory.GetDirectories(directoryPath))
            {
                ProcessDirectoryInfo(subDirectoryPath, reportFile);
            }
        }

        private static void ProcessDirectoryInfo(string directoryPath, string reportFile)
        {
            FilesInfo = new Dictionary<string, Dictionary<string, double>>();

            string[] filesPaths = Directory.GetFiles(directoryPath);

            FillFilesInfo(filesPaths);

            WriteFillInfo(reportFile, directoryPath);
        }

        private static void WriteFillInfo(string reportFile, string directoryPath)
        {
            using (StreamWriter writer = new StreamWriter(reportFile, append))
            {
                int indexOfPathName = directoryPath.LastIndexOf("..\\") + 2;
                writer.WriteLine($"==={directoryPath.Substring(indexOfPathName)}===");

                var sortedDirectory = FilesInfo
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

                writer.Write(Environment.NewLine);
            }

            append = true;
        }

        private static void FillFilesInfo(string[] filesPaths)
        {
            foreach (var filePath in filesPaths)
            {
                string file = GetFile(filePath);

                int indexOfExtension = file.LastIndexOf(".");
                string fileExtension = file.Substring(indexOfExtension);

                double fileLength = (double)File.ReadAllBytes(filePath).LongLength / 1000;

                if (!FilesInfo.ContainsKey(fileExtension))
                {
                    FilesInfo[fileExtension] = new Dictionary<string, double>();
                }

                FilesInfo[fileExtension][file] = fileLength;
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
