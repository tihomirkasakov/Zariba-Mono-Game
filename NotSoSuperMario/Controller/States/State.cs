namespace NotSoSuperMario.Controller.States
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using NotSoSuperMario.Controller.Utils;
    using NotSoSuperMario.View;

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
            this.camera = new Camera(this.viewport);
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
            if (!this.isPlaying)
            {
                renderer.DrawMenuState(this.SpritesInState);
            }
            else
            {
                this.coeff++;
                if (this.coeff % 60 == 0)
                {
                    this.timer--;
                }

                renderer.DrawPlayState(this.SpritesInState, this.camera);
                Globals.SpriteBatch.Begin();
                this.uiFactory.TimerUI.Position = new Vector2(this.camera.center.X - 550, this.camera.center.Y - 400);
                this.SpritesInState.Add(this.uiFactory.TimerUI);
                Globals.SpriteBatch.DrawString(this.fontTimer, this.timer.ToString(), new Vector2(this.camera.Transform.Left.X + 35, this.camera.Transform.Down.Y + 15), Color.Black);
                Globals.SpriteBatch.DrawString(this.fontLevel, "World 1-" + this.currentLevel.ToString(), new Vector2(this.camera.Transform.Left.X + 450, this.camera.Transform.Down.Y + 15), Color.Black);
                Globals.SpriteBatch.End();
            }
        }
    }
}
