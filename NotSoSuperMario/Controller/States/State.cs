namespace NotSoSuperMario.Controller.States
{
    using NotSoSuperMario.Controller.Utils;
    using NotSoSuperMario.View;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class State
    {
        protected InputHandler inputHandler;
        protected UIFactory uiFactory;
        protected SoundManager soundManager;
        protected bool isDone;
        protected bool isPlaying;
        public Camera camera;
        public Viewport viewport;

        public State(InputHandler inputHandler, UIFactory uiFactory, SoundManager soundManager)
        {
            camera = new Camera(viewport);
            this.inputHandler = inputHandler;
            this.uiFactory = uiFactory;
            this.soundManager = soundManager;
            this.NextState = this;
            this.SpriteInState = new List<IRenderable>();
            this.isDone = false;
            this.isPlaying = false;
        }

        public State NextState { get; set; }

        public List<IRenderable> SpriteInState { get; set; }

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
                renderer.DrawMenuState(this.SpriteInState);
            }
            else
            {
                renderer.DrawPlayState(this.SpriteInState, camera);
            }
        }
    }
}
