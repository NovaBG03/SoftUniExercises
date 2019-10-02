namespace MyApp
{
    using Microsoft.Extensions.DependencyInjection;
    using System;

    using Data;
    using Core;
    using Core.Contracts;
    using AutoMapper;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IServiceProvider serviceProvider = GetServiceProvider();

            var engine = (IEngine)serviceProvider.GetService(typeof(IEngine));

            engine.Run();
        }

        private static IServiceProvider GetServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddDbContext<EmployeeContext>(ServiceLifetime.Transient);

            services.AddTransient<IEngine, Engine>();

            services.AddTransient<ICommandInterpreter, CommandInterpreter>();

            services.AddTransient<Mapper>();

            return services.BuildServiceProvider();
        }
    }
}
