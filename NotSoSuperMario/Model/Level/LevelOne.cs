namespace NotSoSuperMario.Model.Level
{
    using NotSoSuperMario.Model.GameObjects;
    using NotSoSuperMario.View;
    using System.Collections.Generic;

    class LevelOne : Level
    {
        public LevelOne()
        {
            this.LevelBackground = UIFactory.CreateSprite("LevelBackground");
            this.Blocks = new List<Block>
            {
                // Blocks
            };
        }
    }
}
