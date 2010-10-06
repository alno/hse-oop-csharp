using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Editor1
{
    abstract class Element
    {
        public Panel UI = new Panel();

        public Color Color
        {
            get { return color; }
            set { color = value; colorBox.BackColor = value; }
        }

        protected Control Container;

        private Color color = Color.Green;

        private TextBox colorBox;

        public Element(Control container)
        {
            this.Container = container;

            Label label = new Label();
            label.Text = GetType().Name;
            label.Left = 10;
            label.Top = 10;

            colorBox = new TextBox();
            colorBox.Left = 10;
            colorBox.Top = 40;
            colorBox.ReadOnly = false;
            colorBox.BackColor = color;
            colorBox.MouseClick += new MouseEventHandler(colorBox_MouseClick);
            
            UI.Controls.Add(label);
            UI.Controls.Add(colorBox);
        }

        void colorBox_MouseClick(object sender, MouseEventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = color;
            dialog.ShowDialog();

            Color = dialog.Color;
            Container.Refresh();
        }

        public abstract void Draw( Graphics graphics );

        public abstract bool Contains(int x, int y);
    }
}
