using System;
using System.Text;

namespace Mankind.Humans
{
    class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }


        public string FacultyNumber
        {
            get => facultyNumber;
            set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    InvalidFacultyNumber();
                }
                facultyNumber = value;
            }
        }


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Faculty number: {this.FacultyNumber}");

            return base.ToString() + builder.ToString().TrimEnd(); 
        }

        private static void InvalidFacultyNumber()
        {
            throw new ArgumentException("Invalid faculty number!");
        }
    }
}
