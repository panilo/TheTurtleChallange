using System;
using System.Collections.Generic;
using System.Text;

namespace TheTurtleChallange
{
    public enum Direction
    {
        North = 1, 
        East = 2, 
        South = ~North, 
        West = ~East
    }

    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Position
    {
        public Tile Tile { get; set; }
        public Direction Direction { get; set; }
    }

    public class GameSettings
    {
        public Position InitPosition { get; set; }
        public Tile ExitPosition { get; set; }
        public List<Tile> MinesPosition { get; set; }
        public Tile GridSize { get; set; }

        public void IsValid()
        {
            if (InitPosition == null)
                throw new ArgumentNullException(nameof(InitPosition));
            if (ExitPosition == null)
                throw new ArgumentNullException(nameof(ExitPosition));
            if (MinesPosition == null)
                throw new ArgumentNullException(nameof(MinesPosition));
            if (GridSize == null)
                throw new ArgumentNullException(nameof(GridSize));
        }
    }


}
