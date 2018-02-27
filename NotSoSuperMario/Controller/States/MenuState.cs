namespace NotSoSuperMario.Controller.States
{
    using Microsoft.Xna.Framework.Input;
    using NotSoSuperMario.Controller.Utils;
    using NotSoSuperMario.View;

    public delegate void OnGameQuit();

    public class MenuState : State
    {
        public static event OnGameQuit OnExitPressed;

        private int menuId;

        public MenuState(InputHandler inputHandler, UIFactory uiFactory, SoundManager soundManager) 
            : base(inputHandler, uiFactory, soundManager)
        {
            //this.SpriteInState.Add(this.uiFactory.MenuBackground);
            this.SpriteInState.Add(this.uiFactory.StartButton.Sprite);
            this.SpriteInState.Add(this.uiFactory.OptionButton.Sprite);
            this.SpriteInState.Add(this.uiFactory.ExitButton.Sprite);
            this.menuId = 1;
        }

        public override void Update()
        {
            base.Update();

            if (!this.isDone)
            {
                foreach (KeyboardButtonState key in this.inputHandler.ActiveKeys)
                {
                    if (key.Button == Keys.Down && key.ButtonState == Utils.KeyState.Clicked)
                    {
                        this.menuId++;

                        if (this.menuId > 3)
                        {
                            this.menuId = 1;
                        }
                    }
                    else if (key.Button == Keys.Up && key.ButtonState == Utils.KeyState.Clicked)
                    {
                        this.menuId--;

                        if (this.menuId < 1)
                        {
                            this.menuId = 3;
                        }
                    }

                    if (key.Button == Keys.Enter && key.ButtonState == Utils.KeyState.Clicked)
                    {
                        switch (this.menuId)
                        {
                            case 1:
                                this.PlayGame();
                                break;
                            case 2:
                                this.Options();
                                break;
                            case 3:
                                this.ExitGame();
                                break;
                        }
                    }
                }
            }
            this.ChangeButtonState();
        }

        private void ExitGame()
        {
            this.isDone = true;
            // Stop Sounds
            MenuState.OnExitPressed.Invoke();
        }

        private void PlayGame()
        {
            this.isDone = true;
            // Pause Sound
            this.NextState = new UpdateState(this.inputHandler, this.uiFactory, this.soundManager);
        }

        private void Options()
        {
            // Go full Screen
            Globals.Graphics.ToggleFullScreen();
            // Sounds
            // Controls

        }

        private void ChangeButtonState()
        {
            this.uiFactory.StartButton.ChangeToNormalImage();
            this.uiFactory.OptionButton.ChangeToNormalImage();
            this.uiFactory.ExitButton.ChangeToNormalImage();

            switch (this.menuId)
            {
                case 1:
                    this.uiFactory.StartButton.ChangeToHoverImage();
                    break;
                case 2:
                    this.uiFactory.OptionButton.ChangeToHoverImage();
                    break;
                case 3:
                    this.uiFactory.ExitButton.ChangeToHoverImage();
                    break;
            }
        }
    }
}
