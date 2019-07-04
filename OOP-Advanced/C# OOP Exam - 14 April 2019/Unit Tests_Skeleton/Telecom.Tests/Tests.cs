namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Tests
    {
        private readonly string make = "IPhone";
        private readonly string model = "X";
        private Phone phone;

        [SetUp]
        public void SetUp()
        {
            this.phone = new Phone(this.make, this.model);
        }

        [Test]
        public void ConstructorShouldCreatePhoneCorrectly()
        {
            Assert.NotNull(this.phone);
        }

        [Test]
        public void MakePropertyShouldWorkCorrectly()
        {
            Assert.AreEqual(this.make, phone.Make);
        }

        [Test]
        public void MakeSetterShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Phone(null, model));
        }

        [Test]
        public void ModelPropertyShouldWorkCorrectly()
        {
            Assert.AreEqual(this.model, phone.Model);
        }

        [Test]
        public void ModelSetterShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Phone(make, null));
        }

        [Test]
        public void CountPropertyShouldReturnPhonebookCountCorrectly()
        {
            Assert.AreEqual(0, phone.Count);
        }

        [Test]
        public void AddContactMethodAddsContactCorrectly()
        {
            phone.AddContact("Ivan", "1111");

            Assert.AreEqual(1, phone.Count);
        }

        [Test]
        public void AddContactMethodShouldThrowInvalidOperationException()
        {
            phone.AddContact("Ivan", "1111");

            Assert.Throws<InvalidOperationException>(() => phone.AddContact("Ivan", "2222"));
        }

        [Test]
        public void CallMethodReturnsCorrectMessage()
        {
            string name = "Ivan";
            string number = "1111";
            phone.AddContact(name, number);

            string message = phone.Call(name);

            Assert.AreEqual($"Calling {name} - {number}...", message);
        }

        [Test]
        public void CallMethoodShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => phone.Call("Ivan"));
        }
    }
}