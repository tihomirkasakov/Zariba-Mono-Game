/* FIXME using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotSoSuperMario.Model.GameObjects
{
    public class Shuriken : GameObject
    {
        private const int LEFT_BOUND = -40;
        private const int RIGHT_BOUND = 1240;

        private const int SHURIKEN_SPEED = 16;
        private const float FALL_VELOCITY = 0.8f;
        private const int DAMAGE = 10;

        public Shuriken(Vector2 position, bool isGoingRight)
            :base(position)
        {
            this.IsGoingRight = isGoingRight;
        }

        public bool IsGoingRight { get; set; }
        
        public void Move()
        {
            float ballSpeed;

            if (this.IsGoingRight)
            {
                ballSpeed = SHURIKEN_SPEED;
            }
            else
            {
                ballSpeed = -SHURIKEN_SPEED;
            }

            //if (this.Position.Y + FALL_VELOCITY < 900)
            //{
            //    if (this.Bounds.Left + (this.Bounds.Width / 2) + ballSpeed < LEFT_BOUND)
            //    {
            //        this.Position = new Vector2(RIGHT_BOUND - (this.Bounds.Width / 2));
            //    }
            //    else if (this.Bounds.Right - (this)
            //    {

            //    }
            //}
        }
    }
}*/
