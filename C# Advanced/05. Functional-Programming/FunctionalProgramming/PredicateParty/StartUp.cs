using System;
using System.Linq;
using System.Collections.Generic;

namespace PredicateParty
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Func<List<string>, string, IEnumerable<string>> namesStartsWith = (n, s) => n.Where(x => x.StartsWith(s));
            Func<List<string>, string, IEnumerable<string>> namesEndsWith = (n, s) => n.Where(x => x.EndsWith(s));
            Func<List<string>, int, IEnumerable<string>> namesLenghtMatch = (n, s) => n.Where(x => x.Length == s);

            var names = Console.ReadLine().Split().ToList();

            while (true)
            {
                Action<IEnumerable<string>, List<string>> reorganize = (r, n) => r.ToList();

                var input = Console.ReadLine().Split().ToList();

                if (input[0] == "Party!")
                {
                    break;
                }

                var command = input[0];
                var criteria = input[1];

                if (command == "Remove")
                {
                    reorganize = (r, n) => r.ToList().ForEach(x => n.Remove(x));
                }
                else if (command == "Double")
                {
                    reorganize = (r, n) => r.ToList().ForEach(x => n.Add(x));
                }

                if (criteria == "StartsWith")
                {
                    var str = input[2];
                    reorganize(namesStartsWith(names, str), names);
                }
                else if (criteria == "EndsWith")
                {
                    var str = input[2];
                    reorganize(namesEndsWith(names, str), names);
                }
                else if (criteria == "Length")
                {
                    var str = int.Parse(input[2]);
                    reorganize(namesLenghtMatch(names, str), names);
                }
            }

            if (names.Count != 0)
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
