namespace BillsPaymentSystem.App.Core.Contracts
{
    using Data;

    public interface ICommandInterpreter
    {
        string Interpret(string[] Args, BillsPaymentSystemContext context);
    }
}
