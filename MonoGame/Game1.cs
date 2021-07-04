using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;
		Sprite sprite, screenSaver;
		int speed = 2;
		
		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			sprite = new Sprite(8 , 10);
			screenSaver = new Sprite();

			_graphics.PreferredBackBufferWidth = 1024;
			_graphics.PreferredBackBufferHeight = 768;
			_graphics.ToggleFullScreen();
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			// TODO: Add your initialization logic here
			
			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);
			sprite.Load(Content, "Textures\\IMG_0001");
			sprite.spritePosition = new Vector2(0, Window.ClientBounds.Height - (sprite.spriteTexture.Height/2));
			screenSaver.Load(Content, "Textures\\IMG_0009");
			
			// TODO: use this.Content to load your game content here
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// TODO: Add your update logic here
			sprite.spritePosition.X += speed;

			if (sprite.spritePosition.X > Window.ClientBounds.Width - sprite.spriteTexture.Width / 8)
			{
				sprite.spriteEffect = SpriteEffects.FlipHorizontally;
				speed *= -1;
			}

			else if (sprite.spritePosition.X < 0)
			{
				sprite.spriteEffect = SpriteEffects.None;
				speed *= -1;
			}

			double elapsed = gameTime.ElapsedGameTime.TotalSeconds;
			sprite.UpdateFrame(elapsed);

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			_spriteBatch.Begin();

			screenSaver.DrawSprite(_spriteBatch);

			

			sprite.DrawAnimationSprite(_spriteBatch);

			_spriteBatch.End();
			// TODO: Add your drawing code here

			base.Draw(gameTime);
		}
	}
}
