using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StarSystem.Objects;
using StarSystem.UI;

namespace StarSystem
{
    public partial class SpaceViewForm : Form
    {
        private Random rand = new Random();
        private StarSystem.Objects.StarSystem starSystem;

        private PointF center = new PointF(0,0);
        private float scale = 1.0f;

        public SpaceViewForm()
        {
            InitializeComponent();

            StartStopAnimation(true);

            starSystem = new StarSystem.Objects.StarSystem();
            starSystem.Changed += new ChangedEventHandler(starSystem_Changed);
            starSystem.CreatePlanetSystem(rand.NextDouble() * 500 + 200, rand.NextDouble() * 100 + 20, rand.NextDouble() * 5).CreatePlanet();
            starSystem.CreatePlanetSystem(rand.NextDouble() * 500 + 200, rand.NextDouble() * 100 + 20, rand.NextDouble() * 5).CreatePlanet();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            starSystem = new StarSystem.Objects.StarSystem();
            starSystem.Changed += new ChangedEventHandler(starSystem_Changed);

            splitContainer.Panel1.Refresh();
        }

        private void starSystem_Changed(CelestialObject sender)
        {
            splitContainer.Panel1.Refresh();
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            starSystem.Animate(1);
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = splitContainer.Panel1.ClientRectangle;

            e.Graphics.TranslateTransform(r.Width / 2, r.Height/2);
            e.Graphics.ScaleTransform(scale, scale);
            e.Graphics.TranslateTransform(-center.X,-center.Y);
            starSystem.Draw(e.Graphics);
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartStopAnimation(true);
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartStopAnimation(false);
        }

        private void StartStopAnimation(bool value)
        {
            animationTimer.Enabled = value;

            stopToolStripMenuItem.Enabled = value;
            startToolStripMenuItem.Enabled = !value;
        }

        private Point lastMousePoint;

        private bool moving = false;
        private bool scaling = false;

        private CelestialBody selectedBody = null;

        private void splitContainer_Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = e.Button == MouseButtons.Left;
            scaling = e.Button == MouseButtons.Right;

            SelectBody( FindBodyByPoint( e.X, e.Y ) );

            lastMousePoint = e.Location;
        }

        private void SelectBody(CelestialBody body)
        {
            selectedBody = body;

            OpenViewer(CreateBodyControl(selectedBody));
        }

        private void OpenViewer(Control viewer)
        {
            // Уничтожаем все элементы управления на второй панели
            foreach (Control c in splitContainer.Panel2.Controls)
                c.Dispose();
            
            // Удаляем их из списка
            splitContainer.Panel2.Controls.Clear();

            if (selectedBody != null)
            {
                viewer.Top = 0;
                viewer.Left = 0;
                viewer.Width = splitContainer.Panel2.ClientSize.Width;
                viewer.Height = splitContainer.Panel2.ClientSize.Height;
                viewer.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;

                splitContainer.Panel2.Controls.Add(viewer);
            }
        }

        private Control CreateBodyControl(CelestialBody body)
        {
            if (body is Planet)
            {
                return new PlanetViewer( (Planet) body, new OpenView(OpenViewer) );
            }
            else
            {
                return new Panel();
            }
        }

        private CelestialBody FindBodyByPoint(float x, float y)
        {
            Rectangle r = splitContainer.Panel1.ClientRectangle;

            x = (x - r.Width / 2) / scale + center.X;
            y = (y - r.Height / 2) / scale + center.Y;

            foreach (CelestialBody body in starSystem.AllBodies)
                if (body.Contains(x, y))
                    return body;

            return null;
        }

        private void splitContainer_Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            moving = moving && e.Button == MouseButtons.Left;
            scaling = scaling && e.Button == MouseButtons.Right;

            if (moving)
            {
                center.X -= (float)((e.X - lastMousePoint.X) / scale);
                center.Y -= (float)((e.Y - lastMousePoint.Y) / scale);

                splitContainer.Panel1.Refresh();
            }

            if (scaling)
            {
                scale *= (float)( Math.Exp((e.X - lastMousePoint.X)/200.0) );

                splitContainer.Panel1.Refresh();
            }

            lastMousePoint = e.Location;
        }

        private void countBodiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach ( CelestialBody b in starSystem.AllBodies ) {
                ++ count;
            }

            MessageBox.Show(Convert.ToString(count));
        }

        private void newPlanetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            starSystem.CreatePlanetSystem(rand.NextDouble() * 500 + 200, rand.NextDouble() * 100 + 20, rand.NextDouble() * 5).CreatePlanet();
        }

        private void addDoublePlanetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            starSystem.CreatePlanetSystem(rand.NextDouble() * 500 + 200, rand.NextDouble() * 100 + 20, rand.NextDouble() * 5).CreateDoublePlanet();
        }
    }
}
