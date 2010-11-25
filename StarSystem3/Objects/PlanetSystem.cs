using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using StarSystem.Utils;
using StarSystem.Movement;

namespace StarSystem
{
    namespace Objects
    {
        class PlanetSystem : CelestialSystem
        {
            private float radius = 10;

            private StarSystem starSystem;

            private List<Planet> planets = new List<Planet>();

            public override IEnumerable<CelestialBody> OwnBodies
            {
                get { return new EnumerableWrapper<Planet, CelestialBody>(planets); }
            }

            public override IEnumerable<CelestialSystem> OwnSystems
            {
                get { return new List<CelestialSystem>(); }
            }

            public override CelestialSystem Parent
            {
                get { return starSystem; }
            }

            public PlanetSystem(StarSystem star, double orbitRadius, double orbitPosition)
            {
                this.starSystem = star;
            }

            public Planet CreatePlanet()
            {
                Planet p = new Planet(this);
                planets.Add(p);
                return p;
            }

            public void CreateDoublePlanet()
            {
                Planet p1 = new Planet(this);
                Planet p2 = new Planet(this);

                double period = 100;
                double startTime = 10;

                p1.Movement = new CircularMovementStrategy(period, 7);
                p2.Movement = new CircularMovementStrategy(period, 7);

                p1.Animate(startTime);
                p2.Animate(startTime + period / 2);

                planets.Add(p1);
                planets.Add(p2);
            }
        }
    }
}
