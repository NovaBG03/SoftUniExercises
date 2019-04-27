using System.IO;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFileLocation = @"..\..\..\..\Files\text.txt";
            string outputFileLocation = @"..\..\..\..\Files\output.txt";

            using (StreamReader reader = new StreamReader(inputFileLocation))
            {
                int lineNumber = 1;

                using (StreamWriter writer = new StreamWriter(outputFileLocation))
                {
                    while (true)
                    {
                        string line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        writer.WriteLine($"Line {lineNumber++}:{line}");
                    }
                }
            }
        }
    }
}
