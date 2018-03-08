namespace NotSoSuperMario.View.UI
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using NotSoSuperMario.Controller;
    using System.Collections.Generic;
    using NotSoSuperMario.Model.Player;
    using NotSoSuperMario.Model.Enemy;

    public static class AnimationFactory
    {
        public static Animation CreatePlayerAnimation(Color tint)
        {
            Animation currentAnimation = new Animation(new Vector2(45, 63), Globals.Content.Load<Texture2D>("Hero/hero"), 60);
            currentAnimation.AnimationStates = new List<AnimationState>();
            currentAnimation.AnimationStates.Add(new AnimationState(PlayerStates.IDLE.ToString(), new Vector2(44, 63), 6, 0));
            currentAnimation.AnimationStates.Add(new AnimationState(PlayerStates.WALK.ToString(), new Vector2(44, 63), 8, 1));
            currentAnimation.AnimationStates.Add(new AnimationState(PlayerStates.JUMP.ToString(), new Vector2(44, 63), 6, 2));

            currentAnimation.Tint = tint;
            currentAnimation.ChangeAnimation("IDLE");
            return currentAnimation;
        }

        public static Animation CreateEnemyAnimaton(Color tint)
        {
            Animation currentAnimation = new Animation(new Vector2(55, 70), Globals.Content.Load<Texture2D>("Enemies/EnemyPig"), 120);
            currentAnimation.AnimationStates = new List<AnimationState>();
            currentAnimation.AnimationStates.Add(new AnimationState(EnemyStates.WALK.ToString(), new Vector2(55, 80), 2, 0));
            currentAnimation.AnimationStates.Add(new AnimationState(EnemyStates.IDLE.ToString(), new Vector2(55, 81), 2, 8));

            currentAnimation.Scale = 0.9f;
            currentAnimation.Tint = tint;
            currentAnimation.ChangeAnimation("WALK");
            return currentAnimation;
        }
    }
}
