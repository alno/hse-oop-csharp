using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StarSystem.Objects;
using System.Drawing;

namespace StarSystem.Movement
{
    class CircularMovementStrategy : MovementStrategy
    {
        public double Time = 0;

        public double Period = 300;

        public double Radius = 100;

        public CircularMovementStrategy()
        {
        }

        public CircularMovementStrategy(double period,double radius)
        {
            Period = period;
            Radius = radius;
        }

        public PointF NextPosition(CelestialObject obj, double dt)
        {
            Time += dt;

            double pos = 2 * Math.PI * Time / Period;

            return new PointF( (float)( Radius * Math.Cos( pos )), (float)( Radius * Math.Sin( pos ) ) );
        }

        public void Recalculate(CelestialObject obj)
        {
            Time = Math.Atan2(obj.LocalPos.Y, obj.LocalPos.X) * Period / 2 / Math.PI;
            Radius = Math.Sqrt( obj.LocalPos.X * obj.LocalPos.X + obj.LocalPos.Y * obj.LocalPos.Y );
        }

    }
}
