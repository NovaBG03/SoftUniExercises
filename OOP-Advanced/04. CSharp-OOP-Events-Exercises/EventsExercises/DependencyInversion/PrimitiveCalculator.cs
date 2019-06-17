namespace DependencyInversion
{
    using DependencyInversion.CalculatorStrategies;
    using DependencyInversion.CalculatorStrategies.Contracts;

    public class PrimitiveCalculator
    {
        private ICalculatorStrategy calculatorStrategy;

        public PrimitiveCalculator()
        {
            this.calculatorStrategy = new AdditionStrategy();
        }

        public void ChangeStrategy(ICalculatorStrategy calculatorStrategy)
        {
            this.calculatorStrategy = calculatorStrategy;
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.calculatorStrategy.Calculate(firstOperand, secondOperand);
        }
    }
}
