using LoggerProject.Appenders.Contracts;
using LoggerProject.Enums;
using LoggerProject.Layouts.Contracts;

namespace LoggerProject.Appenders
{
    public abstract class Appender : IAppender
    {
        public Appender(ILayout layout)
        {
            this.Layout = layout;
            this.MessagesCounter = 0;
        }

        public ReportLevel ReportLevel { protected get; set; }

        protected ILayout Layout { get; }

        protected int MessagesCounter { get; set; }

        public abstract void AppendMessage(string date, ReportLevel reportLevel, string message);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, " +
                $"Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.MessagesCounter}";
        }
    }
}
