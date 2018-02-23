namespace NotSoSuperMario.Model.Classes
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using NotSoSuperMario.Model.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Enemy : Unit, IEnemy, IUnit
    {
        private bool sawPlayer;

        public Enemy(bool sawPlayer, ContentManager Content, int gameWidth, int gameHeight, double velocity, Vector2 scale)
            :base(Content,gameWidth,gameHeight,velocity,scale)
        {
            this.SawPlayer = false;
        }

        public bool SawPlayer
        {
            get { return sawPlayer; }
            set { sawPlayer = value; }
        }

        public override void Move()
        {
            //ToDo
            base.Move();
        }

        public override void Draw()
        {
            //ToDo
            base.Draw();
        }

        public override void Attack()
        {
            //ToDo
            base.Attack();
        }
    }
}
