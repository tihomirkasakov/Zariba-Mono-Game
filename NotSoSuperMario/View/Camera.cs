namespace NotSoSuperMario.View
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Camera
    {
        private Matrix transform;
        private Vector2 center;
        private Viewport viewport;
        private int CENTER_COEFF_X = 300;
        private int CENTER_COEFF_Y = 500;

        public Matrix Transform
        {
            get { return transform; }
        }

        public Camera(Viewport newViewport)
        {
            viewport = newViewport;
        }

        public void Update(Vector2 position, int offSetX, int offSetY)
        {
            if (position.X < viewport.Width / 2 )
            {
                center.X = viewport.Width / 2 - CENTER_COEFF_X;
            }
            else if (position.X > offSetX - (viewport.Width / 2))
            {
                center.X = offSetX - viewport.Width / 2 - CENTER_COEFF_X;
            }
            else
            {
                center.X = position.X - CENTER_COEFF_X;
            }

            if (position.Y < viewport.Height / 2)
            {
                center.Y = viewport.Height / 2 - CENTER_COEFF_Y;
            }
            else if (position.Y > offSetY - (viewport.Height / 2))
            {
                center.Y = offSetY - viewport.Height / 2 - CENTER_COEFF_Y;
            }
            else
            {
                center.Y = position.Y - CENTER_COEFF_Y;
            }


            transform = Matrix.CreateTranslation(new Vector3(-center.X + (viewport.Width/2), 
                -center.Y + (viewport.Height/2), 0));
        }

    }
}
