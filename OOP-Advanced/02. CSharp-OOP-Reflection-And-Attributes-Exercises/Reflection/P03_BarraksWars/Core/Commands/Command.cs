using _03BarracksFactory.Contracts;
using _03BarracksFactory.CustomAttributes;

namespace _03BarracksFactory.Core.Commands
{
    public abstract class Command : IExecutable
    {
        [Inject]
        private readonly string[] data;

        protected Command(string[] data)
        {
            this.data = data;
        }

        protected string[] Data
        {
            get => data;
        }

        public abstract string Execute();
    }
}
