using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.Commands;
using _03BarracksFactory.CustomAttributes;

namespace _03BarracksFactory.Core
{
    public class ReportCommand : Command
    {
        [Inject]
        private readonly IRepository repository;

        public ReportCommand(string[] data, IRepository repository)
            : base(data)
        {
            this.repository = repository;
        }

        public override string Execute()
        {
            string output = this.repository.Statistics;
            return output;
        }
    }
}
