using System;
using System.Linq;

namespace KnightsOfHonor
{
    public class StartUp
    {
        private static Action<string> print = x => Console.WriteLine($"Sir {x}");

        public static void Main(string[] args) => Console.ReadLine()
            .Split(new[] { " " }, StringSplitOptions
            .RemoveEmptyEntries)
            .ToList()
            .ForEach(print);
    }
}
