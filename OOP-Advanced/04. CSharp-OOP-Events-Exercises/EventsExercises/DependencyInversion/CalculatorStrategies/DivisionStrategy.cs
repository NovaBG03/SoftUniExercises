namespace DependencyInversion.CalculatorStrategies
{
    using DependencyInversion.CalculatorStrategies.Contracts;

    public class DivisionStrategy : ICalculatorStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand / secondOperand;
        }
    }
}
