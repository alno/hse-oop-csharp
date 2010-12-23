using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StarSystem.Objects;

namespace StarSystem.Movement
{
    class NoMovementStrategy : MovementStrategy
    {
        public System.Drawing.PointF NextPosition(CelestialObject obj, double dt)
        {
            return obj.LocalPos;
        }

        public void Recalculate(CelestialObject obj)
        {
        }

    }
}
