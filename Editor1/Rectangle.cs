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
        public Int32 X;
        public Int32 Y;
        public Int32 Width;
        public Int32 Height;

        public Rectangle( Control container ) : base( container )
        {
            Color = Color.Red;
        }

        public override void Draw(System.Drawing.Graphics graphics)
        {
            Brush brush = new SolidBrush(Color);

            graphics.FillRectangle(brush, X, Y, Width, Height);
        }

        public override bool Contains(int x, int y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }
    }
}
