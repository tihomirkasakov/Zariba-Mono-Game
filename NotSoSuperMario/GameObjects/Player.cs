namespace NotSoSuperMario.GameObjects
{
    using Utilities;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System;
    using Microsoft.Xna.Framework.Content;

    public delegate void ShootSignal();

    public class Player : Entity
    {
        private const int BORDER_OFFSET = 50;
        private const double SHOOT_DELAY = 50;

        private const string IDLE_ANIMATION_KEY = "idleAnimation";
        private const string SHOOT_ANIMATION_KEY = "shootAnimation";
        private const string MOVE_ANIMATION_KEY = "catninja_walk";


        private double shootDelayTimer;
        public event ShootSignal shootSignal;

        public Player(ContentManager Content, int gameWidth, int gameHeight, double health, double damage, double velocity, Vector2 scale)
            : base(Content, gameWidth, gameHeight, health, damage, velocity, scale)
        {
            this.position = new Vector2(gameWidth / 2, gameHeight / 2);
            this.shootDelayTimer = 0;
        }

        public void Update(GameTime gameTime, int gameWidth, int gameHeight)
        {
            MouseState mouse = Mouse.GetState();
            KeyboardState keyboard = Keyboard.GetState();
            this.Move(gameWidth, gameHeight, keyboard);
            this.currentAnimationKey = MOVE_ANIMATION_KEY;
            foreach (var pair in this.animations)
            {
                pair.Value.Update(gameTime);
            }

            // Shoot
            if (mouse.LeftButton == ButtonState.Pressed)
            {
                this.currentAnimationKey = SHOOT_ANIMATION_KEY;
                this.shootDelayTimer += gameTime.ElapsedGameTime.Milliseconds;
                if (this.shootDelayTimer>SHOOT_DELAY)
                {
                this.shootDelayTimer = 0;
                this.shootSignal.Invoke();
                }
            }

            if (mouse.LeftButton == ButtonState.Released)
            {
                this.shootDelayTimer = 0;
            }

            // Rotation
            //this.rotation = OwnMath.CalculateAngleBetweenPoints(this.position.ToPoint(), mouse.Position);
        }

        private void Move(int gameWidth, int gameHeight, KeyboardState keyboard)
        {
            if (keyboard.IsKeyDown(Keys.W))
            {
                this.position.Y -= (float)velocity;
            }
            if (keyboard.IsKeyDown(Keys.S))
            {
                this.position.Y += (float)velocity;
            }
            if (keyboard.IsKeyDown(Keys.A))
            {
                this.position.X -= (float)velocity;
            }
            if (keyboard.IsKeyDown(Keys.D))
            {
                this.position.X += (float)velocity;
            }

            if (this.position.X <= BORDER_OFFSET)
            {
                this.position.X = BORDER_OFFSET;
            }
            if (this.position.X >= gameWidth - BORDER_OFFSET)
            {
                this.position.X = gameWidth - BORDER_OFFSET;
            }
            if (this.position.Y <= BORDER_OFFSET)
            {
                this.position.Y = BORDER_OFFSET;
            }
            if (this.position.Y >= gameHeight - BORDER_OFFSET)
            {
                this.position.Y = gameHeight - BORDER_OFFSET;
            }
        }

        protected override void CreateAnimations(ContentManager Content)
        {
            var idleAnimation = Content.Load<Texture2D>(IDLE_ANIMATION_KEY);
            var moveAnimation = Content.Load<Texture2D>(MOVE_ANIMATION_KEY);
            var shootAnimation = Content.Load<Texture2D>(SHOOT_ANIMATION_KEY);

            //this.animations.Add(IDLE_ANIMATION_KEY, new Animation(idleAnimation, 20, 4, 5, 313, 207));
            this.animations.Add(MOVE_ANIMATION_KEY, new Animation(moveAnimation, 8, 3, 3, 256, 222));
            this.animations.Add(SHOOT_ANIMATION_KEY, new Animation(shootAnimation, 3, 1, 3, 312, 206));


        }

        public override void TakeDamage(double damage)
        {
            this.Health -= damage;
            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }
        }
    }
}