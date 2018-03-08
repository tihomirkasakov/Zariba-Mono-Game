namespace NotSoSuperMario.Model.Level
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using NotSoSuperMario.Model.GameObjects;
    using NotSoSuperMario.View;

    public class LevelOne : Level
    {
        public LevelOne()
        {
            this.ListOfCrates = new List<Crate>
            {
                new Crate(new Vector2(200, 969)),
                new Crate(new Vector2(170, 474))
            };
            this.LevelBackground = UIFactory.CreateSprite("Backgrounds/background", 1.1f);
        }
    }
}
