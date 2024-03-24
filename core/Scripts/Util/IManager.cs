using Microsoft.Xna.Framework;

namespace Core.Scripts.Util
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
