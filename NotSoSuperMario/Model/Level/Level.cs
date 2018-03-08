namespace NotSoSuperMario.Model.Level
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using NotSoSuperMario.Model.Enemy;
    using NotSoSuperMario.Model.GameObjects;
    using NotSoSuperMario.View.UI;

    public abstract class Level
    {
        private const int SPIKES_OFFSET = 17;
        private const int EXIT_OFFSET = 10;

        private int[,] mapTiles;
        private Vector2 dimensions;
        private int row = 0;
        private int width;
        private int height;

        public Level()
        {
            this.Blocks = new List<Block>();
        }

        public int[,] MapTiles => this.mapTiles;

        public Vector2 Dimensions
        {
            get { return this.dimensions; }
            set { this.dimensions = value; }
        }

        public int Height
        {
            get { return this.height; }
        }

        public int Width
        {
            get { return this.width; }
        }

        public Sprite LevelBackground { get; set; }

        public List<Block> Blocks { get; set; }

        public List<Crate> ListOfCrates { get; set; }

        public List<Enemy> Enemies { get; set; }

        public void LoadContent(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            string line = reader.ReadLine();
            int[] lineArray = line.Split().Select(int.Parse).ToArray();
            this.dimensions = new Vector2(lineArray[0], lineArray[1]);
            int maxRows = lineArray[0];
            this.mapTiles = new int[lineArray[0], lineArray[1]];
            using (reader)
            {
                while (this.row < maxRows)
                {
                    line = reader.ReadLine();
                    lineArray = line.Split().Select(int.Parse).ToArray();
                    for (int col = 0; col < lineArray.Length; col++)
                    {
                        this.mapTiles[this.row, col] = lineArray[col];
                    }

                    this.row++;
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
                    switch (cellValue)
                    {
                        case 1:
                            this.Blocks.Add(new Block(new Vector2(col * size, row * size), BlockType.tile_1));
                            break;
                        case 2:
                            this.Blocks.Add(new Block(new Vector2(col * size, row * size), BlockType.tile_2));
                            break;
                        case 3:
                            this.Blocks.Add(new Block(new Vector2(col * size, row * size), BlockType.tile_3));
                            break;
                        case 4:
                            this.Blocks.Add(new Block(new Vector2(col * size, row * size), BlockType.tile_4));
                            break;
                        case 5:
                            this.Blocks.Add(new Block(new Vector2(col * size, (row * size) + SPIKES_OFFSET), BlockType.spike));
                            break;
                        case 6:
                            this.Blocks.Add(new Block(new Vector2(col * size, (row * size) + EXIT_OFFSET), BlockType.exit));
                            break;
                    }

                    this.width = (col + 1) * size;
                    this.height = (row + 1) * size;
                }
            }
        }
    }
}
