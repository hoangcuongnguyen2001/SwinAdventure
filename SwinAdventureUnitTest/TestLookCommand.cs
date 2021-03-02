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
    public class TestLookCommand
    {
        private Command look;
        private Player p;
        private Item Gem;
        private Bag Bag1;


        [SetUp]
        public void SetUp()
        {
            Gem = new Item(new string[] { "golden", "gem" }, "gem", "A golden gem");
            Bag1 = new Bag(new string[] { "bag", "new" }, "bag", "A bag containing gems");
            p = new Player("Henry", "The player for challenge");
            look = new LookCommand();


        }

        [Test]
        public void TestLookAtMe()
        {
            string expected = "The player for challenge";
            string actual = look.Execute(p, new string[] { "look", "at", "inventory" });

            Assert.AreEqual(expected, actual, "Test when look command used for inventory");
        }

        [Test]
        public void TestLookAtGem()
        {
            p.Inventory.Put(Gem);
            string expected = "A golden gem";
            string actual = look.Execute(p, new string[] { "look", "at", "gem" });

            Assert.AreEqual(expected, actual, "Check that the program could look at gem");
        }

        [Test]
        public void TestLookAtUnk()
        {
            p.Inventory.Put(Gem);
            p.Inventory.Take("gem");
            string expected = "I cannot find the gem.";
            string actual = look.Execute(p, new string[] { "look", "at", "gem" });

            Assert.AreEqual(expected, actual, "Check that the program could not return unknown project");

        }

        [Test]
        public void TestLookAtGemInMe()
        {
            p.Inventory.Put(Gem);
            string expected = "A golden gem";
            string actual = look.Execute(p, new string[] { "look", "at", "gem", "in", "inventory" });

            Assert.AreEqual(expected, actual, "Check that the program could look at gem in me");
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            p.Inventory.Put(Bag1);
            Bag1.Inventory.Put(Gem);
            string expected = "A golden gem";
            string actual = look.Execute(p, new string[] { "look", "at", "gem", "in", "bag" });
            Assert.AreEqual(expected, actual, "Check that the program could look at gem in a bag");
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            p.Inventory.Put(Gem);
            string expected = "I cannot find the bag.";
            string actual = look.Execute(p, new string[] { "look", "at", "gem", "in", "bag" });
            Assert.AreEqual(expected, actual, "Check that the program could not look at gem in no bag");
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            p.Inventory.Put(Bag1);
            string expected = "I cannot find the gem.";
            string actual = look.Execute(p, new string[] { "look", "at", "gem", "in", "bag" });
            Assert.AreEqual(expected, actual, "Check that the program could not look at no gem in a bag");
        }
        [Test]
        public void TestInvalidLook()
        {
            string expected = "I don't know how to look like that";
            string actual = look.Execute(p, new string[] { "hello" });
            Assert.AreEqual(expected, actual);

            string expected1 = "What do you want to look at?";
            string actual1 = look.Execute(p, new string[] { "look", "to", "moon" });
            Assert.AreEqual(expected1, actual1);

            string expected2 = "What do you want to look in?";
            string actual2 = look.Execute(p, new string[] { "look", "at", "paper", "on", "pot" });
            Assert.AreEqual(expected2, actual2);

            string expected3 = "Error at look input";
            string actual3 = look.Execute(p, new string[] { "run", "to", "tree" });
            Assert.AreEqual(expected3, actual3);


        }

    }
}

