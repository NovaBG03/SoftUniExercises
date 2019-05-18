using LoggerProject.Appenders.Contracts;
using LoggerProject.Core.Contracts;
using LoggerProject.Enums;
using LoggerProject.Layouts.Contracts;
using LoggerProject.Loggers;
using LoggerProject.Loggers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LoggerProject.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<IAppender> appenders;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
        }

        public void AddAppender(string[] arg)
        {
            var appenderType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(IAppender).IsAssignableFrom(t)
                    && t.IsClass
                    && t.Name.ToLower().Contains(arg[0].ToLower()))
                .FirstOrDefault();

            var layoutType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(ILayout).IsAssignableFrom(t)
                    && t.IsClass
                    && t.Name.ToLower().Contains(arg[1].ToLower()))
                .FirstOrDefault();

            if (appenderType == null || layoutType == null)
            {
                return;
            }

            var layout = (ILayout) Activator.CreateInstance(layoutType);
            var appender = (IAppender) Activator.CreateInstance(appenderType, layout);

            if (arg.Length == 3)
            {
                string reportLevelString = arg[2][0] + arg[2].ToLower().Remove(0,1);

                var reportLevel = (ReportLevel) Enum.Parse(typeof(ReportLevel), reportLevelString);

                appender.ReportLevel = reportLevel;
            }

            this.appenders.Add(appender);
        }

        public void LogReport(string[] arg)
        {
            string reportLevelString = arg[0][0] + arg[0].ToLower().Remove(0, 1);

            var reportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevelString);
            var date = arg[1];
            var message = arg[2];

            ILogger logger = new Logger(this.appenders.ToArray());

            logger.Log(date, reportLevel, message);
        }

        public void PrintInfo()
        {
            foreach (var appender in appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
