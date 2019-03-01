using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheTurtleChallange;

namespace TheTurtleChallangeTests
{
    [TestClass]
    public class GeneralTests
    {
        Logic gameLogic;
        
        public GeneralTests()
        {
            gameLogic = new Logic();
        }

        [TestMethod]
        public void GetOppositeDirection()
        {                        
            Direction d = Direction.North;
            Assert.IsTrue(gameLogic.GetNextDirection(d) == Direction.South);

            d = Direction.East;
            Assert.IsTrue(gameLogic.GetNextDirection(d) == Direction.West);
        }

        [TestMethod]
        public void GetNextTile()
        {
            Direction d = Direction.North;
            Tile tile = new Tile { X = 0, Y = 1 };

            tile = gameLogic.GetNextTile(tile, d);
            Assert.IsTrue(tile.Equals(new Tile { X = 0, Y = 0 }));

            tile.X = 1;
            d = Direction.West;
            tile = gameLogic.GetNextTile(tile, d);
            Assert.IsTrue(tile.Equals(new Tile { X = 0, Y = 0 }));

            d = Direction.East;
            tile = gameLogic.GetNextTile(tile, d);
            Assert.IsTrue(tile.Equals(new Tile { X = 1, Y = 0 }));

            d = Direction.South;
            tile = gameLogic.GetNextTile(tile, d);
            Assert.IsTrue(tile.Equals(new Tile { X = 1, Y = 1 }));
        }

        [TestMethod]
        public void GetNextPosition()
        {
            Position p = new Position();

            p = gameLogic.GetNextPosition(p, "r");
            Assert.IsTrue(p.Direction == Direction.South);
            Assert.IsTrue(p.Tile.Equals(new Tile()));

            p = gameLogic.GetNextPosition(p, "m");
            Assert.IsTrue(p.Direction == Direction.South);
            Assert.IsTrue(p.Tile.Equals(new Tile { X = 0, Y = 1 }));

            p = gameLogic.GetNextPosition(p, "r");
            p = gameLogic.GetNextPosition(p, "m");
            Assert.IsTrue(p.Tile.Equals(new Tile()));

            p.Direction = Direction.West;

            p = gameLogic.GetNextPosition(p, "r");
            Assert.IsTrue(p.Direction == Direction.East);
            Assert.IsTrue(p.Tile.Equals(new Tile()));

            p = gameLogic.GetNextPosition(p, "m");
            Assert.IsTrue(p.Direction == Direction.East);
            Assert.IsTrue(p.Tile.Equals(new Tile { X = 1, Y = 0 }));

            p = gameLogic.GetNextPosition(p, "r");
            p = gameLogic.GetNextPosition(p, "m");
            Assert.IsTrue(p.Tile.Equals(new Tile()));
        }
    }
}
