namespace NotSoSuperMario.Controller.Utils
{
    using Microsoft.Xna.Framework.Input;

    public enum KeyState
    {
        Held,
        Clicked,
        Released,
        None
    }

    public class KeyboardButtonState
    {
        public KeyboardButtonState(Keys button)
        {
            this.Button = button;
            this.ButtonState = KeyState.Clicked;
        }

        public Keys Button { get; set; }

        public KeyState ButtonState { get; set; }
    }
}
