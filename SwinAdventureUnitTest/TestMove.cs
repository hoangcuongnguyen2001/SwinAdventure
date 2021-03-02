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
    public class TestMove
    {
        private Player p;
        private Path Path1;
        private Location Loc1, Loc2;
        private MoveCommand Move;

        [SetUp]
        public void SetUp()
        {
            p = new Player("Jacques", "A cooker");
            Loc1 = new Location("a coffee house", " which is a place where everyone can chat while drinking coffee");
            Loc2 = new Location("a stable", " where people raise their finest horses");
            Path1 = new Path(new string[] { "northwest" }, "a trail", "This is a long trail for you", Loc1, Loc2);
            Move = new MoveCommand();
            p.Location = Loc1;
            Loc1.AddPath(Path1);
        }

        [Test]
        public void TestPlayerCanMove()
        {
            Move.Execute(p, new string[] { "move", "northwest" });
            string expected = Loc2.Name;
            string actual = p.Location.Name;

            Assert.AreEqual(expected, actual, "Test that move command is executed");

            Move.Execute(p, new string[] { "move", "to", "northwest" });
            string expected1 = Loc2.Name;
            string actual1 = p.Location.Name;

            Assert.AreEqual(expected1, actual1, "Test that move command is executed for 3 elements");
        }


        [Test]
        public void TestInvalidMove()
        {
            Move.Execute(p, new string[] { "move" });
            string expected = Loc1.Name;
            string actual = p.Location.Name;

            Assert.AreEqual(expected, actual, "Test that player can not move when only move is entered.");

            string actual1 = Move.Execute(p, new string[] { "move", "around", "northwest" });
            string expected1 = "What do you want to move to?";
            Assert.AreEqual(expected1, actual1, "Test when second element is not to");

            string expected2 = "Error at move input. Please enter new command.";
            string actual2 = Move.Execute(p, new string[] { "hello", "northwest" });
            Assert.AreEqual(expected2, actual2, "Test when there is wrong identifier");

            string expected3 = "Error at move input.";
            string actual3 = Move.Execute(p, new string[] { "move", "east" });
            Assert.AreEqual(expected3, actual3, "Test when move to another undefined path.");

        }
    }


}