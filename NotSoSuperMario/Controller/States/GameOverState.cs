﻿namespace NotSoSuperMario.Controller.States
{
    using Controller.Utils;
    using Microsoft.Xna.Framework.Input;
    using View;

    public class GameOverState : State
    {
        public GameOverState(InputHandler inputHandler, UIFactory uiFactory, int currentLevel)
            : base(inputHandler, uiFactory, currentLevel)
        {
            this.SpritesInState.Add(this.uiFactory.GameOverBackground);
        }

        public override void Update()
        {
            base.Update();

            if (!this.isDone)
            {
                foreach (KeyboardButtonState key in this.inputHandler.ActiveKeys)
                {
                    if ((key.Button == Keys.Enter || key.Button == Keys.Escape) && key.ButtonState == Utils.KeyState.Clicked)
                    {
                        this.isDone = true;
                        this.NextState = new MenuState(this.inputHandler, this.uiFactory, this.CurrentLevel);
                    }
                }
            }
        }
    }
}
