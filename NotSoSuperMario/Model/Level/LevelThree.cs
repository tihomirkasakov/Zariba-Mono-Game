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
    public class LevelThree : Level
    {
        public LevelThree()
        {
            this.ListOfCrates = new List<Crate>
            {
                new Crate(new Vector2(180, 1015)),
                new Crate(new Vector2(170, 474))

            };
            this.LevelBackground = UIFactory.CreateSprite("Backgrounds/background3", 1.5f);
        }

    }
}
