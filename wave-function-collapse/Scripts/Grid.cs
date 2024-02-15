using App.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.Json;

namespace App.Scripts
{
	internal class Grid
	{
		#region Constants

		//TODO: Сделать PropertiesRegistry, где можно зарегистрировать свойства, которые можно менять в настройках

		public const int TEXTURE_SIZE = 20;
		public const int OFFSET = 20;

		#endregion

		#region Fields

		private readonly Random _random;
		private readonly GameManager _gameManager;
		private readonly JsonSchemaManager _jsonSchemaManager;

		private ContentManager _content;
		private SpriteBatch _spriteBatch;
		private GraphicsDeviceManager _graphics;

		private readonly List<Texture2D> _textures = [];
		private readonly List<Cell> _cells = [];
		//private readonly List<Cell> _collapsedCells = [];

		private SpriteFont _font;
		private GeneratorData _generatorData;
		private TilesetData _tilesetData;

		private FileStream _archiveStream;
		private ZipArchive _archive;

		private readonly JsonSerializerOptions _serializerOptions = new()
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase
		};

		#endregion

		#region Properties

		public string TilesetName { get; private set; }

		public Point GridSize { get; private set; }

		#endregion

		public Grid()
		{
			_random = new();
			_gameManager = GameManager.GetInstance();
			_jsonSchemaManager = JsonSchemaManager.GetInstance();
		}

		public async void Initialize(string tilesetName)
		{
			TilesetName = tilesetName;

			var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Presets", $"{TilesetName}.zip");

			if (File.Exists(filePath))
			{
				_archiveStream = new FileStream(filePath, FileMode.Open);
				_archive = new ZipArchive(_archiveStream, ZipArchiveMode.Read);

				using var generatorStream = _archive.Entries.First(e => e.Name == "generator-data.json").Open();
				using var generatorDocument = await JsonDocument.ParseAsync(generatorStream);

				if (_jsonSchemaManager.EvaluateData("generator-schema", generatorDocument, out var generatorErrors))
					_generatorData = generatorDocument.Deserialize<GeneratorData>(_serializerOptions);
				else
					throw new JsonException("В полученных данных найдены ошибки!");

				using var tilesetStream = _archive.Entries.First(e => e.Name == "tileset-data.json").Open();
				using var tilesetDocument = await JsonDocument.ParseAsync(tilesetStream);

				if (_jsonSchemaManager.EvaluateData("tileset-schema", tilesetDocument, out var tilesetErrors))
					_tilesetData = tilesetDocument.Deserialize<TilesetData>(_serializerOptions);
				else
					throw new JsonException("В полученных данных найдены ошибки!");
			}
			else
				throw new FileNotFoundException("Указанный файл не найден!");

			if (_generatorData.Settings.IsFixed)
			{
				//TODO: Выбор размера поля из предложенных вариантов
				GridSize = new Point(_generatorData.Settings.Dimensions[0][0], _generatorData.Settings.Dimensions[0][1]);
			}
			else
			{
				//TODO: Выбор размера поля пользователем
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

			//TODO: Загрузка изображений со всеми поддерживаемыми типами, через foreach
			var tileEntries = _archive.Entries.Where(e => e.Name.Contains(".png"));
			tileEntries = tileEntries.Concat(_archive.Entries.Where(e => e.Name.Contains(".jpg")));

			foreach (var tileEntry in tileEntries)
			{
				var image = Texture2D.FromStream(_graphics.GraphicsDevice, tileEntry.Open());
				image.Name = tileEntry.Name;

				_textures.Add(image);
			}

			_archive.Dispose();

			foreach (var cell in _cells)
			{
				cell.CreateCell(false, _tilesetData.Tiles);
			}

			_font = _content.Load<SpriteFont>("tempFont");

			_graphics.PreferredBackBufferWidth = (TEXTURE_SIZE * GridSize.X) + (OFFSET * 2);
			_graphics.PreferredBackBufferHeight = (TEXTURE_SIZE * GridSize.Y) + (OFFSET * 2);
			_graphics.ApplyChanges();
		}

		public void Update(GameTime _)
		{
			Cell cell;

			var clearCells = _cells
					.Where(c => !c.Collapsed)
					.OrderBy(c => c.Options.Count);

			if (clearCells.Any())
			{
				var smallestCells = clearCells
					.GroupBy(c => c.Options.Count)
					.Where(g => g.Key == clearCells.First().Options.Count)
					.SelectMany(g => g);

				cell = smallestCells.ElementAt(_random.Next(smallestCells.Count()));

				if (cell.Options.Count > 0)
				{
					cell.Tile = cell.Options[_random.Next(cell.Options.Count)].Tile;
					cell.Texture = _textures.First(t => Path.GetFileNameWithoutExtension(t.Name) == cell.Tile);
					cell.Collapsed = true;
					ChangeNeighbours(cell);
				}
				else
				{
					cell.RecreateCell(false, GetCompatibleTiles(cell));
					ClearNeighbours(cell);
				}
			}
		}

		public void Draw(GameTime _)
		{
			DrawBackground([Color.White, Color.LightGray]);

			Point offset = new(OFFSET);

			for (var y = 0; y < GridSize.Y; y++)
			{
				for (var x = 0; x < GridSize.X; x++)
				{
					if (_cells[y * GridSize.X + x].Texture != null)
					{
						_spriteBatch.Begin(samplerState: SamplerState.PointClamp);
						_spriteBatch.Draw(_cells[y * GridSize.X + x].Texture, new Rectangle(
							new Point(x * TEXTURE_SIZE, y * TEXTURE_SIZE) + offset,
							new Point(TEXTURE_SIZE)), Color.White);
						_spriteBatch.End();
					}
				}
			}

			//DrawLinesGrid(Color.DarkGreen);

			if (_tilesetData != null)
			{
				_spriteBatch.Begin(samplerState: SamplerState.PointClamp);
				_spriteBatch.DrawString(_font, _tilesetData.Name, new Vector2(10), Color.Red);
				_spriteBatch.DrawString(_font, _tilesetData.Version,
					new Vector2(10, 15 + _font.MeasureString(_tilesetData.Name).Y), Color.Red);
				_spriteBatch.DrawString(_font, $"{100 - (int)(_cells.Where(c => !c.Collapsed).Count() / (double)_cells.Count * 100)}%",
					new Vector2(10, 20 + _font.MeasureString(_tilesetData.Name).Y + _font.MeasureString(_tilesetData.Version).Y), Color.Red);
				_spriteBatch.End();
			}
		}

		private void ChangeNeighbours(Cell cell)
		{
			if (cell.Position.X > 0)
			{
				var neighbours = _tilesetData.Tiles.First(t => t.Tile == cell.Tile).Neighbors.Left;

				var neighbourPos = (cell.Position.Y * GridSize.X) + cell.Position.X - 1;
				var neighbourCell = _cells[neighbourPos];
				var neighbourOptions = neighbourCell.Options;
				neighbourOptions.RemoveAll(o => !neighbours.Any(n => n == o.Tile));
			}
			if (cell.Position.Y > 0)
			{
				var neighbours = _tilesetData.Tiles.First(t => t.Tile == cell.Tile).Neighbors.Up;

				var neighbourPos = ((cell.Position.Y - 1) * GridSize.X) + cell.Position.X;
				var neighbourCell = _cells[neighbourPos];
				var neighbourOptions = neighbourCell.Options;
				neighbourOptions.RemoveAll(o => !neighbours.Any(n => n == o.Tile));
			}
			if (cell.Position.X < GridSize.X - 1)
			{
				var neighbours = _tilesetData.Tiles.First(t => t.Tile == cell.Tile).Neighbors.Right;

				var neighbourPos = (cell.Position.Y * GridSize.X) + cell.Position.X + 1;
				var neighbourCell = _cells[neighbourPos];
				var neighbourOptions = neighbourCell.Options;
				neighbourOptions.RemoveAll(o => !neighbours.Any(n => n == o.Tile));
			}
			if (cell.Position.Y < GridSize.Y - 1)
			{
				var neighbours = _tilesetData.Tiles.First(t => t.Tile == cell.Tile).Neighbors.Down;

				var neighbourPos = ((cell.Position.Y + 1) * GridSize.X) + cell.Position.X;
				var neighbourCell = _cells[neighbourPos];
				var neighbourOptions = neighbourCell.Options;
				neighbourOptions.RemoveAll(o => !neighbours.Any(n => n == o.Tile));
			}
		}

		private void ClearNeighbours(Cell cell)
		{
			if (cell.Position.X > 0)
			{
				var neighbourPos = (cell.Position.Y * GridSize.X) + cell.Position.X - 1;
				var neighbourCell = _cells[neighbourPos];
				neighbourCell.RecreateCell(false, neighbourCell.Options);
			}
			if (cell.Position.Y > 0)
			{
				var neighbourPos = ((cell.Position.Y - 1) * GridSize.X) + cell.Position.X;
				var neighbourCell = _cells[neighbourPos];
				neighbourCell.RecreateCell(false, neighbourCell.Options);
			}
			if (cell.Position.X < GridSize.X - 1)
			{
				var neighbourPos = (cell.Position.Y * GridSize.X) + cell.Position.X + 1;
				var neighbourCell = _cells[neighbourPos];
				neighbourCell.RecreateCell(false, neighbourCell.Options);
			}
			if (cell.Position.Y < GridSize.Y - 1)
			{
				var neighbourPos = ((cell.Position.Y + 1) * GridSize.X) + cell.Position.X;
				var neighbourCell = _cells[neighbourPos];
				neighbourCell.RecreateCell(false, neighbourCell.Options);
			}
		}

		private List<TilesetData.TileData> GetCompatibleTiles(Cell cell)
		{
			List<TilesetData.TileData> tileData = _tilesetData.Tiles;

			if (cell.Position.X > 0)
			{
				var neighbourPos = (cell.Position.Y * GridSize.X) + cell.Position.X - 1;
				var neighbourCell = _cells[neighbourPos];

				if (neighbourCell.Collapsed)
				{
					var neighbours = _tilesetData.Tiles.First(t => t.Tile == neighbourCell.Tile).Neighbors.Left;
					tileData = tileData.Intersect(_tilesetData.Tiles.GroupBy(t => neighbours.Contains(t.Tile)).Where(g => g.Key == true).SelectMany(g => g)).ToList();
				}
			}
			if (cell.Position.Y > 0)
			{
				var neighbourPos = ((cell.Position.Y - 1) * GridSize.X) + cell.Position.X;
				var neighbourCell = _cells[neighbourPos];

				if (neighbourCell.Collapsed)
				{
					var neighbours = _tilesetData.Tiles.First(t => t.Tile == neighbourCell.Tile).Neighbors.Up;
					tileData = tileData.Intersect(_tilesetData.Tiles.GroupBy(t => neighbours.Contains(t.Tile)).Where(g => g.Key == true).SelectMany(g => g)).ToList();
				}
			}
			if (cell.Position.X < GridSize.X - 1)
			{
				var neighbourPos = (cell.Position.Y * GridSize.X) + cell.Position.X + 1;
				var neighbourCell = _cells[neighbourPos];

				if (neighbourCell.Collapsed)
				{
					var neighbours = _tilesetData.Tiles.First(t => t.Tile == neighbourCell.Tile).Neighbors.Right;
					tileData = tileData.Intersect(_tilesetData.Tiles.GroupBy(t => neighbours.Contains(t.Tile)).Where(g => g.Key == true).SelectMany(g => g)).ToList();
				}
			}
			if (cell.Position.Y < GridSize.Y - 1)
			{
				var neighbourPos = ((cell.Position.Y + 1) * GridSize.X) + cell.Position.X;
				var neighbourCell = _cells[neighbourPos];

				if (neighbourCell.Collapsed)
				{
					var neighbours = _tilesetData.Tiles.First(t => t.Tile == neighbourCell.Tile).Neighbors.Down;
					tileData = tileData.Intersect(_tilesetData.Tiles.GroupBy(t => neighbours.Contains(t.Tile)).Where(g => g.Key == true).SelectMany(g => g)).ToList();
				}
			}

			return tileData;
		}

		private void DrawBackground(Color[] colors)
		{
			int color;
			Point offset = new(OFFSET);

			Texture2D texture = new(_graphics.GraphicsDevice, TEXTURE_SIZE, TEXTURE_SIZE);

			Color[] colData = [];
			for (int i = 0; i < TEXTURE_SIZE * TEXTURE_SIZE; i++)
				colData = [.. colData, Color.White];

			texture.SetData(colData);

			for (var y = 0; y < GridSize.Y; y++)
			{
				for (var x = 0; x < GridSize.X; x++)
				{
					color = (y + x) % colors.Length;

					_spriteBatch.Begin(samplerState: SamplerState.PointClamp);
					_spriteBatch.Draw(texture, new Rectangle(
						new Point(x * TEXTURE_SIZE, y * TEXTURE_SIZE) + offset,
						new Point(TEXTURE_SIZE)), colors[color]);
					_spriteBatch.End();
				}
			}
		}

		private void DrawLinesGrid(Color linesColor)
		{
			Texture2D bit = new(_graphics.GraphicsDevice, 1, 1);
			bit.SetData([linesColor]);

			for (var y = 0; y < GridSize.Y + 1; y++)
			{
				_spriteBatch.Begin(samplerState: SamplerState.PointClamp);
				_spriteBatch.Draw(bit,
					new Rectangle(0 + OFFSET, y * TEXTURE_SIZE + OFFSET, TEXTURE_SIZE * GridSize.X, 1), Color.White);
				_spriteBatch.End();
			}
			for (var x = 0; x < GridSize.X + 1; x++)
			{
				_spriteBatch.Begin(samplerState: SamplerState.PointClamp);
				_spriteBatch.Draw(bit,
					new Rectangle(x * TEXTURE_SIZE + OFFSET, 0 + OFFSET, 1, TEXTURE_SIZE * GridSize.Y), Color.White);
				_spriteBatch.End();
			}
		}
	}
}
