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
            this.LevelBackground = UIFactory.CreateSprite("Backgrounds/background", 1f);
        }
    }
}
