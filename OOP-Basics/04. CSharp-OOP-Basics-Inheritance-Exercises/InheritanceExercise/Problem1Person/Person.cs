using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1Person
{
    public class Person
    {
        private string name;
        private int age;


        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }


        public virtual string Name
        {
            get => name;
            set
            {
                if (value.Length < 3)
                {
                    InvalideNameExcepiton();
                }
                name = value;
            }
        }

        public virtual int Age
        {
            get => age;
            set
            {
                if (value < 1)
                {
                    InvalidAgeException();
                }
                age = value;
            }
        }


        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }

        private static void InvalidAgeException()
        {
            throw new ArgumentException("Age must be positive!");
        }

        private static void InvalideNameExcepiton()
        {
            throw new ArgumentException("Name's length should not be less than 3 symbols!");
        }
    }
}
