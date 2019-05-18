using LoggerProject.Enums;

namespace LoggerProject.Layouts.Contracts
{
    public interface ILayout
    {
        string FormatMessage(string date, ReportLevel reportLevel, string message);
    }
}
