using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using App.Scripts;
using App.Engine;

namespace App
{
	public class WFCExample : Game
	{
		private readonly GameManager _gameManager;
		private readonly GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;
		private readonly Grid _screen;

		public WFCExample()
		{
			Content.RootDirectory = "Content";
			IsMouseVisible = true;

			_gameManager = GameManager.GetInstance();
			_graphics = new(this);
			_screen = new();
		}

		protected override void Initialize()
		{
			Window.Title = "Wave Func Collapse App";

			_screen.Initialize("Lines");

			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			_gameManager.AddService(_spriteBatch);
			_gameManager.AddService(_spriteBatch.GraphicsDevice);
			_gameManager.AddService(Content);
			_gameManager.AddService(_graphics);
			_gameManager.AddService(Window);
			_gameManager.AddService(this);

			_screen.LoadContent();
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			_screen.Update(gameTime);
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.White);
			_screen.Draw(gameTime);
			base.Draw(gameTime);
		}
	}
}
