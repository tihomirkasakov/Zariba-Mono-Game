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
        WALK,
        JUMP,
        ATTACK
    }
    public class Player
    {
        private const float FRICTION_FORCE = 0.8f;
        private const float MAX_PLAYER_SPEED = 3;
        private const float PLAYER_ACCELERATION = 0.1f;
        private const int JUMP_VELOCITY = 12;
        private const int TEMP_DISTANCE = 3;

        private const int LEFT_BOUND = 0;
        private const int RIGHT_BOUND = 1820;
        private const int DEFAULT_SHURIKEN = 3;
        private const int MAX_HEALTH = 100;

        private Dictionary<string, Keys> controls;
        private bool isGrounded;
        private float jumpHeight;
        private Vector2 velocity;
        private bool isMoving;

        public Player(Keys moveLeft, Keys moveRight, Keys jump, Keys shoot, Vector2 position, bool isFacingRight)
        {
            this.State = PlayerStates.IDLE;
            this.IsFacingRight = isFacingRight;
            this.jumpHeight = 0;


            this.controls = new Dictionary<string, Keys>();
            this.controls.Add("Move Left", moveLeft);
            this.controls.Add("Move Right", moveRight);
            this.controls.Add("Jump", jump);
            this.controls.Add("Shoot", shoot);

            this.Position = position;
            this.Shurikens = DEFAULT_SHURIKEN;
            this.isGrounded = false;


        }

        public Vector2 Position { get; set; }
        public Rectangle Bounds { get; set; }
        public PlayerStates State { get; private set; }
        public bool IsFacingRight { get; set; }
        public bool IsAttacking { get; set; }
        public int Health { get; set; }
        public int Shurikens { get; set; }

        public void Move(List<Block> blocks, List<KeyboardButtonState> activeKeys)
        {
            this.State = PlayerStates.IDLE;

            // Checking for collision with blocks underneath the player
            this.HandleTopCollision(blocks);
            this.Position += this.velocity;

            // Movement
            this.HandleMovement(blocks, activeKeys);
            this.HandleBottomCollision(blocks);

            // Side Collision
            this.HandleSideCollision(blocks);
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

        private bool IsOnTopOf(Rectangle rect)
        {
            return (this.Bounds.Bottom + this.velocity.Y >= rect.Top - 10&& this.Bounds.Bottom + this.velocity.Y >= rect.Top - 11 &&
                this.Bounds.Bottom + this.velocity.Y <= rect.Top+2 &&
                this.Bounds.Right >= rect.Left + 2&&
                this.Bounds.Left <= rect.Right - 2);
        }

        private void HandleSideCollision(List<Block> blocks)
        {
            if ((this.Bounds.Left + (this.Bounds.Width / 2)) + this.velocity.X < LEFT_BOUND)
            {
                this.Position = new Vector2(- (this.Bounds.Width / 2), this.Position.Y);
            }
            else if ((this.Bounds.Right - (this.Bounds.Width / 2)) + this.velocity.X > RIGHT_BOUND)
            {
                this.Position = new Vector2(RIGHT_BOUND - (this.Bounds.Width / 2), this.Position.Y);
            }
            else
            {
                int tempDistance;
                if (this.velocity.X > 0)
                {
                    tempDistance = TEMP_DISTANCE;
                }
                else
                {
                    tempDistance = -TEMP_DISTANCE;
                }

                Rectangle tempRect = new Rectangle((int)(this.Bounds.X + (this.velocity.X + tempDistance)),
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

        private void HandleTopCollision(List<Block> blocks)
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

        private void HandleMovement(List<Block> blocks, List<KeyboardButtonState> activeKeys)
        {
            this.isMoving = false;

            foreach (var key in activeKeys)
            {
                if (key.Button == this.controls["Move Left"] && key.ButtonState == Controller.Utils.KeyState.Held && !this.isMoving)
                {
                    this.State = PlayerStates.WALK;
                    this.isMoving = true;

                    this.MoveLeft();
                }
                else if (key.Button == this.controls["Move Right"] && key.ButtonState == Controller.Utils.KeyState.Held && !this.isMoving)
                {
                    this.State = PlayerStates.WALK;
                    this.isMoving = true;

                    this.MoveRight();
                }
                else if (key.Button == this.controls["Jump"] && key.ButtonState == Controller.Utils.KeyState.Held)
                {
                    this.State = PlayerStates.JUMP;
                    this.Jump();
                }
                else if (key.Button == this.controls["Shoot"] && key.ButtonState == Controller.Utils.KeyState.Clicked)
                {
                    this.Attack();
                }
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
                this.State = PlayerStates.WALK;
            }
            else if (this.velocity.X < -FRICTION_FORCE)
            {
                this.velocity = new Vector2(this.velocity.X + FRICTION_FORCE, this.velocity.Y);
                this.State = PlayerStates.WALK;
            }
            else
            {
                this.velocity = new Vector2(0, this.velocity.Y);
            }

        }

        private void ApplyGravity()
        {
            this.velocity = new Vector2(this.velocity.X, this.velocity.Y + 0.5f);

        }

        private void Attack()
        {
            if (this.Shurikens > 0)
            {
                this.IsAttacking = true;
                this.Shurikens--;
            }
        }

        private void Jump()
        {
            if (this.isGrounded)
            {
                this.isGrounded = false;
                this.velocity = new Vector2(this.velocity.X, -JUMP_VELOCITY);
            }
        }

        private void MoveLeft()
        {
            if (!Keyboard.GetState().IsKeyDown(this.controls["Move Right"]))
            {
                this.IsFacingRight = false;
            }

            if (this.velocity.X > -MAX_PLAYER_SPEED)
            {
                this.velocity = new Vector2(this.velocity.X - PLAYER_ACCELERATION, this.velocity.Y);
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
                this.velocity = new Vector2(this.velocity.X + PLAYER_ACCELERATION, this.velocity.Y);
            }
        }
    }
}
