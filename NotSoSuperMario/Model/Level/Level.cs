namespace NotSoSuperMario.Model.Level
{
    using NotSoSuperMario.Model.GameObjects;
    using NotSoSuperMario.View.UI;
    using System.Collections.Generic;

    public abstract class Level
    {
        public Sprite LevelBackground { get; set; }

        public List<Block> Blocks { get; set; }
        public List<Shuriken> ListOfShurikens { get; set; }

    }
}
