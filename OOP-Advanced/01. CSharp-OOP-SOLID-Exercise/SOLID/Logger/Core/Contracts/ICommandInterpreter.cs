namespace LoggerProject.Core.Contracts
{
    public interface ICommandInterpreter
    {
        void AddAppender(string[] arg);

        void LogReport(string[] arg);

        void PrintInfo();
    }
}
