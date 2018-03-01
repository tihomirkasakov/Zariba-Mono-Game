namespace NotSoSuperMario.Controller
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    class Globals
    {
        public static Random Rng = new Random();

        public static GraphicsDeviceManager Graphics { get; set; }

        public static SpriteBatch SpriteBatch { get; set; }

        public static ContentManager Content { get; set; }

        public static GameTime GameTime { get; set; }

        public static GraphicsDevice GraphicsDevice { get; set; }
    }
}
