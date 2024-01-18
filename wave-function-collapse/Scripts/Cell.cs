using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Scripts
{
    internal class Cell
    {
        public Point Position;
        public Tile[] Options;
        public bool Collapsed;

        public Cell(Point position)
        {
            Position = position;
        }

        public void CreateCell(bool collapsed, Tile[] tiles)
        {
            Collapsed = collapsed;
            Options = tiles;
        }

        public void RecreateCell(Tile[] tiles)
        {
            Options = tiles;
        }
    }
}
