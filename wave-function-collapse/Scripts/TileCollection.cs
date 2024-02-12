using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace App.Scripts
{
	internal class TileCollection
	{
		public List<Tile> tiles = [];

		public TileCollection(List<Texture2D> textures)
		{
			Tile emptyTile = new(null)
			{
				UpNeighbours =
				[
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "0")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "A")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "AB")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "ABD")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "AD")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "B")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "BD")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "D")),
					//new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "F")),
				],
				RightNeighbours =
				[
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "0")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "A")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "AB")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "ABC")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "AC")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "B")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "BC")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "C")),
					//new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "F")),
				],
				DownNeighbours =
				[
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "0")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "B")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "BC")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "BCD")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "BD")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "C")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "CD")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "D")),
					//new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "F")),
				],
				LeftNeighbours =
				[
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "0")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "A")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "AC")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "ACD")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "AD")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "C")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "CD")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "D")),
					//new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "F")),
				]
			};

			Tile fullTile = new(null)
			{
				UpNeighbours =
				[
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "ABC")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "ABCD")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "AC")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "ACD")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "BC")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "BCD")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "C")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "CD")),
				],
				RightNeighbours =
				[
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "ABCD")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "ABD")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "ACD")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "AD")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "BCD")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "BD")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "CD")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "D")),
				],
				DownNeighbours =
				[
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "A")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "AB")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "ABC")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "ABCD")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "ABD")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "AC")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "ACD")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "AD")),
				],
				LeftNeighbours =
				[
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "AB")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "ABC")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "ABCD")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "ABD")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "B")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "BC")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "BCD")),
					new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "BD")),
				]
			};

			tiles.Add(new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "0"))
			{
				UpNeighbours = emptyTile.UpNeighbours,
				RightNeighbours = emptyTile.RightNeighbours,
				DownNeighbours = emptyTile.DownNeighbours,
				LeftNeighbours = emptyTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "A"))
			{
				UpNeighbours = fullTile.UpNeighbours,
				RightNeighbours = emptyTile.RightNeighbours,
				DownNeighbours = emptyTile.DownNeighbours,
				LeftNeighbours = emptyTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "AB"))
			{
				UpNeighbours = fullTile.UpNeighbours,
				RightNeighbours = fullTile.RightNeighbours,
				DownNeighbours = emptyTile.DownNeighbours,
				LeftNeighbours = emptyTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "ABC"))
			{
				UpNeighbours = fullTile.UpNeighbours,
				RightNeighbours = fullTile.RightNeighbours,
				DownNeighbours = fullTile.DownNeighbours,
				LeftNeighbours = emptyTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "ABCD"))
			{
				UpNeighbours = fullTile.UpNeighbours,
				RightNeighbours = fullTile.RightNeighbours,
				DownNeighbours = fullTile.DownNeighbours,
				LeftNeighbours = fullTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "ABD"))
			{
				UpNeighbours = fullTile.UpNeighbours,
				RightNeighbours = fullTile.RightNeighbours,
				DownNeighbours = emptyTile.DownNeighbours,
				LeftNeighbours = fullTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "AC"))
			{
				UpNeighbours = fullTile.UpNeighbours,
				RightNeighbours = emptyTile.RightNeighbours,
				DownNeighbours = fullTile.DownNeighbours,
				LeftNeighbours = emptyTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "ACD"))
			{
				UpNeighbours = fullTile.UpNeighbours,
				RightNeighbours = emptyTile.RightNeighbours,
				DownNeighbours = fullTile.DownNeighbours,
				LeftNeighbours = fullTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "AD"))
			{
				UpNeighbours = fullTile.UpNeighbours,
				RightNeighbours = emptyTile.RightNeighbours,
				DownNeighbours = emptyTile.DownNeighbours,
				LeftNeighbours = fullTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "B"))
			{
				UpNeighbours = emptyTile.UpNeighbours,
				RightNeighbours = fullTile.RightNeighbours,
				DownNeighbours = emptyTile.DownNeighbours,
				LeftNeighbours = emptyTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "BC"))
			{
				UpNeighbours = emptyTile.UpNeighbours,
				RightNeighbours = fullTile.RightNeighbours,
				DownNeighbours = fullTile.DownNeighbours,
				LeftNeighbours = emptyTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "BCD"))
			{
				UpNeighbours = emptyTile.UpNeighbours,
				RightNeighbours = fullTile.RightNeighbours,
				DownNeighbours = fullTile.DownNeighbours,
				LeftNeighbours = fullTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "BD"))
			{
				UpNeighbours = emptyTile.UpNeighbours,
				RightNeighbours = fullTile.RightNeighbours,
				DownNeighbours = emptyTile.DownNeighbours,
				LeftNeighbours = fullTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "C"))
			{
				UpNeighbours = emptyTile.UpNeighbours,
				RightNeighbours = emptyTile.RightNeighbours,
				DownNeighbours = fullTile.DownNeighbours,
				LeftNeighbours = emptyTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "CD"))
			{
				UpNeighbours = emptyTile.UpNeighbours,
				RightNeighbours = emptyTile.RightNeighbours,
				DownNeighbours = fullTile.DownNeighbours,
				LeftNeighbours = fullTile.LeftNeighbours
			});

			tiles.Add(new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "D"))
			{
				UpNeighbours = emptyTile.UpNeighbours,
				RightNeighbours = emptyTile.RightNeighbours,
				DownNeighbours = emptyTile.DownNeighbours,
				LeftNeighbours = fullTile.LeftNeighbours
			});

			//tiles.Add(new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "F"))
			//{
			//	UpNeighbours =
			//	[
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "A")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "AB")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "ABD")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "AD")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "B")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "BD")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "D")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "F")),

			//	],
			//	RightNeighbours =
			//	[
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "A")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "AB")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "ABC")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "AC")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "B")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "BC")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "C")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "F")),
			//	],
			//	DownNeighbours =
			//	[
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "B")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "BC")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "BCD")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "BD")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "C")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "CD")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "D")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "F")),
			//	],
			//	LeftNeighbours =
			//	[
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "A")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "AC")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "ACD")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "AD")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "C")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "CD")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "D")),
			//		new(textures.FirstOrDefault(t => Path.GetFileNameWithoutExtension(t.Name) == "F")),
			//	]
			//});
		}
	}
}
