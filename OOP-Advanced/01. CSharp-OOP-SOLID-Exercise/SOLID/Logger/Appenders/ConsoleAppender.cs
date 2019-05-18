using LoggerProject.Appenders.Contracts;
using LoggerProject.Enums;
using LoggerProject.Layouts.Contracts;
using System;

namespace LoggerProject.Appenders
{
    public class ConsoleAppender : Appender, IAppender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
            this.ReportLevel = ReportLevel.Info;
        }

        public override void AppendMessage(string date, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel > reportLevel)
            {
                return;
            }

            string formatedMessage = this.Layout.FormatMessage(date, reportLevel, message);

            Console.WriteLine(formatedMessage);

            this.MessagesCounter++;
        }
    }
}
