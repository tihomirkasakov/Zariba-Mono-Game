namespace NotSoSuperMario.Model.Enemy
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using NotSoSuperMario.Controller;
    using NotSoSuperMario.Model.GameObjects;

    public enum EnemyStates
    {
        IDLE,
        WALK,
    }

    public class Enemy : Entity
    {
        private const float MAX_WAIT_TIME = 0.5f;
        private const float MOVE_ACCELERATION = 0.15f;

        private float waitTime;
        private Vector2 velocity;

        public Enemy(Vector2 position, Rectangle boundingBounds, float moveSpeed, bool isFacingRight)
            : base(position, isFacingRight)
        {
            this.Position = position;
            this.IsAlive = true;
            this.BoundingRectangle = boundingBounds;
            this.IsFacingRight = isFacingRight;
            this.MoveSpeed = moveSpeed;
        }

        public bool IsAlive { get; private set; }

        public Rectangle BoundingRectangle { get; set; }

        public float MoveSpeed { get; set; }

        public EnemyStates State { get; private set; }

        public void Patrolling(List<Block> blocks)
        {
            this.HandleBottomCollision(blocks);
            this.CheckBounds();
            this.Position += this.velocity;
        }

        public override void ActOnCollision()
        {
            throw new System.NotImplementedException();
        }

        private void CheckBounds()
        {
            float elapsed = (float)Globals.GameTime.ElapsedGameTime.TotalSeconds;

            if (!this.IsAlive)
            {
                this.ActOnCollision();
                return;
            }

            if (this.Bounds.Left <= this.BoundingRectangle.X)
            {
                if (this.waitTime > 0)
                {
                    this.State = EnemyStates.IDLE;
                    this.waitTime = Math.Max(0.0f, this.waitTime - (float)Globals.GameTime.ElapsedGameTime.TotalSeconds);
                }

                if (this.waitTime <= 0.0f)
                {
                    this.State = EnemyStates.WALK;
                    this.IsFacingRight = true;
                }

                this.velocity = new Vector2(this.velocity.X + this.MoveSpeed, this.velocity.Y);
            }
            else if (this.Bounds.Right >= this.BoundingRectangle.Right)
            {
                if (this.waitTime > 0)
                {
                    this.State = EnemyStates.IDLE;
                    this.waitTime = Math.Max(0.0f, this.waitTime - (float)Globals.GameTime.ElapsedGameTime.TotalSeconds);
                }

                if (this.waitTime <= 0.0f)
                {
                    this.IsFacingRight = false;
                    this.State = EnemyStates.WALK;
                }

                this.velocity = new Vector2(this.velocity.X - this.MoveSpeed, this.velocity.Y);
                if (this.Bounds.Left == this.BoundingRectangle.X)
                {
                    this.waitTime = MAX_WAIT_TIME;
                }
            }
        }

        private void HandleBottomCollision(List<Block> blocks)
        {
            this.ApplyGravity();

            foreach (var block in blocks)
            {
                if (this.IsOnTopOf(block.Bounds))
                {
                    this.velocity = new Vector2(this.velocity.X, 0);
                }
            }
        }

        private bool IsOnTopOf(Rectangle rect)
        {
            return (this.Bounds.Bottom + this.velocity.Y >= rect.Top - 10) &&
                this.Bounds.Bottom + this.velocity.Y <= rect.Top &&
                this.Bounds.Right >= rect.Left + 4 &&
                this.Bounds.Left <= rect.Right - 4;
        }

        private void ApplyGravity()
        {
            this.velocity = new Vector2(this.velocity.X, this.velocity.Y + 0.15f);
        }
    }
}
