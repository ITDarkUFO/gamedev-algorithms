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
    internal class Screen
    {
        private readonly Random _random;
        private readonly GameManager _gameManager;

        private SpriteBatch _spriteBatch;
        private ContentManager _content;

        private List<Texture2D> _textures = new();

        public const string GENERATOR_TYPE = "Maze";

        public Screen()
        {
            _random = new();
            _gameManager = GameManager.GetInstance();
        }

        public void Initialize()
        {

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
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(GameTime gameTime)
        {
            var texture = _textures[_random.Next(_textures.Count)];

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(texture, new Rectangle(Point.Zero, new Point(100)), Color.White);
            _spriteBatch.End();
        }
    }
}
