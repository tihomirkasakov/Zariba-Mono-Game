namespace NotSoSuperMario.Controller.States
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using NotSoSuperMario.Controller.Utils;
    using NotSoSuperMario.GameObjects;
    using NotSoSuperMario.Model.GameObjects;
    using NotSoSuperMario.Model.Level;
    using NotSoSuperMario.Utilities;
    using NotSoSuperMario.View;
    using NotSoSuperMario.View.UI;
    using System.Collections.Generic;

    class UpdateState : State
    {
        private Level level;
        private Player player;
        private Animation playerAnimation;

        private List<Sprite> shurikenSpite;

        public UpdateState(InputHandler inputHandler, UIFactory uiFactory, SoundManager soundManager)
            :base(inputHandler, uiFactory, soundManager)
        {
            this.level = new LevelOne();     
            this.player = new Player(Keys.A, Keys.D, Keys.W, Keys.S, new Vector2(1000, 100), false);


            this.Initialize();

        }

        this.playerAnimation = AnimationFactory.CreatePlayerAnimation(ConsoleColor.AliceBlue);
        this.SpritesInState.Add(this.playerAnimation);

        public void Initialize()
        {
            this.SpriteInState.Add(this.level.LevelBackground);

            foreach (var block in this.level.Blocks)
            {
                Sprite sprite = UIFactory.CreateSprite(block.Type.ToString());
                sprite.Position = block.Position;
                block.Bounds = new Rectangle((int)block.Position.X, (int)block.Position.Y, 
                    sprite.Texture.Width, sprite.Texture.Height));
                this.SpriteInState.Add(sprite);
            }
        }

        public override void Update()
        {
            base.Update();

            if (!this.isDone)
            {
                this.UpdatePlayer();
                this.PlayerShoot();
            }

            for (int i = 0; i < this.level.ListOfShurikens.Count; i++)
            {
                this.UpdateShuriken(shuriken);
            }
        }

        private void UpdateShuriken(Shuriken shuriken)
        {
            Shuriken shuriken = this.level.ListOfShurikens[i];

            if (!shuriken.IsMelting)
            {
                this.shuriken.Move();
                this.shurikenSpite[i].Position = shuriken.Position;
                shuriken.Bounds = new Rectangle((int)shuriken.Position.X,
                    (int)shuriken.Position.Y,
                    this.shurikenSpite[i].Texture.Height);
            }
            else
            {
                this.SpritesInState.Remove(this.shurikenSpites[i]);
                this.level.ListOfShuriekns.Remove(shuriken);
                this.shurikenSpites.Remove(this.shurikenSpites[i]);
            }
        }

        public void UpdatePlayer()
        {
            this.player.Move(this.level.Blocks, this.inputHandler.ActiveKeys);
            this.playerAnimation.Update();
            this.playerAnimation.Position = this.player.Position;
            this.playerAnimation.IsFacingRight = this.player.IsFacingRight;
            this.player.Bounds = new Rectangle((int)this.player.Positon.X, (int)this.player.Position.Y, (int)this.playerAnimation.SourceRectangle.Width, (int)this.playerAnimation.SourceRectangle.Height);
            this.playerAnimation
        }

        private void PlayerShoot()
        {
            if (this.player.IsShooting)
            {
                this.player.IsShooting = false;

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

                Shuriken newShuriken = new Shuriken(shurikenPosition, this.player.isFacingRight);

                this.level.ListOfShurikens.Add(newShuriken);

                Sprite shurikenSprite = UIFactory.CreateSprite("Shuriken");
                this.shurikenSpite.Add(shurikenSpite);
                this.SpriteInState.Add(shurikenSpite);
            }
        }
    }
}
