using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheTurtleChallange
{
    public class Logic
    {
        private GameSettings _gameSettings;
        private List<string> _moves;

        public Logic() : this(new GameSettings(), new List<string>()) { }

        public Logic(GameSettings gameSettings, List<string> moves)
        {
            this._gameSettings = gameSettings;
            this._moves = moves;            
        }
        
        public void Play()
        {            
            Position myTurtlePosition = _gameSettings.InitPosition;

            foreach(string move in _moves)
            {
                //Get next position
                myTurtlePosition = GetNextPosition(myTurtlePosition, move);
                //Check what happen
                if (IsOutBound(myTurtlePosition))
                    throw new IndexOutOfRangeException("Your turtle is out of bounds");
                if (MineHit(myTurtlePosition))
                    throw new FieldAccessException("Your turtle hit a mine");
                if (Exit(myTurtlePosition))
                    throw new UnauthorizedAccessException("your turtle is out");
            }

            //Is still in danger....
        }

        public bool IsOutBound(Position position)
        {
            return position.Tile.X < 0 || position.Tile.Y < 0
                || position.Tile.X > _gameSettings.GridSize.X - 1 || position.Tile.Y > _gameSettings.GridSize.Y - 1;
        }

        public bool MineHit(Position position)
        {
            return _gameSettings.MinesPosition.FirstOrDefault(mine => mine.Equals(position.Tile)) != null;
        }

        public bool Exit(Position position)
        {
            return position.Tile.Equals(_gameSettings.ExitPosition);
        }

        public Position GetNextPosition(Position lastPosition, string move)
        {
            Position nextPosition = new Position() { Tile = lastPosition.Tile, Direction = lastPosition.Direction };

            switch (move)
            {
                case "m":
                    //Get next tile
                    nextPosition.Tile = GetNextTile(lastPosition.Tile, lastPosition.Direction);
                    break;
                case "r":
                    //Get next facing
                    nextPosition.Direction = GetNextDirection(lastPosition.Direction);
                    break;
                default:
                    throw new InvalidOperationException("Not valid move");
            }

            return nextPosition;
        }

        public Direction GetNextDirection(Direction lastDirection)
        {
            //Using bitwise operation https://en.wikipedia.org/wiki/Bitwise_operations_in_C
            return ~lastDirection;
        }

        public Tile GetNextTile(Tile lastTile, Direction lastDirection)
        {
            Tile nextTile = new Tile() { X = lastTile.X, Y = lastTile.Y };

            if (lastDirection == Direction.North)
            {                
                nextTile.Y = lastTile.Y - 1;
            }

            if (lastDirection == Direction.South)
            {                
                nextTile.Y = lastTile.Y + 1;
            }

            if (lastDirection == Direction.East)
            {
                nextTile.X = lastTile.X + 1;             
            }

            if (lastDirection == Direction.West)
            {
                nextTile.X = lastTile.X - 1;
            }

            return nextTile;
        }
    }
}
