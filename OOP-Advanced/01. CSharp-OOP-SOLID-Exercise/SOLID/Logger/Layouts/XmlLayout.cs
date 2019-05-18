using LoggerProject.Enums;
using LoggerProject.Layouts.Contracts;
using System.Text;

namespace LoggerProject.Layouts
{
    public class XmlLayout : ILayout
    {
        public XmlLayout()
        {

        }

        public string FormatMessage(string date, ReportLevel reportLevel, string message)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<log>")
                .AppendLine($"  <date>{date}</date>")
                .AppendLine($"  <level>{reportLevel.ToString().ToUpper()}</level>")
                .AppendLine($"  <message>{message}</message>")
                .AppendLine("</log>");

            return builder.ToString().TrimEnd();
        }
    }
}
