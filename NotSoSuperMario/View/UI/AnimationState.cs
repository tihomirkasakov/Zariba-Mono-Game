namespace NotSoSuperMario.View.UI
{
    using Microsoft.Xna.Framework;

    public class AnimationState
    {
        public AnimationState(string name, Vector2 dimensions, int numberOfFrames, int index)
        {
            this.Name = name;
            this.NumberOfFrames = numberOfFrames;
            this.RowOfFrames = new Rectangle(0, (int)dimensions.Y * index, (int)dimensions.X * numberOfFrames,
                (int)dimensions.Y);
        }

        public string Name { get; set; }

        public Rectangle RowOfFrames { get; set; }

        public int NumberOfFrames { get; set; }
    }
}
