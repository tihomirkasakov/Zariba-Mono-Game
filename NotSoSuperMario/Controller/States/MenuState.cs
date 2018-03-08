namespace NotSoSuperMario.Controller.States
{
    using Microsoft.Xna.Framework.Input;
    using NotSoSuperMario.Controller.Utils;
    using NotSoSuperMario.View;

    public delegate void OnGameQuit();

    public class MenuState : State
    {
        private bool isChanged = false;
        private int menuId;

        public MenuState(InputHandler inputHandler, UIFactory uiFactory, int currentLevel)
            : base(inputHandler, uiFactory, currentLevel)
        {
            this.SpritesInState.Add(this.uiFactory.MenuBackground);
            this.SpritesInState.Add(this.uiFactory.StartButton.Sprite);
            this.SpritesInState.Add(this.uiFactory.FullscreenButton.Sprite);
            this.SpritesInState.Add(this.uiFactory.Checkbox.Sprite);
            this.SpritesInState.Add(this.uiFactory.ExitButton.Sprite);

            this.menuId = 1;
        }

        public static event OnGameQuit OnExitPressed;

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
                                this.ToggleFullscreen();
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
            MenuState.OnExitPressed.Invoke();
        }

        private void PlayGame()
        {
            this.isDone = true;
            this.NextState = new UpdateState(this.inputHandler, this.uiFactory, this.currentLevel);
        }

        private void ToggleFullscreen()
        {
            if (Globals.Graphics.IsFullScreen && !this.isChanged)
            {
                this.isChanged = true;
                Globals.Graphics.IsFullScreen = false;
                Globals.Graphics.ApplyChanges();
            }
            else if (!Globals.Graphics.IsFullScreen && !this.isChanged)
            {
                this.isChanged = true;
                Globals.Graphics.IsFullScreen = true;
                Globals.Graphics.ApplyChanges();
            }

            this.isChanged = false;
            this.uiFactory.Checkbox.ChangeToHoverImage();
        }

        private void ChangeButtonState()
        {
            this.uiFactory.StartButton.ChangeToNormalImage();
            this.uiFactory.FullscreenButton.ChangeToNormalImage();
            this.uiFactory.ExitButton.ChangeToNormalImage();

            switch (this.menuId)
            {
                case 1:
                    this.uiFactory.StartButton.ChangeToHoverImage();
                    break;
                case 2:
                    this.uiFactory.FullscreenButton.ChangeToHoverImage();
                    break;
                case 3:
                    this.uiFactory.ExitButton.ChangeToHoverImage();
                    break;
            }
        }
    }
}
