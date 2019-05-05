using System;

namespace ThreeupleProject
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var fullName = input[0] + " " + input[1];
            var address = input[2];
            var town = input[3];

            var firstThreeuple = new Threeuple<string, string, string>(fullName, address, town);

            input = Console.ReadLine().Split();
            var name = input[0];
            var litresBeer = int.Parse(input[1]);
            var isDrinked = input[2] == "drunk";

            var secondThreeuple = new Threeuple<string, int, bool>(name, litresBeer, isDrinked);

            input = Console.ReadLine().Split();
            var personName = input[0];
            var balance = double.Parse(input[1]);
            var bankName = input[2];


            var thirdThreeuple = new Threeuple<string, double, string>(personName, balance, bankName);

            Console.WriteLine(firstThreeuple);
            Console.WriteLine(secondThreeuple);
            Console.WriteLine(thirdThreeuple);
        }
    }
}
