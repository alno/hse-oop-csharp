using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StarSystem.Objects;
using System.Drawing;

namespace StarSystem.Movement
{
    public abstract class MovementStrategy
    {

        public abstract PointF NextPosition( CelestialObject obj, double dt );

    }
}
