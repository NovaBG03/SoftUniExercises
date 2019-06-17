namespace StorageMester.Tests.Structure
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class StartUpTests
    {
        private Type classType;

        [SetUp]
        public void Setup()
        {
            this.classType = typeof(StorageMaster.StartUp);
        }

        [Test]
        public void StartUp_HasMainMethod()
        {
            Type type = typeof(void);
            string name = "Main";
            Type[] arg = { typeof(string[]) };
            
            bool result = TestManager.HasMethod(this.classType, type, name, arg);

            Assert.IsTrue(result);
        }
    }
}