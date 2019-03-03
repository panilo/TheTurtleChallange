using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheTurtleChallange
{    
    public enum Direction
    {
        North = 1, 
        East = 2, 
        South = 3, 
        West = 4
    }    

    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            Tile other = obj as Tile;
            if (other == null)
                return false;

            return other.X == X && other.Y == Y;
        }
    }

    public class Position
    {
        public Tile Tile { get; set; }
        public Direction Direction { get; set; }

        public Position()
        {
            Tile = new Tile();
            Direction = Direction.North;
        }
    }

    public class GameSettings
    {
        public Position InitPosition { get; set; }
        public Tile ExitPosition { get; set; }
        public List<Tile> MinesPosition { get; set; }
        public Tile GridSize { get; set; }
        
        public GameSettings()
        {
            InitPosition = new Position();
            ExitPosition = new Tile();
            MinesPosition = new List<Tile>();
            GridSize = new Tile();
        }
    }


}
