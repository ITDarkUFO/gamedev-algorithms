using Microsoft.Xna.Framework;

namespace App.Engine.Util
{
	public interface IManager
	{
		/// <summary>
		/// Обновляет состояние менеджера.
		/// </summary>
		/// <param name="gameTime">Игровое время.</param>
		void Update(GameTime gameTime);
	}
}
