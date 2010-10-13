using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Editor1
{
    class Rectangle : Element
    {
        public Int32 Width = 20;
        public Int32 Height = 20;

        public Rectangle( Control container ) : base( container )
        {
            Color = Color.Red;
        }

        public override void Draw(System.Drawing.Graphics graphics)
        {
            Brush brush = new SolidBrush(Color);

            graphics.FillRectangle(brush, X - Width/2, Y - Height/2, Width, Height);
        }

        public override bool Contains(int x, int y)
        {
            return x >= X - Width/2 && x <= X + Width/2 && y >= Y - Height/2 && y <= Y + Height/2;
        }
    }
}
