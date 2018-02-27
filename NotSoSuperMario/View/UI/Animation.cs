namespace NotSoSuperMario.Utilities
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using NotSoSuperMario.Controller;
    using NotSoSuperMario.View;
    using NotSoSuperMario.View.UI;
    using System.Collections.Generic;

    public class Animation : IRenderable
    {      
        private Texture2D texture;

        public Animation(Vector2 frameDimensions, Texture2D spriteSheet, int switchFrameTimer)
        {
            this.SourceRectangle = new Rectangle(0, 0, (int)frameDimensions.X, (int)frameDimensions.Y);
            this.Texture = spriteSheet;
            this.IsFacingRight = true;
            this.SwitchFrameTimer = switchFrameTimer;
        }

        public Vector2 Position { get; set; }

        public Color Tint { get; set; }

        public bool IsFacingRight { get; set; }

        public float Scale { get; set; }

        public Rectangle SourceRectangle { get; set; }

        public List<AnimationState> AnimationState { get; set; }

        public Texture2D Texture
        {
            get
            {
                return this.texture;
            }

            set
            {
                this.texture = value;
            }
        }

        private AnimationState CurrentAnimationState { get; set; }

        private int SwitchFrameTimer { get; set; }

        private int ElapsedMiliseconds { get; set; }

        public void ChangeAnimation(string nameOfAction)
        {
            foreach (AnimationState state in this.AnimationStates)
            {
                if (state.Name == nameOfAction && state != this.CurrentAnimationState)
                {
                    this.CurrentAnimationState = state;
                    this.SourceRectangle = new Rectangle(0, state.RowOfFrames.Top, this.SourceRectangle.Width, this.SourceRectangle.Height);
                    break;
                }
            }
        }

        public void Update()
        {
            this.ElapsedMiliseconds += Globals.GameTime.ElapsedGameTime.Miliseconds;
            if (this.ElapsedMiliseconds >= this.SwitchFrameTimer)
            {
                this.ElapsedMiliseconds = 0;

                this.SourceRectangle = new Rectangle(this.SourceRectangle.X + this.SourceRectangle.Width - 1, this.SourceRectangle)
            }
        }

    }
}