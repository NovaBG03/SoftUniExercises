using System;
using System.Linq;

namespace TriFunction
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            Func<string, int, bool> letterSumIsLarger = (str, n) => str.Select(s => (int)s).Sum() >= n;

            Func<string[], Func<string, int, bool>, int, string> getFirstName = (ns, c, n) => ns.FirstOrDefault(p => c(p, n));

            Action<string> print = Console.WriteLine;

            print(getFirstName(Console.ReadLine().Split(), letterSumIsLarger, number));
        }
    }
}
