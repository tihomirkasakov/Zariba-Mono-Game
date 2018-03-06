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
    using NotSoSuperMario.Model.Enemy;
    using Microsoft.Xna.Framework.Graphics;

    class UpdateState : State
    {
        private const int TILE_SIZE = 45;
        private int currentLevel = 1;
        private Level level;
        private Player player;

        private Animation playerAnimation;

        private List<Enemy> enemies;

        private List<Sprite> shurikenSprites;
        private List<Animation> enemyAnimation;
        GraphicsDeviceManager graphics;

        public UpdateState(InputHandler inputHandler, UIFactory uiFactory, SoundManager soundManager, Player playerData = null, List<Enemy> enemiesData = null)
            : base(inputHandler, uiFactory, soundManager)
        {
            isPlaying = true;
            this.level = new LevelOne();
            if (playerData == null)
            {
                this.player = new Player(Keys.Left, Keys.Right, Keys.Up, Keys.Down, Keys.Space, new Vector2(45, 760), true);
            }
            else
            {
                this.player = playerData;
            }
            if (enemiesData == null)
            {
                Enemy enemyPigLow = new Enemy(new Vector2(100, 950), new Rectangle(100, 0, 300, 0), 0.6f, true);
                Enemy enemyPigHigh = new Enemy(new Vector2(130, 450), new Rectangle(100, 0, 250, 0), 0.8f, true);
                Enemy enemyPigMiddle = new Enemy(new Vector2(900, 700), new Rectangle(900, 0, 200, 0), 1f, true);
                this.enemies = new List<Enemy>();
                this.enemies.Add(enemyPigLow);
                this.enemies.Add(enemyPigHigh);
                this.enemies.Add(enemyPigMiddle);
            }
            else
            {
                this.enemies = enemiesData;
            }

            this.shurikenSprites = new List<Sprite>();
            this.Initialize();
        }

        public void Initialize()
        {
            graphics = Globals.Graphics;
            camera = new Camera(graphics.GraphicsDevice.Viewport);
            this.SpritesInState.Add(this.level.LevelBackground);
            this.level.LoadContent($"../../../../Content/Level{currentLevel}.txt");
            this.level.GenerateMap(level.mapTiles, TILE_SIZE);

            foreach (var block in this.level.Blocks)
            {
                Sprite sprite = UIFactory.CreateSprite("Blocks/" + block.Type.ToString(), (float)TILE_SIZE / 128);
                sprite.Position = block.Position;
                double spriteWidth = sprite.Texture.Width * ((double)TILE_SIZE / (double)sprite.Texture.Width);
                double spriteHeight = sprite.Texture.Height * ((double)TILE_SIZE / (double)sprite.Texture.Height);
                block.Bounds = new Rectangle((int)block.Position.X, (int)block.Position.Y,
                    (int)spriteWidth, (int)spriteHeight);
                this.SpritesInState.Add(sprite);
            }
            this.playerAnimation = AnimationFactory.CreatePlayerAnimation(Color.AliceBlue);
            this.SpritesInState.Add(this.playerAnimation);

            this.enemyAnimation = new List<Animation>();

            Animation enemyPigLow = AnimationFactory.CreateEnemyAnimaton(Color.White);
            this.SpritesInState.Add(enemyPigLow);
            this.enemyAnimation.Add(enemyPigLow);

            Animation enemyPigHigh = AnimationFactory.CreateEnemyAnimaton(Color.White);
            this.SpritesInState.Add(enemyPigHigh);
            this.enemyAnimation.Add(enemyPigHigh);

            Animation enemyPigMiddle = AnimationFactory.CreateEnemyAnimaton(Color.White);
            this.SpritesInState.Add(enemyPigMiddle);
            this.enemyAnimation.Add(enemyPigMiddle);
        }

        public override void Update()
        {
            base.Update();

            if (!this.isDone)
            {
                this.CheckGameOver();
                this.PauseGame();

                for (int i = 0; i < this.enemies.Count; i++)
                {
                    this.UpdateEnemy(i);
                    this.CheckPlayerEnemyCollision(i);
                } 

                this.UpdatePlayer();                
                camera.Update(player.Position, level.Width, level.Height);
                //this.PlayerAttack();
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
                SpritesInState.Remove(shurikenSprites[i]);
                this.level.ListOfShurikens.Remove(shuriken);
                shurikenSprites.Remove(shurikenSprites[i]);
            }
        }

        public void UpdatePlayer()
        {
            if (Keyboard.GetState().IsKeyUp(Keys.Down))
            {
                player.IsHidden = false;
                this.playerAnimation.Tint = new Color(Color.White, 1f);
            }
            this.player.Move(this.level.Blocks, this.inputHandler.ActiveKeys);
            this.playerAnimation.Update();
            this.playerAnimation.Position = this.player.Position;
            this.playerAnimation.IsFacingRight = this.player.IsFacingRight;
            this.player.Bounds = new Rectangle((int)this.player.Position.X, (int)this.player.Position.Y,
                (int)(this.playerAnimation.SourceRectangle.Width * 0.5),
                (int)(this.playerAnimation.SourceRectangle.Height * 0.8));
            this.playerAnimation.ChangeAnimation(this.player.State.ToString());
        }

        public void UpdateEnemy(int i)
        {
            this.enemies[i].Patrolling(this.level.Blocks);
            this.enemyAnimation[i].Update();
            this.enemyAnimation[i].Position = this.enemies[i].Position;
            this.enemyAnimation[i].IsFacingRight = this.enemies[i].IsFacingRight;
            this.enemies[i].Bounds = new Rectangle((int)this.enemies[i].Position.X, (int)this.enemies[i].Position.Y,
                (int)(this.enemyAnimation[i].SourceRectangle.Width),
                (int)(this.enemyAnimation[i].SourceRectangle.Height * 0.9));
            this.enemyAnimation[i].ChangeAnimation(this.enemies[i].State.ToString());

        }

        private void CheckPlayerEnemyCollision(int i)
        {
            if (this.player.IsHidden)
            {
                this.playerAnimation.Tint = new Color(Color.White, 0.2f);
            }
            if (this.player.Bounds.Intersects(this.enemies[i].Bounds) && !this.player.IsHidden)
            {
                enemies[i].ActOnCollision();
                this.NextState = new GameOver(this.inputHandler, this.uiFactory, this.soundManager);
            }
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
                this.SpritesInState.Add(shurikenSprite);
            }
        }

        private void PauseGame()
        {
            foreach (var key in this.inputHandler.ActiveKeys)
            {
                if (key.Button == Keys.Escape && key.ButtonState == Utils.KeyState.Clicked)
                {
                    this.isDone = true;
                    this.NextState = new PauseState(this.inputHandler, this.uiFactory, this.soundManager, this.player, this.enemies);
                }
            }
        }

        private void CheckGameOver()
        {
            if (player.Health <= 0)
            {
                this.isDone = true;
                this.NextState = new GameOver(this.inputHandler, this.uiFactory, this.soundManager);
            }
        }
    }
}
