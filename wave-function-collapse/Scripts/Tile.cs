using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace App.Scripts
{
	internal class Tile
	{
		public Texture2D Texture;

		public List<Tile> UpNeighbours;
		public List<Tile> RightNeighbours;
		public List<Tile> DownNeighbours;
		public List<Tile> LeftNeighbours;

		public Tile(Texture2D texture)
		{
			Texture = texture;
		}
	}
}
