/*namespace NotSoSuperMario.GameObjects
{
    using global::NotSoSuperMario.Utilities;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;

    public abstract class Entity
    {
        protected Dictionary<string, Animation> animations;
        protected string currentAnimationKey;

        protected double velocity;
        protected Vector2 position;
        protected double rotation;
        protected Vector2 scale;

        public double Damage { get; private set; }
        public double Health { get; protected set; }
        public bool IsAlive { get; protected set; }
        public Vector2 Position
        {
            get
            {
                return this.position;
            }
        }


        public Entity(ContentManager Content, int gameWidth, int gameHeight, double health, double damage, double velocity, Vector2 scale)
        {
            this.Health = health;
            this.IsAlive = true;
            this.velocity = velocity;
            this.scale = scale;
            this.Damage = damage;

            this.currentAnimationKey = "";
            this.animations = new Dictionary<string, Animation>();

            this.CreateAnimations(Content);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.animations[this.currentAnimationKey].Draw(spriteBatch, this.rotation, this.position, this.scale);
        }
        public abstract void TakeDamage(double damage);

        protected abstract void CreateAnimations(ContentManager Content);

    }
}*/