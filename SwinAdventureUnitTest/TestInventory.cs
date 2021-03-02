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
    public class TestInventory
    {
        private Item Itm;
        private Inventory Inv;


        [SetUp]
        public void SetUp()
        {
            Itm = new Item(new string[] { "table" }, "coffee", "This is a coffee table for you");
            Inv = new Inventory();
        }

        [Test]
        public void TestFindItem()
        {

            Inv.Put(Itm);

            bool actual = Inv.HasItem(Itm.FirstID);
            Assert.IsTrue(actual, "Find item on inventory");
        }

        [Test]
        public void TestNoItemFound()
        {
            Inv.Put(Itm);
            bool actual = Inv.HasItem("bakers");
            Assert.IsFalse(actual, "Not find out this item on inventory");
        }

        [Test]
        public void TestFetchItem()
        {

            Inv.Put(Itm);
            Item fetchedItm = Inv.Fetch(Itm.FirstID);

            Assert.AreEqual(fetchedItm, Itm);
        }

        [Test]
        public void TestTakeItem()
        {
            Inv.Put(Itm);
            Item takenItem = Inv.Take(Itm.FirstID);

            bool actual = Inv.HasItem(Itm.FirstID);
            Assert.IsFalse(actual, "Test that item is taken");
        }
        [Test]
        public void TestItemList()
        {
            Inv.Put(Itm);
            Assert.AreEqual("coffee(table)\r\n", Inv.ItemList);
        }
    }

}
