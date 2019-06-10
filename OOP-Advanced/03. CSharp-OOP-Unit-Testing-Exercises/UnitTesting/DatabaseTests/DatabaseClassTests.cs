namespace DatabaseTests
{
    using Database;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class DatabaseClassTests
    {
        //Arrange

        //Act

        //Assert


        [Test]
        [TestCase(null)]
        [TestCase(1)]
        [TestCase(3, 2, 4, 234)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        public void DatabaseConstructorShouldCreateInstance(params int[] array)
        {
            //Arrange
            FieldInfo field = typeof(Database)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.FieldType == typeof(int[]));

            var databaseDefaultLength = (int)typeof(Database)
                .GetFields(BindingFlags.Static | BindingFlags.NonPublic)
                .First(f => f.Name.ToLower().Contains("default")
                    && f.FieldType == typeof(int))
                .GetRawConstantValue();

            int[] expectedArray = new int[databaseDefaultLength];
            for (int i = 0; i < array.Length; i++)
            {
                expectedArray[i] = array[i];
            }

            //Act
            Database database = new Database(array);

            //Assert
            CollectionAssert.AreEqual(expectedArray, (int[])field.GetValue(database));
        }

        [Test]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 0)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 0, 14, 15, 16, 17, 
                  1, 2, 3, 4, 5, 6, 0, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17)]
        public void DatabaseConstructorShouldThrowException(params int[] array)
        {
            //Arrange
            
            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => new Database(array));
        }

        [Test]
        [TestCase(1, null)]
        [TestCase(1, 1)]
        [TestCase(1, 0, 2, 6664, 0)]
        [TestCase(1, 2, 3, 4, 5, 6, 0, 8, 9, 10, 11, 12, 13, 14, 15, 0)]
        public void DatabaseAddMethodShouldAddElement(int element, params int[] array)
        {
            //Arrange
            FieldInfo field = typeof(Database)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.FieldType == typeof(int[]));

            var databaseDefaultLength = (int)typeof(Database)
                .GetFields(BindingFlags.Static | BindingFlags.NonPublic)
                .First(f => f.Name.ToLower().Contains("default")
                    && f.FieldType == typeof(int))
                .GetRawConstantValue();

            int[] expectedArray = new int[databaseDefaultLength];
            for (int i = 0; i < array.Length; i++)
            {
                expectedArray[i] = array[i];
            }
            expectedArray[array.Length] = element;

            Database database = new Database(array);

            //Act
            database.Add(element);

            //Assert
            CollectionAssert.AreEqual(expectedArray, (int[])field.GetValue(database));
        }

        [Test]
        [TestCase(1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        [TestCase(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
        public void DatabaseAddMethodShouldAddThrowException(int element, params int[] array)
        {
            //Arrange
            Database database = new Database(array);

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(element));
        }

        [Test]
        [TestCase(1, 1)]
        [TestCase(1, 0, 2, 6664, 0)]
        [TestCase(1, 2, 3, 4, 5, 6, 0, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        [TestCase(0, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
        public void DatabaseRemoveMethodShouldRemoveElement(params int[] array)
        {
            //Arrange
            FieldInfo field = typeof(Database)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.FieldType == typeof(int[]));

            var databaseDefaultLength = (int)typeof(Database)
                .GetFields(BindingFlags.Static | BindingFlags.NonPublic)
                .First(f => f.Name.ToLower().Contains("default")
                    && f.FieldType == typeof(int))
                .GetRawConstantValue();

            int[] expectedArray = new int[databaseDefaultLength];
            for (int i = 0; i < array.Length - 1; i++)
            {
                expectedArray[i] = array[i];
            }

            Database database = new Database(array);

            //Act
            database.Remove();

            //Assert
            CollectionAssert.AreEqual(expectedArray, (int[])field.GetValue(database));
        }

        [Test]
        public void DatabaseRemoveMethodShouldAddThrowException()
        {
            //Arrange
            Database database = new Database();

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        [TestCase(1, 1)]
        [TestCase(1, 0, 2, 6664, 0)]
        [TestCase(1, 2, 3, 4, 5, 6, 0, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        [TestCase(0, 0, 0, 0, 0, 0, 0, 0, 0, 0)]
        public void DatabaseFetchMethodShouldReturnElements(params int[] array)
        {
            //Arrange
            Database database = new Database(array);

            //Act
            var result = database.Fetch();

            //Assert
            CollectionAssert.AreEqual(array, result);
        }
    }
}
