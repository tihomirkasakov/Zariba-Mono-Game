namespace NotSoSuperMario.Controller.States
{
    using NotSoSuperMario.Controller.Utils;
    using NotSoSuperMario.View;
    using System.Collections.Generic;

    public abstract class State
    {
        protected InputHandler inputHandler;
        protected UIFactory uiFactory;
        protected SoundManager soundManager;
        protected bool isDone;

        public State(InputHandler inputHandler, UIFactory uiFactory, SoundManager soundManager)
        {
            this.inputHandler = inputHandler;
            this.uiFactory = uiFactory;
            this.soundManager = soundManager;
            this.NextState = this;
            this.SpriteInState = new List<IRenderable>();
            this.isDone = false;
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
            renderer.DrawState(this.SpriteInState);
        }
    }
}
