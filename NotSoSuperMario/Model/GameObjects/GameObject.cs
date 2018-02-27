namespace NotSoSuperMario.Model.GameObjects
{
    using Microsoft.Xna.Framework;

    public abstract class GameObject
    {
        public GameObject(Vector2 position)
        {
            this.Position = position;
        }

        public Vector2 Position { get; set; }

        public Rectangle Bounds { get; set; }

        public abstract void ActOnCollisition();
    }
}
