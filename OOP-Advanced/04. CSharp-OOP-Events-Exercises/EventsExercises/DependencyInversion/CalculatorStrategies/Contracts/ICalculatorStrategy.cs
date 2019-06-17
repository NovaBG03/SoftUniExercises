namespace DependencyInversion.CalculatorStrategies.Contracts
{
    public interface ICalculatorStrategy
    {
        int Calculate(int firstOperand, int secondOperand);
    }
}
