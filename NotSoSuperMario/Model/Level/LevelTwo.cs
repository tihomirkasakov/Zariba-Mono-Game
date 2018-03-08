using Microsoft.Xna.Framework;
using NotSoSuperMario.Model.GameObjects;
using NotSoSuperMario.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSoSuperMario.Model.Level
{
    public class LevelTwo:Level
    {
        public LevelTwo()
        {
            this.ListOfShurikens = new List<Shuriken>();
            this.ListOfCrates = new List<Crate>
            {
                new Crate(new Vector2(200, 969)),
                new Crate(new Vector2(170, 474))

            };
            this.LevelBackground = UIFactory.CreateSprite("Backgrounds/background2", 1.5f);
        }
    }
}
