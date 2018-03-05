namespace NotSoSuperMario.Controller.Utils
{
    using Microsoft.Xna.Framework.Audio;
    using System.Collections.Generic;

    public class SoundManager
    {
        private Dictionary<string, SoundEffectInstance> effects;

        public SoundManager()
        {
            this.effects = new Dictionary<string, SoundEffectInstance>();
        }

        public void LoadContent()
        {
            SoundEffect menuSound = Globals.Content.Load<SoundEffect>("Sounds/mainMenu");


            this.Add("mainMenu", menuSound);
        }

        public void Add(string name, SoundEffect effect)
        {
            this.effects.Add(name, effect.CreateInstance());
        }

        public void Play(string name)
        {
            Play(name, 0.2f);
        }

        public void Play(string name, float volume)
        {
            this.effects[name].Volume = volume;
            this.effects[name].Play();
        }

        public void Stop(string name)
        {
            this.effects[name].Stop();
        }

        public void Pause(string name)
        {
            this.effects[name].Pause();
        }

        public void Resume(string name)
        {
            this.effects[name].Resume();
        }

        public SoundState GetState(string name)
        {
            return this.effects[name].State;
        }
    }
}
