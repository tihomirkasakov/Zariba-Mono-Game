namespace NotSoSuperMario.Controller.States
{
    using NotSoSuperMario.Controller.Utils;
    using NotSoSuperMario.View;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework;

    public abstract class State
    {
        private const int GAME_TIME = 300; // timeout
        protected int currentLevel;
        protected InputHandler inputHandler;
        protected UIFactory uiFactory;
        protected bool isDone;
        protected bool isPlaying;
        public Camera camera;
        public Viewport viewport;
        public SpriteFont fontLevel;
        public SpriteFont fontTimer;
        public int timer;
        private int coeff = 0;

        public State(InputHandler inputHandler, UIFactory uiFactory, int currentLevel)
        {
            this.currentLevel = currentLevel;
            camera = new Camera(viewport);
            this.inputHandler = inputHandler;
            this.uiFactory = uiFactory;
            this.NextState = this;
            this.SpritesInState = new List<IRenderable>();
            this.isDone = false;
            this.isPlaying = false;
            this.timer = GAME_TIME;
            this.fontLevel = Globals.Content.Load<SpriteFont>("Fonts/FontLevel");
            this.fontTimer = Globals.Content.Load<SpriteFont>("Fonts/FontTimer");
        }

        public State NextState { get; set; }

        public List<IRenderable> SpritesInState { get; set; }

        public virtual void Update()
        {
            if (!this.isDone)
            {
                this.inputHandler.Update();
            }
        }

        public virtual void Draw(MonoGameRenderer renderer)
        {
            if (!isPlaying)
            {
                renderer.DrawMenuState(this.SpritesInState);
            }
            else
            {
                coeff++;
                if (coeff % 60 == 0)
                {
                    this.timer--;
                }
                renderer.DrawPlayState(this.SpritesInState, camera);
                Globals.SpriteBatch.Begin();
                this.uiFactory.TimerUI.Position = new Vector2(camera.center.X - 550, camera.center.Y - 400);
                this.SpritesInState.Add(this.uiFactory.TimerUI);
                Globals.SpriteBatch.DrawString(this.fontTimer, this.timer.ToString(), new Vector2(camera.Transform.Left.X + 35, camera.Transform.Down.Y + 15), Color.Black);
                Globals.SpriteBatch.DrawString(this.fontLevel, "World 1-" + this.currentLevel.ToString(), new Vector2(camera.Transform.Left.X + 450, camera.Transform.Down.Y + 15), Color.Black);
                Globals.SpriteBatch.End();

            }
        }
    }
}
