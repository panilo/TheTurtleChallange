using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public GameSettings GetGameSetting(Tile gridSize = null, Position initialPositon = null, Tile exitPosition = null, List<Tile> mines = null)
        {
            return new GameSettings
            {
                InitPosition = initialPositon ?? new Position { Tile = new Tile { X = 0, Y = 1 }, Direction = Direction.North },
                ExitPosition = exitPosition ?? new Tile { X = 4, Y = 2 },
                MinesPosition = mines ?? new List<Tile> { new Tile { X = 1, Y = 1 }, new Tile { X = 3, Y = 1 }, new Tile { X = 3, Y = 3 } },
                GridSize = gridSize ?? new Tile { X = 5, Y = 4 },                                
            };
        }

        [TestMethod]
        public void GetNextDirection()
        {                        
            Direction d = Direction.North;
            d = gameLogic.GetNextDirection(d);
            Assert.IsTrue(d == Direction.East);
            d = gameLogic.GetNextDirection(d);
            Assert.IsTrue(d == Direction.South);
            d = gameLogic.GetNextDirection(d);
            Assert.IsTrue(d == Direction.West);
            d = gameLogic.GetNextDirection(d);
            Assert.IsTrue(d == Direction.North);
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
            Assert.IsTrue(p.Direction == Direction.East);
            Assert.IsTrue(p.Tile.Equals(new Tile()));

            p = gameLogic.GetNextPosition(p, "m");
            Assert.IsTrue(p.Direction == Direction.East);
            Assert.IsTrue(p.Tile.Equals(new Tile { X = 1, Y = 0 }));

            p = gameLogic.GetNextPosition(p, "r");
            Assert.IsTrue(p.Direction == Direction.South);

            p = gameLogic.GetNextPosition(p, "m");
            Assert.IsTrue(p.Tile.Equals(new Tile { X = 1, Y = 1 }));            

            p = gameLogic.GetNextPosition(p, "r");
            Assert.IsTrue(p.Direction == Direction.West);
            Assert.IsTrue(p.Tile.Equals(new Tile { X = 1, Y = 1 }));

            p = gameLogic.GetNextPosition(p, "m");
            Assert.IsTrue(p.Direction == Direction.West);
            Assert.IsTrue(p.Tile.Equals(new Tile { X = 0, Y = 1 }));

            p = gameLogic.GetNextPosition(p, "r");
            Assert.IsTrue(p.Direction == Direction.North);
            p = gameLogic.GetNextPosition(p, "m");
            Assert.IsTrue(p.Tile.Equals(new Tile()));
        }

        [TestMethod]
        public void GameResult()
        {
            GameSettings gs = GetGameSetting();
            Position p = new Position { Tile = gs.ExitPosition };
            gameLogic = new Logic(gs, new List<string>());

            Assert.IsTrue(gameLogic.Exit(p));

            p.Tile.X = gs.GridSize.X + 1;
            p.Tile.Y = gs.GridSize.Y + 1;
            Assert.IsTrue(gameLogic.IsOutBound(p));

            p.Tile = gs.MinesPosition.FirstOrDefault();            
            Assert.IsTrue(gameLogic.MineHit(p));
        }

        [TestMethod]
        public void PlayTurtleExit()
        {
            List<string> moves = new List<string> { "r", "r", "m", "r", "r", "r", "m", "m", "m", "m" };
            gameLogic = new Logic(GetGameSetting(), moves);

            try
            {
                gameLogic.Play();
            }
            catch (IsExitException)
            {
                Assert.IsTrue(true);
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void PlayTurtleIsOutOfBounds()
        {
            List<string> moves = new List<string> { "m", "m" };
            GameSettings gs = GetGameSetting();            
            gameLogic = new Logic(gs, moves);

            try
            {
                gameLogic.Play();
            }
            catch (IsOutOfBoundsException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void PlayTurtleHitMine()
        {
            List<string> moves = new List<string> { "r", "m" };
            GameSettings gs = GetGameSetting();                       
            gameLogic = new Logic(gs, moves);

            try
            {
                gameLogic.Play();
            }
            catch (MineHitException)
            {
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}
