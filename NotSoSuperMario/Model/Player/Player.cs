namespace NotSoSuperMario.Model.Player
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using NotSoSuperMario.Controller.Utils;
    using NotSoSuperMario.Model.GameObjects;
    using NotSoSuperMario.Controller;

    public enum PlayerStates
    {
        IDLE,
        WALK,
        JUMP,
    }

    public class Player : Entity
    {
        private const float FRICTION_FORCE = 0.8f;
        private const float MAX_PLAYER_SPEED = 2;
        private const float PLAYER_ACCELERATION = 0.1f;
        private const int JUMP_VELOCITY = 8;
        private const float SCREEN_BOTTOM_BOUND = 1100;
        private const int SCREEN_LEFT_BOUND = 0;
        public int screenRightBound;
        private const int MAX_PLAYER_HEALTH = 100;

        private Dictionary<string, Keys> controls;
        private bool isGrounded;
        public Vector2 velocity;
        private bool isMoving;

        public Player(Keys moveLeft, Keys moveRight, Keys jump, Keys hide, Vector2 position, bool isFacingRight)
            : base(position, isFacingRight)
        {
            this.State = PlayerStates.IDLE;
            this.IsFacingRight = isFacingRight;

            this.controls = new Dictionary<string, Keys>();
            this.controls.Add("Move Left", moveLeft);
            this.controls.Add("Move Right", moveRight);
            this.controls.Add("Jump", jump);
            this.controls.Add("Hide", hide);

            this.Health = MAX_PLAYER_HEALTH;
            this.Position = position;
            this.isGrounded = false;
            this.IsHidden = false;
        }

        public PlayerStates State { get; private set; }

        public bool IsAttacking { get; set; }

        public bool IsHidden { get; set; }

        public override void ActOnCollision()
        {
            throw new System.NotImplementedException();
        }

        public void Move(List<Block> blocks, List<Crate> crates, List<KeyboardButtonState> activeKeys)
        {
            this.State = PlayerStates.IDLE;

            this.Hide(crates);

            this.HandleTopCollision(blocks);
            this.Position += this.velocity;

            this.HandleMovement(blocks, activeKeys);
            this.HandleBottomCollision(blocks);

            this.HandleSideCollision(blocks);
        }

        private void Hide(List<Crate> crates)
        {
            if (Keyboard.GetState().IsKeyDown(this.controls["Hide"]))
            {
                Rectangle tempRect = new Rectangle((int)(this.Bounds.X + this.Bounds.Width), (int)(this.Bounds.Y + this.velocity.Y), this.Bounds.Width, this.Bounds.Height);

                foreach (var crate in crates)
                {
                    if (tempRect.Intersects(crate.Bounds))
                    {
                        this.velocity = new Vector2(0, 0);
                        this.IsHidden = true;
                    }
                }
            }
            else
            {
                this.IsHidden = false;
            }
        }

        private void HandleBottomCollision(List<Block> blocks)
        {
            this.isGrounded = false;

            foreach (var block in blocks)
            {
                Rectangle tempRect = new Rectangle((int)(this.Bounds.X + PLAYER_ACCELERATION + 1), (int)(this.Bounds.Bottom + this.velocity.Y), this.Bounds.Width, this.Bounds.Height / 3);
                if (tempRect.Intersects(block.Bounds) && block.Type.ToString() == "spike")
                {
                    this.Health = 0;
                }

                if (tempRect.Intersects(block.Bounds))
                {
                    this.isGrounded = true;
                    this.velocity = new Vector2(this.velocity.X, 0);
                }
            }
        }

        private void HandleSideCollision(List<Block> blocks)
        {
            if ((this.Bounds.Left + (this.Bounds.Width / 2)) + this.velocity.X < SCREEN_LEFT_BOUND)
            {
                this.Position = new Vector2(-(this.Bounds.Width / 2), this.Position.Y);
            }
            else if ((this.Bounds.Right - (this.Bounds.Width / 2)) + this.velocity.X > this.screenRightBound)
            {
                this.Position = new Vector2(this.screenRightBound - (this.Bounds.Width / 2), this.Position.Y);
            }
            else
            {
                if (this.IsFacingRight)
                {
                    Rectangle tempRect = new Rectangle((int)(this.Bounds.X + this.Bounds.Width + this.velocity.X + PLAYER_ACCELERATION), (int)(this.Bounds.Y + this.velocity.Y), this.Bounds.Width, this.Bounds.Height);

                    foreach (var block in blocks)
                    {
                        if (tempRect.Intersects(block.Bounds))
                        {
                            this.velocity = new Vector2(0, this.velocity.Y);
                        }
                    }
                }
                else
                {
                    Rectangle tempRect = new Rectangle((int)(this.Bounds.X + this.velocity.X + PLAYER_ACCELERATION), (int)(this.Bounds.Y + this.velocity.Y), this.Bounds.Width, this.Bounds.Height);

                    foreach (var block in blocks)
                    {
                        if (tempRect.Intersects(block.Bounds))
                        {
                            this.velocity = new Vector2(0, this.velocity.Y);
                        }
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
                    Rectangle tempRect = new Rectangle((int)(this.Bounds.X + PLAYER_ACCELERATION), (int)(this.Bounds.Y + this.velocity.Y), this.Bounds.Width, this.Bounds.Height);
                    if (tempRect.Intersects(block.Bounds))
                    {
                        this.velocity = new Vector2(this.velocity.X, 0.5f);
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
                else if (key.Button == this.controls["Hide"] && key.ButtonState == Controller.Utils.KeyState.Held)
                {
                    this.State = PlayerStates.IDLE;
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
            this.velocity = new Vector2(this.velocity.X, this.velocity.Y + 0.2f);
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
