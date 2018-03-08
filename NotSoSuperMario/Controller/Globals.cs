namespace NotSoSuperMario.Controller
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class Globals
    {
        public static GraphicsDeviceManager Graphics { get; set; }

        public static SpriteBatch SpriteBatch { get; set; }

        public static ContentManager Content { get; set; }

        public static GameTime GameTime { get; set; }

        public static GraphicsDevice GraphicsDevice { get; set; }
    }
}
