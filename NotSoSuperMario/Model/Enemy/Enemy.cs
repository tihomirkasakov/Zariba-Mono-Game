namespace NotSoSuperMario.Model.Enemy
{
    using Microsoft.Xna.Framework;
    using NotSoSuperMario.Controller;
    using NotSoSuperMario.Model.GameObjects;
    using NotSoSuperMario.View;
    using System;
    using System.Collections.Generic;

    public enum EnemyStates
    {
        IDLE,
        WALK
    }

    public class Enemy
    {
        private const float MAX_WAIT_TIME = 0.5f;
        private const float MOVE_ACCELERATION = 0.15f;
        private const float MAX_MOVE_SPEED = 2f;

        private float waitTime;
        private Vector2 velocity;
        private bool isGrounded;

        public Enemy(Vector2 position, Rectangle boundingBounds, bool isFacingRight)
        {
            this.State = EnemyStates.IDLE;
            this.Position = position;
            this.IsAlive = true;
            this.isGrounded = false;
            this.BoundingBounds = boundingBounds;
            this.IsFacingRight = isFacingRight;
        }

        public void Patrolling(List<Block> blocks)
        {
            this.State = EnemyStates.IDLE;
            this.HandleBottomCollision(blocks);
            this.CheckBounds();
            this.Position += this.velocity;
        }

        private void CheckBounds()
        {
            float elapsed = (float)Globals.GameTime.ElapsedGameTime.TotalSeconds;

            if (this.BoundingBounds == null)
            {
                return;
            }

            if (this.Bounds.Left <= this.BoundingBounds.X)
            {
                // Wait for some amount of time.
                this.waitTime = Math.Max(0.0f, waitTime - (float)Globals.GameTime.ElapsedGameTime.TotalSeconds);
                this.State = EnemyStates.IDLE;
                if (this.waitTime <= 0.0f)
                {
                    // Then turn around.
                    this.State = EnemyStates.WALK;
                    this.IsFacingRight = true;
                }
                this.velocity = new Vector2(this.velocity.X + MAX_MOVE_SPEED, this.velocity.Y);
                
            }
            else if(this.Bounds.Right >= this.BoundingBounds.Right)
            {
                // Wait for some amount of time.
                this.waitTime = Math.Max(0.0f, waitTime - (float)Globals.GameTime.ElapsedGameTime.TotalSeconds);
                this.State = EnemyStates.IDLE;
                if (this.waitTime <= 0.0f)
                {
                    // Then turn around.
                    this.IsFacingRight = false;      
                    this.State = EnemyStates.WALK;
                }
                this.velocity = new Vector2(this.velocity.X - MAX_MOVE_SPEED, this.velocity.Y);
                
            }           

        }

        private void HandleBottomCollision(List<Block> blocks)
        {
            this.isGrounded = false;
            this.ApplyGravity();

            foreach (var block in blocks)
            {
                if (this.IsOnTopOf(block.Bounds))
                {
                    this.isGrounded = true;
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

        public bool IsAlive { get; private set; }

        public Rectangle Bounds { get; set; }

        public Rectangle BoundingBounds { get; set; }

        public Vector2 Position { get; set; }

        public bool IsFacingRight { get; set; }

        public EnemyStates State { get; private set; }


    }
}
