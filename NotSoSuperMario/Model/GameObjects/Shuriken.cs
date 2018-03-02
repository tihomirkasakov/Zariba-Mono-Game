namespace NotSoSuperMario.Model.GameObjects
{
    using Microsoft.Xna.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Shuriken : GameObject
    {
        private const int LEFT_BOUND = -40;
        private const int RIGHT_BOUND = 2000;

        private const int SHURIKEN_SPEED = 16;
        private const float FALL_VELOCITY = 0.8f;
        private const int DAMAGE = 10;

        public Shuriken(Vector2 position, bool isGoingRight)
            : base(position)
        {
            this.IsFalling = false;
            this.IsGoingRight = isGoingRight;
        }

        public bool IsGoingRight { get; set; }
        public bool IsFalling { get; set; }

        public void Move()
        {
            float shurikenSpeed;

            if (this.IsGoingRight)
            {
                shurikenSpeed = SHURIKEN_SPEED;
            }
            else
            {
                shurikenSpeed = -SHURIKEN_SPEED;
            }

            if (this.Position.Y + FALL_VELOCITY < 900)
            {
                if (this.Bounds.Left + (this.Bounds.Width / 2) + shurikenSpeed < LEFT_BOUND)
                {
                    this.Position = new Vector2(RIGHT_BOUND - (this.Bounds.Width / 2), this.Position.Y);
                }
                else if (this.Bounds.Right - (this.Bounds.Width / 2) + shurikenSpeed > RIGHT_BOUND)
                {
                    this.Position = new Vector2(LEFT_BOUND - (this.Bounds.Width / 2), this.Position.Y);
                }
                else
                {
                    this.Position = new Vector2(this.Position.X + shurikenSpeed, this.Position.Y + FALL_VELOCITY);
                }
            }
            else
            {
                this.IsFalling = true;
            }

        }

        public override void ActOnCollision()
        {
            this.IsFalling = true;
        }
    }

}
