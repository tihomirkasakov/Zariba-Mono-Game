namespace NotSoSuperMario.Model.Player
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using System.Collections.Generic;
    using System;
    using NotSoSuperMario.Model.GameObjects;
    using NotSoSuperMario.Controller.Utils;

    public enum PlayerStates
    {
        IDLE,
        RUNNING,
        WALKING
    }
    public class Player
    {
        private const float FRICTION_FORCE = 0.08f;
        private const float MAX_PLAYER_SPEED = 8;
        private const float PLAYER_ACCEERATION = 0.1f;
        private const int JUMP_VELOCITY = 9;

        private const int LEFT_BOUND = 0;
        private const int RIFGHT_BOUND = 1280;
        // max health

        private Vector2 acceleration;
        private Dictionary<string, Keys> controls;
        private bool isGrounded;
        private float jumpHeight;
        private Vector2 velocity;
        private bool isMoving;

        public Player(Keys moveLeft, Keys moveRight, Keys jump, Vector2 position, bool isFacingRight)
        {
            this.State = PlayerStates.IDLE;
            this.IsFacingRight = isFacingRight;
            this.jumpHeight = 0;

            this.controls = new Dictionary<string, Keys>;
            this.controls.Add("Move Left", moveLeft);
            this.controls.Add("Move Right", moveRight);
            this.controls.Add("Jump", jump);
            //attack

            this.Position = position;
            this.isGrounded = false;


        }

        public Vector2 Position { get; set; }
        public Rectangle Bounds { get; set; }
        public PlayerStates State { get; private set; }
        public bool IsFacingRight { get; set; }

        public void Move(List<Block> blocks, List<KeyboarButtonState> activeKeys)
        {
            this.State = PlayerStates.IDLE;
            // Checking for collision with blocks underneath the player

            this.HandleTopCollisiton(blocks);
            this.Position += this.velocity;

            // Movement
            this.HandleMovement(blocks, activeKeys);
            // Jumping check
            // this.HandleJumping(blocks);

            // Side Collision
            this.HandleCollisiton(blocks);

        }

        private void HandleTopCollisiton(List<Block> blocks)
        {
            if (this.velocity.Y < 0)
            {
                foreach (var block in blocks)
                {
                    Rectangle tempRect = new Rectangle((int)this.Bounds.X, (int)(this.Bounds.Y + this.velocity.Y), this.Bounds.Width, 20);
                    if (tempRect.Intersects(block.Bounds))
                    {
                        this.velocity = new Vector2(this.velocity.X, 5);
                    }
                }
            }
        }

        private bool IsOnTopOf(Rectangle rect)
        {
            return (this.Bounds.Bottom + this.velocity.Y >= rect.Top - 10) &&
                this.Bounds.Bottom + this.velocity.Y <= rect.Top &&
                this.Bounds.Right >= rect.Left +4 && 
                this.Bounds.Left <= rect.Right -4;
        }

        private void HandleBottomCollision(List<Block> blocks)
        {
            this.isGrounded = false;

            foreach (var block in blocks)
            {
                if (this.IsOnTopOf(block.Bounds))
                {
                    this.isGrounded = true;
                    this.velocity = new Vector2(this.velocity.X, 0);
                }
            }

        }

        private void HandleSideCollisiton(List<Block> blocks)
        {
            if ((this.Bounds.Left + (this.Bounds.Width / 2)) + this.velocity.X < LEFT_BOUND)
            {
                this.Position = new Vector2(RIFGHT_BOUND - (this.Bounds.Width / 2), this.Position.Y);
            }
            else if ((this.Bounds.Right - (this.Bounds.Width / 2)) + this.velocity.X > RIFGHT_BOUND)
            {
                this.Position = new Vector2(LEFT_BOUND - (this.Bounds.Width / 2), this.Position.Y);
            }
            else
            {
                int tempDistance;
                if (this.velocity.X > 0)
                {
                    tempDistance = 4;
                }
                else
                {
                    tempDistance = -4;
                }

                Rectangle tempRect = new Rectangle((int)(this.Bounds.X + (this.velocity.Y + tempDistance)),
                    (int)(this.Bounds.Y), this.Bounds.Width, this.Bounds.Height);

                foreach (var block in blocks)
                {
                    if (tempRect.Intersects(block.Bounds))
                    {
                        this.velocity = new Vector2(0, this.velocity.Y);
                    }
                }
            }
        }

        private void HandleMovement(List<Block> blocks, List<KeyboardButtonState> activeKeys)
        {
            this.isMoving = false;

            foreach (var key in activeKeys)
            {
                if (key.Button == this.controls["Move Left"] && key.ButtonState == Controller.Utils.KeyState.Held && !this.isMoving)
                {
                    this.State = PlayerStates.RUNNING;
                    this.isMoving = true;

                    this.MoveLeft();
                }
                else if (key.Button == this.controls["Move Right"] && key.ButtonState == Controller.Utils.KeyState.Held && !this.isMoving)
                {
                    this.State = PlayerStates.RUNNING;
                    this.isMoving = true;

                    this.MoveRight();
                }
                // else if (Move right) ...
                // jump ... KeyState.Held
                // Atack .. KeyState.Clicked
            }

            if (!this.isMoving)
            {
                this.ApplyFriction();
            }

            this.ApplyGravity();
        }

        private void ApplyFriction()
        {
            if (this.velocity.X > FRICTION_FORCE)
            {
                this.velocity = new Vector2(this.velocity.X - FRICTION_FORCE, this.velocity.Y);
                this.State = PlayerStates.WALKING;
            }
            else if(this.velocity.X < -FRICTION_FORCE)
            {
                this.velocity = new Vector2(this.velocity.X + FRICTION_FORCE, this.velocity.Y);
                this.State = PlayerStates.WALKING;
            }
            else
            {
                this.velocity = new Vector2(0, this.velocity.Y);
            }

        }

        private void ApplyGravity()
        {
            this.velocity = new Vector2(this.velocity.X, this.velocity.Y + 0.15f);

        }

        private void Jump()
        {
            if (this.isGrounded)
            {
                this.isGrounded = false;
                this.velocity = new Vector2(this.velocity.X, -JUMP_VELOCITY);
            }
        }
        
        //private void Attack()
        //{
            
        //}

        private void MoveLeft()
        {
            if (!Keyboard.GetState().IsKeyDown(this.controls["Move Right"]))
            {
                this.IsFacingRight = false;
            }

            if (this.velocity.X > -MAX_PLAYER_SPEED)
            {
                this.velocity = new Vector2(this.velocity.X - PLAYER_ACCEERATION, this.velocity.Y);
            }
        }

        private void MoveRight()
        {
            if (!Keyboard.GetState().IsKeyDown(this.controls["Move Left"]))
            {
                this.IsFacingRight = true;
            }

            if (this.velocity.X < MAX_PLAYER_SPEED)
            {
                this.velocity = new Vector2(this.velocity.X + PLAYER_ACCEERATION, this.velocity.Y);
            }
        }
    }
}
