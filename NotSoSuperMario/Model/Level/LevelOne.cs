namespace NotSoSuperMario.Model.Level
{
    using NotSoSuperMario.Model.GameObjects;
    using NotSoSuperMario.View;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    class LevelOne : Level
    {
        public LevelOne()
        {
            this.ListOfShurikens = new List<Shuriken>();

            this.LevelBackground = UIFactory.CreateSprite("Backgrounds/background");
            this.Blocks = new List<Block>
            {
                // Blocks
                new Block(new Vector2(0, 890), BlockType.tile_1),
                new Block(new Vector2(40, 890), BlockType.tile_1),
                new Block(new Vector2(80, 890), BlockType.tile_1),
                //new Block(new Vector2(120, 890), BlockType.tile_1),
                //new Block(new Vector2(160, 890), BlockType.tile_1),
                //new Block(new Vector2(200, 890), BlockType.tile_1),
                //new Block(new Vector2(240, 890), BlockType.tile_1),
                //new Block(new Vector2(280, 890), BlockType.tile_1),
                //new Block(new Vector2(320, 890), BlockType.tile_1),
                //new Block(new Vector2(640, 890), BlockType.tile_1),
                //new Block(new Vector2(720, 890), BlockType.tile_1),
                //new Block(new Vector2(800, 890), BlockType.tile_1),
                //new Block(new Vector2(880, 890), BlockType.tile_1),
                //new Block(new Vector2(960, 890), BlockType.tile_1),
                //new Block(new Vector2(1040, 890), BlockType.tile_1),
                //new Block(new Vector2(1120, 890), BlockType.tile_1),
                //new Block(new Vector2(400, 890), BlockType.tile_1),
                //new Block(new Vector2(1480, 890), BlockType.tile_1),
                //new Block(new Vector2(1660, 890), BlockType.tile_1),
                //new Block(new Vector2(1840, 890), BlockType.tile_1),
                //new Block(new Vector2(1920, 890), BlockType.tile_1),
                //new Block(new Vector2(2060, 890), BlockType.tile_1),



                //new Block(new Vector2(560, 70), BlockType.tile_1),
                //new Block(new Vector2(600, 70), BlockType.tile_1),
                //new Block(new Vector2(640, 70), BlockType.tile_1),
                //new Block(new Vector2(680, 70), BlockType.tile_1),
                //new Block(new Vector2(720, 70), BlockType.tile_1),
                //new Block(new Vector2(760, 70), BlockType.tile_1),
                //new Block(new Vector2(800, 70), BlockType.tile_1),
                //new Block(new Vector2(840, 70), BlockType.tile_1),
                //new Block(new Vector2(880, 70), BlockType.tile_1),
                //new Block(new Vector2(920, 70), BlockType.tile_1),
                //new Block(new Vector2(960, 70), BlockType.tile_1),
                //new Block(new Vector2(1000, 70), BlockType.tile_1),
                //new Block(new Vector2(1040, 70), BlockType.tile_1),
                //new Block(new Vector2(1080, 70), BlockType.tile_1),
                //new Block(new Vector2(1120, 70), BlockType.tile_1),
                //new Block(new Vector2(1160, 70), BlockType.tile_1),
                //new Block(new Vector2(1200, 70), BlockType.tile_1),
                //new Block(new Vector2(1240, 70), BlockType.tile_1),        
                //// BOT BLOCK LINE
                //new Block(new Vector2(0, 950), BlockType.tile_1),
                //new Block(new Vector2(80, 950), BlockType.tile_1),
                //new Block(new Vector2(160, 950), BlockType.tile_1),
                //new Block(new Vector2(240, 950), BlockType.tile_1),
                //new Block(new Vector2(320, 950), BlockType.tile_1),
                //new Block(new Vector2(400, 950), BlockType.tile_1),
                //new Block(new Vector2(480, 950), BlockType.tile_1),
                //new Block(new Vector2(560, 950), BlockType.tile_1),
                //new Block(new Vector2(640, 950), BlockType.tile_1),
                //new Block(new Vector2(720, 950), BlockType.tile_1),
                //new Block(new Vector2(800, 950), BlockType.tile_1),
                //new Block(new Vector2(880, 950), BlockType.tile_1),
                //new Block(new Vector2(960, 950), BlockType.tile_1),
                //new Block(new Vector2(1040, 950), BlockType.tile_1),
                //new Block(new Vector2(1120, 950), BlockType.tile_1),
                //new Block(new Vector2(1200, 950), BlockType.tile_1),
                ////// some
                //new Block(new Vector2(0, 700), BlockType.tile_1),
                //new Block(new Vector2(80, 700), BlockType.tile_1),
                //new Block(new Vector2(160, 750), BlockType.tile_1),
                ////// some
                //new Block(new Vector2(1040, 750), BlockType.tile_1),
                //new Block(new Vector2(1120, 700), BlockType.tile_1),
                //new Block(new Vector2(1200, 700), BlockType.tile_1),
                ////// LEFT CUBE LINE
                //new Block(new Vector2(0, 400), BlockType.tile_1),
                //new Block(new Vector2(40, 400), BlockType.tile_1),
                //new Block(new Vector2(0, 450), BlockType.tile_1),
                //new Block(new Vector2(0, 500), BlockType.tile_1),               
                ////// RIGHT CUBE LINE
                //new Block(new Vector2(1200, 400), BlockType.tile_1),
                //new Block(new Vector2(1240, 400), BlockType.tile_1),
                //new Block(new Vector2(1240, 450), BlockType.tile_1),
                //new Block(new Vector2(1240, 500), BlockType.tile_1),
                ////// Central blocks
                //new Block(new Vector2(480, 580), BlockType.tile_1),
                //new Block(new Vector2(560, 580), BlockType.tile_1),
                //new Block(new Vector2(640, 580), BlockType.tile_1),
                //new Block(new Vector2(720, 580), BlockType.tile_1),
                //new Block(new Vector2(420, 620), BlockType.tile_1),
                //new Block(new Vector2(480, 620), BlockType.tile_1),
                //new Block(new Vector2(560, 620), BlockType.tile_1),
                //new Block(new Vector2(640, 620), BlockType.tile_1),
                //new Block(new Vector2(720, 620), BlockType.tile_1),
                //new Block(new Vector2(780, 620), BlockType.tile_1),
                //
                ////// Central upper
                //new Block(new Vector2(600, 380), BlockType.tile_1),
                //new Block(new Vector2(520, 380), BlockType.tile_1),
                //new Block(new Vector2(680, 380), BlockType.tile_1),
                ////// Right central blocks
                //new Block(new Vector2(1200, 350), BlockType.tile_1),
                //new Block(new Vector2(1040, 400), BlockType.tile_1),
                //new Block(new Vector2(1120, 400), BlockType.tile_1),
                ////// Left central blocks
                //new Block(new Vector2(0, 350), BlockType.tile_1),
                //new Block(new Vector2(80, 400), BlockType.tile_1),
                //new Block(new Vector2(160, 400), BlockType.tile_1),
            };
        }
    }
}
