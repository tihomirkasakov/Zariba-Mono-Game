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

    class UpdateState : State
    {
        private const int TILE_SIZE = 45;
        private Level level;
        private Player player;

        private Animation playerAnimation;

        private List<Enemy> enemies;

        private List<Sprite> crateSprites;
        private List<Animation> enemyAnimation;
        public GraphicsDeviceManager graphics;

        public UpdateState(InputHandler inputHandler, UIFactory uiFactory, int currentLevel, Player playerData = null, List<Enemy> enemiesData = null)
            : base(inputHandler, uiFactory, currentLevel)
        {
            isPlaying = true;
            if (this.currentLevel == 1)
            {
                this.level = new LevelOne();
                if (playerData == null)
                {
                    this.player = new Player(Keys.Left, Keys.Right, Keys.Up, Keys.Down, new Vector2(45, 760), true);
                    player.screenRightBound = level.Width;
                }
                else
                {
                    this.player = playerData;
                }
                if (enemiesData == null)
                {
                    Enemy firstPig = new Enemy(new Vector2(100, 950), new Rectangle(100, 0, 300, 0), 0.6f, true);
                    Enemy secondPig = new Enemy(new Vector2(130, 450), new Rectangle(120, 0, 250, 0), 2f, true);
                    Enemy thirdPig = new Enemy(new Vector2(900, 700), new Rectangle(900, 0, 200, 0), 1.6f, true);
                    this.enemies = new List<Enemy>();
                    this.enemies.Add(firstPig);
                    this.enemies.Add(secondPig);
                    this.enemies.Add(thirdPig);
                }
                else
                {
                    this.enemies = enemiesData;
                }
            }

            else
            {
                if (this.currentLevel == 2)
                {
                    this.level = new LevelTwo();
                    this.enemies = new List<Enemy>();
                    if (playerData == null)
                    {
                        this.player = new Player(Keys.Left, Keys.Right, Keys.Up, Keys.Down, new Vector2(45, 1200), true);
                        player.screenRightBound = level.Width;
                    }
                }
                else
                {
                    this.level = new LevelThree();
                    if (playerData == null)
                    {
                        this.player = new Player(Keys.Left, Keys.Right, Keys.Up, Keys.Down, new Vector2(45, 1200), true);
                        player.screenRightBound = level.Width;
                    }
                    else
                    {
                        this.player = playerData;
                    }
                    if (enemiesData == null)
                    {
                        Enemy enemyPigLow = new Enemy(new Vector2(100, 950), new Rectangle(100, 0, 300, 0), 2.6f, true);
                        Enemy enemyPigHigh = new Enemy(new Vector2(550, 450), new Rectangle(550, 0, 100, 0), 0.4f, true);
                        Enemy enemyPigMiddle = new Enemy(new Vector2(1400, 1200), new Rectangle(1400, 0, 200, 0), 4f, true);
                        Enemy enemyPigOne = new Enemy(new Vector2(1650, 0), new Rectangle(1650, 0, 200, 0), 2f, true);
                        Enemy enemyPigTwo = new Enemy(new Vector2(1980, 950), new Rectangle(1980, 950, 250, 0), 2.5f, true);
                        Enemy enemyPigThree = new Enemy(new Vector2(2230, 950), new Rectangle(2230, 950, 300, 0), 4f, true);
                        this.enemies = new List<Enemy>();
                        this.enemies.Add(enemyPigLow);
                        this.enemies.Add(enemyPigHigh);
                        this.enemies.Add(enemyPigMiddle);
                        this.enemies.Add(enemyPigOne);
                        this.enemies.Add(enemyPigTwo);
                        this.enemies.Add(enemyPigThree);
                    }
                    else
                    {
                        this.enemies = enemiesData;
                    }

                }
            }

            this.Initialize();
        }

        public void Initialize()
        {
            graphics = Globals.Graphics;
            camera = new Camera(graphics.GraphicsDevice.Viewport);
            this.SpritesInState.Add(this.level.LevelBackground);
            this.level.LoadContent($"../../../../Content/Level{base.currentLevel}.txt");
            this.level.GenerateMap(level.mapTiles, TILE_SIZE);
            player.screenRightBound = level.Width;

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

            this.crateSprites = new List<Sprite>();
            foreach (var crate in this.level.ListOfCrates)
            {
                Sprite crateSprite = UIFactory.CreateSprite("Blocks/Crate", 0.6f);
                crateSprite.Position = crate.Position;
                crate.Bounds = new Rectangle((int)crate.Position.X, (int)crate.Position.Y,
                    (int)(crateSprite.Texture.Width * 0.5), crateSprite.Texture.Height);
                this.SpritesInState.Add(crateSprite);
                this.crateSprites.Add(crateSprite);
            }

            this.playerAnimation = AnimationFactory.CreatePlayerAnimation(Color.AliceBlue);
            this.SpritesInState.Add(this.playerAnimation);

            this.enemyAnimation = new List<Animation>();

            Animation firstPig = AnimationFactory.CreateEnemyAnimaton(Color.White);
            this.SpritesInState.Add(firstPig);
            this.enemyAnimation.Add(firstPig);

            Animation secondPig = AnimationFactory.CreateEnemyAnimaton(Color.White);
            this.SpritesInState.Add(secondPig);
            this.enemyAnimation.Add(secondPig);

            Animation thirdPig = AnimationFactory.CreateEnemyAnimaton(Color.White);
            this.SpritesInState.Add(thirdPig);
            this.enemyAnimation.Add(thirdPig);

            if (currentLevel==3)
            {
                Animation forthPig = AnimationFactory.CreateEnemyAnimaton(Color.White);
                this.SpritesInState.Add(forthPig);
                this.enemyAnimation.Add(forthPig);

                Animation fifthPig = AnimationFactory.CreateEnemyAnimaton(Color.White);
                this.SpritesInState.Add(fifthPig);
                this.enemyAnimation.Add(fifthPig);

                Animation sixthPig = AnimationFactory.CreateEnemyAnimaton(Color.White);
                this.SpritesInState.Add(sixthPig);
                this.enemyAnimation.Add(sixthPig);
            }
        }

        public override void Update()
        {
            base.Update();

            if (!this.isDone)
            {
                this.CheckGameOver();
                this.CheckGameWin();
                this.PauseGame();

                for (int i = 0; i < this.enemies.Count; i++)
                {
                    this.UpdateEnemy(i);
                    this.CheckPlayerEnemyCollision(i);
                }

                this.HidePlayer();
                this.UpdatePlayer();
                camera.Update(player.Position, level.Width, level.Height);
                //this.PlayerAttack();
            }

            if (this.player.Bounds.Bottom + this.player.velocity.Y >= level.Height)
            {
                this.player.Health = 0;
            }

        }

        public void UpdatePlayer()
        {
            if (Keyboard.GetState().IsKeyUp(Keys.Down))
            {
                player.IsHidden = false;
                this.playerAnimation.Tint = new Color(Color.White, 1f);
            }
            this.player.Move(this.level.Blocks, this.level.ListOfCrates, this.inputHandler.ActiveKeys);
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
                (int)(this.enemyAnimation[i].SourceRectangle.Width * 0.7),
                (int)(this.enemyAnimation[i].SourceRectangle.Height * 0.75));
            this.enemyAnimation[i].ChangeAnimation(this.enemies[i].State.ToString());

        }

        private void HidePlayer()
        {
            if (this.player.IsHidden)
            {
                this.playerAnimation.Tint = new Color(Color.White, 0.2f);
            }
            else
            {
                this.player.IsHidden = false;
                this.playerAnimation.Tint = new Color(Color.White, 1f);
            }
        }

        private void CheckPlayerEnemyCollision(int i)
        {
            foreach (var crate in this.level.ListOfCrates)
            {
                if (this.player.Bounds.Intersects(this.enemies[i].Bounds) && !crate.HiddenPlayer && !this.player.IsHidden)
                {
                    this.NextState = new GameOverState(this.inputHandler, this.uiFactory, this.currentLevel);
                }
            }
        }

        private void CheckPlayerCrateCollision()
        {
            foreach (var crate in this.level.ListOfCrates)
            {
                if (!this.player.IsHidden)
                {
                    if (crate.Bounds.Intersects(this.player.Bounds))
                    {
                        crate.ActOnCollision();
                        this.player.IsHidden = true;
                        this.playerAnimation.Tint = new Color(Color.White, 0.2f);
                    }
                    else if (!crate.Bounds.Intersects(this.player.Bounds) && Keyboard.GetState().IsKeyDown(Keys.Down))
                    {
                        crate.HiddenPlayer = false;
                        this.player.IsHidden = false;
                        this.playerAnimation.Tint = new Color(Color.White, 1f);
                    }
                }
            }
        }

        private void PauseGame()
        {
            foreach (var key in this.inputHandler.ActiveKeys)
            {
                if (key.Button == Keys.Escape && key.ButtonState == Utils.KeyState.Clicked)
                {
                    this.isDone = true;
                    this.NextState = new PauseState(this.inputHandler, this.uiFactory, this.player, this.enemies, this.currentLevel);
                }
            }
        }

        private void CheckGameOver()
        {
            {
                if (player.Health <= 0 || this.timer == 0)
                {
                    this.isDone = true;
                    this.NextState = new GameOverState(this.inputHandler, this.uiFactory, this.currentLevel);
                }
            }
        }

        private void CheckGameWin()
        {
            foreach (var block in level.Blocks)
            {
                if (player.Bounds.Intersects(block.Bounds) && block.Type.ToString() == "exit")
                {
                    int nextLevel = base.currentLevel + 1;
                    if (base.currentLevel < 3)
                    {
                        this.NextState = new UpdateState(this.inputHandler, this.uiFactory, nextLevel);
                    }
                    else
                    {
                        this.isDone = true;
                        this.NextState = new GameWinState(this.inputHandler, this.uiFactory, base.currentLevel);
                    }
                }
            }
        }
    }
}
