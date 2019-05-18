using LoggerProject.Enums;

namespace LoggerProject.Appenders.Contracts
{
    public interface IAppender
    {
        void AppendMessage(string date, ReportLevel reportLevel, string message);

        ReportLevel ReportLevel { set; }
    }
}
