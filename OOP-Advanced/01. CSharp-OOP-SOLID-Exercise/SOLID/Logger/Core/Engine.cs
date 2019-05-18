using LoggerProject.Appenders;
using LoggerProject.Appenders.Contracts;
using LoggerProject.Core.Contracts;
using LoggerProject.Enums;
using LoggerProject.Layouts;
using LoggerProject.Layouts.Contracts;
using LoggerProject.Loggers;
using LoggerProject.Loggers.Contracts;
using System;

namespace LoggerProject.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            int AppendersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < AppendersCount; i++)
            {
                var appenderInput = Console.ReadLine()
                    .Split();

                this.commandInterpreter.AddAppender(appenderInput);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                var reportInput = input
                    .Split("|");

                this.commandInterpreter.LogReport(reportInput);
            }

            this.commandInterpreter.PrintInfo();
        }
    }
}
