﻿namespace NotSoSuperMario.Model.Level
{
    using Microsoft.Xna.Framework;
    using NotSoSuperMario.Model.GameObjects;
    using NotSoSuperMario.View.UI;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public abstract class Level
    {
        public int[,] mapTiles;
        Vector2 dimensions;
        private int row = 0;
        private int width;
        private int height;

        public Level()
        {
            this.Blocks = new List<Block>();
        }

        public int Height
        {
            get { return height; }
        }

        public int Width
        {
            get { return width; }
        }

        public Sprite LevelBackground { get; set; }
        public List<Block> Blocks { get; set; }
        public List<Shuriken> ListOfShurikens { get; set; }

        public void LoadContent(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            string line = reader.ReadLine();
            int[] lineArray = line.Split().Select(int.Parse).ToArray();
            dimensions = new Vector2(lineArray[0], lineArray[1]);
            mapTiles = new int[lineArray[0], lineArray[1]];
            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    lineArray = line.Split().Select(int.Parse).ToArray();
                    for (int col = 0; col < lineArray.Length; col++)
                    {
                        mapTiles[row, col] = lineArray[col];
                    }
                    row++;
                }
            }
        }

        public void GenerateMap(int[,] map, int size)
        {
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    int cellValue = map[row, col];

                    if (cellValue > 0)
                    {
                        this.Blocks.Add(new Block(new Vector2(col * size, row * size), BlockType.tile_1));
                    }
                    width = (col + 1) * size;
                    height = (row + 1) * size;
                }
            }
        }
    }
}
