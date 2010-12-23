using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace StarSystem.Objects
{
    public class Satellite : CelestialBody
    {
        private PlanetSystem planetSystem;

        public override CelestialSystem Parent
        {
            get { return planetSystem; }
        }

        public Satellite(PlanetSystem planetSystem)
        {
            this.planetSystem = planetSystem;
            this.Color = Color.Gray;
            this.Radius = 2;
        }

        public override void Draw(System.Drawing.Graphics gr)
        {
            Brush brush = new SolidBrush(Color);
            PointF pos = GlobalPos;

            gr.FillEllipse(brush, pos.X - Radius, pos.Y - Radius, 2 * Radius, 2 * Radius);
        }
    }
}
