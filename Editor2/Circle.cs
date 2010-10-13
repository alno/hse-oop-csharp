using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Editor1
{
    class Circle : Element
    {
        public Int32 Radius
        {
            get { return radius; }
            set { radius = value; radiusTextBox.Text = Convert.ToString(value); }
        }

        private Int32 radius;
        private TextBox radiusTextBox;

        public Circle(Control container)
            : base(container)
        {
            radiusTextBox = new TextBox();
            radiusTextBox.Left = 10;
            radiusTextBox.Top = 70;
            radiusTextBox.Width = 100;
            radiusTextBox.TextChanged += new EventHandler(radiusTextBox_TextChanged);

            UI.Controls.Add(radiusTextBox);
        }

        void radiusTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                radius = Convert.ToInt32(radiusTextBox.Text);

                Container.Refresh();
            }
            catch (FormatException)
            {
            }
        }

        public override void Draw(System.Drawing.Graphics graphics)
        {
            Brush brush = new SolidBrush(Color);

            graphics.FillEllipse(brush, X - radius, Y - radius, 2 * radius, 2 * radius);
        }

        public override bool Contains(int x, int y)
        {
            return (X - x) * (X - x) + (Y - y) * (Y - y) <= Radius * Radius;
        }

        public override void Read(BinaryReader reader)
        {
            base.Read(reader);

            Radius = reader.ReadInt32();
        }

        public override void Write(BinaryWriter writer)
        {
            base.Write(writer);

            writer.Write(Radius);
        }
    }
}
