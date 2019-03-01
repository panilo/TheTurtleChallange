using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
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

        public GameSettings GetSimpleGameSetting(Tile gridSize = null, Position initialPositon = null, Tile exitPosition = null)
        {
            return new GameSettings
            {
                ExitPosition = exitPosition ?? new Tile { X = 2, Y = 2 },
                GridSize = gridSize ?? new Tile { X = 3, Y = 3 },
                InitPosition = initialPositon ?? new Position { Tile = new Tile { Y = 2, X = 0 }, Direction = Direction.East },
                MinesPosition = new List<Tile> { new Tile { X = 1, Y = 1 } }
            };
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

        [TestMethod]
        public void GameResult()
        {
            Position p = new Position { Tile = new Tile { X = 2, Y = 2 } };
            gameLogic = new Logic(GetSimpleGameSetting(), new List<string>());

            Assert.IsTrue(gameLogic.Exit(p));

            p.Tile.X = 3;
            p.Tile.Y = 3;
            Assert.IsTrue(gameLogic.IsOutBound(p));

            p.Tile.X = 1;
            p.Tile.Y = 1;
            Assert.IsTrue(gameLogic.MineHit(p));
        }
    }
}
