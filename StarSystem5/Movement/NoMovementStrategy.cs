using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarSystem.Movement
{
    class NoMovementStrategy : MovementStrategy
    {
        public override System.Drawing.PointF NextPosition(StarSystem.Objects.CelestialObject obj, double dt)
        {
            return obj.LocalPos;
        }
    }
}
