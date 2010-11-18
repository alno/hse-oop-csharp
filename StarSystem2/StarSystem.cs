using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace StarSystem
{
    class StarSystem : CelestialSystem
    {

        private List<Star> stars = new List<Star>();

        private List<PlanetSystem> planetSystems = new List<PlanetSystem>();

        public override IEnumerable<CelestialBody> OwnBodies
        {
            get { return new EnumerableWrapper<Star, CelestialBody>(stars); }
        }

        public override IEnumerable<CelestialSystem> OwnSystems
        {
            get { return new EnumerableWrapper<PlanetSystem, CelestialSystem>(planetSystems); }
        }

        public override CelestialSystem Parent
        {
            get { return null; }
        }

        public override PointF Position
        {
            get { return new PointF(0, 0); }
        }

        public StarSystem()
        {
            stars.Add(new Star(this));
        }

        public Planet CreatePlanet(double orbitRadius, double orbitPosition)
        {
            PlanetSystem ps = new PlanetSystem(this, orbitRadius, orbitPosition);
            planetSystems.Add(ps);

            return ps.CreatePlanet();
        }

    }
}
