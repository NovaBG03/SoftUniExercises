using System;
using System.Text;

namespace Mankind.Humans
{
    class Worker : Human
    {
        private decimal weekSalary;
        private int workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }


        public decimal WeekSalary
        {
            get => weekSalary;
            set
            {
                if (value <= 10)
                {
                    InvalidWeekSalaryValue();
                }

                weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get => workHoursPerDay;
            set
            {
                if (value < 1 || value > 12)
                {
                    WorkHoursOutOfRange();
                }

                workHoursPerDay = value;
            }
        }

        public decimal SalaryPerHour
        {
            get
            {
                return CalculateSalaryPerHour();
            }
        }


        private decimal CalculateSalaryPerHour()
        {
            decimal salaryPerDay = this.WeekSalary / 5;
            decimal salaryPerHour = salaryPerDay / this.WorkHoursPerDay;

            return salaryPerHour;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Week Salary: {this.WeekSalary:f2}")
                .AppendLine($"Hours per dayy: {this.WorkHoursPerDay:f2}")
                .AppendLine($"Salary per hour: {this.SalaryPerHour:f2}");

            return base.ToString() + builder.ToString().TrimEnd();
        }


        private static void InvalidWeekSalaryValue()
        {
            throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
        }

        private static void WorkHoursOutOfRange()
        {
            throw new ArgumentOutOfRangeException("Expected value mismatch! Argument: workHoursPerDay");
        }
    }
}
