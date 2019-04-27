using System;
using System.Linq;
using System.Collections.Generic;

namespace PartyFilterModule
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Action<List<string>, string> startsWithFilter = (n, str) => n.RemoveAll(x => x.StartsWith(str));
            Action<List<string>, string> endsWithFilter = (n, str) => n.RemoveAll(x => x.EndsWith(str));
            Action<List<string>, string> LenghtFilter = (n, str) => n.RemoveAll(x => x.Length == int.Parse(str));
            Action<List<string>, string> ContainsFilter = (n, str) => n.RemoveAll(x => x.Contains(str));

            var filters = new Dictionary<Action<List<string>, string>, List<string>>();

            var names = Console.ReadLine()
                .Split()
                .ToList();

            while (true)
            {
                var input = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Print")
                {
                    break;
                }

                var command = input[0].Split()[0];
                var filterType = input[1];
                var parametar = input[2];

                if (command == "Add")
                {
                    switch (filterType)
                    {
                        case "Starts with":
                            if (!filters.ContainsKey(startsWithFilter))
                            {
                                filters[startsWithFilter] = new List<string>();
                            }
                            filters[startsWithFilter].Add(parametar);
                            break;
                        case "Ends with":
                            if (!filters.ContainsKey(endsWithFilter))
                            {
                                filters[endsWithFilter] = new List<string>();
                            }
                            filters[endsWithFilter].Add(parametar);
                            break;
                        case "Length":
                            if (!filters.ContainsKey(LenghtFilter))
                            {
                                filters[LenghtFilter] = new List<string>();
                            }
                            filters[LenghtFilter].Add(parametar);
                            break;
                        case "Contains":
                            if (!filters.ContainsKey(ContainsFilter))
                            {
                                filters[ContainsFilter] = new List<string>();
                            }
                            filters[ContainsFilter].Add(parametar);
                            break;
                        default:
                            break;
                    }
                }
                else if (command == "Remove")
                {
                    switch (filterType)
                    {
                        case "Starts with":
                            if (!filters.ContainsKey(startsWithFilter))
                            {
                                filters[startsWithFilter] = new List<string>();
                            }
                            filters[startsWithFilter].Remove(parametar);
                            break;
                        case "Ends with":
                            if (!filters.ContainsKey(endsWithFilter))
                            {
                                filters[endsWithFilter] = new List<string>();
                            }
                            filters[endsWithFilter].Remove(parametar);
                            break;
                        case "Length":
                            if (!filters.ContainsKey(LenghtFilter))
                            {
                                filters[LenghtFilter] = new List<string>();
                            }
                            filters[LenghtFilter].Remove(parametar);
                            break;
                        case "Contains":
                            if (!filters.ContainsKey(ContainsFilter))
                            {
                                filters[ContainsFilter] = new List<string>();
                            }
                            filters[ContainsFilter].Remove(parametar);
                            break;
                        default:
                            break;
                    }
                }
            }

            foreach (var kvp in filters)
            {
                Action<List<string>, string> currentAction = kvp.Key;

                foreach (var parameter in kvp.Value)
                {
                    currentAction(names, parameter);
                }
            }

            Console.WriteLine(string.Join(" ", names));
        }
    }
}
