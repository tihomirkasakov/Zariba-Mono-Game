namespace NotSoSuperMario
{
    using System;

#if WINDOWS || LINUX

    public static class EntryPoint
    {
        [STAThread]
        public static void Main()
        {
            using (var Game = new NinjaCat())
            {
                Game.Run();
            }
        }
    }
#endif
}
