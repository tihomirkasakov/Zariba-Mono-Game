﻿namespace NotSoSuperMario.View
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using NotSoSuperMario.Controller;
    using NotSoSuperMario.Model;
    using NotSoSuperMario.View.UI;

    public class UIFactory
    {
        public Sprite MenuBackground { get; set; }

        public Button StartButton { get; set; }

        public Button ResumeButton { get; set; }

        public Button OptionButton { get; set; }

        public Button CreditsButton { get; set; }

        public Button ExitButton { get; set; }

        public Button ExitToMenuButton { get; set; }

        public UIFactory()
        {
            this.MenuBackground = CreateSprite("Backgrounds\\menuBackground");
            this.StartButton = CreateButton("Controls/StartNormal", "Controls/StartHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 300) / 2, 100));
            //this.StartButton = CreateButton("ResumeNormal", "ResumeHover", new Vector2(Globals.Graphics.PreferredBackBufferHeight / 2, 150));
            this.OptionButton = CreateButton("Controls/OptionsNormal", "Controls/OptionsHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 300) / 2, 200));
            this.ExitButton = CreateButton("Controls/ExitNormal", "Controls/ExitHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 300) / 2, 450));
            //this.StartButton = CreateButton("CreditsNormal", "CreditsHover", new Vector2((Globals.Graphics.PreferredBackBufferHeight)))
            //this.StartButton = CreateButton("StartNormal", "StartHover", new Vector2((Globals.Graphics.PreferredBackBufferHeight)))
            //this.StartButton = CreateButton("ExitToMenuNormal", "ExitToMenuHover", new Vector2((Globals.Graphics.PreferredBackBufferHeight)))

        }

        private Button CreateButton(string buttonNormal, string buttonHover, Vector2 position)
        {
            Texture2D startNormal = Globals.Content.Load<Texture2D>(buttonNormal);
            Texture2D startHover = Globals.Content.Load<Texture2D>(buttonHover);
            Sprite startSprite = new Sprite(startNormal, position);
            Button newButton = new Button(startSprite, startHover, startNormal);
            return newButton;
        }

        public static Sprite CreateSprite(string fileName)
        {
            var texture = Globals.Content.Load<Texture2D>(fileName);
            Sprite sprite = new Sprite(texture);
            return sprite;
        }
    }
}
