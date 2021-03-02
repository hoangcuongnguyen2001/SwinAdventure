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
    public class TestPlayer
    {
        private Item Itm;
        private Player p;

        [SetUp]
        public void SetUp()
        {
            Itm = new Item(new string[] { "table" }, "coffee", "This is a coffee table for you");
            p = new Player("Henry", "The first player");
        }


        [Test]
        public void TestPlayerIsIdentifiable()
        {
            bool actual = p.AreYou("me");
            Assert.IsTrue(actual, "Player is identifiable through me");

            bool actual2 = p.AreYou("inventory");
            Assert.IsTrue(actual2, "Player is identifiable through inventory");
        }

        [Test]
        public void TestPlayerLocatesThemselves()
        {
            GameObject expected = p;
            GameObject actual = p.Locate("me");

            Assert.AreEqual(expected, actual, "Test player can locate themselves");

        }

        [Test]
        public void TestPlayerLocatesNothing()
        {
            GameObject expected = null;
            GameObject actual = p.Locate("Carottes");

            Assert.AreEqual(expected, actual, "Test when player locates nothing");
        }

        [Test]
        public void TestPlayerLocatesItem()
        {
            p.Inventory.Put(Itm);

            GameObject expected = Itm;
            GameObject actual = p.Locate(Itm.FirstID);

            Assert.AreEqual(expected, actual, "Test player can locate item");
        }
        [Test]
        public void TestPlayerFullDescription()
        {
            string expected = "The first player";
            string actual = p.FullDescription;

            Assert.AreEqual(expected, actual, "Test for full description.");
        }
    }
}