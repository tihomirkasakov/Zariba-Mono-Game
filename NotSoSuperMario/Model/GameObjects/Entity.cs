namespace NotSoSuperMario.Model.GameObjects
{
    using Microsoft.Xna.Framework;

    public abstract class Entity : GameObject
    {
        public Entity(Vector2 position, bool isFacingRight) 
            : base(position)
        {
            this.IsFacingRight = isFacingRight;
        }

        public bool IsFacingRight { get; set; }

        public bool IsGrounded { get; set; }

        public int Health { get; set; }

    }
}
