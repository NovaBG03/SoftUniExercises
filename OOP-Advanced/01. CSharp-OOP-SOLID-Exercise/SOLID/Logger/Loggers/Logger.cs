using LoggerProject.Appenders.Contracts;
using LoggerProject.Enums;
using LoggerProject.Loggers.Contracts;
using System.Collections.Generic;

namespace LoggerProject.Loggers
{
    public class Logger : ILogger
    {
        private IEnumerable<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Critical(string date, string message)
        {
            LogAllAppenders(date, ReportLevel.Critical, message);
        }

        public void Error(string date, string message)
        {
            LogAllAppenders(date, ReportLevel.Error, message);
        }

        public void Fatal(string date, string message)
        {
            LogAllAppenders(date, ReportLevel.Fatal, message);
        }

        public void Warning(string date, string message)
        {
            LogAllAppenders(date, ReportLevel.Warning, message);
        }

        public void Info(string date, string message)
        {
            LogAllAppenders(date, ReportLevel.Info, message);
        }

        private void LogAllAppenders(string date, ReportLevel reportLevel, string message)
        {
            foreach (var appender in appenders)
            {
                appender.AppendMessage(date, reportLevel, message);
            }
        }

        public void Log(string date, ReportLevel reportLevel, string message)
        {
            LogAllAppenders(date, reportLevel, message);
        }
    }
}
