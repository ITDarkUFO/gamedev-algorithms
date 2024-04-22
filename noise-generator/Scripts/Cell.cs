using Core.Scripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Scripts
{
    internal class Cell(int x, int y)
    {
        private Color _color;

        public bool IsDone;

        public Vector2 Position { get; private set; } = new(x, y);

        public Texture2D Texture { get; private set; }

        public void SetColor(int colorValue)
        {
            _color = new(colorValue, colorValue, colorValue);
            Texture = new(GameManager.GetInstance().GetService<GraphicsDevice>(), 1, 1);
            Texture.SetData([_color]);
        }
    }
}
