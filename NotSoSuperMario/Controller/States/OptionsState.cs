namespace NotSoSuperMario.Controller.States
{
    using Microsoft.Xna.Framework.Input;
    using NotSoSuperMario.Controller.Utils;
    using NotSoSuperMario.View;

    public class OptionsState : State
    {
        public int menuId;

        public OptionsState(InputHandler inputHandler, UIFactory uiFactory, SoundManager soundManager)
            : base(inputHandler, uiFactory, soundManager)
        {
            this.SpriteInState.Add(this.uiFactory.MenuBackground);
            this.SpriteInState.Add(this.uiFactory.VolumeButton.Sprite);
            this.SpriteInState.Add(this.uiFactory.FullscreenButton.Sprite);
            this.SpriteInState.Add(this.uiFactory.Checkbox.Sprite);
            this.SpriteInState.Add(this.uiFactory.BackButton.Sprite);
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
                            case 2:
                                this.ToggleFullscreen();
                                break;
                            case 3:
                                this.GoBack();
                                break;
                        }
                    }
                }
            }
            this.ChangeButtonState();
        }

        private void GoBack()
        {
            this.isDone = true;
            this.NextState = new MenuState(this.inputHandler, this.uiFactory, this.soundManager);
        }

        private void ToggleFullscreen()
        {
            Globals.Graphics.IsFullScreen = true;
            Globals.Graphics.ApplyChanges();
            this.uiFactory.Checkbox.ChangeToHoverImage();
        }

        private void ChangeButtonState()
        {
            this.uiFactory.VolumeButton.ChangeToNormalImage();
            this.uiFactory.FullscreenButton.ChangeToNormalImage();
            this.uiFactory.BackButton.ChangeToNormalImage();

            switch (this.menuId)
            {
                case 1:
                    this.uiFactory.VolumeButton.ChangeToHoverImage();
                    break;
                case 2:
                    this.uiFactory.FullscreenButton.ChangeToHoverImage();
                    break;
                case 3:
                    this.uiFactory.BackButton.ChangeToHoverImage();
                    break;
            }
        }
    }
}
