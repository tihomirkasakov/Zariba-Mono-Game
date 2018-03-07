namespace NotSoSuperMario.View
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using NotSoSuperMario.Controller;
    using System.Collections.Generic;

    public class MonoGameRenderer
    {
        public void DrawPlayState(List<IRenderable> spritesToDraw, Camera camera)
        {
            Globals.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Transform);
            foreach (IRenderable sprite in spritesToDraw)
            {
                if (sprite.IsFacingRight)
                {
                    Globals.SpriteBatch.Draw(sprite.Texture, sprite.Position, sprite.SourceRectangle,
                    sprite.Tint, 0.0f, Vector2.Zero, sprite.Scale, SpriteEffects.None, 0);
                }
                else
                {
                    Globals.SpriteBatch.Draw(sprite.Texture, sprite.Position, sprite.SourceRectangle,
                    sprite.Tint, 0.0f, Vector2.Zero, sprite.Scale, SpriteEffects.FlipHorizontally, 0);
                }
            }

            Globals.SpriteBatch.End();
        }

        public void DrawMenuState(List<IRenderable> spritesToDraw)
        {
            Globals.SpriteBatch.Begin();
            foreach (IRenderable sprite in spritesToDraw)
            {
                if (sprite.IsFacingRight)
                {
                    Globals.SpriteBatch.Draw(sprite.Texture, sprite.Position, sprite.SourceRectangle,
                    sprite.Tint, 0.0f, Vector2.Zero, sprite.Scale, SpriteEffects.None, 0);
                }
                else
                {
                    Globals.SpriteBatch.Draw(sprite.Texture, sprite.Position, sprite.SourceRectangle,
                    sprite.Tint, 0.0f, Vector2.Zero, sprite.Scale, SpriteEffects.FlipHorizontally, 0);
                }

            }

            Globals.SpriteBatch.End();
        }
    }
}
