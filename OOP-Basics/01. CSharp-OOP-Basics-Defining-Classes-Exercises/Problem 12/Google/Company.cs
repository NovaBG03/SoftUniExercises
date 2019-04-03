using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google
{
    public class Company
    {
        private string name;
        private string department;
        private decimal salary;

        public Company(string name, string department, decimal salary)
        {
            this.Name = name;
            this.Department = department;
            this.Salary = salary;
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }

    }
}
