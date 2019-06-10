namespace DatabaseTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Database;
    using NUnit.Framework;

    [TestFixture]
    public class PeopleDatabaseTest
    {
        //Arrange

        //Act

        //Assert

        private PeopleDatabase database;

        [SetUp]
        public void SetFields()
        {
            this.database = new PeopleDatabase();
        }

        private ICollection<Person> GetInncerDatabaseCollection()
        {
            var collection = (ICollection<Person>)this.database
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => typeof(ICollection<Person>).IsAssignableFrom(f.FieldType))
                .GetValue(this.database);

            return collection;
        }

        [Test]
        public void PeopleDatabaseConstructorShouldCreateAnInstance()
        {
            Assert.IsNotNull(this.database);
        }

        [Test]
        public void PeopleDatabaseAddMethodShouldAddPersonCorrectly()
        {
            //Arrange
            List<Person> people = new List<Person>
            {
                new Person(15, "Ivan"),
                new Person(33, "Ginka")
            };
            var collection = this.GetInncerDatabaseCollection();

            //Act
            foreach (var person in people)
            {
                this.database.Add(person);
            }

            //Assert
            CollectionAssert.AreEquivalent(people, collection);
        }

        [Test]
        public void PeopleDatabaseAddMethodShouldThrowInvalidOperationExceptionForUsername()
        {
            //Arrange
            var firstPerson = new Person(1, "Ivan");
            var secondPerson = new Person(2, "Ivan");

            //Act
            this.database.Add(firstPerson);

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Add(secondPerson));
        }

        [Test]
        public void PeopleDatabaseAddMethodShouldThrowInvalidOperationExceptionForId()
        {
            //Arrange
            var firstPerson = new Person(1, "Ivan");
            var secondPerson = new Person(1, "Pesho");

            //Act
            this.database.Add(firstPerson);

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Add(secondPerson));
        }

        [Test]
        public void PeopleDatabaseRemoveMethodShouldRemoveLastPersonCorrectly()
        {
            //Arrange
            var people = new List<Person>
            {
                new Person(15, "Ivan"),
                new Person(33, "Ginka"),
            };
            people.ForEach(p => this.database.Add(p));

            database.Add(new Person(11, "Sasho"));

            var collection = this.GetInncerDatabaseCollection();

            //Act
            this.database.Remove();

            //Assert
            CollectionAssert.AreEquivalent(people, collection);
        }

        [Test]
        public void PeopleDatabaseRemoveMethodShouldThrowInvalidOperationException()
        {
            //Arrange

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void PeopleDatabaseFindByUsernameMethodShouldWorkCorrectly()
        {
            //Arrange
            var expectedPerson = new Person(33, "Ginka");

            this.database.Add(expectedPerson);
            this.database.Add(new Person(15, "Ivan"));
            this.database.Add(new Person(11, "Sasho"));

            //Act
            var actualPerson = this.database.FindByUsername(expectedPerson.Username);

            //Assert
            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [Test]
        public void PeopleDatabaseFindByUsernameMethodShouldThrowInvalidOperationException()
        {
            //Arrange
            var ussername = "iVAN";

            this.database.Add(new Person(15, "Ivan"));
            this.database.Add(new Person(11, "Sasho"));

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername(ussername));
        }

        [Test]
        public void PeopleDatabaseFindByUsernameMethodShouldThrowArgumentNullException()
        {
            //Arrange
            string ussername = null;

            this.database.Add(new Person(15, "Ivan"));
            this.database.Add(new Person(11, "Sasho"));

            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(ussername));
        }


        [Test]
        public void PeopleDatabaseFindByIdMethodShouldWorkCorrectly()
        {
            //Arrange
            var expectedPerson = new Person(33, "Ginka");

            this.database.Add(expectedPerson);
            this.database.Add(new Person(15, "Ivan"));
            this.database.Add(new Person(11, "Sasho"));

            //Act
            var actualPerson = this.database.FindById(expectedPerson.Id);

            //Assert
            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [Test]
        public void PeopleDatabaseFindByIdMethodShouldThrowInvalidOperationException()
        {
            //Arrange
            var id = 1;

            this.database.Add(new Person(15, "Ivan"));
            this.database.Add(new Person(11, "Sasho"));

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => this.database.FindById(id));
        }

        [Test]
        public void PeopleDatabaseFindByIdMethodShouldThrowArgumentOutOfRangeException()
        {
            //Arrange
            var id = -1;

            this.database.Add(new Person(15, "Ivan"));
            this.database.Add(new Person(11, "Sasho"));

            //Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(id));
        }

    }
}
