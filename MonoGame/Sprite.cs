using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
	class Sprite
	{
		// Текстура спрайта
		public Texture2D spriteTexture;
		// Позиция спрайта
		public Vector2 spritePosition;
		// Эффект спрайта
		public SpriteEffects spriteEffect = SpriteEffects.None;
		// количество кадров
		int frameCount;
		// как долго один кадр будет показ на экране (в мс)
		double timeFrame;
		// текущий кадр
		int frame = 0;
		// для расчета времени задержки показа одного кадра
		double totalElapsed = 0;

		public Sprite(int frameCount, int framesPerSec)
		{
			this.frameCount = frameCount;
			timeFrame = (float)1 / framesPerSec;
		}

		public Sprite()
		{

		}
		
		public void UpdateFrame(double elapsed)
		{
			// всего пройденного времени = все пройденное время + еще пройденное время
			totalElapsed += elapsed;
			// если пройденное время больше времени, отведенного для показа одного кадра
			if (totalElapsed > timeFrame)
			{
				// меняем кадр
				frame++;
				// Удалив этот оператор, спрайт исчезает с экрана ???
				//frame = frame % (frameCount - 1);
				if (frame > frameCount - 1)
					frame = 0;
				// пройденное время = 0;
				totalElapsed = 0; ;
			}
		}

		//выводит анимированный спрайт
		public void DrawAnimationSprite(SpriteBatch spriteBatch)
		{
			//ширина кадра = ширина спрайта / количество кадров
			int frameWidth = spriteTexture.Width / frameCount;
			// выоста кадра = высота спрайта / 2
			int frameHeight = spriteTexture.Height / 2;
			// область выводимого кадра (x, y, ширина, высота)
			Rectangle rectangle = new (frameWidth * frame, 0, frameWidth, frameHeight);
			// вывод спрайта
			spriteBatch.Draw (spriteTexture, spritePosition, rectangle, Color.White, 0.0f,Vector2.Zero, 1.0f, spriteEffect, 0.0f);

		}

		//загружает текстуру
		public void Load (ContentManager content, String stringTexture)
		{
			spriteTexture = content.Load<Texture2D>(stringTexture);
		}

		// выводит статический спрайт
		public void DrawSprite(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(spriteTexture, spritePosition, Color.White);
		}
	}
}
