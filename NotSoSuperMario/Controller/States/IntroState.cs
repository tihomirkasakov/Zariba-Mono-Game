namespace NotSoSuperMario.Controller.States
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using NotSoSuperMario.Controller.Utils;
    using NotSoSuperMario.View;
    using System;

    class IntroState : State
    {
        public IntroState(InputHandler inputHandler, UIFactory uiFactory, int currentLevel)
            : base(inputHandler, uiFactory, currentLevel)
        {
            this.SpritesInState.Add(this.uiFactory.IntroBackground);
        }

        public override void Update()
        {
            base.Update();

            if (!isDone)
            {
                if (inputHandler.ActiveKeys.Count > 0)
                {
                    GoToMenu();
                }
            }
        }

        private void GoToMenu()
        {
            this.isDone = true;
            this.NextState = new MenuState(this.inputHandler, this.uiFactory, this.currentLevel);
        }
    }
}
