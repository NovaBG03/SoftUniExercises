namespace StorageMester.Tests.Structure.EntitiesTests.VehiclesTests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    using StorageMaster.Entities.Products;

    [TestFixture]
    public class VehicleTests
    {
        private Type classType;

        [SetUp]
        public void Setup()
        {
            this.classType = typeof(StorageMaster.Entities.Vehicles.Vehicle);
        }

        [Test]
        public void Vehicle_LoadProductMethod()
        {
            Type type = typeof(void);
            string name = "LoadProduct";
            Type[] arg = { typeof(Product) };

            bool result = TestManager.HasMethod(this.classType, type, name, arg);

            Assert.IsTrue(result);
        }

        [Test]
        public void Vehicle_UnloadMethod()
        {
            Type type = typeof(Product);
            string name = "Unload";
            Type[] arg = {};

            bool result = TestManager.HasMethod(this.classType, type, name, arg);

            Assert.IsTrue(result);
        }

        [Test]
        public void Vehicle_IntConstructor()
        {
            Type[] arg = { typeof(int) };

            bool result = TestManager.HasConstructor(this.classType, arg);

            Assert.IsTrue(result);
        }

        [Test]
        public void Vehicle_trunkField()
        {
            Type type = typeof(List<Product>);
            string name = "trunk";

            bool result = TestManager.HasField(this.classType, type, name);

            Assert.IsTrue(result);
        }

        [Test]
        public void Vehicle_CapacityProperty()
        {
            Type type = typeof(int);
            string name = "Capacity";
            bool getter = true;
            bool setter = false;

            bool result = TestManager.HasProperty(this.classType, type, name, getter, setter);

            Assert.IsTrue(result);
        }

        [Test]
        public void Vehicle_TrunkProperty()
        {
            Type type = typeof(IReadOnlyCollection<Product>);
            string name = "Trunk";
            bool getter = true;
            bool setter = false;

            bool result = TestManager.HasProperty(this.classType, type, name, getter, setter);

            Assert.IsTrue(result);
        }

        [Test]
        public void Vehicle_IsFullProperty()
        {
            Type type = typeof(bool);
            string name = "IsFull";
            bool getter = true;
            bool setter = false;

            bool result = TestManager.HasProperty(this.classType, type, name, getter, setter);

            Assert.IsTrue(result);
        }

        [Test]
        public void Vehicle_IsEmptyProperty()
        {
            Type type = typeof(bool);
            string name = "IsEmpty";
            bool getter = true;
            bool setter = false;

            bool result = TestManager.HasProperty(this.classType, type, name, getter, setter);

            Assert.IsTrue(result);
        }
    }
}
