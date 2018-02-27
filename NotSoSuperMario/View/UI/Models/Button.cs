namespace NotSoSuperMario.Model
{
    using Microsoft.Xna.Framework.Graphics;
    using NotSoSuperMario.View.UI;

    public class Button
    {
        public Button(Sprite sprite, Texture2D hoverImage, Texture2D normalImage)
        {
            this.Sprite = sprite;
            this.HoverImage = hoverImage;
            this.NormalImage = normalImage;
        }

        public Sprite Sprite { get; set; }

        private Texture2D HoverImage { get; set; }

        private Texture2D NormalImage { get; set; }

        public void ChangeToHoverImage()
        {
            this.Sprite.Texture = this.HoverImage;
        }

        public void ChangeToNormalImage()
        {
            this.Sprite.Texture = this.NormalImage;
        }
    }
}
