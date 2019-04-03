using Mankind.Humans;
using System;

namespace Mankind.Core
{
    class Engine
    {
        private Student student;
        private Worker worker;

        public void Run()
        {
            try
            {
                string[] data = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string firstName = data[0];
                string lastName = data[1];
                string facultyNumber = data[2];

                student = new Student(firstName, lastName, facultyNumber);

                data = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                firstName = data[0];
                lastName = data[1];
                decimal weekSalary = decimal.Parse(data[2]);
                int workHoursPerDay = int.Parse(data[3]);

                worker = new Worker(firstName, lastName, weekSalary, workHoursPerDay);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Print();
        }


        private void Print()
        {
            Console.WriteLine(student + Environment.NewLine);
            Console.WriteLine(worker);
        }

    }
}
