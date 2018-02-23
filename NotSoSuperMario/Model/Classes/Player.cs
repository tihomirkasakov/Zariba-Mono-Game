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

    public class Player : Unit, IPlayer, IUnit
    {
        private List<Enemy> enemies;

        public Player(ContentManager Content, int gameWidth, int gameHeight, double velocity, Vector2 scale)
            : base(Content, gameWidth, gameHeight, velocity, scale)
        {
            this.enemies = new List<Enemy>();
        }

        public void Jump()
        {
            //ToDo
        }

        public void TakeDamage()
        {
            //ToDo
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
