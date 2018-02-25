namespace NotSoSuperMario.Controller
{
    using NotSoSuperMario.Controller.States;

    public static class StateMachine
    {
        public static State CurrentState;
        public static State NextState;

        public static void ChangeState()
        {
            CurrentState = CurrentState.NextState;
        }
    }
}
