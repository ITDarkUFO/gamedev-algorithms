using Microsoft.Xna.Framework;

namespace Core.Scripts.Util
{
	public interface IUpdateable
	{
		/// <summary>
		/// Обновляет состояние менеджера.
		/// </summary>
		/// <param name="gameTime">Игровое время.</param>
		void Update(GameTime gameTime);
	}
}
