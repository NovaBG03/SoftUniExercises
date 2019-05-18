using LoggerProject.Appenders.Contracts;
using LoggerProject.Enums;
using LoggerProject.Layouts.Contracts;
using LoggerProject.Loggers;
using LoggerProject.Loggers.Contracts;
using System.IO;

namespace LoggerProject.Appenders
{
    public class FileAppender : Appender, IAppender
    {
        private readonly string path;
        private readonly ILogFile logFile;

        public FileAppender(ILayout layout)
            : base(layout)
        {
            path = @"..\..\..\Text.txt";
            this.logFile = new LogFile();
            ReportLevel = ReportLevel.Info;
        }

        public FileAppender(ILayout layout, ILogFile logFile)
            : this(layout)
        {
            this.logFile = logFile;
        }

        public override void AppendMessage(string date, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel > reportLevel)
            {
                return;
            }

            string formatedMessage = this.Layout.FormatMessage(date, reportLevel, message);

            using (StreamWriter streamWriter = new StreamWriter(path, true))
            {
                streamWriter.WriteLine(formatedMessage);
            }

            logFile.Write(formatedMessage);
            this.MessagesCounter++;
        }

        public override string ToString()
        {
            return base.ToString() + 
                $", File size: {this.logFile.Size}";
        }
    }
}
