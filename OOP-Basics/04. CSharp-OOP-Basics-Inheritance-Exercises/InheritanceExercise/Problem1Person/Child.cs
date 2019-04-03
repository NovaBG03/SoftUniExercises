using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1Person
{
    public class Child : Person
    {
        public Child(string name, int age)
            : base(name, age)
        {

        }


        public override int Age
        {
            get => base.Age;
            set
            {
                if (value > 15)
                {
                    NotChildAgeException();
                }
                base.Age = value;
            }
        }


        private static void NotChildAgeException()
        {
            throw new ArgumentException("Child's age must be less than 15!");
        }
    }
}
