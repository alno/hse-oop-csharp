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

            public StarSystem()
            {
                stars.Add(new Star(this));
            }

            public PlanetSystem CreatePlanetSystem(double period,double orbitRadius, double orbitPosition)
            {                
                PlanetSystem ps = new PlanetSystem(this, orbitRadius, orbitPosition);
                ps.Movement = new CircularMovementStrategy(period,orbitRadius);
                ps.Animate(orbitPosition);

                planetSystems.Add(ps);

                return ps;
            }

        }
    }
}
