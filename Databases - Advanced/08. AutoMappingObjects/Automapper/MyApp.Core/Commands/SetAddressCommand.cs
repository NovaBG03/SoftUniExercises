namespace MyApp.Core.Commands
{
    using System;
    using System.Linq;

    using AutoMapper;
    using Contracts;
    using Data;
    using ViewModels;

    public class SetAddressCommand : ICommand
    {
        private const string Message = "Employee {0} {1} address is successfully set to {2}.";

        private readonly EmployeeContext context;
        private readonly Mapper mapper;

        public SetAddressCommand(EmployeeContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] args)
        {
            int employeeId = int.Parse(args[0]);

            var addressArgs = args.Skip(1);
            string employeeAddress = string.Join(" ", addressArgs); ;

            var employee = this.context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Invalid employee Id");
            }

            employee.Address = employeeAddress;
            this.context.SaveChanges();

            var employeeDto = this.mapper.CreateMappedObject<EmployeeAddressDto>(employee);

            return string.Format(Message, employeeDto.FirstName, employeeDto.LastName, employeeDto.Address);
        }
    }
}
