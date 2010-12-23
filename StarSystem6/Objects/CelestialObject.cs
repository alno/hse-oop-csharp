using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using StarSystem.Movement;

namespace StarSystem.Objects
{
    public delegate void MovedEventHandler( CelestialObject sender );

    public delegate void ChangedEventHandler( CelestialObject sender );

    public abstract class CelestialObject
    {
        public event MovedEventHandler Moved;

        public event ChangedEventHandler Changed;

        private PointF localPos = new PointF();

        public PointF LocalPos
        {
            get { return localPos; }
            set { localPos = value; Movement.Recalculate(this); OnMoved(); OnChanged(); }
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
        public void Animate(double dt)
        {
            AnimateInternal(dt);
            OnMoved();
            OnChanged();
        }

        /**
         * Нарисовать объект
         */
        public abstract void Draw(Graphics gr);

        internal virtual void AnimateInternal(double dt)
        {
            localPos = Movement.NextPosition(this, dt);
        }

        internal virtual void OnMoved()
        {
            if (Moved != null) // Вызываем обработчик события
                Moved(this);
        }

        protected void OnChanged()
        {
            if (Changed != null)
                Changed(this);

            if (Parent != null)
                Parent.OnChanged();
        }

    }
}
