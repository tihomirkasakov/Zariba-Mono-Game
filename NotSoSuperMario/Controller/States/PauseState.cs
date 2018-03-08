namespace NotSoSuperMario.Controller.States
{
    using Microsoft.Xna.Framework.Input;
    using NotSoSuperMario.Controller.Utils;
    using NotSoSuperMario.Model.Enemy;
    using NotSoSuperMario.Model.Player;
    using NotSoSuperMario.View;
    using System;
    using System.Collections.Generic;

    public class PauseState : State
    {
        private Player player;
        private List<Enemy> enemies;
        private bool isChanged = false;

        public PauseState(InputHandler inputHandler, UIFactory uiFactory, Player playerData, List<Enemy> enemiesData, int currentLevel)
            : base(inputHandler, uiFactory, currentLevel)
        {
            this.player = playerData;
            this.enemies = enemiesData;

            this.SpritesInState.Add(this.uiFactory.PauseBackground);
            this.SpritesInState.Add(this.uiFactory.PauseBackgroundTransperant);
            this.SpritesInState.Add(this.uiFactory.ResumeButton.Sprite);
            this.SpritesInState.Add(this.uiFactory.ExitToMenuButton.Sprite);
            this.SpritesInState.Add(this.uiFactory.ExitFromGame.Sprite);

            this.MenuId = 1;
        }

        public int MenuId { get; private set; }

        public override void Update()
        {
            base.Update();

            if (!this.isDone)
            {
                foreach (KeyboardButtonState key in this.inputHandler.ActiveKeys)
                {
                    if (key.Button == Keys.Down && key.ButtonState == Utils.KeyState.Clicked)
                    {
                        this.MenuId++;

                        if (this.MenuId > 3)
                        {
                            this.MenuId = 1;
                        }
                    }

                    if (key.Button == Keys.Up && key.ButtonState == Utils.KeyState.Clicked)
                    {
                        this.MenuId--;

                        if (this.MenuId < 1)
                        {
                            this.MenuId = 3;
                        }
                    }

                    if (key.Button == Keys.Enter && key.ButtonState == Utils.KeyState.Clicked)
                    {
                        switch (this.MenuId)
                        {
                            case 1:
                                this.ResumeGame();
                                break;
                            case 2:
                                this.ExitToMenu();
                                break;
                            case 3:
                                this.ExitFromGame();
                                break;
                        }
                    }
                }

                this.ChangeButtonsState();
            }
        }

        private void ExitToMenu()
        {
            this.isDone = true;
            this.NextState = new MenuState(this.inputHandler, this.uiFactory, this.currentLevel);
        }

        private void ResumeGame()
        {
            this.isDone = true;
            this.NextState = new UpdateState(this.inputHandler, this.uiFactory, this.currentLevel, this.player, this.enemies);
        }

        private void ExitFromGame()
        {
            Environment.Exit(0);
        }

        private void ChangeButtonsState()
        {
            this.uiFactory.ResumeButton.ChangeToNormalImage();
            this.uiFactory.ExitToMenuButton.ChangeToNormalImage();
            this.uiFactory.ExitFromGame.ChangeToNormalImage();

            switch (this.MenuId)
            {
                case 1:
                    this.uiFactory.ResumeButton.ChangeToHoverImage();
                    break;

                case 2:
                    this.uiFactory.ExitToMenuButton.ChangeToHoverImage();
                    break;

                case 3:
                    this.uiFactory.ExitFromGame.ChangeToHoverImage();
                    break;
            }
        }
    }
}
