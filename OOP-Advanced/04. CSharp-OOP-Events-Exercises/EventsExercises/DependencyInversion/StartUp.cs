namespace DependencyInversion
{
    using System;
    using DependencyInversion.CalculatorStrategies;
    using DependencyInversion.CalculatorStrategies.Contracts;

    public class StartUp
    {
        static void Main(string[] args)
        {
            PrimitiveCalculator calculator = new PrimitiveCalculator();

            while (true)
            {
                var input = Console.ReadLine().Split();

                if (input[0] == "End")
                {
                    break;
                }

                if (input[0] == "mode")
                {
                    string mode = input[1];
                    ICalculatorStrategy strategy = GetCalculatorStrategy(mode);

                    calculator.ChangeStrategy(strategy);
                    continue;
                }

                int firstOperand = int.Parse(input[0]);
                int secondOperand = int.Parse(input[1]);

                int result = calculator.PerformCalculation(firstOperand, secondOperand);

                Console.WriteLine(result);
            }
        }

        private static ICalculatorStrategy GetCalculatorStrategy(string mode)
        {
            switch (mode)
            {
                case "+":
                    return new AdditionStrategy();
                case "-":
                    return new SubtractionStrategy();
                case "*":
                    return new MultiplicationStrategy();
                case "/":
                    return new DivisionStrategy();
                default:
                    return null;
            }
        }
    }
}
