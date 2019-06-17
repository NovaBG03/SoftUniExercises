namespace DependencyInversion.CalculatorStrategies
{
    using DependencyInversion.CalculatorStrategies.Contracts;

    public class SubtractionStrategy : ICalculatorStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}
