namespace NotSoSuperMario.Controller
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using NotSoSuperMario.Controller.States;
    using NotSoSuperMario.Controller.Utils;
    using NotSoSuperMario.View;

    public class NinjaCat : Game
    {
        private MonoGameRenderer renderer;
        private StateMachine stateMachine;
        private UIFactory uiFactory;
        private InputHandler inputHandler;
        private SoundManager soundManager;
        private int currentLevel;

        public NinjaCat()
        {
            Globals.Graphics = new GraphicsDeviceManager(this);
            Globals.Content = this.Content;
            Globals.Content.RootDirectory = "Content";

            IsMouseVisible = false;

            Window.Title = "Ninja Cat";

            Globals.Graphics.PreferredBackBufferWidth = 1080;
            Globals.Graphics.PreferredBackBufferHeight = 800;

            MenuState.OnExitPressed += this.QuitGame;
        }

        protected override void Initialize()
        {
            currentLevel = 2;
            this.renderer = new MonoGameRenderer();
            this.soundManager = new SoundManager();
            this.inputHandler = new InputHandler();
            this.uiFactory = new UIFactory();

            this.stateMachine = new StateMachine(this.inputHandler, this.uiFactory, this.soundManager, currentLevel);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);
            //this.soundManager.LoadContent();
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            Globals.GameTime = gameTime;
            this.stateMachine.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.TransparentBlack);
            this.stateMachine.Draw(renderer);

            base.Draw(gameTime);
        }

        private void QuitGame()
        {
            this.Exit();
        }
    }
}
