namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type boxType = typeof(BlackBoxInteger);

            var boxInstance = Activator.CreateInstance(boxType, true);

            var methods = boxType
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                var inputArg = input.Split("_");

                string methodName = inputArg[0];
                int value = int.Parse(inputArg[1]);

                methods.First(m => m.Name == methodName)
                    .Invoke(boxInstance, new object[] { value });

                var currentInnerValue = boxType
                    .GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(boxInstance);

                Console.WriteLine(currentInnerValue);
            }
        }
    }
}
