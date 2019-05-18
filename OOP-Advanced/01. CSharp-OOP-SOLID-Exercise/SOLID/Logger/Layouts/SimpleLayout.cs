using LoggerProject.Enums;
using LoggerProject.Layouts.Contracts;

namespace LoggerProject.Layouts
{
    public class SimpleLayout : ILayout
    {
        public SimpleLayout()
        {

        }

        public string FormatMessage(string date, ReportLevel reportLevel, string message)
        {
            return $"{date} - {reportLevel.ToString().ToUpper()} - {message}";
        }
    }
}
