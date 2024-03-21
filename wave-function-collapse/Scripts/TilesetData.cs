using System.Collections.Generic;

namespace App.Scripts
{
    internal class TilesetData
    {
        public string Name { get; set; }

        public string Version { get; set; }

        public List<TileData> Tiles { get; set; }

        internal class TileData
        {
            public string Tile { get; set; }

            public float Weight { get; set; } = 1f;

            public NeighborsData Neighbors { get; set; }

            internal class NeighborsData
            {
                public List<string> Up { get; set; }

                public List<string> Right { get; set; }

                public List<string> Down { get; set; }

                public List<string> Left { get; set; }
            }
        }
    }
}