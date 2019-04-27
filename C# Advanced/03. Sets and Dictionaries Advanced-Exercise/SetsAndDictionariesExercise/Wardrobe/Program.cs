using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> colors = new Dictionary<string, Dictionary<string, int>>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] line = Console.ReadLine().Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string color = line[0];
                string[] clothes = line[1].Split(',');

                if (!colors.ContainsKey(color))
                {
                    colors[color] = new Dictionary<string, int>();
                }

                for (int j = 0; j < clothes.Length; j++)
                {
                    string currentClothe = clothes[j];

                    if (colors[color].ContainsKey(currentClothe))
                    {
                        colors[color][currentClothe]++;
                    }
                    else
                    {
                        colors[color][currentClothe] = 1;

                    }
                }
            }

            string[] wantedClothe = Console.ReadLine().Split();
            string wantedColor = wantedClothe[0];
            string wantedType = wantedClothe[1];

            foreach (var colorKvp in colors)
            {
                Console.WriteLine($"{colorKvp.Key} clothes:");

                foreach (var clotheKvp in colorKvp.Value)
                {
                    string foundMessage = string.Empty;

                    if (colorKvp.Key == wantedColor && clotheKvp.Key == wantedType)
                    {
                        foundMessage = " (found!)";
                    }

                    Console.WriteLine($"* {clotheKvp.Key} - {clotheKvp.Value}{foundMessage}");
                }
            }
        }
    }
}
