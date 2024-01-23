using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace App.Scripts
{
	internal class Cell
    {
        public Point Position;
        public List<Tile> Options;
        public Tile Tile;
        public bool Collapsed;

        public Cell(Point position)
        {
            Position = position;
        }

        public void CreateCell(bool collapsed, List<Tile> tiles)
        {
            Collapsed = collapsed;
            Options = new(tiles);
        }
    }
}
