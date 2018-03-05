namespace NotSoSuperMario.View.UI
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using NotSoSuperMario.Controller;
    using System.Collections.Generic;
    using NotSoSuperMario.Model.Player;

    public static class AnimationFactory
    {
        public static Animation CreatePlayerAnimation(Color tint)
        {
            Animation currentAnimation = new Animation(new Vector2(104, 98), Globals.Content.Load<Texture2D>("Hero/hero_sword"), 60);
            currentAnimation.AnimationStates = new List<AnimationState>();
            currentAnimation.AnimationStates.Add(new AnimationState(PlayerStates.IDLE.ToString(), new Vector2(104, 98), 1, 0));
            currentAnimation.AnimationStates.Add(new AnimationState(PlayerStates.WALK.ToString(), new Vector2(104, 98), 7, 1));
            currentAnimation.AnimationStates.Add(new AnimationState(PlayerStates.JUMP.ToString(), new Vector2(104, 98), 5, 2));
            currentAnimation.AnimationStates.Add(new AnimationState(PlayerStates.ATTACK.ToString(), new Vector2(104, 98), 3, 3));

            currentAnimation.Tint = tint;
            currentAnimation.ChangeAnimation("IDLE");
            return currentAnimation;
        }
    }
}
