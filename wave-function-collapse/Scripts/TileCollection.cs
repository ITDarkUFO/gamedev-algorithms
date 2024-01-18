using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Scripts
{
    internal class TileCollection
    {
        public List<Tile> tiles;

        public TileCollection(List<Texture2D> textures)
        {
            // 0 Tile
            tiles.Add(new(textures.FirstOrDefault(t => t.Name == "Maze/0"))
            {
                UpNeighbours = new()
                {
                    new(textures.FirstOrDefault(t => t.Name == "Maze/0")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/A")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/AB")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ABD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/AD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/B")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/BD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/D")),
                },

                RightNeighbours = new()
                {
                    new(textures.FirstOrDefault(t => t.Name == "Maze/0")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/A")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/AB")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ABC")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/AC")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/B")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/BC")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/C")),
                },

                DownNeighbours = new()
                {
                    new(textures.FirstOrDefault(t => t.Name == "Maze/0")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/B")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/BC")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/BCD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/BD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/C")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/CD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/D")),
                },

                LeftNeighbours = new()
                {
                    new(textures.FirstOrDefault(t => t.Name == "Maze/0")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/A")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/AC")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ACD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/AD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/C")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/CD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/D")),
                }
            });

            // A Tile
            tiles.Add(new(textures.FirstOrDefault(t => t.Name == "Maze/A"))
            {
                UpNeighbours = new()
                {
                    new(textures.FirstOrDefault(t => t.Name == "Maze/BC")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/BCD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ACD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/AC")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ABC")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/CD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/C")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ABCD")),
                },

                RightNeighbours = new()
                {
                    new(textures.FirstOrDefault(t => t.Name == "Maze/0")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/A")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/AB")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ABC")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/AC")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/B")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/BC")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/C")),
                },

                DownNeighbours = new()
                {
                    new(textures.FirstOrDefault(t => t.Name == "Maze/0")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/B")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/BC")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/BCD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/BD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/C")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/CD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/D")),
                },

                LeftNeighbours = new()
                {
                    new(textures.FirstOrDefault(t => t.Name == "Maze/0")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/A")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/AC")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ACD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/AD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/C")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/CD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/D")),
                }
            });

            // AB Tile
            tiles.Add(new(textures.FirstOrDefault(t => t.Name == "Maze/AB"))
            {
                UpNeighbours = new()
                {
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ABC")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ABCD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/AC")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ACD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/BC")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/BCD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/C")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/CD")),
                },

                RightNeighbours = new()
                {
                    new(textures.FirstOrDefault(t => t.Name == "Maze/BD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/BCD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ACD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/D")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/CD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/AD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ABD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ABCD")),
                },

                DownNeighbours = new()
                {
                    new(textures.FirstOrDefault(t => t.Name == "Maze/0")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/B")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/BC")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/BCD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/BD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/C")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/CD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/D")),
                },

                LeftNeighbours = new()
                {
                    new(textures.FirstOrDefault(t => t.Name == "Maze/0")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/A")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/AC")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ACD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/AD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/C")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/CD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/D")),
                }
            });

            // ABCD Tile
            tiles.Add(new(textures.FirstOrDefault(t => t.Name == "Maze/ABCD"))
            {
                UpNeighbours = new()
                {
                    new(textures.FirstOrDefault(t => t.Name == "Maze/BC")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/BCD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ACD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/AC")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ABC")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/CD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/C")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ABCD")),
                },

                RightNeighbours = new()
                {
                    new(textures.FirstOrDefault(t => t.Name == "Maze/BD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/BCD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ACD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/D")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/CD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/AD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ABD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ABCD")),
                },

                DownNeighbours = new()
                {
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ACD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/AC")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ABC")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/AB")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/A")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/AD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ABD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ABCD")),
                },

                LeftNeighbours = new()
                {
                    new(textures.FirstOrDefault(t => t.Name == "Maze/BD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/BC")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/BCD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ABC")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/AB")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/B")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ABD")),
                    new(textures.FirstOrDefault(t => t.Name == "Maze/ABCD")),
                }
            });
        }
    }
}
