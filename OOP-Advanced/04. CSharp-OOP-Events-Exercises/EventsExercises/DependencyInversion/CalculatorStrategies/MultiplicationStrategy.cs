namespace DependencyInversion.CalculatorStrategies
{
    using DependencyInversion.CalculatorStrategies.Contracts;

    public class MultiplicationStrategy : ICalculatorStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }
}
