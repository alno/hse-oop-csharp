using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace StarSystem
{
    abstract class Body
    {
        public abstract PointF Position
        {
            get;
        }

        public abstract void Animate(double dt);

        public abstract void Draw(Graphics gr);
    }
}
