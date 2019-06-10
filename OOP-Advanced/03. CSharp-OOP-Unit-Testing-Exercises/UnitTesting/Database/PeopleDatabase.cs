namespace Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PeopleDatabase
    {
        private ICollection<Person> peopleCollection;

        public PeopleDatabase()
        {
            this.peopleCollection = new List<Person>();
        }

        public void Add(Person person)
        {
            if (this.peopleCollection.Any(p => p.Id == person.Id))
            {
                throw new InvalidOperationException("There is already user with this id.");
            }

            if (this.peopleCollection.Any(p => p.Username == person.Username))
            {
                throw new InvalidOperationException("There is already user with this username.");
            }

            this.peopleCollection.Add(person);
        }

        public void Remove()
        {
            if (this.peopleCollection.Count == 0)
            {
                throw new InvalidOperationException("Can't remove from empty database.");
            }

            var person = this.peopleCollection.Last();
            this.peopleCollection.Remove(person);
        }

        public Person FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username parameter can not be null");
            }

            var person = this.peopleCollection.FirstOrDefault(p => p.Username == username);

            if (person == null)
            {
                throw new InvalidOperationException("There is no user with this ussername");
            }

            return person;
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id parameter can not be negative number.");
            }

            var person = this.peopleCollection.FirstOrDefault(p => p.Id == id);

            if (person == null)
            {
                throw new InvalidOperationException("There is no user with this id");
            }

            return person;
        }
    }
}

