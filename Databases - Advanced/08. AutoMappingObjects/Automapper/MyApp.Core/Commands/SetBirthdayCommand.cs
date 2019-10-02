namespace MyApp.Core.Commands
{
    using System;
    using System.Globalization;

    using AutoMapper;
    using Contracts;
    using Data;
    using ViewModels;

    public class SetBirthdayCommand : ICommand
    {
        private const string Message = "Employee {0} {1} birthday is successfully set to {2}.";
        private const string DateFormat = "dd-MM-yyyy";

        private readonly EmployeeContext context;
        private readonly Mapper mapper;

        public SetBirthdayCommand(EmployeeContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] args)
        {
            int employeeId = int.Parse(args[0]);

            DateTime employeeBirthday = DateTime.ParseExact(args[1], DateFormat, DateTimeFormatInfo.InvariantInfo);

            var employee = this.context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Invalid employee Id");
            }

            employee.Birthday = employeeBirthday;
            this.context.SaveChanges();

            var employeeDto = this.mapper.CreateMappedObject<EmployeeBirthdayDto>(employee);

            return string.Format(Message, employeeDto.FirstName, employeeDto.LastName, employeeDto.Birthday.ToString(DateFormat));
        }
    }
}
