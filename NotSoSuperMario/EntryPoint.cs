using System;

namespace NotSoSuperMario
{
#if WINDOWS || LINUX

    public static class EntryPoint
    {

        [STAThread]
        static void Main()
        {
            using (var game = new NotSoSuperMario())
                game.Run();
        }
    }
#endif
}
