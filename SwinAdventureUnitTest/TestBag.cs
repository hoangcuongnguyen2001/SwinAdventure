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
    public class TestBag
    {
        private Bag B1, B2;
        private Item Itm, Itm2;

        [SetUp]
        public void SetUp()
        {
            B1 = new Bag(new string[] { "bag", "new" }, "bag", "A bag containing gems");
            B2 = new Bag(new string[] { "second", "marble" }, "box", "A box with marble");
            Itm = new Item(new string[] { "ball" }, "a yellow ball", "This is a yellow ball for you");
            Itm2 = new Item(new string[] { "box" }, "a golden box", "This is a golden box for you");
        }

        [Test]
        public void TestBagLocatesItem()
        {

            B1.Inventory.Put(Itm);
            GameObject actual = B1.Locate(Itm.FirstID);
            GameObject expected = Itm;
            Assert.AreEqual(expected, actual, "Test bag can locate item");

        }

        [Test]
        public void TestBagLocatesItself()
        {
            GameObject expected = B1;
            GameObject actual = B1.Locate("bag");
            Assert.AreEqual(expected, actual, "Test bag can locate itself");
        }

        [Test]
        public void TestBagLocatesNothing()
        {
            GameObject expected = null; // return null when asked
            GameObject actual = B1.Locate("Erika");
            Assert.AreEqual(expected, actual, "Test bag locates nothing");
        }

        [Test]
        public void TestBagFullDescription()

        {
            B1.Inventory.Put(Itm);
            string expected = "In the bag you can see: a yellow ball(ball)\r\n";
            string actual = B1.FullDescription;

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void TestBagInBag()
        {
            B1.Inventory.Put(B2);
            B1.Inventory.Put(Itm);
            B2.Inventory.Put(Itm2);

            GameObject expected = B2;
            GameObject actual = B1.Locate(B2.FirstID);

            Assert.AreEqual(expected, actual, "Check that bag 1 can locate bag 2");

            GameObject expected1 = Itm;
            GameObject actual1 = B1.Locate(Itm.FirstID);
            Assert.AreEqual(expected1, actual1, "Check that bag 1 can locate item");

            GameObject expected2 = Itm2;
            GameObject actual2 = B1.Locate(Itm2.FirstID);
            Assert.AreNotEqual(expected2, actual2, "Check that bag 1 can not locate item in bag 2");

        }
    }
}