using System;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }


        public string Name { get; private set; }

        public int Age { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Name, this.Age);
        }

        public override bool Equals(object obj)
        {
            if (obj is Person other)
            {
                return this.Name.CompareTo(other.Name) == 0
                && this.Age == other.Age;
            }

            return false;
        }

        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name) != 0)
            {
                return this.Name.CompareTo(other.Name);
            }

            if (this.Age != other.Age)
            {
                return this.Age - other.Age;
            }

            return 0;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }
    }
}