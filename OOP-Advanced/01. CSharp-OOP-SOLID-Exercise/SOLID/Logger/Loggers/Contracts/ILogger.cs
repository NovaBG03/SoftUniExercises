﻿using LoggerProject.Enums;

namespace LoggerProject.Loggers.Contracts
{
    public interface ILogger
    {
        void Info(string date, string message);

        void Warning(string date, string message);

        void Error(string date, string message);

        void Critical(string date, string message);

        void Fatal(string date, string message);

        void Log(string date, ReportLevel reportLevel, string message);
    }
}
