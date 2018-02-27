namespace NotSoSuperMario.Model.GameObjects
{
    using Microsoft.Xna.Framework;

    public enum BlockType
    {
        tile_1
    }

    public class Block : GameObject
    {
        public Block(Vector2 position, BlockType type)
            :base(position)
        {
            this.Type = type;
        }

        public BlockType Type { get; set; }

        public override void ActOnCollision()
        {
            throw new System.NotImplementedException();
        }
    }
}
