namespace MyApp.Core.Command.Contracts
{
    public interface ICommand
    {
        string Execute(string[] args);
    }
}
