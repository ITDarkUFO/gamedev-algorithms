﻿using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace App.Scripts
{
	internal class TileCollection
	{
		public List<Tile> tiles = new();

		public TileCollection(List<Texture2D> textures)
		{
			Tile emptyTile = new(null)
			{
				UpNeighbours = new()
				{
					new(textures.FirstOrDefault(t => t.Name == "Maze/0")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/A")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/AB")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/ABD")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/AD")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/B")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/BD")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/D")),
				},
				RightNeighbours = new()
				{
					new(textures.FirstOrDefault(t => t.Name == "Maze/0")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/A")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/AB")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/ABC")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/AC")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/B")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/BC")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/C")),
				},
				DownNeighbours = new()
				{
					new(textures.FirstOrDefault(t => t.Name == "Maze/0")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/B")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/BC")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/BCD")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/BD")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/C")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/CD")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/D")),
				},
				LeftNeighbours = new()
				{
					new(textures.FirstOrDefault(t => t.Name == "Maze/0")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/A")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/AC")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/ACD")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/AD")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/C")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/CD")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/D")),
				}
			};

			Tile fullTile = new(null)
			{
				UpNeighbours = new()
				{
					new(textures.FirstOrDefault(t => t.Name == "Maze/ABC")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/ABCD")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/AC")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/ACD")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/BC")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/BCD")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/C")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/CD")),
				},
				RightNeighbours = new()
				{
					new(textures.FirstOrDefault(t => t.Name == "Maze/ABCD")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/ABD")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/ACD")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/AD")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/BCD")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/BD")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/CD")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/D")),
				},
				DownNeighbours = new()
				{
					new(textures.FirstOrDefault(t => t.Name == "Maze/A")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/AB")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/ABC")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/ABCD")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/ABD")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/AC")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/ACD")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/AD")),
				},
				LeftNeighbours = new()
				{
					new(textures.FirstOrDefault(t => t.Name == "Maze/AB")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/ABC")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/ABCD")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/ABD")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/B")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/BC")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/BCD")),
					new(textures.FirstOrDefault(t => t.Name == "Maze/BD")),
				}
			};

			tiles.Add(new(textures.FirstOrDefault(t => t.Name == "Maze/0"))
			{
				UpNeighbours = emptyTile.UpNeighbours,
				RightNeighbours = emptyTile.RightNeighbours,
				DownNeighbours = emptyTile.DownNeighbours,
				LeftNeighbours = emptyTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => t.Name == "Maze/A"))
			{
				UpNeighbours = fullTile.UpNeighbours,
				RightNeighbours = emptyTile.RightNeighbours,
				DownNeighbours = emptyTile.DownNeighbours,
				LeftNeighbours = emptyTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => t.Name == "Maze/AB"))
			{
				UpNeighbours = fullTile.UpNeighbours,
				RightNeighbours = fullTile.RightNeighbours,
				DownNeighbours = emptyTile.DownNeighbours,
				LeftNeighbours = emptyTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => t.Name == "Maze/ABC"))
			{
				UpNeighbours = fullTile.UpNeighbours,
				RightNeighbours = fullTile.RightNeighbours,
				DownNeighbours = fullTile.DownNeighbours,
				LeftNeighbours = emptyTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => t.Name == "Maze/ABCD"))
			{
				UpNeighbours = fullTile.UpNeighbours,
				RightNeighbours = fullTile.RightNeighbours,
				DownNeighbours = fullTile.DownNeighbours,
				LeftNeighbours = fullTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => t.Name == "Maze/ABD"))
			{
				UpNeighbours = fullTile.UpNeighbours,
				RightNeighbours = fullTile.RightNeighbours,
				DownNeighbours = emptyTile.DownNeighbours,
				LeftNeighbours = fullTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => t.Name == "Maze/AC"))
			{
				UpNeighbours = fullTile.UpNeighbours,
				RightNeighbours = emptyTile.RightNeighbours,
				DownNeighbours = fullTile.DownNeighbours,
				LeftNeighbours = emptyTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => t.Name == "Maze/ACD"))
			{
				UpNeighbours = fullTile.UpNeighbours,
				RightNeighbours = emptyTile.RightNeighbours,
				DownNeighbours = fullTile.DownNeighbours,
				LeftNeighbours = fullTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => t.Name == "Maze/AD"))
			{
				UpNeighbours = fullTile.UpNeighbours,
				RightNeighbours = emptyTile.RightNeighbours,
				DownNeighbours = emptyTile.DownNeighbours,
				LeftNeighbours = fullTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => t.Name == "Maze/B"))
			{
				UpNeighbours = emptyTile.UpNeighbours,
				RightNeighbours = fullTile.RightNeighbours,
				DownNeighbours = emptyTile.DownNeighbours,
				LeftNeighbours = emptyTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => t.Name == "Maze/BC"))
			{
				UpNeighbours = emptyTile.UpNeighbours,
				RightNeighbours = fullTile.RightNeighbours,
				DownNeighbours = fullTile.DownNeighbours,
				LeftNeighbours = emptyTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => t.Name == "Maze/BCD"))
			{
				UpNeighbours = emptyTile.UpNeighbours,
				RightNeighbours = fullTile.RightNeighbours,
				DownNeighbours = fullTile.DownNeighbours,
				LeftNeighbours = fullTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => t.Name == "Maze/BD"))
			{
				UpNeighbours = emptyTile.UpNeighbours,
				RightNeighbours = fullTile.RightNeighbours,
				DownNeighbours = emptyTile.DownNeighbours,
				LeftNeighbours = fullTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => t.Name == "Maze/C"))
			{
				UpNeighbours = emptyTile.UpNeighbours,
				RightNeighbours = emptyTile.RightNeighbours,
				DownNeighbours = fullTile.DownNeighbours,
				LeftNeighbours = emptyTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => t.Name == "Maze/CD"))
			{
				UpNeighbours = emptyTile.UpNeighbours,
				RightNeighbours = emptyTile.RightNeighbours,
				DownNeighbours = fullTile.DownNeighbours,
				LeftNeighbours = fullTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => t.Name == "Maze/D"))
			{
				UpNeighbours = emptyTile.UpNeighbours,
				RightNeighbours = emptyTile.RightNeighbours,
				DownNeighbours = emptyTile.DownNeighbours,
				LeftNeighbours = fullTile.LeftNeighbours
			});
		}
	}
}