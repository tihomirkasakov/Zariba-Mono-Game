namespace NotSoSuperMario.Controller.States
{
    using NotSoSuperMario.Controller.Utils;
    using NotSoSuperMario.View;

    public class IntroState : State
    {
        public IntroState(InputHandler inputHandler, UIFactory uiFactory, int currentLevel)
            : base(inputHandler, uiFactory, currentLevel)
        {
            this.SpritesInState.Add(this.uiFactory.IntroBackground);
        }

        public override void Update()
        {
            base.Update();

            if (!this.isDone)
            {
                if (inputHandler.ActiveKeys.Count > 0)
                {
                    this.GoToMenu();
                }
            }
        }

        private void GoToMenu()
        {
            this.isDone = true;
            this.NextState = new MenuState(this.inputHandler, this.uiFactory, this.CurrentLevel);
        }
    }
}
