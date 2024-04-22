using App.Scripts;
using Core.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace App
{
    public class NGExample : Game
    {
        private readonly GameManager _gameManager;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Generator _generator;

        public NGExample()
        {
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _gameManager = GameManager.GetInstance();
            _generator = new Generator();
            _graphics = new GraphicsDeviceManager(this);
        }

        protected override void Initialize()
        {
            Window.Title = "Noise Generator App";

            _gameManager.AddService(_graphics);
            _gameManager.AddService(Content);
            _gameManager.AddService(Window);
            _gameManager.AddService(this);
            _gameManager.AddService(GraphicsDevice);

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _gameManager.AddService(_spriteBatch);

            _generator.Initialize();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _generator.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _generator.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _generator.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
