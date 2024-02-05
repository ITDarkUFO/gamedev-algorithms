﻿using App.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace App.Scripts
{
	internal class Grid
	{
		#region Constants

		public const int TEXTURE_SIZE = 20;
		public const int OFFSET = 20;
		public const string GENERATOR_TYPE = "Maze";

		#endregion

		#region Fields

		private readonly Random _random;
		private readonly GameManager _gameManager;
		private SpriteBatch _spriteBatch;
		private ContentManager _content;
		private GraphicsDeviceManager _graphics;

		private readonly List<Texture2D> _textures = [];
		private readonly List<Cell> _cells = [];
		private readonly List<Cell> _collapsedCells = [];
		private TileCollection _tiles;

		private SpriteFont _font;
		private GeneratorData generatorData;
		private TilesetData tilesetData;

		private readonly JsonSerializerOptions serializerOptions = new()
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase
		};

		#endregion

		#region Properties

		public string TilesetName { get; private set; }

		public Point GridSize;

		#endregion

		public Grid()
		{
			_random = new();
			_gameManager = GameManager.GetInstance();
		}

		public async void Initialize(string tilesetName)
		{
			TilesetName = tilesetName;

			var _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Presets", $"{tilesetName}.zip");

			if (File.Exists(_filePath))
			{
				var archiveStream = new FileStream(_filePath, FileMode.Open);

				var archive = new ZipArchive(archiveStream, ZipArchiveMode.Read);

				using Stream generatorJsonStream = archive.Entries.First(e => e.Name == "generator-data.json").Open();
				generatorData = await JsonSerializer.DeserializeAsync<GeneratorData>(generatorJsonStream, serializerOptions);
				generatorJsonStream.Close();

				using Stream tilesetJsonStream = archive.Entries.First(e => e.Name == "tileset-data.json").Open();
				tilesetData = await JsonSerializer.DeserializeAsync<TilesetData>(tilesetJsonStream, serializerOptions);
				tilesetJsonStream.Close();
			}

			//TODO: Добавить проверку легальности json по схеме

			if (generatorData.Settings.IsFixed)
			{
				//TODO: Выбор размера поля из предложенных вариантов
				GridSize = new Point(generatorData.Settings.Dimensions[0][0], generatorData.Settings.Dimensions[0][1]);
			}
			else
			{
				//TODO: Выбор размера поля
				GridSize = new Point(20, 30);
			}

			for (int y = 0; y < GridSize.Y; y++)
			{
				for (int x = 0; x < GridSize.X; x++)
				{
					_cells.Add(new(new Point(x, y)));
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

			_font = _content.Load<SpriteFont>("tempFont");

			_graphics.PreferredBackBufferWidth = (TEXTURE_SIZE * GridSize.X) + (OFFSET * 2);
			_graphics.PreferredBackBufferHeight = (TEXTURE_SIZE * GridSize.Y) + (OFFSET * 2);
			_graphics.ApplyChanges();
		}

		public void Update(GameTime _)
		{
			Cell cell;

			if (_collapsedCells.Count != _cells.Count)
			{
				if (_collapsedCells.Count == 0)
				{
					cell = _cells[_random.Next(GridSize.Y * GridSize.X)];

					cell.Tile = cell.Options[_random.Next(cell.Options.Count)];
					cell.Collapsed = true;
				}
				else
				{
					var clearCells = _cells
						.Where(c => !c.Collapsed)
						.OrderBy(c => c.Options.Count);

					var smallestCells = clearCells
						.GroupBy(c => c.Options.Count)
						.Where(g => g.Key == clearCells.First().Options.Count)
						.SelectMany(g => g);

					cell = smallestCells.ElementAt(_random.Next(smallestCells.Count()));
					cell.Tile = cell.Options[_random.Next(cell.Options.Count)];
					cell.Collapsed = true;
				}

				_collapsedCells.Add(cell);

				if (cell.Position.X > 0)
				{
					var position = (cell.Position.Y * GridSize.X) + cell.Position.X - 1;
					var newCell = _cells[position];
					var options = newCell.Options;
					var neighbours = _tiles.tiles.FirstOrDefault(t => t.Texture == cell.Tile.Texture).LeftNeighbours;
					options.RemoveAll(o => !neighbours.Any(n => n.Texture == o.Texture));
				}
				if (cell.Position.Y > 0)
				{
					var position = ((cell.Position.Y - 1) * GridSize.X) + cell.Position.X;
					var newCell = _cells[position];
					var options = newCell.Options;
					var neighbours = _tiles.tiles.FirstOrDefault(t => t.Texture == cell.Tile.Texture).UpNeighbours;
					options.RemoveAll(o => !neighbours.Any(n => n.Texture == o.Texture));
				}
				if (cell.Position.X < GridSize.X - 1)
				{
					var position = (cell.Position.Y * GridSize.X) + cell.Position.X + 1;
					var newCell = _cells[position];
					var options = newCell.Options;
					var neighbours = _tiles.tiles.FirstOrDefault(t => t.Texture == cell.Tile.Texture).RightNeighbours;
					options.RemoveAll(o => !neighbours.Any(n => n.Texture == o.Texture));
				}
				if (cell.Position.Y < GridSize.Y - 1)
				{
					var position = ((cell.Position.Y + 1) * GridSize.X) + cell.Position.X;
					var newCell = _cells[position];
					var options = newCell.Options;
					var neighbours = _tiles.tiles.FirstOrDefault(t => t.Texture == cell.Tile.Texture).DownNeighbours;
					options.RemoveAll(o => !neighbours.Any(n => n.Texture == o.Texture));
				}
			}
		}

		public void Draw(GameTime _)
		{
			Point offset = new(OFFSET);
			for (var y = 0; y < GridSize.Y; y++)
			{
				for (var x = 0; x < GridSize.X; x++)
				{
					if (_cells[y * GridSize.X + x].Tile == null)
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
						_spriteBatch.Draw(_cells[y * GridSize.X + x].Tile.Texture, new Rectangle(
							new Point(x * TEXTURE_SIZE, y * TEXTURE_SIZE) + offset,
							new Point(TEXTURE_SIZE)), Color.White);
						_spriteBatch.End();
					}
				}
			}

			if (tilesetData != null)
			{
				_spriteBatch.Begin(samplerState: SamplerState.PointClamp);
				_spriteBatch.DrawString(_font, tilesetData.Name, new Vector2(10), Color.Red);
				_spriteBatch.DrawString(_font, tilesetData.Version,
					new Vector2(10, 15 + _font.MeasureString(tilesetData.Name).Y), Color.Red);
				_spriteBatch.End();
			}
		}
	}
}
