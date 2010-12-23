using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace StarSystem.Objects
{
    public class Star : CelestialBody
    {
        private StarSystem starSystem;

        public override CelestialSystem Parent
        {
            get { return starSystem; }
        }

        public Star(StarSystem starSystem)
        {
            this.starSystem = starSystem;
            this.Color = Color.Yellow;
            this.Radius = 20;
        }

        public override void Draw(System.Drawing.Graphics gr)
        {
            Brush brush = new SolidBrush(Color);

            gr.FillEllipse(brush, GlobalPos.X - Radius, GlobalPos.Y - Radius, 2 * Radius, 2 * Radius);
        }
    }
}
