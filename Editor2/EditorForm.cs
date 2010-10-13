using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Editor1
{
    public partial class EditorForm : Form
    {
        private List<Element> elements = new List<Element>();

        private Element selectedElement = null;

        private int lastMouseX;
        private int lastMouseY;
        private bool moving = false;

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

            SelectElement(el);

            splitContainer.Panel1.Refresh();
        }

        private void SelectElement(Element el)
        {
            splitContainer.Panel2.Controls.Clear();
            if (el != null)
                splitContainer.Panel2.Controls.Add(el.UI);

            selectedElement = el;
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

        private void splitContainer_Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            SelectElement(GetElement(e.X, e.Y));

            moving = true;
            lastMouseX = e.X;
            lastMouseY = e.Y;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            elements.Clear();

            splitContainer.Panel1.Refresh();
            splitContainer.Panel2.Controls.Clear();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.DefaultExt = "drw";
            dialog.Filter = "Vector Drawing (*.drw)|*.drw";
            dialog.FileName = "MyDrawing.drw";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                BinaryWriter writer = new BinaryWriter( File.Create( dialog.FileName ) );

                writer.Write( elements.Count );

                foreach ( Element el in elements )
                {
                    writer.Write(el.GetType().FullName);

                    el.Write(writer);
                }

                writer.Close();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.DefaultExt = "drw";
            dialog.Filter = "Vector Drawing (*.drw)|*.drw";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                BinaryReader reader = new BinaryReader(File.OpenRead(dialog.FileName));

                int count = reader.ReadInt32();

                elements.Clear();

                for (int i = 0; i < count; ++i)
                {
                    String typeName = reader.ReadString();
                    Type type = Type.GetType(typeName);
                    ConstructorInfo constructor = type.GetConstructor( new Type[]{ typeof( Control ) } );
                    Element el = (Element) constructor.Invoke(new Object[] { splitContainer.Panel1 });

                    el.Read(reader);

                    elements.Add(el);
                }

                reader.Close();

                splitContainer.Panel1.Refresh();
            }
        }

        private void splitContainer_Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            moving = moving && e.Button == MouseButtons.Left;

            if (moving && selectedElement != null)
            {
                selectedElement.X += e.X - lastMouseX;
                selectedElement.Y += e.Y - lastMouseY;

                lastMouseX = e.X;
                lastMouseY = e.Y;

                splitContainer.Panel1.Refresh();
            }
        }
    }
}
