using App.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Scripts
{
    internal class Grid
    {
        #region Constants

        public int GRID_SIZE = 20;
        public const string GENERATOR_TYPE = "Maze";

        #endregion

        #region Fields

        private readonly Random _random;
        private readonly GameManager _gameManager;
        private SpriteBatch _spriteBatch;
        private ContentManager _content;

        private List<Texture2D> _textures = new();
        private List<Cell> _cells = new();
        private TileCollection _tiles;

        #endregion

        #region Properties

        #endregion

        public Grid()
        {
            _random = new();
            _gameManager = GameManager.GetInstance();
        }

        public void Initialize()
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                for (int j = 0; j < GRID_SIZE; j++)
                {
                    Cell newCell = new(new Point(i, j));
                }
            }
        }

        public void LoadContent()
        {
            _content = _gameManager.GetService<ContentManager>();
            _spriteBatch = _gameManager.GetService<SpriteBatch>();

            foreach (var _fileName in Directory
                .EnumerateFiles(Path.Combine(_content.RootDirectory, GENERATOR_TYPE))
                .Select(Path.GetFileNameWithoutExtension))
            {
                _textures.Add(_content.Load<Texture2D>($"{GENERATOR_TYPE}/{_fileName}"));
            }

            _tiles = new(_textures);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime)
        {
            int textureSize = 50;

            for (var i = 0; i < GRID_SIZE; i++)
            {
                for (var j = 0; j < GRID_SIZE; j++)
                {
                    var texture = _textures[_random.Next(_textures.Count)];

                    _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
                    _spriteBatch.Draw(texture, new Rectangle(new Point(i * textureSize, j * textureSize), new Point(textureSize)), Color.White);
                    _spriteBatch.End();
                }
            }
        }
    }
}
