namespace NotSoSuperMario.View.UI
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using NotSoSuperMario.Controller;
    using NotSoSuperMario.Utilities;
    using System.Collections.Generic;
    using System;
    using NotSoSuperMario.Model.Player;

    public static class AnimationFactory
    {
        public static Animation CreatePlayerAnimation(Color tint)
        {
            Animation currentAnimation = new Animation(new Vector2(71, 120), Globals.Content.Load<Texture2D>("PlayerSpriteSheet"), 60);
            currentAnimation.AnimationState = new List<AnimationState>();
            currentAnimation.AnimationState.Add(new AnimationState(PlayerStates.WALKING.ToString(), new Vector2(71, 120), 9, 0));

            currentAnimation.Tint = tint;
            currentAnimation.ChangeAnimation("IDLE");
            return currentAnimation;
        }

        internal static Animation CreatePlayerAnimation(object aliceBlue)
        {
            throw new NotImplementedException();
        }
    }
}
