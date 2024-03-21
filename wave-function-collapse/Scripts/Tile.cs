using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace App.Scripts
{
    internal class Tile(Texture2D texture)
    {
        public Texture2D Texture = texture;

        public List<Tile> UpNeighbours;
        public List<Tile> RightNeighbours;
        public List<Tile> DownNeighbours;
        public List<Tile> LeftNeighbours;
    }
}
