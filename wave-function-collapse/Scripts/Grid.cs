using App.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace App.Scripts
{
	internal class Grid
	{
		#region Constants

		public const int GRID_SIZE = 30;
		public const int TEXTURE_SIZE = 30;
		public const int OFFSET = 20;
		public const string GENERATOR_TYPE = "Maze";

		#endregion

		#region Fields

		private readonly Random _random;
		private readonly GameManager _gameManager;
		private SpriteBatch _spriteBatch;
		private ContentManager _content;
		private GraphicsDeviceManager _graphics;

		private string _tilesetName;
		private readonly List<Texture2D> _textures = [];
		private readonly List<Cell> _cells = [];
		private TileCollection _tiles;

		private bool _isInitialized = false;
		private int _collapsedCells = 0;

		#endregion

		#region Properties

		#endregion

		public Grid()
		{
			_random = new();
			_gameManager = GameManager.GetInstance();
		}

		public void Initialize(string tilesetName)
		{
			_tilesetName = tilesetName;

			//TODO: Открытие zip-архива
			for (int i = 0; i < GRID_SIZE; i++)
			{
				for (int j = 0; j < GRID_SIZE; j++)
				{
					_cells.Add(new(new Point(j, i)));
				}
			}
		}

		public void LoadContent()
		{
			_content = _gameManager.GetService<ContentManager>();
			_spriteBatch = _gameManager.GetService<SpriteBatch>();
			_graphics = _gameManager.GetService<GraphicsDeviceManager>();

			foreach (var _fileName in Directory
				.EnumerateFiles(Path.Combine(_content.RootDirectory, GENERATOR_TYPE))
				.Select(Path.GetFileNameWithoutExtension))
			{
				_textures.Add(_content.Load<Texture2D>($"{GENERATOR_TYPE}/{_fileName}"));
			}

			_tiles = new(_textures);

			foreach (var cell in _cells)
			{
				cell.CreateCell(false, _tiles.tiles);
			}

			_graphics.PreferredBackBufferWidth = (TEXTURE_SIZE * GRID_SIZE) + (OFFSET * 2);
			_graphics.PreferredBackBufferHeight = (TEXTURE_SIZE * GRID_SIZE) + (OFFSET * 2);
			_graphics.ApplyChanges();
		}

		public void Update(GameTime gameTime)
		{
			Cell cell;

			if (_collapsedCells != _cells.Count)
			{
				if (!_isInitialized)
				{
					cell = _cells[_random.Next(GRID_SIZE * GRID_SIZE)];

					cell.Tile = cell.Options[_random.Next(cell.Options.Count)];
					cell.Collapsed = true;

					_isInitialized = true;
				}
				else
				{

					cell = _cells.Where(c => !c.Collapsed).OrderBy(c => c.Options.Count).First();
					cell.Tile = cell.Options[_random.Next(cell.Options.Count)];
					cell.Collapsed = true;

				}

				_collapsedCells += 1;


				if (cell.Position.X > 0)
				{
					var position = (cell.Position.Y * GRID_SIZE) + cell.Position.X - 1;
					var newCell = _cells[position];
					var options = newCell.Options;
					var neighbours = _tiles.tiles.FirstOrDefault(t => t.Texture == cell.Tile.Texture).LeftNeighbours;
					options.RemoveAll(o => !neighbours.Any(n => n.Texture == o.Texture));
				}
				if (cell.Position.Y > 0)
				{
					var position = ((cell.Position.Y - 1) * GRID_SIZE) + cell.Position.X;
					var newCell = _cells[position];
					var options = newCell.Options;
					var neighbours = _tiles.tiles.FirstOrDefault(t => t.Texture == cell.Tile.Texture).UpNeighbours;
					options.RemoveAll(o => !neighbours.Any(n => n.Texture == o.Texture));
				}
				if (cell.Position.X < GRID_SIZE - 1)
				{
					var position = (cell.Position.Y * GRID_SIZE) + cell.Position.X + 1;
					var newCell = _cells[position];
					var options = newCell.Options;
					var neighbours = _tiles.tiles.FirstOrDefault(t => t.Texture == cell.Tile.Texture).RightNeighbours;
					options.RemoveAll(o => !neighbours.Any(n => n.Texture == o.Texture));
				}
				if (cell.Position.Y < GRID_SIZE - 1)
				{
					var position = ((cell.Position.Y + 1) * GRID_SIZE) + cell.Position.X;
					var newCell = _cells[position];
					var options = newCell.Options;
					var neighbours = _tiles.tiles.FirstOrDefault(t => t.Texture == cell.Tile.Texture).DownNeighbours;
					options.RemoveAll(o => !neighbours.Any(n => n.Texture == o.Texture));
				}
			}
		}

		public void Draw(GameTime gameTime)
		{
			Point offset = new(OFFSET);
			for (var y = 0; y < GRID_SIZE; y++)
			{
				for (var x = 0; x < GRID_SIZE; x++)
				{
					if (_cells[y * GRID_SIZE + x].Tile == null)
					{
						_spriteBatch.Begin(samplerState: SamplerState.PointClamp);
						_spriteBatch.Draw(_textures[0], new Rectangle(
							new Point(x * TEXTURE_SIZE, y * TEXTURE_SIZE) + offset,
							new Point(TEXTURE_SIZE)), Color.White);
						_spriteBatch.End();
					}
					else
					{
						_spriteBatch.Begin(samplerState: SamplerState.PointClamp);
						_spriteBatch.Draw(_cells[y * GRID_SIZE + x].Tile.Texture, new Rectangle(
							new Point(x * TEXTURE_SIZE, y * TEXTURE_SIZE) + offset,
							new Point(TEXTURE_SIZE)), Color.White);
						_spriteBatch.End();
					}
				}
			}
		}
	}
}
