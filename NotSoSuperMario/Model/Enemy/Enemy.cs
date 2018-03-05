using Microsoft.Xna.Framework;
using NotSoSuperMario.Model.GameObjects;
using NotSoSuperMario.View;
using System;

namespace NotSoSuperMario.Model.Enemy
{
    public enum EnemyStates
    {
        IDLE,
        WALK
    }

    class Enemy
    {
        private const float MAX_WAIT_TIME = 0.5f;
        private const float MOVE_SPEED = 64.0f;

        private enum FaceDirection
        {
            Left = -1,
            Right = 1,
        }

        private float waitTime;
        private Animation animation;
        private Rectangle localBounds;
        private FaceDirection direction = FaceDirection.Left;

        public Enemy(Vector2 position, bool isFacingRight)
        {
            this.State = EnemyStates.IDLE;
            this.Position = position;
            this.IsAlive = true;
            this.IsFacingRight = isFacingRight;
        }

        // Gets a rectangle which bounds this enemy in the world space.
        //public Rectangle BoundingRectangle
        //{
        //    get
        //    {
        //        int left = (int)Math.Round(Position.X - animation.Origin.X) + localBounds.X;
        //        int top = (int)Math.Round(Position.Y - animation.Origin.Y) + localBounds.Y;

        //        return new Rectangle(left, top, localBounds.Width, localBounds.Height);
        //    }
        //}

        //public void CalculateBlockPosition()
        //{
        //    float positionX = Position.X + localBounds.Width / 2 * (int)direction;
        //    int blockX = (int)Math.Floor(positionX / block.)
        //}

        public bool IsAlive { get; private set; }

        public Vector2 Position { get; set; }

        public bool IsFacingRight { get; set; }

        public EnemyStates State { get; set; }


    }
}
