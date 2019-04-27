using System;
using System.Linq;
using System.Collections.Generic;

namespace InfernoIII
{
    public class StartUp
    {
        private static Func<int, int, int> sumLeft;
        private static Func<int, int, int> sumRight;
        private static Func<int, int, int> sumLeftRight;
        private static List<int> gems;

        public static void Main(string[] args)
        {
            sumLeft = (n, i) =>
            {
                if (i == 0)
                {
                    return n;
                }
                else
                {
                    return n + gems[i - 1];
                }
            };
            sumRight = (n, i) =>
            {
                if (i == gems.Count - 1)
                {
                    return n;
                }
                else
                {
                    return n + gems[i + 1];
                }
            };
            sumLeftRight = (n, i) => sumLeft(n, i) + sumRight(n, i) - n;

            var selectedGems = new Dictionary<string, HashSet<int>>();

            gems = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                var input = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Forge")
                {
                    break;
                }

                var command = input[0];
                var filterType = input[1];
                var parameter = int.Parse(input[2]);
                var key = $"{filterType};{parameter}";

                if (command == "Exclude")
                {
                    switch (filterType)
                    {
                        case "Sum Left":
                            selectedGems[key] = GetSelectedIndexed(sumLeft, parameter);
                            break;
                        case "Sum Right":
                            selectedGems[key] = GetSelectedIndexed(sumRight, parameter);
                            break;
                        case "Sum Left Right":
                            selectedGems[key] = GetSelectedIndexed(sumLeftRight, parameter);
                            break;
                        default:
                            break;
                    }
                }
                else if (command == "Reverse")
                {
                    if (selectedGems.ContainsKey(key))
                    {
                        selectedGems.Remove(key);
                    }
                }
            }

            HashSet<int> gemsToRemove = new HashSet<int>();
            FillHashSet(gemsToRemove, selectedGems);

            for (int i = 0; i < gems.Count; i++)
            {
                if (!gemsToRemove.Contains(i))
                {
                    Console.Write(gems[i] + " ");
                }
            }
        }

        private static void FillHashSet(HashSet<int> gemsToRemove, Dictionary<string, HashSet<int>> selectedGems)
        {
            foreach (var kvp in selectedGems)
            {
                foreach (var index in kvp.Value)
                {
                    gemsToRemove.Add(index);
                }
            }
        }

        private static HashSet<int> GetSelectedIndexed(Func<int, int, int> sumFunc, int parameter)
        {
            HashSet<int> selectedIndexes = new HashSet<int>();
            int startIndex = 0;
            while (true)
            {
                startIndex = gems.FindIndex(startIndex, x => sumFunc(x, gems.IndexOf(x)) == parameter);

                if (startIndex == -1)
                {
                    break;
                }

                selectedIndexes.Add(startIndex++);
            }

            return selectedIndexes;
        }
    }
}
