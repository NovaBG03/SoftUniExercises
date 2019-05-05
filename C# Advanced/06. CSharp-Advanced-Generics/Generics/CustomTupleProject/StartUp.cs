using System;

namespace CustomTupleProject
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var fullName = input[0] + " " + input[1];
            var address = input[2];

            var firstTuple = new CustomTuple<string, string>(fullName, address);

            input = Console.ReadLine().Split();
            var name = input[0];
            var litresBeer = int.Parse(input[1]);

            var secondTuple = new CustomTuple<string, int>(name, litresBeer);

            input = Console.ReadLine().Split();
            var integer = int.Parse(input[0]);
            var doubleValue = double.Parse(input[1]);

            var thirdTuple = new CustomTuple<int, double>(integer, doubleValue);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
