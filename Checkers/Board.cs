using System;

namespace Checkers
{
    public class Board
    {
        public Tile[,] Tiles { get; set; }

        public Board()
        {
            Tiles = new Tile[8,8];

            for (var i = 0; i < Tiles.GetLength(0); i++)
            {
                for (var j = 0; j < Tiles.GetLength(1); j++)
                {
                    Tiles[i,j] = new Tile();
                }
            }
        }

        public void MovePiece(TileLocation origin, TileLocation destination)
        {
            if (Math.Abs(origin.X - destination.X) != 1 || Math.Abs(origin.Y - destination.Y) != 1)
                throw new InvalidMoveException("That move is not valid");

            Tiles[origin.X, origin.Y].IsOccupied = false;
            Tiles[destination.X, destination.Y].IsOccupied = true;
        }
    }

    public class TileLocation
    {
        public int X { get; set; }
        public int Y { get; set; }
    }


    public class Tile
    {
        public bool IsOccupied { get; set; }
    }
}
