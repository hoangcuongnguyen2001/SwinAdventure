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
    public class TestLocation
    {
        private Location Loc;
        private Player P;
        private Item Itm;

        [SetUp]
        public void SetUp()
        {
            Loc = new Location("Bungalow", "This is a small but neat bungalow near the forest");
            P = new Player("Richard", "A great leader of a group");
            Itm = new Item(new string[] { "golden", "gem" }, "gem", "A golden gem");

        }

        [Test]
        public void TestLocationIsIdentifiable()
        {
            bool actual = Loc.AreYou("here");
            Assert.IsTrue(actual, "Location is identifiable through keyword");
        }

        [Test]
        public void TestItemInLocationIsIdentifiable()
        {
            Loc.Inventory.Put(Itm);

            GameObject expected = Itm;
            GameObject actual = Loc.Locate(Itm.FirstID);

            Assert.AreEqual(expected, actual, "Test that location can identify item it has");
        }

        [Test]
        public void TestPlayerCanLocateItems()
        {
            Loc.Inventory.Put(Itm);
            P.Location = Loc;

            GameObject expected = Itm;
            GameObject actual = P.Locate(Itm.FirstID);

            Assert.AreEqual(expected, actual);
        }
    }
}

