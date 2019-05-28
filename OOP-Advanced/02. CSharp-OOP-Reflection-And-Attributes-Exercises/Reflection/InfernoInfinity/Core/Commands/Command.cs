namespace InfernoInfinity.Core.Commands
{
    using InfernoInfinity.Contracts;

    public abstract class Command : IExecutable
    {
        public abstract void Execute(string[] input);
    }
}
