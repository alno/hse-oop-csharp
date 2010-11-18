using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace StarSystem
{
    abstract class CelestialObject
    {
        /**
         * Позиция центра небесного объекта
         */
        public abstract PointF Position
        {
            get;
        }

        /**
         * Родительская система для объекта
         */
        public abstract CelestialSystem Parent
        {
            get;
        }

        /**
         * Анимировать объект
         */
        public abstract void Animate(double dt);

        /**
         * Нарисовать объект
         */
        public abstract void Draw(Graphics gr);
    }
}
