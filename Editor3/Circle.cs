﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Editor1
{
    class Circle : Element
    {
        // Радиус круга
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
            return (X - x) * (X - x) + (Y - y) * (Y - y) <= Radius * Radius; // Квадрат растояния от точки до центра меньше квадрата радуиса
        }

        public override void Read(BinaryReader reader)
        {
            base.Read(reader); // Вызываем чтение базового класс (координаты, цвет)

            Radius = reader.ReadInt32();
        }

        public override void Write(BinaryWriter writer)
        {
            base.Write(writer); // Вызываем запись базового класса

            writer.Write(Radius);
        }

        public override XmlNode ExportToSvg(XmlDocument svg)
        {
            XmlElement svgElement = svg.CreateElement("circle");
            svgElement.SetAttribute("cx", Convert.ToString(X));
            svgElement.SetAttribute("cy", Convert.ToString(Y));
            svgElement.SetAttribute("r", Convert.ToString(radius));
            svgElement.SetAttribute("fill", GetColorString() );

            return svgElement;
        }
    }
}
