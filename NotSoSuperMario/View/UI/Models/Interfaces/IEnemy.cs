﻿namespace NotSoSuperMario.Model.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    interface IEnemy : IUnit
    {
        bool SawPlayer { get; set; }
    }
}
