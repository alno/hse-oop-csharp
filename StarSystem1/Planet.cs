using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace StarSystem
{
    class Planet : Body
    {
        private float radius = 10;

        private Star star;

        private double orbitRadius;
        private double orbitPosition;

        public Planet(Star star, double orbitRadius, double orbitPosition)
        {
            this.star = star;
            this.orbitRadius = orbitRadius;
            this.orbitPosition = orbitPosition;
        }

        public override PointF Position
        {
            get { 
                PointF p = star.Position;
                p.X += (float)( orbitRadius * Math.Cos(orbitPosition) );
                p.Y += (float)( orbitRadius * Math.Sin(orbitPosition) );
                return p;
            }
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
    
    }
}
