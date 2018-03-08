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
            this.LevelBackground = UIFactory.CreateSprite("Backgrounds/background2", 1.5f);
            this.ListOfCrates = new List<Crate>();
        }
    }
}
