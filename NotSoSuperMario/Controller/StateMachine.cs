namespace NotSoSuperMario.Controller
{
    using NotSoSuperMario.Controller.States;
    using NotSoSuperMario.Controller.Utils;
    using NotSoSuperMario.View;

    public class StateMachine
    {
        public State CurrentState { get; set; }

        public StateMachine(InputHandler inputHandler, UIFactory uiFactory, SoundManager soundManager, int currentLevel)
        {

            // Initialize starting state
            this.CurrentState = new IntroState(inputHandler, uiFactory, soundManager, currentLevel);
        }

        public void Update()
        {
            this.CurrentState.Update();
            this.CurrentState = this.CurrentState.NextState;
        }

        public void Draw(MonoGameRenderer renderer)
        {
            this.CurrentState.Draw(renderer);
        }
    }
}
