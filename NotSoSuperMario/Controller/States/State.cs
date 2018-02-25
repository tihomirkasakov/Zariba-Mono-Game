namespace NotSoSuperMario.Controller.States
{
    public abstract class State
    {
        public State(State nextState)
        {
            this.NextState = nextState;
        }

        public State NextState { get; set; }

        public abstract void Update();
        public abstract void Draw();
    }
}
