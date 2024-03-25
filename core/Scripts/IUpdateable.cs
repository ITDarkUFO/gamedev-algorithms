using Microsoft.Xna.Framework;
using System;

namespace Core.Scripts
{
    public interface IUpdateable
    {
        #region Properties

        /// <summary>
        /// Указывает на активность (требуется ли обновлять).
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        /// Позиция в списке обновления.
        /// </summary>
        int UpdateOrder { get; }

        #endregion

        #region Events

        /// <summary>
        /// Событие, возникающее при изменении значения свойства Enabled.
        /// </summary>
        public event EventHandler<EventArgs> EnabledChanged;

        /// <summary>
        /// Событие, возникающее при изменении значения свойства UpdateOrder.
        /// </summary>
        public event EventHandler<EventArgs> UpdateOrderChanged;

        #endregion

        /// <summary>
        /// Обновляет состояние.
        /// </summary>
        /// <param name="gameTime">Игровое время.</param>
        void Update(GameTime gameTime);
    }
}
