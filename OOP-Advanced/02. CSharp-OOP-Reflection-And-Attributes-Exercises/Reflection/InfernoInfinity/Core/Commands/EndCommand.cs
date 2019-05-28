namespace InfernoInfinity.Core.Commands
{
    using System;

    public class EndCommand : Command
    {
        public override void Execute(string[] input)
        {
            Environment.Exit(0);
        }
    }
}
