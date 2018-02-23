namespace NotSoSuperMario
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using NotSoSuperMario.GameObjects;

    public class NinjaCat : Game
    {
        private const int GAME_WIDTH = 1030;
        private const int GAME_HEIGHT = 579;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D background;

        private Player player;

        public NinjaCat()
        {
            this.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            this.graphics.PreferredBackBufferWidth = GAME_WIDTH;
            this.graphics.PreferredBackBufferHeight = GAME_HEIGHT;
            this.graphics.ApplyChanges();
            this.player = new Player(Content, GAME_WIDTH, GAME_HEIGHT, 200, 10, 8, new Vector2(0.45f, 0.45f));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.background = Content.Load<Texture2D>("background");

            this.spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        public NinjaCat(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, Texture2D background)
        {
            this.graphics = graphics;
            this.spriteBatch = spriteBatch;
            this.background = background;
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SandyBrown);

            this.spriteBatch.Begin();
            this.spriteBatch.Draw(this.background, Vector2.Zero, Color.AliceBlue);

            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
