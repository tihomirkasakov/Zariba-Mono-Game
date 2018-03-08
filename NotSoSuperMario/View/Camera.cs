namespace NotSoSuperMario.View
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Camera
    {
        private Vector2 center;
        private Viewport viewport;
        private Matrix transform;

        public Camera(Viewport newViewport)
        {
            this.viewport = newViewport;
        }

        public Vector2 Center => this.center;

        public Matrix Transform
        {
            get { return this.transform; }
        }

        public void Update(Vector2 position, int offSetX, int offSetY)
        {
            if (position.X < this.viewport.Width / 2)
            {
                this.center.X = this.viewport.Width / 2;
            }
            else if (position.X > offSetX - (this.viewport.Width / 2))
            {
                this.center.X = offSetX - (this.viewport.Width / 2);
            }
            else
            {
                this.center.X = position.X;
            }

            if (position.Y < this.viewport.Height / 2)
            {
                this.center.Y = this.viewport.Height / 2;
            }
            else if (position.Y > offSetY - (this.viewport.Height / 2))
            {
                this.center.Y = offSetY - (this.viewport.Height / 2);
            }
            else
            {
                this.center.Y = position.Y;
            }

            this.transform = Matrix.CreateTranslation(new Vector3(-this.center.X + (this.viewport.Width / 2), -this.center.Y + (this.viewport.Height / 2), 0));
        }
    }
}
