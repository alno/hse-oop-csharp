using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace StarSystem
{
    class PlanetSystem : CelestialSystem
    {
        private float radius = 10;

        private StarSystem starSystem;

        private double orbitRadius;
        private double orbitPosition;

        private List<Planet> planets = new List<Planet>();

        public override IEnumerable<CelestialBody> OwnBodies
        {
            get { return new EnumerableWrapper<Planet,CelestialBody>( planets ); }
        }

        public override IEnumerable<CelestialSystem> OwnSystems
        {
            get { return new List<CelestialSystem>(); }
        }

        public override PointF Position
        {
            get
            {
                PointF p = starSystem.Position;
                p.X += (float)(orbitRadius * Math.Cos(orbitPosition));
                p.Y += (float)(orbitRadius * Math.Sin(orbitPosition));
                return p;
            }
        }
        
        public override CelestialSystem Parent
        {
            get { return starSystem; }
        }

        public PlanetSystem(StarSystem star, double orbitRadius, double orbitPosition)
        {
            this.starSystem = star;
            this.orbitRadius = orbitRadius;
            this.orbitPosition = orbitPosition;
        }


        public override void Animate(double dt)
        {
            orbitPosition += dt;
        }

        public override void Draw(System.Drawing.Graphics gr)
        {
            Brush brush = new SolidBrush(Color.Blue);
            PointF pos = Position;

            gr.FillEllipse(brush, pos.X -radius, pos.Y - radius, 2*radius, 2*radius);
        }

        public Planet CreatePlanet()
        {
            Planet p = new Planet(this);
            planets.Add(p);
            return p;
        }
    }
}
