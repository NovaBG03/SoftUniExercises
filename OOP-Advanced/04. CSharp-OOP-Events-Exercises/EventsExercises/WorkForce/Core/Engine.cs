namespace WorkForce.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using WorkForce.Factories.Contracts;
    using WorkForce.Models;
    using WorkForce.Models.Employees.Contracts;

    public class Engine
    {
        private JobList jobs;
        private ICollection<IEmployee> employees;
        private IEmployeeFactory employeeFactory;

        public Engine(JobList jobs, ICollection<IEmployee> employees, IEmployeeFactory employeeFactory)
        {
            this.jobs = jobs;
            this.employees = employees;
            this.employeeFactory = employeeFactory;
        }

        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine()
                    .Split();

                string command = input[0];

                switch (command)
                {
                    case "Job":
                        this.CreateJob(input);
                        break;
                    case "StandardEmployee":
                    case "PartTimeEmployee":
                        this.CreateEmployee(input);
                        break;
                    case "Pass":
                        this.UpdateJobs();
                        break;
                    case "Status":
                        this.PrintJobStatus();
                        break;
                    case "End":
                        return;
                    default:
                        break;
                }
            }
        }

        private void PrintJobStatus()
        {
            foreach (var job in this.jobs)
            {
                Console.WriteLine($"Job: {job.Name} Hours Remaining: {job.WorkHoursRequired}");
            }
        }

        private void UpdateJobs()
        {
            this.jobs.Reverse();

            for (int i = this.jobs.Count - 1; i >= 0; i--)
            {
                var job = jobs[i];
                job.Update();
            }

            this.jobs.Reverse();
        }

        private void CreateEmployee(string[] input)
        {
            string typeName = input[0];
            string employeeName = input[1];

            IEmployee employee = this.employeeFactory.CreateEmployee(typeName, employeeName);

            this.employees.Add(employee);
        }

        private void CreateJob(string[] input)
        {
            string jobName = input[1];
            int workHoursRequired = int.Parse(input[2]);
            string employeeName = input[3];

            IEmployee employee = this.GetEmploee(employeeName);

            if (employee == null)
            {
                //TODO ?throw Exception
                return;
            }

            Job job = new Job(jobName, workHoursRequired, employee);
            job.FinishedWork += this.jobs.DeliteJob;

            this.jobs.Add(job);
        }

        private IEmployee GetEmploee(string employeeName)
        {
            return this.employees.FirstOrDefault(e => e.Name == employeeName);
        }
    }
}
