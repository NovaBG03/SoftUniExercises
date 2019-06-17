namespace DependencyInversion.CalculatorStrategies
{
    using DependencyInversion.CalculatorStrategies.Contracts;

    public class AdditionStrategy : ICalculatorStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}
