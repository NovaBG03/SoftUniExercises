﻿using System;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }


        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Town { get; private set; }


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

            else return this.Town.CompareTo(other.Town);
        }
    }
}
