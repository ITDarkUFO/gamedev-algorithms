using App.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Scripts
{
    internal class Screen
    {
        private readonly GameManager _gameManager;
        //private List<>

        public ContentManager Content;

        public Screen()
        {
            _gameManager = GameManager.GetInstance();
        }

        public void Initialize()
        {

        }


        public void LoadContent()
        {
            //Content.Load<Texture2D>("")
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime)
        {

        }
    }
}
