using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using static App.Scripts.TilesetData;

namespace App.Scripts
{
    internal class Cell(Point position)
    {
        private bool _collapsed = false;

        public Point Position = position;
        public string Tile;
        public Texture2D Texture;
        public List<TileData> Options;

        public bool Collapsed
        {
            get { return _collapsed; }
            set
            {
                _collapsed = value;

                if (value)
                    CollapsedCount++;
            }
        }

        public uint CollapsedCount { get; private set; } = 0;

        public void CreateCell(bool collapsed, List<TileData> options)
        {
            Collapsed = collapsed;
            Options = new(options);
        }

        public void RecreateCell(bool collapsed, List<TileData> options)
        {
            Tile = null;
            Texture = null;
            CreateCell(collapsed, options);
        }

        public void ResetCell(List<TileData> options)
        {
            CollapsedCount = 0;
            RecreateCell(false, options);
        }
    }
}
