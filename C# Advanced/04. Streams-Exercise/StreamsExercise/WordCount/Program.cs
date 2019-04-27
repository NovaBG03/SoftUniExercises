using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordsFile = @"..\..\..\..\Files\words.txt";
            string textFile = @"..\..\..\..\Files\text.txt";
            string resultFile = @"..\..\..\..\Files\result.txt";

            var words = new Dictionary<string, int>(); 


            using (StreamReader wordsReader = new StreamReader(wordsFile))
            {
                while (true)
                {
                    string word = wordsReader.ReadLine();

                    if (word == null)
                    {
                        break;
                    }

                    words.Add(word, 0);
                }
            }


            using (StreamReader textReader = new StreamReader(textFile))
            {
                while (true)
                {
                    string line = textReader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    string[] lineWords = line.ToLower()
                        .Split(new[] { ' ', ',', '-', '.', '?' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in lineWords)
                    {
                        if (words.ContainsKey(word))
                        {
                            words[word]++;
                        }
                    }
                }
            }


            words = words.OrderByDescending(x => x.Value).ToDictionary(y => y.Key, x => x.Value);


            using (StreamWriter writer = new StreamWriter(resultFile))
            {
                foreach (var kvp in words)
                {
                    writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }
        }
    }
}
