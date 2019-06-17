namespace CustomLinkedListTest
{
    using CustomLinkedList;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class DynamicListTests
    {
        private List<int> elements;
        private DynamicList<int> dynamicList;
        
        [SetUp]
        public void SetUp()
        {
            this.dynamicList = new DynamicList<int>();
            this.elements = new List<int>{ 123, 243, 124, 42, 533, 115}; 

            for (int i = 0; i < this.elements.Count; i++)
            {
                this.dynamicList.Add(this.elements[i]);
            }
        }

        //Arrange

        //Act

        //Assert

        [Test]
        public void DynamicListConstructorCreateInstance()
        {
            //Assert
            Assert.IsNotNull(this.dynamicList, "DynamicList constructor do not create instance.");
        }

        [Test]
        public void DynamicListAddMethodAddsItemAtTheEnd()
        {
            //Arrange
            int item = 2;

            //Act
            this.dynamicList.Add(item);

            //Assert
            Assert.AreEqual(this.dynamicList[this.elements.Count], item, "Dynamic List Add Method does not add item at the end.");
        }

        [Test]
        public void DynamicListIndexGetterReturnsCorrectElement()
        {
            //Arrange
            int expected = this.elements[2];
            int actual;

            //Act
            actual = this.dynamicList[2];

            //Assert
            Assert.AreEqual(expected, actual, "Dynamic List Index Getter does not return correct element.");
        }

        [Test]
        public void DynamicListIndexSetterSetsCorrectlyElement()
        {
            //Arrange
            int expected = 3;
            int index = 2;

            //Act
            this.dynamicList[index] = expected;

            //Assert
            Assert.AreEqual(expected, this.dynamicList[index], "Dynamic List Index Setter does not set correctly element.");
        }

        public void DynamicListCountGetterReturnsCorrectElement()
        {
            //Arrange
            int expected = this.elements.Count;
            int actual;

            //Act
            actual = this.dynamicList.Count;

            //Assert
            Assert.AreEqual(expected, actual, "Dynamic List Count Getter does not return correct element.");
        }

        [Test]
        public void DynamicListRemoveAtMethodRemovesCorrectly()
        {
            //Arrange
            int position = 2;
            int expected = this.dynamicList[position];
            int actual;

            //Act
            this.dynamicList.RemoveAt(position);
            actual = this.dynamicList[position];

            //Assert
            Assert.AreNotEqual(expected, actual, "DynamicList RemoveAt Method does not remove correctly");
        }

        [Test]
        public void DynamicListRemoveAtMethodThrowsArgumentOutOfRangeException()
        {
            //Arrange
            int position = this.dynamicList.Count + 10;

            //Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => this.dynamicList.RemoveAt(position),
                "DynamicList RemoveAt Method doesn not throw ArgumentOutOfRangeException");
        }

        [Test]
        public void DynamicListRemoveMethodRemovesCorrectly()
        {
            //Arrange
            int position = 2;
            int expected = this.dynamicList[position];
            int actual;
            int index;

            //Act
            index = this.dynamicList.Remove(expected);
            actual = this.dynamicList[position];

            //Assert
            Assert.AreNotEqual(expected, actual, "DynamicList Remove Method does not remove correctly");
            Assert.AreEqual(position, index, "DynamicList Remove Method does not return correct index");
        }

        [Test]
        public void DynamicListRemoveMethodReturnsMinusOne()
        {
            //Arrange
            int expected = 1321313;
            int index;

            //Act
            index = this.dynamicList.Remove(expected);

            //Assert
            Assert.AreEqual(-1, index, "DynamicList Remove Method does not return -1");
        }

        [Test]
        public void DynamicListIndexOfMethodReturnsCorrectly()
        {
            //Arrange
            int expected = 2;
            int item = this.elements[expected];
            int actual;

            //Act
            actual = this.dynamicList.IndexOf(item);

            //Assert
            Assert.AreEqual(expected, actual, "DynamicList IndexOf Method does not return correct index");
        }

        [Test]
        public void DynamicListIndexOfMethodReturnsMinusOne()
        {
            //Arrange
            int expected = -1;
            int actual;

            //Act
            actual = this.dynamicList.IndexOf(112133231);

            //Assert
            Assert.AreEqual(expected, actual, "DynamicList IndexOf Method does not return -1");
        }

        [Test]
        public void DynamicListIndexOfMethodContainsWorksCorrectly()
        {
            //Arrange
            int item = this.elements[4];
            bool actualTrue;
            bool actualFalse;

            //Act
            actualTrue = this.dynamicList.Contains(item);
            actualFalse = this.dynamicList.Contains(-1291);

            //Assert
            Assert.IsTrue(actualTrue, "DynamicList IndexOf Method does not work correctly.");
            Assert.IsFalse(actualFalse, "DynamicList IndexOf Method does not work correctly.");
        }
    }
}
