using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace StarSystem
{
    namespace Objects
    {
        class Star : CelestialBody
        {
            private float radius = 20;

            private StarSystem starSystem;

            public override CelestialSystem Parent
            {
                get { return starSystem; }
            }

            public Star(StarSystem starSystem)
            {
                this.starSystem = starSystem;
            }

            public override void Draw(System.Drawing.Graphics gr)
            {
                Brush brush = new SolidBrush(Color.Yellow);

                gr.FillEllipse(brush, -radius, -radius, 2 * radius, 2 * radius);
            }
        }
    }
}
