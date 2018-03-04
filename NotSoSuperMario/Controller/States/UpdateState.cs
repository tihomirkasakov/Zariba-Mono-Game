﻿namespace NotSoSuperMario.Controller.States
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using NotSoSuperMario.Controller.Utils;
    using NotSoSuperMario.Model.GameObjects;
    using NotSoSuperMario.Model.Level;
    using Model.Player;
    using NotSoSuperMario.View;
    using NotSoSuperMario.View.UI;
    using System.Collections.Generic;
    using System;

    class UpdateState : State
    {
        private const int TILE_SIZE = 45;
        private Level level;
        private Player player;
        private Animation playerAnimation;
        private List<Sprite> shurikenSprites;
        private List<Animation> listOfPlayerAnimations;

        public UpdateState(InputHandler inputHandler, UIFactory uiFactory, SoundManager soundManager)
            : base(inputHandler, uiFactory, soundManager)
        {
            isPlaying = true;
            this.level = new LevelOne();
            this.player = new Player(Keys.Left, Keys.Right, Keys.Up, Keys.Space, new Vector2(160, 40), true);
            this.shurikenSprites = new List<Sprite>();
            this.Initialize();
        }

        public void Initialize()
        {
            this.SpriteInState.Add(this.level.LevelBackground);
            this.level.LoadContent("../../../../Content/map.txt");
            this.level.GenerateMap(level.mapTiles, TILE_SIZE);

            foreach (var block in this.level.Blocks)
            {
                Sprite sprite = UIFactory.CreateSprite("Blocks/" + block.Type.ToString(), (float)TILE_SIZE / 128);
                sprite.Position = block.Position;
                double spriteWidth = sprite.Texture.Width * ((double)TILE_SIZE / (double)sprite.Texture.Width);
                double spriteHeight = sprite.Texture.Height * ((double)TILE_SIZE / (double)sprite.Texture.Height);
                block.Bounds = new Rectangle((int)block.Position.X, (int)block.Position.Y,
                    (int)spriteWidth, (int)spriteHeight);
                this.SpriteInState.Add(sprite);
            }
            this.playerAnimation = AnimationFactory.CreatePlayerAnimation(Color.AliceBlue);
            this.SpriteInState.Add(this.playerAnimation);
        }

        public override void Update()
        {
            base.Update();



            if (!this.isDone)
            {
                this.UpdatePlayer();
                camera.Update(player.Position, level.Width, level.Height);
                this.PlayerAttack();
            }

            foreach (KeyboardButtonState key in this.inputHandler.ActiveKeys)
            {
                if (key.Button == Keys.Escape && key.ButtonState == Utils.KeyState.Clicked)
                {
                    ExitGame();
                }
            }

            for (int i = 0; i < this.level.ListOfShurikens.Count; i++)
            {
                this.UpdateShuriken(i);
            }
        }

        private void UpdateShuriken(int i)
        {
            Shuriken shuriken = this.level.ListOfShurikens[i];

            if (!shuriken.IsFalling)
            {
                shuriken.Move();
                shurikenSprites[i].Position = shuriken.Position;
                shuriken.Bounds = new Rectangle((int)shuriken.Position.X, (int)shuriken.Position.Y,
                    shurikenSprites[i].Texture.Width, shurikenSprites[i].Texture.Height);
            }
            else
            {
                SpriteInState.Remove(shurikenSprites[i]);
                this.level.ListOfShurikens.Remove(shuriken);
                shurikenSprites.Remove(shurikenSprites[i]);
            }
        }

        public void UpdatePlayer()
        {
            this.player.Move(this.level.Blocks, this.inputHandler.ActiveKeys);
            this.playerAnimation.Update();
            this.playerAnimation.Position = this.player.Position;
            this.playerAnimation.IsFacingRight = this.player.IsFacingRight;
            this.player.Bounds = new Rectangle((int)this.player.Position.X, (int)this.player.Position.Y,
                (int)(this.playerAnimation.SourceRectangle.Width * 0.5),
                (int)(this.playerAnimation.SourceRectangle.Height * 0.8));
            this.playerAnimation.ChangeAnimation(this.player.State.ToString());
        }

        private void PlayerAttack()
        {
            if (this.player.IsAttacking)
            {
                this.player.IsAttacking = false;

                Vector2 shurikenPosition = new Vector2();

                if (this.player.IsFacingRight)
                {
                    shurikenPosition = new Vector2(this.player.Bounds.Right,
                        this.player.Position.Y + (this.player.Bounds.Height * 0.2f));
                }
                else
                {
                    shurikenPosition = new Vector2(this.player.Bounds.Left - 40,
                        this.player.Position.Y + (this.player.Bounds.Height * 0.2f));
                }

                Shuriken newShuriken = new Shuriken(shurikenPosition, this.player.IsFacingRight);
                this.level.ListOfShurikens.Add(newShuriken);

                Sprite shurikenSprite = UIFactory.CreateSprite("Hero/shuriken", 0.15f);
                this.shurikenSprites.Add(shurikenSprite);
                this.SpriteInState.Add(shurikenSprite);
            }
        }
        private void ExitGame()
        {
            this.isDone = true;
            // Stop Sounds
            Environment.Exit(0);
        }
    }
}
