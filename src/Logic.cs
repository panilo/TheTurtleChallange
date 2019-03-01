using System;
using System.Collections.Generic;
using System.Text;

namespace TheTurtleChallange
{
    public class Logic
    {
        private GameSettings _gameSettings;
        private List<string> _moves;

        public Logic(GameSettings gameSettings, List<string> moves)
        {
            this._gameSettings = gameSettings;
            this._moves = moves;
            PreinitChecks();
        }

        private void PreinitChecks()
        {
            if (_gameSettings == null)
                throw new ArgumentNullException(nameof(_gameSettings));
            if (_moves == null)
                throw new ArgumentNullException(nameof(_moves));

            _gameSettings.IsValid();            
        }
        
        public void Play()
        {
            foreach(string move in _moves)
            {
                //Get next position
                //Check what happen 
            }
        }

        private Position GetNextPosition(Position lastPosition, string move)
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

        private Direction GetNextDirection(Direction lastDirection)
        {
            //Using bitwise operation https://en.wikipedia.org/wiki/Bitwise_operations_in_C
            return ~lastDirection;
        }

        private Tile GetNextTile(Tile lastTile, Direction lastDirection)
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
