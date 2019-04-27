using System;
using System.Linq;

namespace PredicateForNames
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var nameLength = int.Parse(Console.ReadLine());
            Predicate<string> filter = n => n.Length <= nameLength;

            Console.ReadLine()
                .Split()
                .ToList()
                .FindAll(filter)
                .ForEach(Console.WriteLine);
        }
    }
}
