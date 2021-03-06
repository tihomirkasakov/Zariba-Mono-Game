﻿namespace NotSoSuperMario.Controller.Utils
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Input;

    public class InputHandler
    {
        public InputHandler()
        {
            this.ActiveKeys = new List<KeyboardButtonState>();
        }

        public KeyboardState CurrentKeyboardState { get; set; }

        public KeyboardState PreviousKeyboardState { get; set; }

        public List<KeyboardButtonState> ActiveKeys { get; set; }

        public Keys KeyToCheck { get; set; }

        public void Update()
        {
            this.PreviousKeyboardState = this.CurrentKeyboardState;
            this.CurrentKeyboardState = Keyboard.GetState();
            this.CheckKey();
        }

        public void CheckKey()
        {
            for (int i = 0; i < this.CurrentKeyboardState.GetPressedKeys().Length; i++)
            {
                this.KeyToCheck = this.CurrentKeyboardState.GetPressedKeys()[i];

                if (this.PreviousKeyboardState.IsKeyUp(this.KeyToCheck) &&
                    this.CurrentKeyboardState.IsKeyDown(this.KeyToCheck))
                {
                    this.ActiveKeys.Add(new KeyboardButtonState(this.KeyToCheck));
                }
                else if (this.PreviousKeyboardState.IsKeyDown(this.KeyToCheck) &&
                    this.CurrentKeyboardState.IsKeyDown(this.KeyToCheck))
                {
                    foreach (KeyboardButtonState key in this.ActiveKeys)
                    {
                        if (key.Button == this.KeyToCheck)
                        {
                            key.ButtonState = KeyState.Held;
                        }
                    }
                }
            }

            for (int i = 0; i < this.ActiveKeys.Count; i++)
            {
                if (this.PreviousKeyboardState.IsKeyUp(this.ActiveKeys[i].Button) &&
                    this.CurrentKeyboardState.IsKeyUp(this.ActiveKeys[i].Button))
                {
                    this.ActiveKeys[i].Button = Keys.None;
                    this.ActiveKeys[i].ButtonState = KeyState.None;
                }
            }

            while (this.ActiveKeys.Contains(new KeyboardButtonState(Keys.None)))
            {
                this.ActiveKeys.Remove(new KeyboardButtonState(Keys.None));
            }
        }
    }
}
