namespace NotSoSuperMario.Model.Classes
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using NotSoSuperMario.Model.Interfaces;
    using NotSoSuperMario.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Unit : IUnit
    {
        protected bool isAlive;
        protected Dictionary<string, Animation> animations;
        protected string currentAnimationKey;
        protected double velocity;
        protected Vector2 position;
        protected double rotation;
        protected Vector2 scale;

        public Unit(ContentManager Content, int gameWidth, int gameHeight, double velocity, Vector2 scale)
        {
            this.IsAlive = true;
            this.velocity = velocity;
            this.scale = scale;
            this.currentAnimationKey = "";
            this.animations = new Dictionary<string, Animation>();
        }

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        public Vector2 Position
        {
            get
            {
                return this.position;
            }
        }

        public virtual void Move()
        {
            //ToDo
        }

        public virtual void Draw()
        {
            //ToDo
        }

        public virtual void Attack()
        {
            //ToDo
        }
    }
}
