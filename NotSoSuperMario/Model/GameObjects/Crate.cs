namespace NotSoSuperMario.Model.GameObjects
{
    using Microsoft.Xna.Framework;

    public class Crate : GameObject
    {
        public Crate(Vector2 position) 
            : base(position)
        {
            this.HiddenPlayer = false;
        }

        public bool HiddenPlayer { get; set; }

        public override void ActOnCollision()
        {
            if (!HiddenPlayer)
            {
                this.HiddenPlayer = true;
            }
        }
    }
}
