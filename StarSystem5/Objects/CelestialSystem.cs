using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarSystem.Objects
{
    public abstract class CelestialSystem : CelestialObject
    {
        private class AllBodiesEnumerable : IEnumerable
        {
            private CelestialSystem system;

            public AllBodiesEnumerable(CelestialSystem system)
            {
                this.system = system;
            }

            public IEnumerator GetEnumerator()
            {
                foreach (CelestialBody body in system.OwnBodies)
                {
                    yield return body;
                }

                foreach (CelestialSystem subSystem in system.OwnSystems)
                {
                    foreach (CelestialBody body in subSystem.AllBodies)
                    {
                        yield return body;
                    }
                }
            }

        }

        public abstract IEnumerable<CelestialBody> OwnBodies
        {
            get;
        }

        public abstract IEnumerable<CelestialSystem> OwnSystems
        {
            get;
        }

        public IEnumerable AllBodies
        {
            get
            {
                return new AllBodiesEnumerable(this);
            }
        }

        public override void Animate(double dt)
        {
            DisableOnMoved();

            base.Animate(dt);

            foreach (CelestialBody body in OwnBodies)
                body.Animate(dt);

            foreach (CelestialSystem system in OwnSystems)
                system.Animate(dt);

            EnableOnMoved();
            OnMoved();
        }

        public override void Draw(System.Drawing.Graphics gr)
        {
            foreach (CelestialBody body in OwnBodies)
                body.Draw(gr);

            foreach (CelestialSystem system in OwnSystems)
                system.Draw(gr);
        }

        internal override void OnMoved()
        {
            base.OnMoved(); // Обрабатываем событие как в обычном объекте

            foreach (CelestialBody body in OwnBodies )
                body.OnMoved();

            foreach (CelestialSystem system in OwnSystems)
                system.OnMoved();
        }

    }
}
