using Core.Scripts.Util;
using Microsoft.Xna.Framework;
using System;

namespace Core.Scripts
{
    /// <summary>
    /// Менеджер, управляющий игровыми сервисами.
    /// </summary>
    public class GameManager : GameServiceContainer, Util.IUpdateable
    {
        #region Fields

        private static GameManager _instance;

        #endregion

        #region Events

        /// <summary>
        /// Событие, возникающее при добавлении сервиса в коллекцию игрового менеджера.
        /// </summary>
        public event EventHandler<EventArgs> ServiceAdded;

        #endregion

        private GameManager() { }

        /// <summary>
        /// Возвращает синглтон игрового менеджера.
        /// </summary>
        public static GameManager GetInstance()
        {
            _instance ??= new GameManager();
            return _instance;
        }

        /// <summary>
        /// Добавляет сервис в игровой менеджер.
        /// </summary>
        /// <param name="type">Тип сервиса</param>
        /// <param name="provider">Экземпляр сервиса</param>
        public new void AddService(Type type, object provider)
        {
            if (provider is Game game)
            {
                base.AddService(game);
                ServiceAdded?.Invoke(this, EventArgs.Empty);
            }

            base.AddService(type, provider);
            ServiceAdded?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Добавляет сервис в игровой менеджер.
        /// </summary>
        /// <typeparam name="T">Тип сервиса</typeparam>
        /// <param name="provider">Экземпляр сервиса</param>
        public new void AddService<T>(T provider)
        {
            //if (provider is Game game)
            //{
            //    base.AddService(game);
            //    ServiceAdded?.Invoke(this, EventArgs.Empty);
            //}

            base.AddService(provider);
            ServiceAdded?.Invoke(this, EventArgs.Empty);
        }

        /// <inheritdoc/>
        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}