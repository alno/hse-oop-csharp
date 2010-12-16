using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace StarSystem.Objects
{
    public abstract class CelestialBody : CelestialObject
    {
        public Color Color = Color.Black;

        public float Radius = 5;

        public bool Contains(float x, float y)
        {
            float dx = GlobalPos.X - x;
            float dy = GlobalPos.Y - y;

            return dx * dx + dy * dy <= Radius * Radius;
        }

    }
}
