namespace NotSoSuperMario.Controller.States
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
        private Level level;
        private Player player;
        private Animation playerAnimation;

        private List<Sprite> shurikenSprites;

        public UpdateState(InputHandler inputHandler, UIFactory uiFactory, SoundManager soundManager)
            :base(inputHandler, uiFactory, soundManager)
        {
            this.level = new LevelOne();     
            this.player = new Player(Keys.A, Keys.D, Keys.W, Keys.S, new Vector2(1100, 800), false);

            this.Initialize();
        }

        public void Initialize()
        {
            this.SpriteInState.Add(this.level.LevelBackground);

            foreach (var block in this.level.Blocks)
            {
                Sprite sprite = UIFactory.CreateSprite(block.Type.ToString());
                sprite.Position = block.Position;
                block.Bounds = new Rectangle((int)block.Position.X, (int)block.Position.Y, 
                    sprite.Texture.Width, sprite.Texture.Height);
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
                this.PlayerShoot();
            }

            //FIXME for (int i = 0; i < this.level.ListOfShurikens.Count; i++)
            //FIXME {
            //FIXME     this.UpdateShuriken(shuriken);
            //FIXME }
        }

        //FIXMEprivate void UpdateShuriken(Shuriken shuriken)
        //FIXME{
        //FIXME Shuriken shuriken = this.level.ListOfShurikens[i];
        //FIXME 
        //FIXME if (!shuriken.IsMelting)
        //FIXME {
        //FIXME     this.shuriken.Move();
        //FIXME     this.shurikenSpite[i].Position = shuriken.Position;
        //FIXME     shuriken.Bounds = new Rectangle((int)shuriken.Position.X,
        //FIXME         (int)shuriken.Position.Y,
        //FIXME         this.shurikenSpite[i].Texture.Height);
        //FIXME }
        //FIXME else
        //FIXME {
        //FIXME     this.SpritesInState.Remove(this.shurikenSpites[i]);
        //FIXME     this.level.ListOfShuriekns.Remove(shuriken);
        //FIXME     this.shurikenSpites.Remove(this.shurikenSpites[i]);
        //FIXME }
        //FIXME}

        public void UpdatePlayer()
        {
            this.player.Move(this.level.Blocks, this.inputHandler.ActiveKeys);
            this.playerAnimation.Update();
            this.playerAnimation.Position = this.player.Position;
            this.playerAnimation.IsFacingRight = this.player.IsFacingRight;
            this.player.Bounds = new Rectangle((int)this.player.Position.X, (int)this.player.Position.Y, (int)this.playerAnimation.SourceRectangle.Width, (int)this.playerAnimation.SourceRectangle.Height);
            this.playerAnimation.ChangeAnimation(this.player.State.ToString());
        }

        private void PlayerShoot()
        {
            //FIXME if (this.player.IsShooting)
            //FIXME {
            //FIXME     this.player.IsShooting = false;
            //FIXME 
            //FIXME     Vector2 shurikenPosition = new Vector2();
            //FIXME 
            //FIXME     if (this.player.IsFacingRight)
            //FIXME     {
            //FIXME         shurikenPosition = new Vector2(this.player.Bounds.Right,
            //FIXME             this.player.Position.Y + (this.player.Bounds.Height * 0.2f));
            //FIXME     }
            //FIXME     else
            //FIXME     {
            //FIXME         shurikenPosition = new Vector2(this.player.Bounds.Left - 40,
            //FIXME             this.player.Position.Y + (this.player.Bounds.Height * 0.2f));
            //FIXME     }
            //FIXME 
            //FIXME     Shuriken newShuriken = new Shuriken(shurikenPosition, this.player.isFacingRight);
            //FIXME 
            //FIXME     this.level.ListOfShurikens.Add(newShuriken);
            //FIXME 
            //FIXME     Sprite shurikenSprite = UIFactory.CreateSprite("Shuriken");
            //FIXME     this.shurikenSpite.Add(shurikenSpite);
            //FIXME     this.SpriteInState.Add(shurikenSpite);
            //FIXME }
        }
    }
}
