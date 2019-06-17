namespace WorkForce.Models
{
    using System;

    using WorkForce.Models.Contracts;
    using WorkForce.Models.Employees.Contracts;

    public class Job : IJob
    {
        private readonly IEmployee employee;
        private int workHoursRequired;

        public event EventHandler<FinishedWorkArgs> FinishedWork;

        public Job(string jobName, int workHoursRequired, IEmployee employee)
        {
            this.Name = jobName;
            this.employee = employee;
            this.WorkHoursRequired = workHoursRequired;
        }

        public string Name { get; private set; }

        public int WorkHoursRequired
        {
            get => this.workHoursRequired;
            private set
            {
                if (value <= 0)
                {
                    this.OnFinishedWork(new FinishedWorkArgs(this.Name));
                    this.workHoursRequired = 0;
                }

                this.workHoursRequired = value;
            }
        }

        public void Update()
        {
            this.WorkHoursRequired -= employee.WorkHoursPerWeek;
        }

        private void OnFinishedWork(FinishedWorkArgs args)
        {
            Console.WriteLine($"Job {this.Name} done!");
            FinishedWork?.Invoke(this, args);
        }
    }
}
