using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using StarSystem.Movement;

namespace StarSystem.Objects
{
    public delegate void MovedEventHandler( CelestialObject sender );

    public abstract class CelestialObject
    {
        public event MovedEventHandler Moved;

        private PointF localPos = new PointF();

        public PointF LocalPos
        {
            get { return localPos; }
            set { localPos = value; OnMoved(); }
        }

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

        private int onMovedDisableCount = 0;

        protected void DisableOnMoved()
        {
            onMovedDisableCount++;
        }

        protected void EnableOnMoved()
        {
            onMovedDisableCount--;
        }

        protected bool IsOnMovedDisabled()
        {
            return onMovedDisableCount > 0;
        }

        internal virtual void OnMoved()
        {
            if (IsOnMovedDisabled())
                return;

            if (Moved != null) // Вызываем обработчик события
                Moved(this);
        }

    }
}
