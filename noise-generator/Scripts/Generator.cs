using Core.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace App.Scripts
{
    internal class Generator : Core.Scripts.IUpdateable, Core.Scripts.IDrawable, IGameComponent
    {
        #region Fields

        private readonly Random _random;
        private readonly GameManager _gameManager;

        private ContentManager _content;
        private SpriteBatch _spriteBatch;
        private GraphicsDeviceManager _graphics;

        private readonly List<Cell> _grid = [];
        private Texture2D _texture;
        private readonly List<Color> _colorData = [];
        private int current = 0;
        private SpriteFont _font;

        private int _textureWidth = 1000;
        private int _textureHeight = 500;
        private int _generatorStep = 1000;

        #endregion

        #region Properties

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public bool Visible => throw new NotImplementedException();

        public int DrawOrder => throw new NotImplementedException();

        #endregion

        #region Events

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
        public event EventHandler<EventArgs> DrawOrderChanged;

        #endregion

        public Generator()
        {
            _random = new();
            _gameManager = GameManager.GetInstance();
        }

        public void Initialize()
        {
            _graphics = _gameManager.GetService<GraphicsDeviceManager>();
            //_graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            //_graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();

            //_textureWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            //_textureHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //_generatorStep = _textureWidth * _textureHeight / 100;

            _textureWidth = 800;
            _textureHeight = 600;

            for (int y = 0; y < _textureHeight; y++)
            {
                for (int x = 0; x < _textureWidth; x++)
                {
                    _grid.Add(new Cell(x, y));
                    _colorData.Add(Color.White);
                }
            }
        }

        public void LoadContent()
        {
            _content = _gameManager.GetService<ContentManager>();
            _spriteBatch = _gameManager.GetService<SpriteBatch>();

            _texture = new(_graphics.GraphicsDevice, _textureWidth, _textureHeight);
            _font = _content.Load<SpriteFont>("Font");
        }

        public void Update(GameTime gameTime)
        {
            //current = 0;

            //while (current < _textureWidth * _textureHeight)
            //{
            for (int i = current; i < _textureWidth * _textureHeight; i++)
            {
                var color = _random.Next(255);
                _colorData[i] = new Color(color, color, color);
            }

            //    current = _textureWidth * _textureHeight;
            //}

            _texture.SetData(_colorData.ToArray());
        }

        public void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            _spriteBatch.Draw(_texture, new Rectangle(0, 0, _textureWidth, _textureHeight), Color.White);
            _spriteBatch.DrawString(_font, $"{gameTime.ElapsedGameTime.TotalMilliseconds}",
                new Vector2(15, 10), Color.Blue);

            _spriteBatch.End();
        }
    }
}
