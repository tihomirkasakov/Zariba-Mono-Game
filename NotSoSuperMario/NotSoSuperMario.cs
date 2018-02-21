using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NotSoSuperMario
{

    public class NotSoSuperMario : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private const int GAME_WIDTH = 1030;
        private const int GAME_HEIGTH = 579;

        private Texture2D background;

        public NotSoSuperMario()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = GAME_WIDTH;
            graphics.PreferredBackBufferHeight = GAME_HEIGTH;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.background = Content.Load<Texture2D>("background");
            spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        public NotSoSuperMario(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, Texture2D background)
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
                Exit();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SandyBrown);

            spriteBatch.Begin();
            spriteBatch.Draw(background, Vector2.Zero, Color.AliceBlue);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
