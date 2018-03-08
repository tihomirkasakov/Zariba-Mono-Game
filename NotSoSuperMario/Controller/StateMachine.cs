namespace NotSoSuperMario.Controller
{
    using NotSoSuperMario.Controller.States;
    using NotSoSuperMario.Controller.Utils;
    using NotSoSuperMario.View;

    public class StateMachine
    {
        public StateMachine(InputHandler inputHandler, UIFactory uiFactory, int currentLevel)
        {
            this.CurrentState = new IntroState(inputHandler, uiFactory, currentLevel);
        }

        public State CurrentState { get; set; }

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
