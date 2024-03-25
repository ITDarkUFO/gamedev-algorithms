using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Scripts
{
    /// <summary>
    /// Интерфейс, определяющий методы отрисовки на экране.
    /// </summary>
    internal interface IDrawable
    {
        #region Properties 

        /// <summary>
        /// Указывает, будет ли отображаться объект.
        /// </summary>
        bool Visible { get; }

        /// <summary>
        /// Позиция объекта в списке отрисовки.
        /// </summary>
        int DrawOrder { get; }

        #endregion

        #region Events

        /// <summary>
        /// Событие, возникающее при изменении значения свойства Visible.
        /// </summary>
        event EventHandler<EventArgs> VisibleChanged;

        /// <summary>
        /// Событие, возникающее при изменении значения свойства DrawOrder.
        /// </summary>
        event EventHandler<EventArgs> DrawOrderChanged;

        #endregion

        /// <summary>
        /// Позволяет загрузить требуемый контент.
        /// </summary>
        public void LoadContent();

        /// <summary>
        /// Отрисовывает на экране.
        /// </summary>
        /// <param name="gameTime">Игровое время.</param>
        public void Draw(GameTime gameTime);
    }
}

