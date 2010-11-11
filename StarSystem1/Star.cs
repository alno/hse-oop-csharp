using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace StarSystem
{
    class Star : Body
    {
        private float radius = 20;

        private List<Planet> planets = new List<Planet>();

        public IList<Planet> Planets
        {
            get { return planets.AsReadOnly(); }
        }

        public override PointF Position
        {
            get { return new PointF(0, 0); }
        }

        public Planet CreatePlanet(double orbitRadius, double orbitPosition)
        {
            Planet p = new Planet(this, orbitRadius, orbitPosition);
            planets.Add(p);
            return p;
        }

        public override void Animate(double dt)
        {
            foreach ( Planet p in planets )
                p.Animate( dt );
        }

        public override void Draw(System.Drawing.Graphics gr)
        {
            Brush brush = new SolidBrush(Color.Yellow);

            gr.FillEllipse(brush, -radius, -radius, 2*radius, 2*radius);

            foreach ( Planet p in planets )
                p.Draw( gr );
        }
    }
}
