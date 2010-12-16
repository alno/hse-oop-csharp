using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace StarSystem.Objects
{
    public class Planet : CelestialBody
    {
        private PlanetSystem planetSystem;

        public override CelestialSystem Parent
        {
            get { return planetSystem; }
        }

        public Planet(PlanetSystem planetSystem)
        {
            this.planetSystem = planetSystem;
            this.Color = Color.Blue;
            this.Radius = 5;
        }

        public override void Draw(System.Drawing.Graphics gr)
        {
            Brush brush = new SolidBrush(Color);
            PointF pos = GlobalPos;

            gr.FillEllipse(brush, pos.X - Radius, pos.Y - Radius, 2 * Radius, 2 * Radius);
        }

        public override void Animate(double dt)
        {
            base.Animate(dt);

            Color = Color.FromArgb((Color.R + 5) % 256, (Color.B + 3) % 256, Color.G);
        }
    }
}
