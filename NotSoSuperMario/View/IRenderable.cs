namespace NotSoSuperMario.View
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface IRenderable
    {
        Vector2 Position { get; set; }
        Texture2D Texture { get; set; }
        Rectangle SourceRectangle { get; set; }
        Color Tint { get; set; }
        bool IsFacingRight { get; set; }
        float Scale { get; set; }
    }
}
