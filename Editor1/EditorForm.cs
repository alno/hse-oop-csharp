using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Editor1
{
    public partial class EditorForm : Form
    {
        private List<Element> elements = new List<Element>();

        private Random rand = new Random();

        public EditorForm()
        {
            InitializeComponent();
        }

        private Element GetElement(Int32 x, Int32 y)
        {
            foreach (Element el in elements)
                if (el.Contains(x, y))
                    return el;

            return null;
        }

        private void AddElement(Element el)
        {
            elements.Add(el);

            splitContainer.Panel2.Controls.Clear();
            splitContainer.Panel2.Controls.Add(el.UI);

            splitContainer.Panel1.Refresh();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Element el in elements)
                el.Draw(e.Graphics);
        }

        private void newRectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rectangle rc = new Rectangle( splitContainer.Panel1 );
            rc.Width = rand.Next( 10, 100 );
            rc.Height = rand.Next(10, 100);
            rc.X = rand.Next(0, splitContainer.Panel1.ClientRectangle.Width - rc.Width);
            rc.Y = rand.Next(0, splitContainer.Panel1.ClientRectangle.Height - rc.Height);

            AddElement(rc);
        }

        private void newEllipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Circle rc = new Circle(splitContainer.Panel1);
            rc.Radius = rand.Next(10, 100);
            rc.X = rand.Next(rc.Radius, splitContainer.Panel1.ClientRectangle.Width - rc.Radius);
            rc.Y = rand.Next(rc.Radius, splitContainer.Panel1.ClientRectangle.Height - rc.Radius);

            AddElement(rc);
        }

        private void splitContainer1_Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Element el = GetElement(e.X, e.Y);

            splitContainer.Panel2.Controls.Clear();
            if ( el != null )
                splitContainer.Panel2.Controls.Add(el.UI);
        }
    }
}
