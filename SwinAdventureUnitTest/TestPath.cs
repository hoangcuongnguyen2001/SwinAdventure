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
    public class TestPath
    {
        private Location Loc1, Loc2;
        private Player p;
        private Path newPath;

        [SetUp]
        public void SetUp()
        {
            Loc1 = new Location("treehouse", "This is a small, yet picturesque treehouse");
            Loc2 = new Location("building gate", "Gate of the central building");
            p = new Player("George", "The main player");
            newPath = new Path(new string[] { "path", "route" }, "path", "This is the path needed for me", Loc1, Loc2);

            // For setting location and path for player.
            p.Location = Loc1;
            Loc1.AddPath(newPath);
        }


        [Test]
        public void TestGetPath()
        {
            Location expected = Loc2;
            Location actual = newPath.Destination;

            Assert.AreEqual(expected, actual, "Test that path connects two rooms.");
        }

        [Test]
        public void TestPathDescription()
        {
            string expected = "This is the path needed for me";
            string actual = newPath.FullDescription;

            Assert.AreEqual(expected, actual, "Test description of the path.");
        }
    }
}
