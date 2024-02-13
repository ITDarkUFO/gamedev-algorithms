using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using static App.Scripts.TilesetData;

namespace App.Scripts
{
	internal class Cell(Point position)
	{
        public Point Position = position;
        public string Tile;
        public Texture2D Texture;
        public List<TileData> Options;
        public bool Collapsed;

		public void CreateCell(bool collapsed, List<TileData> options)
        {
            Collapsed = collapsed;
            Options = new(options);
        }
    }
}
