namespace NotSoSuperMario.Model.Interfaces
{
    using Microsoft.Xna.Framework;
    using NotSoSuperMario.Utilities;
    using System.Collections.Generic;

    interface IUnit
    {
        bool IsAlive { get; set; }
        void Move();
        void Draw();
        void Attack();
    }
}
