using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using StarSystem.Movement;

namespace StarSystem.Objects
{
    public abstract class CelestialObject
    {
        public PointF LocalPos = new PointF();

        public MovementStrategy Movement = new NoMovementStrategy();

        public PointF GlobalPos
        {
            get
            {
                if (Parent != null)
                {
                    return new PointF(Parent.GlobalPos.X + LocalPos.X, Parent.GlobalPos.Y + LocalPos.Y);
                }
                else
                {
                    return LocalPos;
                }
            }
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
        public virtual void Animate(double dt)
        {
            LocalPos = Movement.NextPosition(this, dt);
        }

        /**
         * Нарисовать объект
         */
        public abstract void Draw(Graphics gr);
    }
}
