namespace NotSoSuperMario.View.UI
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using NotSoSuperMario.Controller;
    using NotSoSuperMario.Utilities;
    using System.Collections.Generic;

    public static class AnimationFactory
    {
        public static Animation CreatePlayerAnimation(Color tint)
        {
            Animation currentAnimation = new Animation(new Vector2(71, 120), Globals.Content.Load<Texture2D>("PlayerSpriteSheet"), 60);
            currentAnimation.AnimationStates = new List<AnimationState>();
            //currentAnimation.AnimationStates.Add(new AnimationState(PlayerStates.WALKING.ToString(), new Vector2(71, 120), 9, 0));

            currentAnimation.Tint = tint;
            currentAnimation.ChangeAnimation("IDLE");
            return currentAnimation;
        }
    }
}
