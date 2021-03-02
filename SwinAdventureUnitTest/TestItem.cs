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
    public class TestItem
    {
        Item itm = new Item(new string[] { "table" }, "coffee", "This is a coffee table for you");

        [Test]
        public void TestItemIsIdentifiable()
        {
            bool actual = itm.AreYou("table");
            Assert.IsTrue(actual, "Test that Item could be identified");
        }

        [Test]
        public void TestShortDescription()
        {
            string actual = "coffee(table)";
            string expected = itm.ShortDescription;

            Assert.AreEqual(expected, actual, "Return short description");
        }

        [Test]
        public void TestFullDescription()
        {
            string actual = "This is a coffee table for you";
            string expected = itm.FullDescription;

            Assert.AreEqual(expected, actual, "Return full description");
        }
    }
}
