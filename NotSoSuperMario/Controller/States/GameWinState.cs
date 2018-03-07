namespace NotSoSuperMario.Controller.States
{
    using Microsoft.Xna.Framework.Input;
    using Controller.Utils;
    using View;

    public class GameWinState : State
    {
        public GameWinState(InputHandler inputHandler, UIFactory uiFactory, SoundManager soundManager, int currentLevel)
            : base(inputHandler, uiFactory, soundManager, currentLevel)
        {
            this.SpritesInState.Add(this.uiFactory.GameWinBackground);
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
                        this.NextState = new MenuState(this.inputHandler, this.uiFactory, this.soundManager,this.currentLevel);
                    }
                }
            }
        }
    }
}
