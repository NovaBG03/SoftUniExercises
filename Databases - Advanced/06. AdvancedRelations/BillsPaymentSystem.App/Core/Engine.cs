namespace BillsPaymentSystem.App.Core
{
    using System;
    using BillsPaymentSystem.Data;
    using Contracts;

    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = new CommandInterpreter();
        }
        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine().Split();

                using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
                {
                    try
                    {
                        var result = this.commandInterpreter.Interpret(input, context);

                        Console.WriteLine(result);
                    }
                    catch (InvalidOperationException io)
                    {
                        Console.WriteLine(io.Message);
                    }
                }
            }
        }
    }
}
