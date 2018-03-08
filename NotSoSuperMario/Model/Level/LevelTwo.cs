namespace NotSoSuperMario.Model.Level
{
    using System.Collections.Generic;
    using NotSoSuperMario.Model.GameObjects;
    using NotSoSuperMario.View;

    public class LevelTwo : Level
    {
        public LevelTwo()
        {
            this.LevelBackground = UIFactory.CreateSprite("Backgrounds/background2", 1.5f);
            this.ListOfCrates = new List<Crate>();
        }
    }
}
