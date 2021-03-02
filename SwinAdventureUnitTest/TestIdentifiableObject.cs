using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure
{
    [TestFixture]
    public class IdentifiableObjectUnitTest
    //This test program is done with help from Pum Suan Khai.
    {
        private IdentifiableObject _testableObject;

        [SetUp]
        public void SetUp()
        {
            _testableObject = new IdentifiableObject(new string[] { "fred", "bob" });
        }

        [Test]
        public void TestAreYou()
        {
            bool actual = _testableObject.AreYou("bob");
            Assert.IsTrue(actual, "Calling are you");
        }

        [Test]
        public void TestNotAreYou()
        {
            bool actual = _testableObject.AreYou("wilma");
            Assert.IsFalse(actual, "Calling are you");
        }
        [Test]
        public void TestCaseSensitive()
        {
            bool actual = _testableObject.AreYou("BOB");
            Assert.IsTrue(actual, "Calling are you");
        }
        [Test]
        public void TestFirstID()
        {
            string actual = _testableObject.FirstID;
            Assert.AreEqual("fred", actual);
        }
        [Test]
        public void TestAddId()
        {
            _testableObject.AddIdentifier("wilma");
            bool actual = _testableObject.AreYou("wilma");
            Assert.IsTrue(actual, "Calling are you");
        }
    }
}
