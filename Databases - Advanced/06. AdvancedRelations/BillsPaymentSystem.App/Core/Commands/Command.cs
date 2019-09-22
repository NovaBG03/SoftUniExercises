namespace BillsPaymentSystem.App.Core.Commands
{
    using System;

    using Contracts;
    using Data;

    public abstract class Command : ICommand
    {
        private readonly BillsPaymentSystemContext context;

        public Command(BillsPaymentSystemContext context)
        {
            this.context = context;
        }

        protected BillsPaymentSystemContext Context
            => this.context;

        public abstract string Execute(string[] args);
    }
}
