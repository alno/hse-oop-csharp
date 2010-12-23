using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using StarSystem.Utils;
using StarSystem.Movement;

namespace StarSystem.Objects
{
    public class PlanetSystem : CelestialSystem
    {
        private StarSystem starSystem;

        private List<Planet> planets = new List<Planet>();
        private List<Satellite> satellites = new List<Satellite>();

        public override IEnumerable<CelestialBody> OwnBodies
        {
            get
            {
                List<CelestialBody> bodies = new List<CelestialBody>();

                foreach (Planet p in planets)
                    bodies.Add(p);
                foreach (Satellite s in satellites)
                    bodies.Add(s);

                return bodies;
            }
        }

        public override IEnumerable<CelestialSystem> OwnSystems
        {
            get { return new List<CelestialSystem>(); }
        }

        public override CelestialSystem Parent
        {
            get { return starSystem; }
        }

        public PlanetSystem(StarSystem star)
        {
            this.starSystem = star;
        }

        public Planet CreatePlanet()
        {
            Planet p = new Planet(this);
            planets.Add(p);

            CreateSatellite();

            OnChanged(); // Вызываем обработку события изменения

            return p;
        }

        public void CreateDoublePlanet()
        {
            Random rand = new Random();

            Planet p1 = new Planet(this);
            Planet p2 = new Planet(this);

            double period = rand.NextDouble() * 100 + 50;
            double startTime = rand.NextDouble() * 200;
            double orbitRadius = rand.NextDouble() * 4 + 5;

            p1.Movement = new CircularMovementStrategy(period, orbitRadius);
            p2.Movement = new CircularMovementStrategy(period, orbitRadius);

            p1.Animate(startTime);
            p2.Animate(startTime + period / 2);

            planets.Add(p1);
            planets.Add(p2);

            OnChanged(); // Вызываем обработку события изменения
        }

        public Satellite CreateSatellite()
        {
            Random rand = new Random();

            Satellite sat = new Satellite(this);

            double period = rand.NextDouble() * 100 + 50;
            double startTime = rand.NextDouble() * 200;
            double orbitRadius = rand.NextDouble() * (satellites.Count * 4 + 3) + 7;

            sat.Movement = new CircularMovementStrategy( period, orbitRadius );
            sat.Animate(startTime);

            satellites.Add(sat);

            OnChanged(); // Вызываем обработку события изменения

            return sat;
        }
    }
}