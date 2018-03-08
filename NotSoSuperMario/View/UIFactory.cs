namespace NotSoSuperMario.View
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using NotSoSuperMario.Controller;
    using NotSoSuperMario.Model;
    using NotSoSuperMario.View.UI;

    public class UIFactory
    {
        public Sprite IntroBackground { get; set; }

        public Sprite GameOverBackground { get; set; }

        public Sprite GameWinBackground { get; set; }

        public Sprite MenuBackground { get; set; }

        public Sprite PauseBackground { get; set; }

        public Sprite PauseBackgroundTransperant { get; set; }

        public Sprite TimerUI { get; set; }

        public Button StartButton { get; set; }

        public Button ResumeButton { get; set; }

        public Button FullscreenButton { get; set; }

        public Button Checkbox { get; set; }

        public Button BackButton { get; set; }

        public Button ExitButton { get; set; }

        public Button ExitToMenuButton { get; set; }

        public Button ExitFromGame { get; set; }

        public UIFactory()
        {
            this.IntroBackground = CreateSprite("Backgrounds/introBackground", 1.2f);
            this.GameOverBackground = CreateSprite("Backgrounds/gameOverBackground", 1.2f);
            this.GameWinBackground = CreateSprite("Backgrounds/gameWinBackground", 1.2f);
            this.MenuBackground = CreateSprite("Backgrounds/menuBackground", 1.2f);
            this.PauseBackground = CreateSprite("Backgrounds/pausedBackground", 1f);
            this.PauseBackgroundTransperant = CreateSprite("Backgrounds/pausedBackgroundTransperant", 1f);
            this.TimerUI = CreateSprite("UI/timer", 0.1f);
            this.StartButton = CreateButton("Controls/StartNormal", "Controls/StartHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 300) / 2, 100));
            this.ResumeButton = CreateButton("Controls/ResumeNormal", "Controls/ResumeHover", new Vector2(Globals.Graphics.PreferredBackBufferHeight - 300 / 2, 100));
            this.FullscreenButton = CreateButton("Controls/FullscreenNormal", "Controls/FullscreenHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 300) / 2, 200));
            this.Checkbox = CreateButton("Controls/CheckboxNormal", "Controls/CheckboxTick", new Vector2((Globals.Graphics.PreferredBackBufferWidth + 350) / 2, 220));
            this.BackButton = CreateButton("Controls/BackNormal", "Controls/BackHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 300) / 2, 450));
            this.ExitButton = CreateButton("Controls/ExitNormal", "Controls/ExitHover", new Vector2((Globals.Graphics.PreferredBackBufferWidth - 300) / 2, 450));
            this.ExitToMenuButton = CreateButton("Controls/ExitToMenuNormal", "Controls/ExitToMenuHover", new Vector2((Globals.Graphics.PreferredBackBufferHeight - 300 / 2), 450));
            this.ExitFromGame = CreateButton("Controls/ExitFromGameNormal", "Controls/ExitFromGameHover", new Vector2((Globals.Graphics.PreferredBackBufferHeight - 300 / 2), 550));
        }

        private Button CreateButton(string buttonNormal, string buttonHover, Vector2 position)
        {
            Texture2D startNormal = Globals.Content.Load<Texture2D>(buttonNormal);
            Texture2D startHover = Globals.Content.Load<Texture2D>(buttonHover);
            Sprite startSprite = new Sprite(startNormal, position);
            Button newButton = new Button(startSprite, startHover, startNormal);
            return newButton;
        }

        public static Sprite CreateSprite(string fileName, float scale)
        {
            var texture = Globals.Content.Load<Texture2D>(fileName);
            Sprite sprite = new Sprite(texture, new Vector2(0, 0), scale);
            return sprite;
        }
    }
}
