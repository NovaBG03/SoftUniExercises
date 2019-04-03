using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Roster
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                decimal salary = decimal.Parse(input[1]);
                string position = input[2];
                string department = input[3];
                string email;
                int age;

                Employee employee = new Employee(name, salary, position, department);

                if (input.Length == 5)
                {
                    if (input[4].All(char.IsDigit))
                    {
                        age = int.Parse(input[4]);
                        employee.Age = age;
                    }
                    else
                    {
                        email = input[4];
                        employee.Email = email;
                    }
                }
                else if (input.Length == 6)
                {
                    email = input[4];
                    employee.Email = email;

                    age = int.Parse(input[5]);
                    employee.Age = age;
                }

                employees.Add(employee);
            }




            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
            }

            Console.ReadLine();
        }
    }
}
